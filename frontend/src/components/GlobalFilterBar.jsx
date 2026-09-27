import React, { useMemo } from 'react';
import { 
  Building,
  Building2, 
  Users,
  Calendar, 
  RotateCcw, 
  RefreshCw, 
  Layers, 
  Sparkles,
  ShieldCheck,
  FileSpreadsheet,
  CheckCircle2
} from 'lucide-react';
import * as XLSX from 'xlsx';

function getCanonicalFY(fy) {
  if (!fy || fy === 'ALL' || fy === 'all' || fy === 'All Financial Years' || fy === 'CUSTOM_RANGE' || fy === 'Custom Date Range' || fy === 'CUSTOM') return null;
  const s = String(fy).trim();
  if (s.includes('2026-27') || s.includes('2026-2027') || s.includes('26-27')) return '2026-2027';
  if (s.includes('2025-26') || s.includes('2025-2026') || s.includes('25-26')) return '2025-2026';
  if (s.includes('2024-25') || s.includes('2024-2025') || s.includes('24-25')) return '2024-2025';
  if (s.includes('2023-24') || s.includes('2023-2024') || s.includes('23-24')) return '2023-2024';
  if (s.includes('2022-23') || s.includes('2022-2023') || s.includes('22-23')) return '2022-2023';
  if (s.includes('2021-22') || s.includes('2021-2022') || s.includes('21-22')) return '2021-2022';
  if (s.includes('2020-21') || s.includes('2020-2021') || s.includes('20-21')) return '2020-2021';
  return null;
}

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} L`;
  return `₹ ${num.toLocaleString('en-IN')}`;
}

function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

export default function GlobalFilterBar({
  selectedCompany = 'ALL',
  setSelectedCompany,
  selectedCustomer = 'ALL',
  setSelectedCustomer,
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  selectedFY = 'ALL',
  setSelectedFY,
  customFromDate = '2026-04-01',
  setCustomFromDate,
  customToDate = '2026-09-26',
  setCustomToDate,
  financialData,
  companies = [],
  customers = [],
  topCustomers = [],
  customerTerminalMatrix = [],
  companyCustomers = {},
  companyTerminals = {},
  triMatrix = [],
  terminals = [],
  financialYears = [
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'Custom Date Range'
  ],
  terminalFyMatrix = [],
  onRefresh,
  onExport,
  loading = false,
  activeTab = 'analytics'
}) {
  const isFilterActive = 
    selectedCompany !== 'ALL' || 
    selectedCustomer !== 'ALL' || 
    selectedTerminal !== 'ALL' || 
    selectedFY !== 'ALL';

  const resetFilters = () => {
    if (setSelectedCompany) setSelectedCompany('ALL');
    if (setSelectedCustomer) setSelectedCustomer('ALL');
    if (setSelectedTerminal) setSelectedTerminal('ALL');
    if (setSelectedFY) setSelectedFY('ALL');
  };

  // Dynamic Company List: 5 Official SPJ Group Companies with revenue stats dynamically matched to current selected FY / Date Range
  const companyList = useMemo(() => {
    const base = (companies && companies.length > 0) ? companies : [
      { id: 3, companyId: 3, code: 'PJ-OLD', name: 'PURAN JOSHI OLD', gstin: '07ADGPJ3166M1ZA', director: 'Mr. Puran Joshi' },
      { id: 2, companyId: 2, code: 'SPJ', name: 'SPJ CARGO PVT LTD', gstin: '07AAOCS1758E1Z5', director: 'Mr. Puran Joshi' },
      { id: 1, companyId: 1, code: 'SJ', name: 'S.J. CARGO MOVERS', gstin: '07ADGPJ3166M1ZA', director: 'Mr. Puran Joshi' },
      { id: 5, companyId: 5, code: 'PJ', name: 'PURAN JOSHI', gstin: '07ADGPJ3166M2Z9', director: 'Mr. Puran Joshi' },
      { id: 4, companyId: 4, code: 'SPJ-MUM', name: 'SPJ CARGO PVT LTD-MUMBAI', gstin: '27AAOCS1758E1Z3', director: 'Mr. Puran Joshi' }
    ];

    const activeComps = financialData?.companyAnalytics || [];
    const activeMap = {};
    activeComps.forEach(ac => {
      activeMap[String(ac.id || ac.companyId)] = ac;
    });

    return base.map(comp => {
      const cId = String(comp.id || comp.companyId);
      const activeInfo = activeMap[cId];

      const terms = companyTerminals[cId] || [];
      const custs = companyCustomers[cId] || [];
      const gross = activeInfo ? Number(activeInfo.grossRevenue || 0) : terms.reduce((acc, t) => acc + Number(t.totalAmount || t.netRevenue || 0), 0);
      const invs = activeInfo ? Number(activeInfo.invoiceCount || 0) : terms.reduce((acc, t) => acc + Number(t.invoiceCount || 0), 0);

      return {
        ...comp,
        totalRevenue: gross,
        invoiceCount: invs,
        terminalCount: terms.length,
        customerCount: custs.length
      };
    });
  }, [companies, companyTerminals, companyCustomers, financialData]);

  // Helper to resolve company object and canonical ID (1..5)
  const resolveCompany = (val) => {
    if (!val || val === 'ALL' || val === 'all') return null;
    const str = String(val).toLowerCase().trim();
    return companyList.find(c => 
      String(c.id).toLowerCase() === str || 
      String(c.companyId).toLowerCase() === str || 
      String(c.code).toLowerCase() === str ||
      String(c.name).toLowerCase() === str
    ) || null;
  };

  const selectedCompanyObj = useMemo(() => resolveCompany(selectedCompany), [selectedCompany, companyList]);
  const activeCompId = selectedCompanyObj ? String(selectedCompanyObj.id || selectedCompanyObj.companyId) : null;

  // Dynamic Customer List: Filtered by selectedCompany and selectedTerminal, dynamically enriched with active scope metrics
  const availableCustomers = useMemo(() => {
    const activeCustList = financialData?.customerWise || financialData?.topCustomers || [];
    const activeCustMap = new Map();

    activeCustList.forEach(c => {
      const nameKey = (c.customerName || c.name || '').trim().toLowerCase();
      const idKey = String(c.customerId || c.id || '').trim().toLowerCase();
      const payload = {
        customerId: c.customerId || c.id,
        customerName: c.customerName || c.name,
        invoiceCount: Number(c.invoiceCount || c.totalInvoices || c.invoices || 0),
        containerCount: Number(c.containerCount || c.containers || 0),
        grossRevenue: Number(c.grossAmount || c.grossRevenue || c.totalRevenue || c.revenue || 0),
        netRevenue: Number(c.netRevenue || c.grossAmount || c.grossRevenue || 0),
        terminals: c.terminals || []
      };
      if (nameKey) activeCustMap.set(nameKey, payload);
      if (idKey) activeCustMap.set(idKey, payload);
    });

    const custMap = new Map();

    // Gather from master customers array
    (customers || []).forEach(c => {
      const nameKey = (c.customerName || c.name || '').trim().toLowerCase();
      if (!nameKey) return;
      if (!custMap.has(nameKey)) {
        custMap.set(nameKey, {
          id: c.customerId || c.id || nameKey,
          customerId: c.customerId || c.id || nameKey,
          name: c.customerName || c.name,
          customerName: c.customerName || c.name,
          code: c.code || '',
          city: c.city || ''
        });
      }
    });

    // Incorporate registered matrix entries
    (customerTerminalMatrix || []).forEach(c => {
      const nameKey = (c.customerName || c.name || '').trim().toLowerCase();
      if (!nameKey) return;
      if (!custMap.has(nameKey)) {
        custMap.set(nameKey, {
          id: c.customerId || c.id || nameKey,
          customerId: c.customerId || c.id || nameKey,
          name: c.customerName || c.name,
          customerName: c.customerName || c.name,
          code: c.code || '',
          city: c.city || ''
        });
      }
    });

    // Build master list enriched with activeData
    let result = Array.from(custMap.values()).map(c => {
      const nameKey = (c.customerName || c.name || '').trim().toLowerCase();
      const idKey = String(c.customerId || c.id || '').trim().toLowerCase();
      const activeData = activeCustMap.get(nameKey) || activeCustMap.get(idKey);

      const invs = activeData ? activeData.invoiceCount : 0;
      const conts = activeData ? activeData.containerCount : 0;
      const gross = activeData ? activeData.grossRevenue : 0;

      return {
        ...c,
        invoiceCount: invs,
        containerCount: conts,
        grossRevenue: gross,
        netRevenue: gross,
        hasActivity: invs > 0 || gross > 0
      };
    });

    // Add active customers that were not in static master array
    activeCustMap.forEach((activeData, key) => {
      const exists = result.some(r => (r.customerName || '').trim().toLowerCase() === key || String(r.id).trim().toLowerCase() === key);
      if (!exists) {
        result.push({
          id: activeData.customerId,
          customerId: activeData.customerId,
          name: activeData.customerName,
          customerName: activeData.customerName,
          invoiceCount: activeData.invoiceCount,
          containerCount: activeData.containerCount,
          grossRevenue: activeData.grossRevenue,
          netRevenue: activeData.netRevenue,
          hasActivity: activeData.invoiceCount > 0 || activeData.grossRevenue > 0
        });
      }
    });

    // Filter by selected company if applicable
    if (activeCompId) {
      if (companyCustomers && companyCustomers[activeCompId] && companyCustomers[activeCompId].length > 0) {
        const compNames = new Set(companyCustomers[activeCompId].map(c => (c.name || c.customerName || '').toLowerCase().trim()));
        result = result.filter(c => 
          compNames.has((c.customerName || '').toLowerCase().trim()) ||
          Array.from(compNames).some(cn => cn.includes((c.customerName || '').toLowerCase()) || (c.customerName || '').toLowerCase().includes(cn))
        );
      }
    }

    // Sort: Active customers first (by grossRevenue desc), then inactive customers alphabetically (A-Z)
    return result.sort((a, b) => {
      if (a.hasActivity && !b.hasActivity) return -1;
      if (!a.hasActivity && b.hasActivity) return 1;
      if (a.hasActivity && b.hasActivity) return b.grossRevenue - a.grossRevenue;
      return (a.customerName || '').localeCompare(b.customerName || '');
    });
  }, [financialData, customers, customerTerminalMatrix, activeCompId, companyCustomers]);

  // Look up selected customer's matrix details
  const customerMatrixEntry = useMemo(() => {
    if (!selectedCustomer || selectedCustomer === 'ALL' || selectedCustomer === 'all') return null;
    const sLower = String(selectedCustomer).toLowerCase().trim();

    const directMatch = availableCustomers.find(c => 
      String(c.customerId || c.id).toLowerCase() === sLower ||
      String(c.customerName || c.name).toLowerCase() === sLower ||
      String(c.customerName || c.name).toLowerCase().includes(sLower)
    );
    if (directMatch && directMatch.terminals && directMatch.terminals.length > 0) return directMatch;

    const matrixMatch = (customerTerminalMatrix || []).find(c => 
      String(c.customerId).toLowerCase() === sLower ||
      String(c.customerName).toLowerCase() === sLower ||
      String(c.customerName).toLowerCase().includes(sLower)
    );
    return matrixMatch || directMatch || null;
  }, [selectedCustomer, availableCustomers, customerTerminalMatrix]);

  const terminalsWithStats = useMemo(() => {
    const activeTerms = financialData?.terminalAnalytics || [];
    const termMap = new Map();
    activeTerms.forEach(t => {
      const tId = String(t.terminalId || t.id || '');
      const tName = String(t.terminalName || t.name || '').toLowerCase().trim();
      if (tId) termMap.set(tId, t);
      if (tName) termMap.set(tName, t);
    });

    const baseList = (terminals && terminals.length > 0) ? terminals : [];

    return baseList.map(t => {
      const tId = String(t.terminalId || t.id || '');
      const tName = String(t.terminalName || t.name || '').toLowerCase().trim();
      const activeObj = termMap.get(tId) || termMap.get(tName);

      const invs = activeObj ? Number(activeObj.invoiceCount || activeObj.invoices || 0) : 0;
      const conts = activeObj ? Number(activeObj.containerCount || activeObj.containers || 0) : 0;
      const rev = activeObj ? Number(activeObj.grossSale || activeObj.grossRevenue || activeObj.netRevenue || 0) : 0;

      return {
        ...t,
        currentStats: {
          totalContainers: conts,
          netRevenue: rev,
          totalJobs: invs,
          invoiceCount: invs
        }
      };
    });
  }, [terminals, financialData]);


  // STRICT CASCADING TERMINALS:
  // 1. If Customer selected -> Only that customer's operating terminals
  // 2. If Company selected -> Only that company's operating terminals
  // 3. If All -> All active operational terminals
  const availableTerminals = useMemo(() => {
    // 1. Customer selected: Only show branches this customer operates at
    if (customerMatrixEntry && customerMatrixEntry.terminals && customerMatrixEntry.terminals.length > 0) {
      return customerMatrixEntry.terminals.map(t => {
        const fullTerm = terminals.find(ft => String(ft.terminalId || ft.id) === String(t.terminalId));
        return {
          terminalId: t.terminalId,
          terminalName: t.terminalName || fullTerm?.terminalName || ('Terminal ' + t.terminalId),
          invoiceCount: t.invoiceCount || 0,
          totalContainers: t.totalContainers || 0,
          netRevenue: t.netRevenue || 0,
          isCustomerBranch: true
        };
      }).sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0));
    }

    // 2. Company selected: Only show branches operated by this company
    if (activeCompId) {
      const compTerms = companyTerminals[activeCompId];
      if (compTerms && compTerms.length > 0) {
        return compTerms.map(t => {
          const fullTerm = terminalsWithStats.find(ft => String(ft.terminalId || ft.id) === String(t.terminalId));
          return {
            terminalId: t.terminalId,
            terminalName: t.terminalName || fullTerm?.terminalName || ('Terminal ' + t.terminalId),
            invoiceCount: t.invoiceCount || fullTerm?.currentStats?.invoiceCount || 0,
            totalContainers: fullTerm?.currentStats?.totalContainers || 0,
            netRevenue: t.totalAmount || fullTerm?.currentStats?.netRevenue || 0,
            isCompanyBranch: true
          };
        }).sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0));
      }
    }

    // 3. No Customer & No Company selected: Full terminals list
    return terminalsWithStats
      .filter(t => t.currentStats.totalContainers > 0 || t.currentStats.netRevenue > 0)
      .sort((a, b) => (b.currentStats.netRevenue || 0) - (a.currentStats.netRevenue || 0));
  }, [customerMatrixEntry, activeCompId, companyTerminals, terminalsWithStats, terminals]);

  const activeTerminals = terminalsWithStats.filter(t => t.currentStats.totalContainers > 0 || t.currentStats.netRevenue > 0)
    .sort((a, b) => (b.currentStats.netRevenue || 0) - (a.currentStats.netRevenue || 0));

  const inactiveTerminals = terminalsWithStats.filter(t => t.currentStats.totalContainers === 0 && t.currentStats.netRevenue === 0);

  // Selected Object Resolvers for Scope Badge and Displays
  const selectedCustomerObj = useMemo(() => {
    if (!selectedCustomer || selectedCustomer === 'ALL' || selectedCustomer === 'all') return null;
    return availableCustomers.find(c => 
      String(c.id).toLowerCase() === String(selectedCustomer).toLowerCase() ||
      String(c.customerId).toLowerCase() === String(selectedCustomer).toLowerCase() ||
      String(c.name || c.customerName).toLowerCase() === String(selectedCustomer).toLowerCase()
    ) || customerMatrixEntry || null;
  }, [selectedCustomer, availableCustomers, customerMatrixEntry]);

  const selectedTerminalObj = useMemo(() => {
    if (!selectedTerminal || selectedTerminal === 'ALL' || selectedTerminal === 'all') return null;
    return availableTerminals.find(t => 
      String(t.terminalId).toLowerCase() === String(selectedTerminal).toLowerCase() ||
      String(t.terminalName).toLowerCase() === String(selectedTerminal).toLowerCase()
    ) || terminalsWithStats.find(t => 
      String(t.terminalId).toLowerCase() === String(selectedTerminal).toLowerCase() ||
      String(t.terminalName).toLowerCase() === String(selectedTerminal).toLowerCase()
    ) || null;
  }, [selectedTerminal, availableTerminals, terminalsWithStats]);

  // Cascading event handlers with auto-reset
  const handleCompanyChange = (newCompanyVal) => {
    if (setSelectedCompany) setSelectedCompany(newCompanyVal);

    // If company changed, verify if current selectedCustomer belongs to new company
    if (newCompanyVal !== 'ALL' && selectedCustomer !== 'ALL') {
      const targetObj = resolveCompany(newCompanyVal);
      const targetId = targetObj ? String(targetObj.id || targetObj.companyId) : null;
      if (targetId && companyCustomers[targetId]) {
        const isCustValid = companyCustomers[targetId].some(c => 
          String(c.id).toLowerCase() === String(selectedCustomer).toLowerCase() ||
          c.name.toLowerCase() === String(selectedCustomer).toLowerCase()
        );
        if (!isCustValid) {
          if (setSelectedCustomer) setSelectedCustomer('ALL');
          if (setSelectedTerminal) setSelectedTerminal('ALL');
        }
      } else {
        if (setSelectedCustomer) setSelectedCustomer('ALL');
        if (setSelectedTerminal) setSelectedTerminal('ALL');
      }
    }
  };

  const handleCustomerChange = (newCustomerVal) => {
    if (setSelectedCustomer) setSelectedCustomer(newCustomerVal);

    // If customer changed, verify if current selectedTerminal is valid for this customer
    if (newCustomerVal !== 'ALL' && selectedTerminal !== 'ALL') {
      const match = (customerTerminalMatrix || []).find(c => 
        String(c.customerId).toLowerCase() === String(newCustomerVal).toLowerCase() ||
        c.customerName.toLowerCase() === String(newCustomerVal).toLowerCase()
      );
      if (match && match.terminals) {
        const hasTerm = match.terminals.some(t => String(t.terminalId) === String(selectedTerminal));
        if (!hasTerm) {
          if (setSelectedTerminal) setSelectedTerminal('ALL');
        }
      }
    }
  };

  const handleQuickExport = () => {
    if (onExport) {
      onExport();
      return;
    }
    const wb = XLSX.utils.book_new();
    const dataToExport = (availableTerminals || []).map(t => ({
      'Terminal ID': t.terminalId,
      'Terminal / Branch': t.terminalName,
      'Fiscal Year': selectedFY === 'ALL' ? 'Cumulative (All Years)' : selectedFY,
      'Status': (t.totalContainers > 0 || t.netRevenue > 0 || t.invoiceCount > 0) ? 'Active with Data' : 'Zero Data / Inactive',
      'Invoices': t.invoiceCount || 0,
      'Containers': t.totalContainers || 0,
      'Net Sales (Gross Sale INR)': t.netRevenue || 0
    }));
    const ws = XLSX.utils.json_to_sheet(dataToExport);
    XLSX.utils.book_append_sheet(wb, ws, 'Branch_Overview');
    XLSX.writeFile(wb, `SPJ_Enterprise_Overview_${selectedFY.replace(/\s+/g, '_')}_${new Date().toISOString().slice(0, 10)}.xlsx`);
  };

  return (
    <div className="bg-white rounded-2xl sm:rounded-3xl border border-slate-200 shadow-soft overflow-hidden transition-all">
      {/* Top Filter & Actions Row */}
      <div className="p-3 sm:p-5">
        <div className="flex flex-col lg:flex-row items-start lg:items-end justify-between gap-3 sm:gap-4">
          
          {/* Controls Group: 1. Financial Year -> 2. Company -> 3. Branch -> 4. Customer */}
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-2.5 sm:gap-3.5 w-full lg:w-auto flex-1">
            
            {/* 1. Custom Date Range Selector (Primary Date Selector - Clean Prompt Mode) */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 flex items-center justify-between">
                <span className="flex items-center gap-1.5">
                  <Calendar className="w-3.5 h-3.5 text-[#ff6a00]" />
                  Custom Date Range
                </span>
                {(customFromDate || customToDate) ? (
                  <button
                    onClick={() => {
                      if (setCustomFromDate) setCustomFromDate('');
                      if (setCustomToDate) setCustomToDate('');
                      if (setSelectedFY) setSelectedFY('ALL');
                    }}
                    className="text-[9px] font-extrabold text-rose-600 bg-rose-50 hover:bg-rose-100 px-1.5 py-0.5 rounded-md border border-rose-200 cursor-pointer"
                    title="Clear Custom Date Range (Show All Time Data)"
                  >
                    ✕ Clear (All Time)
                  </button>
                ) : (
                  <span className="text-[9px] font-bold text-slate-400 bg-slate-100 px-1.5 py-0.5 rounded-md border border-slate-200">
                    All Time Data
                  </span>
                )}
              </label>

              <div className="flex items-center gap-1.5 bg-slate-50 p-1.5 rounded-xl border border-slate-300 shadow-xs">
                <div className="flex-1 min-w-0">
                  <span className="text-[8px] font-extrabold text-slate-400 block uppercase">From Date</span>
                  <input
                    type="date"
                    value={customFromDate || ''}
                    placeholder="Select From Date"
                    onChange={(e) => {
                      if (setCustomFromDate) setCustomFromDate(e.target.value);
                      if (setSelectedFY) setSelectedFY('CUSTOM_RANGE');
                    }}
                    className="w-full h-7 px-1.5 bg-white border border-slate-200 rounded-lg text-[11px] font-bold text-slate-800 focus:outline-none focus:ring-1 focus:ring-[#ff6a00]"
                  />
                </div>
                <span className="text-slate-400 font-bold text-xs mt-3">→</span>
                <div className="flex-1 min-w-0">
                  <span className="text-[8px] font-extrabold text-slate-400 block uppercase">To Date</span>
                  <input
                    type="date"
                    value={customToDate || ''}
                    placeholder="Select To Date"
                    onChange={(e) => {
                      if (setCustomToDate) setCustomToDate(e.target.value);
                      if (setSelectedFY) setSelectedFY('CUSTOM_RANGE');
                    }}
                    className="w-full h-7 px-1.5 bg-white border border-slate-200 rounded-lg text-[11px] font-bold text-slate-800 focus:outline-none focus:ring-1 focus:ring-[#ff6a00]"
                  />
                </div>
              </div>
            </div>

            {/* 2. Company Selection */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 flex items-center justify-between">
                <span className="flex items-center gap-1.5">
                  <Building className="w-3.5 h-3.5 text-indigo-600" />
                  Company Selection
                </span>
                {selectedCompany !== 'ALL' && (
                  <button 
                    onClick={() => setSelectedCompany && setSelectedCompany('ALL')}
                    className="text-[9px] font-bold text-indigo-600 hover:underline cursor-pointer"
                  >
                    Reset
                  </button>
                )}
              </label>
              <div className="relative">
                <select
                  value={selectedCompany}
                  onChange={(e) => handleCompanyChange(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-indigo-600 transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">🏛️ All Companies (5 Entities — ₹ {formatNumber(Math.round((companyList.reduce((a,c)=>a+c.totalRevenue,0)/10000000)*100)/100)} Cr)</option>
                  {companyList.map(comp => {
                    const revStr = comp.totalRevenue ? ` [${formatCurrency(comp.totalRevenue)}]` : ' [₹ 0.00]';
                    const invStr = comp.invoiceCount ? ` (${formatNumber(comp.invoiceCount)} Invs)` : ' (0 Invs)';
                    return (
                      <option key={comp.id || comp.code} value={String(comp.id || comp.code)}>
                        🏢 {comp.name} ({comp.code}){revStr}{invStr}
                      </option>
                    );
                  })}
                </select>
              </div>
            </div>

            {/* 3. Branch Selection (Cascaded by Date Range + Company) */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 flex items-center justify-between">
                <span className="flex items-center gap-1.5">
                  <Building2 className="w-3.5 h-3.5 text-[#2b1f55]" />
                  Branch Selection
                </span>
                {selectedTerminal !== 'ALL' && (
                  <button 
                    onClick={() => setSelectedTerminal && setSelectedTerminal('ALL')}
                    className="text-[9px] font-bold text-[#2b1f55] hover:underline cursor-pointer"
                  >
                    Reset
                  </button>
                )}
              </label>
              <div className="relative">
                <select
                  value={selectedTerminal}
                  onChange={(e) => setSelectedTerminal && setSelectedTerminal(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-[#2b1f55] transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">🏢 All Branches ({availableTerminals.length || 39} Operating Hubs)</option>
                  
                  {activeTerminals.length > 0 && (
                    <optgroup label={`── 🟢 Active Operating Branches in Date Range (${activeTerminals.length}) ──`}>
                      {activeTerminals.map(t => {
                        const invs = t.invoiceCount || t.currentStats?.invoiceCount || 0;
                        const conts = t.totalContainers || t.currentStats?.totalContainers || 0;
                        const teus = t.teus || t.currentStats?.teus || Math.round(conts * 1.9);
                        const rev = t.netRevenue || t.currentStats?.netRevenue || 0;
                        return (
                          <option key={t.terminalId || t.terminalName} value={String(t.terminalId || t.terminalName)}>
                            🟢 {t.terminalName} ({formatNumber(conts)} Cont | {formatNumber(teus)} TEUs | {formatNumber(invs)} Invs | {formatCurrency(rev)})
                          </option>
                        );
                      })}
                    </optgroup>
                  )}

                  {inactiveTerminals.length > 0 && (
                    <optgroup label={`── ⚪ Zero Activity Hubs in Selected Scope (${inactiveTerminals.length}) ──`}>
                      {inactiveTerminals.map(t => (
                        <option key={t.terminalId || t.terminalName} value={String(t.terminalId || t.terminalName)} className="text-slate-400">
                          ⚪ {t.terminalName} (0 Cont | ₹ 0.00)
                        </option>
                      ))}
                    </optgroup>
                  )}
                </select>
              </div>
            </div>

            {/* 4. Customer Selection (Cascaded by Date Range + Company + Branch) */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 flex items-center justify-between">
                <span className="flex items-center gap-1.5">
                  <Users className="w-3.5 h-3.5 text-emerald-600" />
                  Customer Selection
                </span>
                {selectedCustomer !== 'ALL' && (
                  <button 
                    onClick={() => setSelectedCustomer && setSelectedCustomer('ALL')}
                    className="text-[9px] font-bold text-emerald-600 hover:underline cursor-pointer"
                  >
                    Reset
                  </button>
                )}
              </label>
              <div className="relative">
                <select
                  value={selectedCustomer}
                  onChange={(e) => handleCustomerChange(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-emerald-600 transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">👥 All Customers ({availableCustomers.length} Total Clients)</option>
                  
                  {availableCustomers.some(c => c.hasActivity) && (
                    <optgroup label={`── 🟢 Active Billed Clients in Selected Scope (${availableCustomers.filter(c => c.hasActivity).length}) ──`}>
                      {availableCustomers.filter(c => c.hasActivity).map(c => (
                        <option key={c.id || c.customerId || c.customerName} value={String(c.customerId || c.id || c.customerName)}>
                          🟢 {c.customerName} ({formatNumber(c.invoiceCount)} Invs | {formatNumber(c.containerCount)} Cont | {formatCurrency(c.grossRevenue)})
                        </option>
                      ))}
                    </optgroup>
                  )}

                  {availableCustomers.some(c => !c.hasActivity) && (
                    <optgroup label={`── ⚪ Inactive Customers in Selected Scope (${availableCustomers.filter(c => !c.hasActivity).length}) ──`}>
                      {availableCustomers.filter(c => !c.hasActivity).map(c => (
                        <option key={c.id || c.customerId || c.customerName} value={String(c.customerId || c.id || c.customerName)} className="text-slate-400">
                          ⚪ {c.customerName} (0 Invoices in Selected Scope)
                        </option>
                      ))}
                    </optgroup>
                  )}
                </select>
              </div>
            </div>

          </div>

          {/* Action Buttons Group */}
          <div className="flex items-center gap-2 w-full lg:w-auto justify-end shrink-0 pt-1 lg:pt-0">
            {/* Reset Button */}
            {isFilterActive && (
              <button
                onClick={resetFilters}
                className="h-9 sm:h-11 inline-flex items-center gap-1.5 px-3 sm:px-4 bg-rose-50 text-rose-700 hover:bg-rose-100 border border-rose-200 rounded-xl text-xs font-bold transition-all shadow-xs shrink-0 cursor-pointer"
                title="Reset All Filters to Default"
              >
                <RotateCcw className="w-3.5 h-3.5" />
                <span>Reset</span>
              </button>
            )}

            <button
              onClick={onRefresh}
              disabled={loading}
              className="h-9 sm:h-11 inline-flex items-center justify-center gap-1.5 px-3 sm:px-4 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all border border-slate-200 shadow-xs disabled:opacity-50 cursor-pointer"
            >
              <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
              <span>Sync DB</span>
            </button>

            <button
              onClick={handleQuickExport}
              className="h-9 sm:h-11 inline-flex items-center justify-center gap-1.5 px-3.5 sm:px-5 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] text-white hover:opacity-95 rounded-xl text-xs font-bold shadow-md shadow-purple-900/20 transition-all shrink-0 cursor-pointer"
            >
              <FileSpreadsheet className="w-3.5 h-3.5 sm:w-4 sm:h-4 text-emerald-400" />
              <span>Export Excel</span>
            </button>
          </div>

        </div>
      </div>

      {/* Bottom Context & Status Bar */}
      <div className="px-3 sm:px-5 py-2 sm:py-3 bg-slate-50/80 border-t border-slate-100 flex flex-wrap items-center justify-between gap-2 text-[10px] sm:text-xs">
        
        {/* Left: Active Scope Pills */}
        <div className="flex flex-wrap items-center gap-1.5 sm:gap-2">
          <span className="flex items-center gap-1 text-slate-500 font-medium">
            <span className="w-1.5 h-1.5 rounded-full bg-emerald-500 animate-pulse"></span>
            Scope:
          </span>

          {/* Company Scope Pill */}
          {selectedCompany !== 'ALL' && (
            <>
              <span className="inline-flex items-center font-bold text-indigo-800 bg-indigo-100/80 border border-indigo-200 px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg">
                🏢 {selectedCompanyObj?.name || `Company ${selectedCompany}`}
              </span>
              <span className="text-slate-400 font-bold">&bull;</span>
            </>
          )}

          {/* Customer Scope Pill with Branch count */}
          {selectedCustomer !== 'ALL' && (
            <>
              <span className="inline-flex items-center font-bold text-blue-800 bg-blue-100/80 border border-blue-200 px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg truncate max-w-[280px]" title={String(selectedCustomer)}>
                👥 {customerMatrixEntry 
                  ? `${customerMatrixEntry.customerName} (${customerMatrixEntry.terminalCount} Branches: ${customerMatrixEntry.terminals.map(t=>t.terminalName).join(', ')})`
                  : (selectedCustomerObj?.customerName || selectedCustomerObj?.name || `Customer: ${selectedCustomer}`)}
              </span>
              <span className="text-slate-400 font-bold">&bull;</span>
            </>
          )}

          {/* Terminal / Branch Scope Pill */}
          <span className={`inline-flex items-center font-bold px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg border ${
            selectedTerminal === 'ALL'
              ? 'text-[#2b1f55] bg-purple-100/70 border-purple-200'
              : (selectedTerminalObj && (selectedTerminalObj.currentStats?.totalContainers === 0 && selectedTerminalObj.currentStats?.netRevenue === 0)
                  ? 'text-rose-700 bg-rose-100/80 border-rose-300'
                  : 'text-[#2b1f55] bg-purple-100/70 border-purple-200')
          }`}>
            {selectedTerminal === 'ALL' 
              ? (customerMatrixEntry 
                  ? `All ${availableTerminals.length} Client Branches` 
                  : selectedCompanyObj 
                  ? `All ${availableTerminals.length} Entity Branches` 
                  : `All ${terminals.length || 39} Branches`)
              : `${selectedTerminalObj && (selectedTerminalObj.currentStats?.totalContainers === 0 && selectedTerminalObj.currentStats?.netRevenue === 0) ? '🔴 ' : '🟢 '}${selectedTerminalObj?.terminalName || `Branch ${selectedTerminal}`}`}
          </span>

          <span className="text-slate-400 font-bold">&bull;</span>

          {/* FY Scope Pill */}
          <span className="inline-flex items-center font-bold text-[#ea580c] bg-orange-100/70 border border-orange-200 px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg">
            {selectedFY === 'ALL' ? 'All FYs' : selectedFY}
          </span>
        </div>

        {/* Right: Database Source */}
        <div className="flex items-center gap-1.5 text-[10px] sm:text-[11px] text-slate-500 font-mono">
          <ShieldCheck className="w-3.5 h-3.5 text-emerald-600" />
          <span>Oracle Live</span>
          <span className="font-bold text-emerald-700 bg-emerald-50 px-1.5 py-0.5 rounded border border-emerald-200">SPJLIVE</span>
        </div>

      </div>

    </div>
  );
}
