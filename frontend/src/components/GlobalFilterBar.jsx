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

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
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
    'FY 2023-24', 
    'FY 2022-23 & Earlier'
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

  // 5 Official SPJ Group Companies in exact user requested order
  const companyList = useMemo(() => {
    if (companies && companies.length > 0) return companies;
    return [
      { id: 3, companyId: 3, code: 'PJ-OLD', name: 'PURAN JOSHI OLD', gstin: '07ADGPJ3166M1ZA', director: 'Mr. Puran Joshi' },
      { id: 2, companyId: 2, code: 'SPJ', name: 'SPJ CARGO PVT LTD', gstin: '07AAOCS1758E1Z5', director: 'Mr. Puran Joshi' },
      { id: 1, companyId: 1, code: 'SJ', name: 'S.J. CARGO MOVERS', gstin: '07ADGPJ3166M1ZA', director: 'Mr. Puran Joshi' },
      { id: 5, companyId: 5, code: 'PJ', name: 'PURAN JOSHI', gstin: '07ADGPJ3166M2Z9', director: 'Mr. Puran Joshi' },
      { id: 4, companyId: 4, code: 'SPJ-MUM', name: 'SPJ CARGO PVT LTD-MUMBAI', gstin: '27AAOCS1758E1Z3', director: 'Mr. Puran Joshi' }
    ];
  }, [companies]);

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

  // STRICT CASCADING CUSTOMERS: Filtered exclusively to selectedCompany
  const availableCustomers = useMemo(() => {
    // A) If a company is selected: ONLY show customers belonging to this company
    if (activeCompId) {
      // 1. From backend companyCustomers map if available
      if (companyCustomers && companyCustomers[activeCompId] && companyCustomers[activeCompId].length > 0) {
        return companyCustomers[activeCompId].map(c => {
          const matrixMatch = (customerTerminalMatrix || []).find(m => 
            String(m.companyId) === activeCompId && 
            (String(m.customerId) === String(c.id) || (m.customerName && c.name && m.customerName.toLowerCase() === c.name.toLowerCase()))
          );
          return {
            id: c.id,
            customerId: c.id,
            name: c.name,
            customerName: c.name,
            code: c.code || '',
            city: c.city || '',
            invoiceCount: matrixMatch ? matrixMatch.totalInvoices : (c.invoiceCount || 0),
            terminalCount: matrixMatch ? matrixMatch.terminalCount : (c.terminalCount || 1),
            terminals: matrixMatch ? matrixMatch.terminals : [],
            netRevenue: matrixMatch ? matrixMatch.totalRevenue : (c.totalAmount || 0)
          };
        }).sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0));
      }

      // 2. From customerTerminalMatrix filtered by this companyId
      const matrixMatchList = (customerTerminalMatrix || []).filter(c => 
        String(c.companyId) === activeCompId || 
        String(c.companyId) === String(selectedCompanyObj?.code)
      );
      if (matrixMatchList.length > 0) {
        return matrixMatchList.map(c => ({
          id: c.customerId,
          customerId: c.customerId,
          name: c.customerName,
          customerName: c.customerName,
          code: '',
          city: '',
          invoiceCount: c.totalInvoices || 0,
          terminalCount: c.terminalCount || (c.terminals?.length || 1),
          terminals: c.terminals || [],
          netRevenue: c.totalRevenue || 0
        })).sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0));
      }
      return [];
    }

    // B) If ALL companies are selected: Show all active clients from customerTerminalMatrix or topCustomers
    if (customerTerminalMatrix && customerTerminalMatrix.length > 0) {
      return customerTerminalMatrix.map(c => ({
        id: c.customerId,
        customerId: c.customerId,
        name: c.customerName,
        customerName: c.customerName,
        code: '',
        city: '',
        invoiceCount: c.totalInvoices || 0,
        terminalCount: c.terminalCount || (c.terminals?.length || 1),
        terminals: c.terminals || [],
        netRevenue: c.totalRevenue || 0,
        companyId: c.companyId
      })).sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0));
    }

    if (topCustomers && topCustomers.length > 0) {
      return topCustomers.slice(0, 100);
    }
    return (customers || []).slice(0, 200);
  }, [activeCompId, selectedCompanyObj, companyCustomers, customerTerminalMatrix, topCustomers, customers]);

  // Look up selected customer's matrix details
  const customerMatrixEntry = useMemo(() => {
    if (!selectedCustomer || selectedCustomer === 'ALL' || selectedCustomer === 'all') return null;
    const sLower = String(selectedCustomer).toLowerCase().trim();

    // Look in currently available customers first
    const directMatch = availableCustomers.find(c => 
      String(c.customerId || c.id).toLowerCase() === sLower ||
      String(c.customerName || c.name).toLowerCase() === sLower ||
      String(c.customerName || c.name).toLowerCase().includes(sLower)
    );
    if (directMatch && directMatch.terminals && directMatch.terminals.length > 0) return directMatch;

    // Look in global customerTerminalMatrix
    const matrixMatch = (customerTerminalMatrix || []).find(c => 
      String(c.customerId).toLowerCase() === sLower ||
      String(c.customerName).toLowerCase() === sLower ||
      String(c.customerName).toLowerCase().includes(sLower)
    );
    return matrixMatch || directMatch || null;
  }, [selectedCustomer, availableCustomers, customerTerminalMatrix]);

  // Compute terminal stats specifically for current selectedFY
  const getTerminalStats = (t) => {
    if (selectedFY === 'ALL' || selectedFY === 'all') {
      return {
        totalContainers: t.totalContainers || 0,
        netRevenue: t.netRevenue || 0,
        totalJobs: t.totalJobs || 0,
        invoiceCount: t.invoiceCount || 0
      };
    }
    const cell = (terminalFyMatrix || []).find(m => String(m.terminalId) === String(t.terminalId) && m.fy === selectedFY);
    if (cell) {
      return {
        totalContainers: cell.totalContainers || 0,
        netRevenue: cell.netRevenue || 0,
        totalJobs: cell.totalJobs || 0,
        invoiceCount: cell.invoiceCount || 0
      };
    }
    return { totalContainers: 0, netRevenue: 0, totalJobs: 0, invoiceCount: 0 };
  };

  const terminalsWithStats = terminals.map(t => ({
    ...t,
    currentStats: getTerminalStats(t)
  }));

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
      'Net Revenue (Gross Sale INR)': t.netRevenue || 0
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
          
          {/* Controls Group: 1. Company -> 2. Customer -> 3. Terminal -> 4. Financial Year */}
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-2.5 sm:gap-3.5 w-full lg:w-auto flex-1">
            
            {/* 1. Company Selection */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 sm:mb-2 flex items-center gap-1.5">
                <Building className="w-3.5 h-3.5 text-indigo-600" />
                Company Selection
              </label>
              <div className="relative">
                <select
                  value={selectedCompany}
                  onChange={(e) => handleCompanyChange(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-indigo-600 transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">🏛️ All Companies (5 Group Entities)</option>
                  {companyList.map(comp => (
                    <option key={comp.id || comp.code} value={String(comp.id || comp.code)}>
                      🏢 {comp.name} ({comp.code})
                    </option>
                  ))}
                </select>
              </div>
            </div>

            {/* 2. Customer Selection (Strictly filtered by selectedCompany) */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 sm:mb-2 flex items-center gap-1.5">
                <Users className="w-3.5 h-3.5 text-blue-600" />
                Customer Selection
                {selectedCompanyObj && (
                  <span className="text-[9px] font-semibold text-indigo-700 bg-indigo-50 px-1.5 py-0.2 rounded-full border border-indigo-200">
                    {selectedCompanyObj.code}
                  </span>
                )}
              </label>
              <div className="relative">
                <select
                  value={selectedCustomer}
                  onChange={(e) => handleCustomerChange(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-blue-600 transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">
                    👥 {selectedCompanyObj ? `All Customers in ${selectedCompanyObj.code} (${availableCustomers.length} Total)` : `All Customers (${availableCustomers.length} Total)`}
                  </option>
                  
                  {availableCustomers.length > 0 ? (
                    <optgroup label={selectedCompanyObj ? `── 🏢 Customers of ${selectedCompanyObj.name} (${availableCustomers.length}) ──` : `── 🟢 Active Customers with Branch Coverage ──`}>
                      {availableCustomers.map(c => {
                        const val = c.customerId || c.id || c.customerName || c.name;
                        const name = c.customerName || c.name;
                        const branches = c.terminalCount ? ` (${c.terminalCount} Hubs)` : '';
                        const bills = c.invoiceCount ? ` [${formatNumber(c.invoiceCount)} Invoices]` : '';
                        return (
                          <option key={val} value={String(val)}>
                            🟢 {name}{branches}{bills}
                          </option>
                        );
                      })}
                    </optgroup>
                  ) : (
                    <option value="" disabled>No registered clients for this entity</option>
                  )}
                </select>
              </div>
            </div>

            {/* 3. Branch / Terminal Selection (Cascaded: Filtered by Customer or Company) */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 sm:mb-2 flex items-center gap-1.5">
                <Building2 className="w-3.5 h-3.5 text-[#2b1f55]" />
                Branch / Terminal Selection
                {customerMatrixEntry ? (
                  <span className="text-[9px] font-normal text-emerald-700 bg-emerald-100 px-1.5 py-0.2 rounded-full">
                    {availableTerminals.length} Client Hubs
                  </span>
                ) : selectedCompanyObj ? (
                  <span className="text-[9px] font-normal text-purple-700 bg-purple-100 px-1.5 py-0.2 rounded-full">
                    {availableTerminals.length} Entity Hubs
                  </span>
                ) : null}
              </label>
              <div className="relative">
                <select
                  value={selectedTerminal}
                  onChange={(e) => setSelectedTerminal(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-[#2b1f55] transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">
                    {customerMatrixEntry
                      ? `🏢 All Active Branches for ${customerMatrixEntry.customerName || customerMatrixEntry.name} (${availableTerminals.length} Hubs)`
                      : selectedCompanyObj
                      ? `🏢 All Operating Branches of ${selectedCompanyObj.name} (${availableTerminals.length} Hubs)`
                      : `🏢 All Terminals & Hubs (${terminals.length || 39} Total)`}
                  </option>
                  
                  {/* If a customer is selected, show strictly their active branches */}
                  {customerMatrixEntry && availableTerminals.length > 0 ? (
                    <optgroup label={`── 🟢 Active Operating Branches for ${customerMatrixEntry.customerName || customerMatrixEntry.name} ──`}>
                      {availableTerminals.map(t => (
                        <option key={t.terminalId} value={String(t.terminalId)}>
                          🟢 {t.terminalName} ({formatNumber(t.invoiceCount)} Invoices{t.totalContainers ? ` | ${formatNumber(t.totalContainers)} Cont` : ''}{t.netRevenue ? ` | ${formatCurrency(t.netRevenue)}` : ''})
                        </option>
                      ))}
                    </optgroup>
                  ) : selectedCompanyObj && availableTerminals.length > 0 ? (
                    /* If a company is selected (and customer is ALL), show strictly that company's terminals */
                    <optgroup label={`── 🏢 Operating Terminals of ${selectedCompanyObj.name} (${availableTerminals.length}) ──`}>
                      {availableTerminals.map(t => (
                        <option key={t.terminalId} value={String(t.terminalId)}>
                          🟢 {t.terminalName} ({formatNumber(t.invoiceCount)} Invoices{t.totalContainers ? ` | ${formatNumber(t.totalContainers)} Cont` : ''}{t.netRevenue ? ` | ${formatCurrency(t.netRevenue)}` : ''})
                        </option>
                      ))}
                    </optgroup>
                  ) : (
                    /* Global unfiltered view with Active vs Inactive hubs */
                    <>
                      <optgroup label={selectedFY === 'ALL' ? "── 🟢 Active Hubs with Data ──" : `── 🟢 Active Hubs in ${selectedFY} ──`}>
                        {activeTerminals.map(t => (
                          <option key={t.terminalId} value={String(t.terminalId)}>
                            🟢 {t.terminalName} ({formatNumber(t.currentStats.totalContainers)} Cont | {formatCurrency(t.currentStats.netRevenue)})
                          </option>
                        ))}
                      </optgroup>

                      {inactiveTerminals.length > 0 && (
                        <optgroup label={selectedFY === 'ALL' ? "── 🔴 Inactive / Zero Data Terminals ──" : `── 🔴 No Activity in ${selectedFY} ──`}>
                          {inactiveTerminals.map(t => (
                            <option key={t.terminalId} value={String(t.terminalId)} className="text-rose-600 font-semibold bg-rose-50/50">
                              🔴 {t.terminalName} (0 Cont | Inactive)
                            </option>
                          ))}
                        </optgroup>
                      )}
                    </>
                  )}
                </select>
              </div>
            </div>

            {/* 4. Financial Year Filter */}
            <div className="flex flex-col min-w-0">
              <label className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-1 sm:mb-2 flex items-center gap-1.5">
                <Calendar className="w-3.5 h-3.5 text-[#ff6a00]" />
                Financial Year Filter
              </label>
              <div className="relative">
                <select
                  value={selectedFY}
                  onChange={(e) => setSelectedFY(e.target.value)}
                  className="w-full h-9 sm:h-11 pl-3 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-[#ff6a00] transition-all cursor-pointer shadow-xs truncate"
                >
                  <option value="ALL">📅 All Financial Years (Cumulative)</option>
                  
                  {/* Highlight customer's available FYs if customer selected */}
                  {customerMatrixEntry && customerMatrixEntry.financialYears?.length > 0 ? (
                    <>
                      <optgroup label={`── 🟢 Active FYs for ${customerMatrixEntry.customerName} ──`}>
                        {customerMatrixEntry.financialYears.map(fy => (
                          <option key={fy} value={fy}>
                            🟢 {fy} (Active Activity)
                          </option>
                        ))}
                      </optgroup>
                      <optgroup label="── All Financial Years ──">
                        {financialYears.filter(fy => fy !== 'All Financial Years' && !customerMatrixEntry.financialYears.includes(fy)).map(fy => (
                          <option key={fy} value={fy} className="text-slate-400">
                            ⚪ {fy}
                          </option>
                        ))}
                      </optgroup>
                    </>
                  ) : (
                    <>
                      <option value="FY 2026-27">FY 2026-27 (Current Fiscal)</option>
                      <option value="FY 2025-26">FY 2025-26 (Past Year 1)</option>
                      <option value="FY 2024-25">FY 2024-25 (Past Year 2)</option>
                      <option value="FY 2023-24">FY 2023-24 (Past Year 3)</option>
                      <option value="FY 2022-23 & Earlier">FY 2022-23 & Earlier (Historical)</option>
                    </>
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

          {/* Terminal Scope Pill */}
          <span className={`inline-flex items-center font-bold px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg border ${
            selectedTerminal === 'ALL'
              ? 'text-[#2b1f55] bg-purple-100/70 border-purple-200'
              : (selectedTerminalObj && (selectedTerminalObj.currentStats?.totalContainers === 0 && selectedTerminalObj.currentStats?.netRevenue === 0)
                  ? 'text-rose-700 bg-rose-100/80 border-rose-300'
                  : 'text-[#2b1f55] bg-purple-100/70 border-purple-200')
          }`}>
            {selectedTerminal === 'ALL' 
              ? 'All 39 Terminals' 
              : `${selectedTerminalObj && (selectedTerminalObj.currentStats?.totalContainers === 0 && selectedTerminalObj.currentStats?.netRevenue === 0) ? '🔴 ' : '🟢 '}${selectedTerminalObj?.terminalName || `Terminal ${selectedTerminal}`}`}
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
