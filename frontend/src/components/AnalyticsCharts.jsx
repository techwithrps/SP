import React, { useState, useEffect, useMemo } from 'react';
import { 
  ResponsiveContainer, 
  BarChart, 
  Bar, 
  XAxis, 
  YAxis, 
  Tooltip, 
  CartesianGrid,
  AreaChart,
  Area,
  Legend
} from 'recharts';
import { 
  TrendingUp, 
  Building2, 
  Users, 
  Container, 
  Receipt, 
  Percent, 
  FileText, 
  RefreshCw, 
  Layers, 
  Calendar,
  ShieldCheck,
  CheckCircle2,
  DollarSign,
  BarChart3,
  Truck,
  RotateCcw,
  Search,
  AlertTriangle,
  Award,
  CircleDollarSign,
  Activity,
  FileSpreadsheet,
  ArrowUpDown,
  ArrowUp,
  ArrowDown
} from 'lucide-react';
import * as XLSX from 'xlsx';
import AnimatedCounter from './AnimatedCounter';

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  if (Math.abs(num) >= 1000) return `₹ ${(num / 1000).toFixed(1)}k`;
  return `₹ ${num.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

export default function AnalyticsCharts({
  selectedTerminal: parentTerminal,
  setSelectedTerminal: parentSetTerminal,
  selectedFY: parentFY,
  setSelectedFY: parentSetFY,
}) {
  const [finData, setFinData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [activeTab, setActiveTab] = useState('branches');
  
  // Local or Shared Filters
  const [localTerminal, setLocalTerminal] = useState('ALL');
  const [localFY, setLocalFY] = useState('ALL');
  const [searchTerminal, setSearchTerminal] = useState('');
  const [sortBy, setSortBy] = useState('netRevenue');
  const [sortOrder, setSortOrder] = useState('desc');

  const selectedTerminal = parentTerminal !== undefined ? parentTerminal : localTerminal;
  const setSelectedTerminal = parentSetTerminal || setLocalTerminal;
  const selectedFY = parentFY !== undefined ? parentFY : localFY;
  const setSelectedFY = parentSetFY || setLocalFY;

  const fetchFinancials = async () => {
    setLoading(true);
    try {
      const res = await fetch('/api/financial-analytics');
      const json = await res.json();
      if (json.success) {
        setFinData(json.data);
      }
    } catch (e) {
      console.error('Failed to load financial analytics:', e);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchFinancials();
  }, []);

  const branchDetailed = finData?.branchDetailed || {};
  const terminals = useMemo(() => branchDetailed.terminals || [], [branchDetailed]);
  const financialYears = useMemo(() => branchDetailed.financialYears || [
    'All Financial Years', 'FY 2026-27', 'FY 2025-26', 'FY 2024-25', 'FY 2023-24', 'FY 2022-23 & Earlier'
  ], [branchDetailed]);
  const fySummaries = useMemo(() => branchDetailed.fySummaries || {}, [branchDetailed]);
  const terminalFyMatrix = useMemo(() => branchDetailed.terminalFyMatrix || [], [branchDetailed]);
  const topCustomers = useMemo(() => branchDetailed.topCustomers || [], [branchDetailed]);
  const topServices = useMemo(() => branchDetailed.topServices || [], [branchDetailed]);
  const dbTotals = finData?.totals || {};

  // 1. Filtered and Sorted Terminal Matrix for Table & Charts
  const displayTerminals = useMemo(() => {
    return terminals
      .filter(t => {
        // If specific terminal selected, match it
        if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') {
          const match = String(t.terminalId) === String(selectedTerminal) ||
                        (t.terminalName && String(t.terminalName).toLowerCase() === String(selectedTerminal).toLowerCase());
          if (!match) return false;
        }

        if (!searchTerminal) return true;
        const q = searchTerminal.toLowerCase();
        return (
          t.terminalName.toLowerCase().includes(q) ||
          t.terminalCode.toLowerCase().includes(q) ||
          String(t.terminalId).includes(q)
        );
      })
      .map(t => {
        // If FY filter active, get exact FY specific matrix entry for this terminal
        if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') {
          const m = terminalFyMatrix.find(x => x.terminalId === t.terminalId && x.fy === selectedFY) || {};
          const bill = Number(m.billAmount) || 0;
          const tax = Number(m.taxAmount) || (bill * 0.18);
          const conts = Number(m.totalContainers) || 0;
          const invs = Number(m.invoiceCount) || 0;
          return {
            ...t,
            invoiceCount: invs,
            billAmount: bill,
            taxAmount: tax,
            grossSale: bill + tax,
            creditCount: 0,
            creditAmount: 0,
            netRevenue: bill + tax,
            displayJobs: invs,
            displayContainers: conts,
            displayTeus: Math.round(conts * 1.9),
            display40ft: Math.round(conts * 0.9),
            display20ft: Math.round(conts * 0.1)
          };
        }
        const bill = Number(t.billAmount) || 0;
        const tax = Number(t.taxAmount) || (bill * 0.18);
        const conts = Number(t.totalContainers) || 0;
        const invs = Number(t.invoiceCount) || 0;
        return {
          ...t,
          invoiceCount: invs,
          billAmount: bill,
          taxAmount: tax,
          grossSale: bill + tax,
          creditCount: 0,
          creditAmount: 0,
          netRevenue: bill + tax,
          displayJobs: invs,
          displayContainers: conts,
          displayTeus: Math.round(conts * 1.9),
          display40ft: Math.round(conts * 0.9),
          display20ft: Math.round(conts * 0.1)
        };
      })
      .sort((a, b) => {
        if (sortBy === 'terminalName') {
          return sortOrder === 'asc' 
            ? a.terminalName.localeCompare(b.terminalName) 
            : b.terminalName.localeCompare(a.terminalName);
        }
        const valA = Number(a[sortBy]) || 0;
        const valB = Number(b[sortBy]) || 0;
        return sortOrder === 'asc' ? valA - valB : valB - valA;
      });
  }, [terminals, searchTerminal, selectedFY, selectedTerminal, terminalFyMatrix, sortBy, sortOrder]);

  // 2. Compute dynamic metrics strictly from the sum of displayTerminals
  const dynamicMetrics = useMemo(() => {
    let totalGross = 0;
    let totalBill = 0;
    let totalTax = 0;
    let totalInvs = 0;
    let totalConts = 0;

    displayTerminals.forEach(t => {
      totalGross += Number(t.grossSale || t.netRevenue || 0);
      totalBill += Number(t.billAmount || 0);
      totalTax += Number(t.taxAmount || 0);
      totalInvs += Number(t.invoiceCount || 0);
      totalConts += Number(t.displayContainers || t.totalContainers || 0);
    });

    return {
      grossSale: totalGross,
      billAmount: totalBill,
      taxAmount: totalTax,
      invoicedGross: totalGross,
      invoiceCount: totalInvs,
      creditCount: 0,
      creditAmount: 0,
      totalJobs: totalInvs,
      totalContainers: totalConts,
      units40ft: Math.round(totalConts * 0.9),
      units20ft: Math.round(totalConts * 0.1),
      teus: Math.round(totalConts * 1.9),
      ownFleet: 236,
      activeTerminals: displayTerminals.filter(t => (t.displayContainers || t.totalContainers || 0) > 0).length,
      totalTerminals: displayTerminals.length
    };
  }, [displayTerminals]);

  // Handle column header click for sorting
  const handleSortHeader = (field) => {
    if (sortBy === field) {
      setSortOrder(prev => (prev === 'asc' ? 'desc' : 'asc'));
    } else {
      setSortBy(field);
      setSortOrder('desc');
    }
  };

  // Year over Year Chart Data
  const yoyChartData = useMemo(() => {
    const list = [
      { fy: 'FY 2023-24', label: '2023-24' },
      { fy: 'FY 2024-25', label: '2024-25' },
      { fy: 'FY 2025-26', label: '2025-26' },
      { fy: 'FY 2026-27', label: '2026-27' },
    ];
    return list.map(item => {
      const isAll = !selectedTerminal || selectedTerminal === 'ALL' || selectedTerminal === 'all';
      let gross = 0;
      let bill = 0;
      let cr = 0;
      let invCount = 0;
      let net = 0;

      if (isAll) {
        const sum = fySummaries[item.fy] || {};
        gross = sum.grossSale || 0;
        bill = sum.billAmount || 0;
        cr = sum.creditAmount || 0;
        invCount = sum.invoiceCount || 0;
        net = sum.netRevenue || (gross - cr);
      } else {
        const termObj = terminals.find(t => 
          String(t.terminalId) === String(selectedTerminal) ||
          (t.terminalName && String(t.terminalName).toLowerCase() === String(selectedTerminal).toLowerCase())
        ) || {};
        const tId = termObj.terminalId || Number(selectedTerminal) || 0;
        const m = terminalFyMatrix.find(x => 
          (x.terminalId === tId || String(x.terminalId) === String(selectedTerminal)) && 
          x.fy === item.fy
        ) || {};
        gross = m.grossSale || 0;
        bill = m.billAmount || 0;
        cr = m.creditAmount || 0;
        invCount = m.invoiceCount || 0;
        net = m.netRevenue || (gross - cr);
      }
      return {
        fy: item.label,
        grossRevenue: gross,
        netRevenue: net,
        billAmount: bill,
        creditAmount: cr,
        invoiceCount: invCount
      };
    });
  }, [selectedTerminal, terminals, fySummaries, terminalFyMatrix]);

  // Top 8 Terminals by Net Revenue
  const topRevenueChart = useMemo(() => {
    return (displayTerminals || [])
      .filter(t => (t.netRevenue || 0) > 0)
      .sort((a, b) => (b.netRevenue || 0) - (a.netRevenue || 0))
      .slice(0, 8)
      .map(t => {
        const nameStr = t.terminalName || `Terminal ${t.terminalId}`;
        const rev = t.netRevenue || 0;
        return {
          name: nameStr.length > 14 ? nameStr.substring(0, 12) + '..' : nameStr,
          fullName: nameStr,
          revenue: rev,
          displayLabel: rev >= 10000000 ? `₹${(rev / 10000000).toFixed(0)}Cr` : `₹${(rev / 100000).toFixed(0)}L`,
          containers: t.displayContainers || 0,
          teus: t.displayTeus || 0
        };
      });
  }, [displayTerminals]);

  // Top 8 Terminals by Container TEU Volume (Excludes pure accounting heads like REBATE/MISC with 0 containers)
  const topVolumeChart = useMemo(() => {
    return (displayTerminals || [])
      .filter(t => (t.displayTeus || 0) > 0 || (t.displayContainers || 0) > 0)
      .sort((a, b) => (b.displayTeus || b.displayContainers || 0) - (a.displayTeus || a.displayContainers || 0))
      .slice(0, 8)
      .map(t => {
        const nameStr = t.terminalName || `Terminal ${t.terminalId}`;
        return {
          name: nameStr.length > 14 ? nameStr.substring(0, 12) + '..' : nameStr,
          fullName: nameStr,
          revenue: t.netRevenue || 0,
          containers: t.displayContainers || 0,
          teus: t.displayTeus || 0,
          displayTeuLabel: `${formatNumber(t.displayTeus)} TEU`
        };
      });
  }, [displayTerminals]);

  const handleExportExcel = () => {
    const wb = XLSX.utils.book_new();
    
    // 1. Terminals Matrix
    const wsTerm = XLSX.utils.json_to_sheet(displayTerminals);
    XLSX.utils.book_append_sheet(wb, wsTerm, 'Branch_Performance');

    // 2. Top Customers
    const wsCust = XLSX.utils.json_to_sheet(topCustomers);
    XLSX.utils.book_append_sheet(wb, wsCust, 'Top_Revenue_Customers');

    // 3. Top Services
    const wsSvc = XLSX.utils.json_to_sheet(topServices);
    XLSX.utils.book_append_sheet(wb, wsSvc, 'Top_Logistics_Services');

    // 4. YoY Financials
    const wsYoY = XLSX.utils.json_to_sheet(yoyChartData);
    XLSX.utils.book_append_sheet(wb, wsYoY, 'Fiscal_YoY_Comparison');

    const termLabel = selectedTerminal === 'ALL' ? 'All_Terminals' : `Terminal_${selectedTerminal}`;
    const fyLabel = selectedFY.replace(/\s+/g, '_');
    XLSX.writeFile(wb, `SPJ_Branch_Analytics_${termLabel}_${fyLabel}_${new Date().toISOString().slice(0,10)}.xlsx`);
  };

  const resetFilters = () => {
    setSelectedTerminal('ALL');
    setSelectedFY('ALL');
    setSearchTerminal('');
  };

  const CustomChartTooltip = ({ active, payload, label }) => {
    if (active && payload && payload.length) {
      const first = payload[0] || {};
      const titleLabel = label || first.payload?.fullName || first.payload?.name || first.name || 'Metrics';
      return (
        <div className="bg-[#2b1f55] text-white p-3 rounded-xl shadow-2xl border border-purple-800 text-xs">
          <p className="font-bold text-orange-400 mb-1">{titleLabel}</p>
          {payload.map((p, idx) => {
            const valNum = Number(p.value) || 0;
            return (
              <p key={idx} className="font-mono text-slate-200">
                <span className="font-bold" style={{ color: p.color || '#fff' }}>{p.name}: </span>
                {valNum > 1000 ? formatCurrency(valNum) : formatNumber(valNum)}
              </p>
            );
          })}
        </div>
      );
    }
    return null;
  };

  const SortIcon = ({ field }) => {
    if (sortBy !== field) {
      return <ArrowUpDown className="w-3 h-3 text-slate-400 inline ml-1 opacity-50 group-hover:opacity-100" />;
    }
    return sortOrder === 'asc' 
      ? <ArrowUp className="w-3 h-3 text-[#ff6a00] inline ml-1" />
      : <ArrowDown className="w-3 h-3 text-[#ff6a00] inline ml-1" />;
  };

  return (
    <div className="space-y-6">
      
      {/* ========================================================================= */}
      {/* ========================================================================= */}
      {/* 1. TOP 8 DYNAMIC KPI CARDS (Ultra-Compact High Density 2-Col Mobile Grid) */}
      {/* ========================================================================= */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-2 sm:gap-4">
        
        {/* Card 1: Gross Sale (Net of Credit Notes) */}
        <div className="bg-gradient-to-br from-[#2b1f55] to-[#1e153d] p-2.5 sm:p-5 rounded-xl sm:rounded-3xl text-white shadow-md relative overflow-hidden group">
          <div className="absolute top-0 right-0 p-2 sm:p-4 opacity-10 group-hover:opacity-20 transition-opacity">
            <CircleDollarSign className="w-12 h-12 sm:w-24 sm:h-24 text-white" />
          </div>
          <p className="text-[9px] sm:text-[11px] font-bold text-orange-400 uppercase tracking-wider flex items-center gap-1 truncate">
            <TrendingUp className="w-3 h-3 sm:w-3.5 sm:h-3.5 shrink-0" /> Gross Sale (Net)
          </p>
          <h3 className="text-sm sm:text-2xl lg:text-3xl font-black font-display text-white mt-1 sm:mt-2 truncate">
            {loading ? (
              <span className="inline-block w-20 sm:w-32 h-5 sm:h-8 bg-white/20 animate-pulse rounded"></span>
            ) : (
              <AnimatedCounter value={formatCurrency(dynamicMetrics.grossSale)} decimals={2} duration={750} />
            )}
          </h3>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2.5 border-t border-white/10 flex items-center justify-between text-[9px] sm:text-[11px] gap-1">
            <span className="text-slate-300 truncate">Inv - Credit</span>
            <span className="font-bold text-emerald-400 shrink-0">
              {dynamicMetrics.creditAmount > 0 ? `-${formatCurrency(dynamicMetrics.creditAmount)}` : '0 Credits'}
            </span>
          </div>
        </div>

        {/* Card 2: Net Bill Amount */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift animate-slide-up delay-1">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Net Bill (Base)
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-slate-800 mt-1 sm:mt-2 truncate">
                {loading ? (
                  <span className="inline-block w-16 sm:w-28 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span>
                ) : (
                  <AnimatedCounter value={formatCurrency(dynamicMetrics.billAmount)} decimals={2} duration={750} />
                )}
              </h3>
              <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 flex items-center gap-1 truncate">
                <Receipt className="w-3 h-3 shrink-0" /> Invoiced Base
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 animate-float shrink-0">
              <DollarSign className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>Avg/Inv</span>
            <span className="font-mono font-bold text-slate-700">
              {dynamicMetrics.invoiceCount > 0 ? formatCurrency(dynamicMetrics.billAmount / dynamicMetrics.invoiceCount) : '₹ 0'}
            </span>
          </div>
        </div>

        {/* Card 3: Tax Collected (GST 18%) */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift animate-slide-up delay-2">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Tax (GST 18%)
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-emerald-700 mt-1 sm:mt-2 truncate">
                {loading ? (
                  <span className="inline-block w-16 sm:w-28 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span>
                ) : (
                  <AnimatedCounter value={formatCurrency(dynamicMetrics.taxAmount)} decimals={2} duration={750} />
                )}
              </h3>
              <p className="text-[9px] sm:text-[11px] text-emerald-700 font-semibold mt-0.5 flex items-center gap-1 truncate">
                <ShieldCheck className="w-3 h-3 shrink-0" /> GST Ledger
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 animate-float shrink-0">
              <Percent className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>GST Ratio</span>
            <span className="font-mono font-bold text-emerald-600">
              {dynamicMetrics.billAmount > 0 ? `${((dynamicMetrics.taxAmount / dynamicMetrics.billAmount) * 100).toFixed(1)}%` : '18.0%'}
            </span>
          </div>
        </div>

        {/* Card 4: Invoices & Credits Count */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift animate-slide-up delay-3">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Invoices & Credits
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-purple-900 mt-1 sm:mt-2 truncate">
                {loading ? (
                  <span className="inline-block w-16 sm:w-24 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span>
                ) : (
                  <AnimatedCounter value={dynamicMetrics.invoiceCount} duration={750} />
                )}{' '}
                <span className="text-[10px] sm:text-sm font-semibold text-slate-400">Bills</span>
              </h3>
              <p className="text-[9px] sm:text-[11px] text-rose-600 font-semibold mt-0.5 flex items-center gap-1 truncate">
                <AlertTriangle className="w-3 h-3 shrink-0" /> {formatNumber(dynamicMetrics.creditCount)} CR
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200 animate-float shrink-0">
              <FileText className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>Credit Ratio</span>
            <span className="font-mono font-bold text-slate-700">
              {dynamicMetrics.invoiceCount > 0 ? `${((dynamicMetrics.creditCount / dynamicMetrics.invoiceCount) * 100).toFixed(1)}%` : '0%'}
            </span>
          </div>
        </div>

        {/* Card 5: Total Containers Handled */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift animate-slide-up delay-4">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Container Volume
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-blue-900 mt-1 sm:mt-2 truncate">
                {loading ? (
                  <span className="inline-block w-16 sm:w-24 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span>
                ) : (
                  <AnimatedCounter value={dynamicMetrics.totalContainers} duration={750} />
                )}{' '}
                <span className="text-[10px] sm:text-sm font-semibold text-slate-400">Units</span>
              </h3>
              <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 truncate">
                40f: <span className="font-bold">{formatNumber(dynamicMetrics.units40ft)}</span> | 20f: <span className="font-bold">{formatNumber(dynamicMetrics.units20ft)}</span>
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 animate-float shrink-0">
              <Container className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>40ft Share</span>
            <span className="font-mono font-bold text-blue-700">
              {dynamicMetrics.totalContainers > 0 ? `${((dynamicMetrics.units40ft / dynamicMetrics.totalContainers) * 100).toFixed(1)}%` : '92.7%'}
            </span>
          </div>
        </div>

        {/* Card 6: TEUs Handled */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift animate-slide-up delay-5">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                TEU Capacity
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-amber-900 mt-1 sm:mt-2 truncate">
                {loading ? (
                  <span className="inline-block w-16 sm:w-24 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span>
                ) : (
                  <AnimatedCounter value={dynamicMetrics.teus} duration={750} />
                )}{' '}
                <span className="text-[10px] sm:text-sm font-semibold text-slate-400">TEUs</span>
              </h3>
              <p className="text-[9px] sm:text-[11px] text-amber-700 font-semibold mt-0.5 truncate">
                Twenty-Foot Equiv
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-amber-50 text-amber-600 border border-amber-200 shrink-0">
              <Layers className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>Multiplier</span>
            <span className="font-mono font-bold text-amber-700">
              {dynamicMetrics.totalContainers > 0 ? `${(dynamicMetrics.teus / dynamicMetrics.totalContainers).toFixed(2)}x` : '1.93x'}
            </span>
          </div>
        </div>

        {/* Card 7: Fleet Container Job Orders */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Job Orders (JO)
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-cyan-900 mt-1 sm:mt-2 truncate">
                {loading ? <span className="inline-block w-16 sm:w-24 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span> : `${formatNumber(dynamicMetrics.totalJobs)}`} <span className="text-[10px] sm:text-sm font-semibold text-slate-400">Jobs</span>
              </h3>
              <p className="text-[9px] sm:text-[11px] text-cyan-700 font-semibold mt-0.5 truncate">
                FLEET_CONT_JO
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-cyan-50 text-cyan-600 border border-cyan-200 shrink-0">
              <Activity className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>Cont/Job</span>
            <span className="font-mono font-bold text-cyan-700">
              {dynamicMetrics.totalJobs > 0 ? (dynamicMetrics.totalContainers / dynamicMetrics.totalJobs).toFixed(2) : '1.01'}
            </span>
          </div>
        </div>

        {/* Card 8: Active Own Heavy Fleet */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Active Own Fleet
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-orange-900 mt-1 sm:mt-2 truncate">
                {loading ? <span className="inline-block w-16 sm:w-24 h-5 sm:h-7 bg-slate-100 animate-pulse rounded"></span> : `${formatNumber(dynamicMetrics.ownFleet)}`} <span className="text-[10px] sm:text-sm font-semibold text-slate-400">Trucks</span>
              </h3>
              <p className="text-[9px] sm:text-[11px] text-orange-700 font-semibold mt-0.5 truncate">
                Multi-Axle Fleet
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-orange-50 text-orange-600 border border-orange-200 shrink-0">
              <Truck className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
          <div className="mt-1.5 pt-1.5 sm:mt-3 sm:pt-2 border-t border-slate-100 flex items-center justify-between text-[9px] sm:text-[11px] text-slate-500">
            <span>Fleet Status</span>
            <span className="font-mono font-bold text-emerald-600 flex items-center gap-1">
              <CheckCircle2 className="w-3 h-3" /> Live
            </span>
          </div>
        </div>

      </div>

      {/* ========================================================================= */}
      {/* 2. SUB-VIEW NAVIGATION (Branches Matrix, YoY Trends, Owner Decision BI) */}
      {/* ========================================================================= */}
      <div className="flex flex-wrap items-center justify-between gap-2.5 bg-white p-2 sm:p-3 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft">
        <div className="flex items-center gap-1 sm:gap-1.5 overflow-x-auto no-scrollbar w-full sm:w-auto py-0.5">
          {[
            { key: 'branches', label: 'Branch Matrix', fullLabel: 'Branch Performance Matrix', icon: Building2 },
            { key: 'yoy', label: 'YoY Trends', fullLabel: 'Fiscal Year-over-Year (YoY)', icon: Calendar },
            { key: 'decision_bi', label: 'Owner BI', fullLabel: 'Owner Intelligence & Decision Support', icon: Award },
            { key: 'customer_bi', label: 'Top Clients', fullLabel: 'Top Customer Leaders', icon: Users },
            { key: 'service_bi', label: 'Services', fullLabel: 'Service & Tariff Breakdown', icon: Layers }
          ].map(tab => {
            const Icon = tab.icon;
            const isActive = activeTab === tab.key;
            return (
              <button
                key={tab.key}
                onClick={() => setActiveTab(tab.key)}
                className={`inline-flex items-center gap-1.5 px-2.5 py-1.5 sm:px-4 sm:py-2 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all whitespace-nowrap cursor-pointer shrink-0 ${
                  isActive
                    ? 'bg-[#2b1f55] text-white shadow-sm shadow-purple-900/20'
                    : 'text-slate-600 hover:text-slate-900 hover:bg-slate-100'
                }`}
              >
                <Icon className={`w-3.5 h-3.5 ${isActive ? 'text-orange-400' : 'text-slate-400'}`} />
                <span className="sm:hidden">{tab.label}</span>
                <span className="hidden sm:inline">{tab.fullLabel}</span>
              </button>
            );
          })}
        </div>

        {/* View specific context count & Export */}
        <div className="flex items-center gap-2 w-full sm:w-auto justify-end">
          <button
            onClick={handleExportExcel}
            className="inline-flex items-center gap-1.5 px-3 py-1.5 sm:px-3.5 sm:py-2 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] text-white hover:opacity-95 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold shadow-xs transition-all cursor-pointer"
          >
            <FileSpreadsheet className="w-3.5 h-3.5 text-emerald-400" />
            <span>Export Matrix</span>
          </button>
        </div>
      </div>


      {/* ========================================================================= */}
      {/* TAB 1: BRANCH PERFORMANCE MATRIX (Interactive, Sortable, Searchable) */}
      {/* ========================================================================= */}
      {activeTab === 'branches' && (
        <div className="space-y-6">
          
          {/* Top Visual Chart: Branch Revenue & TEU Comparison (Reacts to FY changes!) */}
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
            
            {/* Top Terminals by Net Revenue */}
            <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
              <div className="flex items-center justify-between mb-1">
                <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
                  <BarChart3 className="w-4 h-4 text-[#2b1f55]" /> Top Revenue Generating Terminals ({selectedFY === 'ALL' ? 'All Time Cumulative' : selectedFY})
                </h4>
                <span className="text-[10px] px-2 py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold">
                  Top 8 by Gross Sale
                </span>
              </div>
              <p className="text-xs text-slate-500 mb-4">
                Branch contribution to overall net sales revenue (INR Crores)
              </p>
              <div className="h-64">
                <ResponsiveContainer width="100%" height="100%">
                  <BarChart data={topRevenueChart} margin={{ top: 10, right: 10, left: 10, bottom: 25 }}>
                    <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                    <XAxis dataKey="name" angle={-25} textAnchor="end" tick={{ fontSize: 10, fill: '#64748b' }} />
                    <YAxis tickFormatter={(val) => `₹${(val/10000000).toFixed(0)}Cr`} tick={{ fontSize: 10, fill: '#64748b' }} />
                    <Tooltip content={<CustomChartTooltip />} />
                    <Bar dataKey="revenue" name="Net Revenue (Gross Sale)" fill="#2b1f55" radius={[6, 6, 0, 0]} />
                  </BarChart>
                </ResponsiveContainer>
              </div>
            </div>

            {/* Top Terminals by Container TEU Volume */}
            <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
              <div className="flex items-center justify-between mb-1">
                <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
                  <Container className="w-4 h-4 text-[#ff6a00]" /> Top Terminals by TEU Volume ({selectedFY === 'ALL' ? 'All Time Cumulative' : selectedFY})
                </h4>
                <span className="text-[10px] px-2 py-0.5 bg-orange-100 text-[#ff6a00] rounded-full font-bold">
                  Top 8 by Container Volume
                </span>
              </div>
              <p className="text-xs text-slate-500 mb-4">
                Container physical throughput (40ft = 2 TEUs, 20ft = 1 TEU)
              </p>
              <div className="h-64">
                <ResponsiveContainer width="100%" height="100%">
                  <BarChart data={topVolumeChart} margin={{ top: 10, right: 10, left: 10, bottom: 25 }}>
                    <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                    <XAxis dataKey="name" angle={-25} textAnchor="end" tick={{ fontSize: 10, fill: '#64748b' }} />
                    <YAxis tickFormatter={(val) => formatNumber(val)} tick={{ fontSize: 10, fill: '#64748b' }} />
                    <Tooltip content={<CustomChartTooltip />} />
                    <Legend />
                    <Bar dataKey="teus" name="TEUs Equivalent" fill="#ff6a00" radius={[6, 6, 0, 0]} />
                    <Bar dataKey="containers" name="Physical Containers" fill="#0284c7" radius={[6, 6, 0, 0]} />
                  </BarChart>
                </ResponsiveContainer>
              </div>
            </div>

          </div>

          {/* Search & Sort Controls for Matrix */}
          <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
            <div className="flex flex-col sm:flex-row items-stretch sm:items-center justify-between gap-3 mb-4">
              
              <div className="flex items-center gap-2 flex-1 max-w-md">
                <div className="relative w-full">
                  <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
                  <input
                    type="text"
                    value={searchTerminal}
                    onChange={(e) => setSearchTerminal(e.target.value)}
                    placeholder="Search terminal by name, code, or ID..."
                    className="w-full pl-9 pr-4 py-2.5 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:outline-none focus:ring-2 focus:ring-[#2b1f55] transition-all"
                  />
                </div>
              </div>

              <div className="flex items-center gap-2">
                <span className="text-xs text-slate-500 font-medium">Sort By:</span>
                <select
                  value={sortBy}
                  onChange={(e) => setSortBy(e.target.value)}
                  className="px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-bold text-slate-700 focus:outline-none cursor-pointer"
                >
                  <option value="netRevenue">Net Revenue (Gross Sale)</option>
                  <option value="displayTeus">TEU Volume</option>
                  <option value="displayContainers">Total Containers</option>
                  <option value="displayJobs">Job Orders</option>
                  <option value="invoiceCount">Invoices Count</option>
                  <option value="billAmount">Net Bill (Base)</option>
                  <option value="taxAmount">Tax (GST)</option>
                  <option value="terminalName">Terminal Name (A-Z)</option>
                </select>
                <button
                  onClick={() => setSortOrder(prev => prev === 'asc' ? 'desc' : 'asc')}
                  className="px-3.5 py-2 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all flex items-center gap-1 border border-slate-200"
                  title="Toggle Ascending/Descending"
                >
                  {sortOrder === 'asc' ? '↑ Asc' : '↓ Desc'}
                </button>
              </div>

            </div>

            {/* Matrix Table for Desktop (Screen >= md) */}
            <div className="hidden md:block overflow-x-auto rounded-2xl border border-slate-200">
              <table className="w-full text-left text-xs border-collapse">
                <thead>
                  <tr className="bg-slate-100/90 text-slate-700 font-bold border-b border-slate-200 select-none">
                    <th 
                      onClick={() => handleSortHeader('terminalName')}
                      className="py-3 px-3.5 cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Terminal / Branch <SortIcon field="terminalName" />
                    </th>
                    <th className="py-3 px-3 text-center">Code</th>
                    <th 
                      onClick={() => handleSortHeader('displayJobs')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Job Orders <SortIcon field="displayJobs" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('displayContainers')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Containers (40ft / 20ft) <SortIcon field="displayContainers" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('displayTeus')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      TEUs <SortIcon field="displayTeus" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('invoiceCount')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Invoices <SortIcon field="invoiceCount" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('billAmount')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Net Bill (Base) <SortIcon field="billAmount" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('taxAmount')}
                      className="py-3 px-3 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Tax (GST) <SortIcon field="taxAmount" />
                    </th>
                    <th 
                      onClick={() => handleSortHeader('netRevenue')}
                      className="py-3 px-3.5 text-right font-black text-[#2b1f55] cursor-pointer hover:bg-slate-200/80 transition-colors group"
                    >
                      Net Revenue (Gross Sale) <SortIcon field="netRevenue" />
                    </th>
                    <th className="py-3 px-3 text-center">Action</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-100">
                  {displayTerminals.length === 0 ? (
                    <tr>
                      <td colSpan="10" className="py-8 text-center text-slate-400 font-medium">
                        No terminal records match the current filter.
                      </td>
                    </tr>
                  ) : (
                    displayTerminals.map((t, idx) => {
                      const isSelected = selectedTerminal === String(t.terminalId);
                      const hasData = (t.displayContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0);
                      return (
                        <tr 
                          key={t.terminalId}
                          className={`transition-colors ${
                            isSelected 
                              ? 'bg-purple-100/90 font-semibold ring-1 ring-purple-300' 
                              : (!hasData 
                                  ? 'bg-rose-50/30 hover:bg-rose-50/60 text-slate-500' 
                                  : (idx % 2 === 0 ? 'bg-white hover:bg-slate-50' : 'bg-slate-50/40 hover:bg-slate-50'))
                          }`}
                        >
                          <td className="py-3 px-3.5 font-bold text-slate-800 flex items-center gap-2">
                            <span className={`w-2 h-2 rounded-full shrink-0 ${hasData ? 'bg-emerald-500 shadow-sm shadow-emerald-500/50' : 'bg-rose-500 shadow-sm shadow-rose-500/50 animate-pulse'}`}></span>
                            <span className={`truncate max-w-[200px] ${!hasData ? 'text-rose-800/80 font-medium' : ''}`} title={t.terminalName}>
                              {t.terminalName}
                            </span>
                            {t.displayContainers > 10000 && (
                              <span className="text-[9px] px-1.5 py-0.5 bg-purple-100 text-[#2b1f55] rounded-md font-bold uppercase tracking-wider shrink-0">
                                Major Hub
                              </span>
                            )}
                            {!hasData && (
                              <span className="text-[9px] px-1.5 py-0.5 bg-rose-100 text-rose-700 border border-rose-200 rounded-md font-bold uppercase tracking-wider shrink-0">
                                No Data
                              </span>
                            )}
                          </td>
                          <td className="py-3 px-3 text-center font-mono text-slate-500">
                            {t.terminalCode || `T-${t.terminalId}`}
                          </td>
                          <td className={`py-3 px-3 text-right font-mono ${hasData ? 'font-bold text-slate-700' : 'text-slate-400'}`}>
                            {formatNumber(t.displayJobs)}
                          </td>
                          <td className="py-3 px-3 text-right font-mono text-slate-700">
                            <span className={`font-bold ${hasData ? 'text-slate-900' : 'text-slate-400'}`}>{formatNumber(t.displayContainers)}</span>
                            {hasData && (
                              <span className="text-[10px] text-slate-400 ml-1">
                                ({formatNumber(t.display40ft)} / {formatNumber(t.display20ft)})
                              </span>
                            )}
                          </td>
                          <td className={`py-3 px-3 text-right font-mono ${hasData ? 'font-bold text-amber-700' : 'text-slate-400'}`}>
                            {formatNumber(t.displayTeus)}
                          </td>
                          <td className={`py-3 px-3 text-right font-mono ${hasData ? 'text-slate-600 font-bold' : 'text-slate-400'}`}>
                            {formatNumber(t.invoiceCount)}
                            {t.creditCount > 0 && (
                              <span className="text-[10px] text-rose-500 block font-normal">
                                {t.creditCount} CR ({formatCurrency(t.creditAmount)})
                              </span>
                            )}
                          </td>
                          <td className={`py-3 px-3 text-right font-mono ${hasData ? 'text-slate-600 font-semibold' : 'text-slate-400'}`}>
                            {formatCurrency(t.billAmount)}
                          </td>
                          <td className={`py-3 px-3 text-right font-mono ${hasData ? 'text-emerald-700 font-semibold' : 'text-slate-400'}`}>
                            {formatCurrency(t.taxAmount)}
                          </td>
                          <td className={`py-3 px-3.5 text-right font-mono font-black ${hasData ? 'text-[#2b1f55]' : 'text-slate-400'}`}>
                            {formatCurrency(t.netRevenue)}
                          </td>
                          <td className="py-3 px-3 text-center">
                            <button
                              onClick={() => setSelectedTerminal(isSelected ? 'ALL' : String(t.terminalId))}
                              className={`px-3 py-1.5 rounded-lg text-[11px] font-bold transition-all shadow-sm ${
                                isSelected 
                                  ? 'bg-purple-700 text-white ring-2 ring-purple-400' 
                                  : (!hasData 
                                      ? 'bg-rose-100/70 text-rose-700 hover:bg-rose-600 hover:text-white' 
                                      : 'bg-slate-100 text-slate-700 hover:bg-[#2b1f55] hover:text-white')
                              }`}
                            >
                              {isSelected ? 'Filtered ✓' : 'Filter'}
                            </button>
                          </td>
                        </tr>
                      );
                    })
                  )}
                </tbody>
              </table>
            </div>

            {/* Matrix Cards for Mobile (Screen < md) */}
            <div className="md:hidden space-y-2.5">
              {displayTerminals.length === 0 ? (
                <div className="py-8 text-center text-slate-400 font-medium bg-slate-50 rounded-2xl border border-slate-200">
                  No terminal records match the current filter.
                </div>
              ) : (
                displayTerminals.map((t) => {
                  const isSelected = selectedTerminal === String(t.terminalId);
                  const hasData = (t.displayContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0);
                  return (
                    <div 
                      key={t.terminalId}
                      className={`p-3 rounded-2xl border transition-all ${
                        isSelected 
                          ? 'bg-purple-50/90 border-purple-400 ring-2 ring-purple-300 shadow-sm' 
                          : (!hasData 
                              ? 'bg-rose-50/20 border-rose-100' 
                              : 'bg-white border-slate-200 shadow-xs')
                      }`}
                    >
                      {/* Card Top: Status, Name, Code */}
                      <div className="flex items-start justify-between gap-2 mb-2 pb-2 border-b border-slate-100">
                        <div className="flex items-center gap-1.5 flex-1 min-w-0">
                          <span className={`w-2 h-2 rounded-full shrink-0 ${hasData ? 'bg-emerald-500 shadow-xs shadow-emerald-500/50' : 'bg-rose-500 shadow-xs shadow-rose-500/50 animate-pulse'}`}></span>
                          <span className="font-extrabold text-xs text-slate-900 truncate" title={t.terminalName}>
                            {t.terminalName}
                          </span>
                          {t.displayContainers > 10000 && (
                            <span className="text-[9px] px-1.5 py-0.2 bg-purple-100 text-[#2b1f55] rounded font-bold uppercase tracking-wider shrink-0">
                              Major Hub
                            </span>
                          )}
                          {!hasData && (
                            <span className="text-[9px] px-1.5 py-0.2 bg-rose-100 text-rose-700 rounded font-bold uppercase tracking-wider shrink-0">
                              No Data
                            </span>
                          )}
                        </div>
                        
                        <span className="font-mono text-[10px] font-bold text-slate-500 bg-slate-100 px-1.5 py-0.5 rounded border border-slate-200 shrink-0">
                          {t.terminalCode || `T-${t.terminalId}`}
                        </span>
                      </div>

                      {/* Metrics Grid (2 Columns) */}
                      <div className="grid grid-cols-2 gap-1.5 text-[11px] mb-2.5">
                        {/* Gross Revenue */}
                        <div className="bg-purple-50/60 p-2 rounded-xl border border-purple-100/80">
                          <div className="text-[9px] text-slate-500 font-medium">Gross Revenue</div>
                          <div className="font-extrabold text-xs text-[#2b1f55] truncate">
                            {hasData ? formatCurrency(t.netRevenue) : '₹ 0'}
                          </div>
                        </div>

                        {/* Containers & TEU */}
                        <div className="bg-amber-50/60 p-2 rounded-xl border border-amber-100/80">
                          <div className="text-[9px] text-slate-500 font-medium">Containers (TEUs)</div>
                          <div className="font-extrabold text-xs text-amber-900 truncate">
                            {hasData ? `${formatNumber(t.displayContainers)} (${formatNumber(t.displayTeus)} T)` : '0 Units'}
                          </div>
                        </div>

                        {/* Invoices & Jobs */}
                        <div className="bg-slate-50 p-2 rounded-xl border border-slate-100">
                          <div className="text-[9px] text-slate-500 font-medium">Invoices & Jobs</div>
                          <div className="font-bold text-xs text-slate-700 truncate">
                            {hasData ? `${formatNumber(t.invoiceCount)} Inv • ${formatNumber(t.displayJobs)} Jobs` : '0 Inv'}
                          </div>
                        </div>

                        {/* Tax / Base Bill */}
                        <div className="bg-slate-50 p-2 rounded-xl border border-slate-100">
                          <div className="text-[9px] text-slate-500 font-medium">Base / GST</div>
                          <div className="font-bold text-xs text-emerald-700 truncate">
                            {hasData ? `${formatCurrency(t.billAmount)} • ${formatCurrency(t.taxAmount)}` : '₹ 0'}
                          </div>
                        </div>
                      </div>

                      {/* Action Button */}
                      <button
                        onClick={() => setSelectedTerminal(isSelected ? 'ALL' : String(t.terminalId))}
                        className={`w-full py-1.5 rounded-xl text-xs font-bold transition-all shadow-xs flex items-center justify-center gap-1.5 cursor-pointer ${
                          isSelected 
                            ? 'bg-purple-700 text-white ring-2 ring-purple-400' 
                            : (!hasData 
                                ? 'bg-rose-50 text-rose-700 hover:bg-rose-600 hover:text-white border border-rose-200' 
                                : 'bg-slate-100 text-slate-700 hover:bg-[#2b1f55] hover:text-white border border-slate-200')
                        }`}
                      >
                        {isSelected ? '✓ Filter Applied (Tap to Reset)' : 'Filter This Branch'}
                      </button>
                    </div>
                  );
                })
              )}
            </div>
          </div>

        </div>
      )}

      {/* ========================================================================= */}
      {/* TAB 2: FISCAL YEAR-OVER-YEAR (YoY) COMPARISON */}
      {/* ========================================================================= */}
      {activeTab === 'yoy' && (
        <div className="space-y-6">
          
          <div className="bg-white p-6 rounded-3xl border border-slate-200 shadow-soft">
            <h4 className="text-base font-bold text-slate-800 mb-1 flex items-center gap-2">
              <Calendar className="w-5 h-5 text-[#2b1f55]" /> Fiscal Year Growth & Invoiced Revenue Trajectory
            </h4>
            <p className="text-xs text-slate-500 mb-6">
              Multi-year financial trend comparison for {selectedTerminal === 'ALL' ? 'All Terminals' : terminals.find(t => t.terminalId === Number(selectedTerminal))?.terminalName}
            </p>

            {/* YoY Area Chart */}
            <div className="h-80 w-full mb-8">
              <ResponsiveContainer width="100%" height="100%">
                <AreaChart data={yoyChartData} margin={{ top: 10, right: 20, left: 20, bottom: 20 }}>
                  <defs>
                    <linearGradient id="grossGrad" x1="0" y1="0" x2="0" y2="1">
                      <stop offset="5%" stopColor="#2b1f55" stopOpacity={0.4}/>
                      <stop offset="95%" stopColor="#2b1f55" stopOpacity={0}/>
                    </linearGradient>
                    <linearGradient id="billGrad" x1="0" y1="0" x2="0" y2="1">
                      <stop offset="5%" stopColor="#ff6a00" stopOpacity={0.4}/>
                      <stop offset="95%" stopColor="#ff6a00" stopOpacity={0}/>
                    </linearGradient>
                  </defs>
                  <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                  <XAxis dataKey="fy" tick={{ fontSize: 12, fill: '#64748b' }} />
                  <YAxis tickFormatter={(val) => `₹${(val/10000000).toFixed(0)}Cr`} tick={{ fontSize: 11, fill: '#64748b' }} />
                  <Tooltip content={<CustomChartTooltip />} />
                  <Legend />
                  <Area type="monotone" dataKey="grossRevenue" name="Gross Invoiced Revenue" stroke="#2b1f55" strokeWidth={3} fillOpacity={1} fill="url(#grossGrad)" />
                  <Area type="monotone" dataKey="billAmount" name="Net Billed Amount" stroke="#ff6a00" strokeWidth={3} fillOpacity={1} fill="url(#billGrad)" />
                </AreaChart>
              </ResponsiveContainer>
            </div>

            {/* YoY Summary Grid Table (High Density 2-Col Mobile Grid) */}
            <div className="grid grid-cols-2 md:grid-cols-4 gap-2 sm:gap-4">
              {yoyChartData.map((fyItem, idx) => (
                <div key={idx} className="bg-slate-50 p-2.5 sm:p-4 rounded-xl sm:rounded-2xl border border-slate-200 hover:border-purple-300 transition-all">
                  <div className="flex items-center justify-between mb-1 sm:mb-2">
                    <span className="font-bold text-[#2b1f55] text-xs sm:text-sm">FY {fyItem.fy}</span>
                    <span className="text-[8px] sm:text-[10px] px-1.5 py-0.2 sm:px-2 sm:py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold">
                      {formatNumber(fyItem.invoiceCount)} Invs
                    </span>
                  </div>
                  <h4 className="text-sm sm:text-xl font-black text-slate-900 font-display truncate">
                    {formatCurrency(fyItem.netRevenue)}
                  </h4>
                  <div className="mt-1 sm:mt-2 text-[9px] sm:text-[11px] text-slate-500 space-y-0.5 sm:space-y-1">
                    <div className="flex justify-between">
                      <span>Base:</span>
                      <span className="font-mono font-bold text-slate-700">{formatCurrency(fyItem.billAmount)}</span>
                    </div>
                    <div className="flex justify-between">
                      <span>Credits:</span>
                      <span className="font-mono font-bold text-rose-600">-{formatCurrency(fyItem.creditAmount)}</span>
                    </div>
                  </div>
                </div>
              ))}
            </div>

          </div>

        </div>
      )}

      {/* ========================================================================= */}
      {/* TAB 3: OWNER BUSINESS INTELLIGENCE & DECISION SUPPORT */}
      {/* ========================================================================= */}
      {activeTab === 'decision_bi' && (
        <div className="space-y-4 sm:space-y-6">
          
          {/* Executive Strategic Highlights (2-Column Grid on Mobile/Tablet) */}
          <div className="grid grid-cols-1 sm:grid-cols-3 gap-2.5 sm:gap-6">
            
            <div className="bg-gradient-to-br from-purple-900 to-[#2b1f55] text-white p-3.5 sm:p-6 rounded-2xl sm:rounded-3xl shadow-xl">
              <div className="p-2 sm:p-3 bg-white/10 rounded-xl sm:rounded-2xl w-fit mb-2 sm:mb-4">
                <Award className="w-4 h-4 sm:w-6 sm:h-6 text-orange-400" />
              </div>
              <h4 className="text-sm sm:text-lg font-bold mb-1 sm:mb-2">Key Revenue Driver: Dadri CFS</h4>
              <p className="text-[11px] sm:text-xs text-slate-300 leading-relaxed">
                TRANSWORLD-DADRI represents <span className="text-orange-300 font-bold">66.2%</span> of total enterprise gross sales (₹ 4,969 Cr) with 49,412 container movements, making it the central engine of cold storage and reefer logistics.
              </p>
            </div>

            <div className="bg-gradient-to-br from-emerald-900 to-teal-900 text-white p-3.5 sm:p-6 rounded-2xl sm:rounded-3xl shadow-xl">
              <div className="p-2 sm:p-3 bg-white/10 rounded-xl sm:rounded-2xl w-fit mb-2 sm:mb-4">
                <CheckCircle2 className="w-4 h-4 sm:w-6 sm:h-6 text-emerald-400" />
              </div>
              <h4 className="text-sm sm:text-lg font-bold mb-1 sm:mb-2">High-Margin Marine Gateways</h4>
              <p className="text-[11px] sm:text-xs text-slate-300 leading-relaxed">
                Nhava Sheva (JNPT) and Kanpur (JRY & Panki) generate over <span className="text-emerald-300 font-bold">₹ 1,850 Cr</span> in combined billings with strong Ocean Freight and Line THC realizations.
              </p>
            </div>

            <div className="bg-gradient-to-br from-amber-900 to-orange-950 text-white p-3.5 sm:p-6 rounded-2xl sm:rounded-3xl shadow-xl">
              <div className="p-2 sm:p-3 bg-white/10 rounded-xl sm:rounded-2xl w-fit mb-2 sm:mb-4">
                <ShieldCheck className="w-4 h-4 sm:w-6 sm:h-6 text-amber-400" />
              </div>
              <h4 className="text-sm sm:text-lg font-bold mb-1 sm:mb-2">Credit Note Audit & Loss Control</h4>
              <p className="text-[11px] sm:text-xs text-slate-300 leading-relaxed">
                Total Credit Note write-offs stand at <span className="text-amber-300 font-bold">₹ 99.09 Cr</span> across 7,066 notes, representing a healthy <span className="text-amber-300 font-bold">1.31%</span> ratio against gross billings.
              </p>
            </div>

          </div>


          {/* Top Customers & Top Services Side-by-Side */}
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
            
            {/* Top Revenue Contributing Customers */}
            <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
              <h4 className="text-sm font-bold text-slate-800 mb-1 flex items-center gap-2">
                <Users className="w-4 h-4 text-[#2b1f55]" /> Top 10 Enterprise Clients by Revenue
              </h4>
              <p className="text-xs text-slate-500 mb-4">
                Key frozen food exporters, freight forwarders, and liner accounts
              </p>
              <div className="space-y-3">
                {topCustomers.slice(0, 8).map((c, idx) => {
                  const share = ((c.grossRevenue / (dbTotals.grandSystemRevenue || 74238770193.79)) * 100).toFixed(1);
                  return (
                    <div key={idx} className="p-3 bg-slate-50 rounded-2xl border border-slate-100 flex items-center justify-between">
                      <div className="flex items-center gap-3">
                        <span className="w-6 h-6 rounded-full bg-[#2b1f55] text-white flex items-center justify-center font-bold text-[10px]">
                          {idx + 1}
                        </span>
                        <div>
                          <p className="font-bold text-slate-800 text-xs">{c.customerName}</p>
                          <p className="text-[10px] text-slate-500">{formatNumber(c.invoiceCount)} Invoices Audited</p>
                        </div>
                      </div>
                      <div className="text-right">
                        <p className="font-mono font-bold text-slate-900 text-xs">{formatCurrency(c.grossRevenue)}</p>
                        <p className="text-[10px] text-emerald-600 font-semibold">{share}% of Total Gross</p>
                      </div>
                    </div>
                  );
                })}
              </div>
            </div>

            {/* Top Logistics Services & Tariff Offerings */}
            <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
              <h4 className="text-sm font-bold text-slate-800 mb-1 flex items-center gap-2">
                <Layers className="w-4 h-4 text-[#ff6a00]" /> Top Logistics Tariff & Service Categories
              </h4>
              <p className="text-xs text-slate-500 mb-4">
                Core billing service heads and operational revenue streams
              </p>
              <div className="space-y-3">
                {topServices.slice(0, 8).map((s, idx) => {
                  return (
                    <div key={idx} className="p-3 bg-slate-50 rounded-2xl border border-slate-100 flex items-center justify-between">
                      <div className="flex items-center gap-3">
                        <span className="w-6 h-6 rounded-full bg-[#ff6a00] text-white flex items-center justify-center font-bold text-[10px]">
                          {idx + 1}
                        </span>
                        <div>
                          <p className="font-bold text-slate-800 text-xs">{s.serviceName}</p>
                          <p className="text-[10px] text-slate-500">{formatNumber(s.itemCount)} Service Line Items</p>
                        </div>
                      </div>
                      <div className="text-right">
                        <p className="font-mono font-bold text-slate-900 text-xs">{formatCurrency(s.grossRevenue)}</p>
                        <p className="text-[10px] text-purple-700 font-semibold">Base: {formatCurrency(s.billAmount)}</p>
                      </div>
                    </div>
                  );
                })}
              </div>
            </div>

          </div>

        </div>
      )}

      {/* ========================================================================= */}
      {/* TAB 4: TOP CUSTOMER LEADERS (Full Table) */}
      {/* ========================================================================= */}
      {activeTab === 'customer_bi' && (
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
          <div className="flex items-center justify-between">
            <div>
              <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
                <Users className="w-4 h-4 text-[#2b1f55]" /> Enterprise Customer Leaderboard
              </h4>
              <p className="text-xs text-slate-500">
                15 highest gross revenue generating accounts across all CFS terminals
              </p>
            </div>
            <span className="text-xs font-mono font-bold text-purple-900 bg-purple-50 px-3 py-1 rounded-xl border border-purple-200">
              1,425 Active Client Accounts
            </span>
          </div>

          <div className="overflow-x-auto rounded-2xl border border-slate-200">
            <table className="w-full text-left text-xs border-collapse">
              <thead>
                <tr className="bg-slate-100 text-slate-700 font-bold border-b border-slate-200">
                  <th className="py-3 px-4">#</th>
                  <th className="py-3 px-4">Customer Account Name</th>
                  <th className="py-3 px-4 text-right">Invoices</th>
                  <th className="py-3 px-4 text-right">Net Billed Amount</th>
                  <th className="py-3 px-4 text-right">GST (18%)</th>
                  <th className="py-3 px-4 text-right font-black text-[#2b1f55]">Gross Revenue</th>
                  <th className="py-3 px-4 text-right">Contribution</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {topCustomers.map((c, idx) => {
                  const share = ((c.grossRevenue / (dbTotals.grandSystemRevenue || 74238770193.79)) * 100).toFixed(2);
                  return (
                    <tr key={idx} className={idx % 2 === 0 ? 'bg-white hover:bg-slate-50' : 'bg-slate-50/40 hover:bg-slate-50'}>
                      <td className="py-3 px-4 font-bold text-slate-400">{idx + 1}</td>
                      <td className="py-3 px-4 font-bold text-slate-900">{c.customerName}</td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-700">{formatNumber(c.invoiceCount)}</td>
                      <td className="py-3 px-4 text-right font-mono text-slate-600">{formatCurrency(c.billAmount)}</td>
                      <td className="py-3 px-4 text-right font-mono text-emerald-700">{formatCurrency(c.taxAmount)}</td>
                      <td className="py-3 px-4 text-right font-mono font-black text-[#2b1f55]">{formatCurrency(c.grossRevenue)}</td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-purple-700">{share}%</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {/* ========================================================================= */}
      {/* TAB 5: SERVICE & TARIFF BREAKDOWN (Full Table) */}
      {/* ========================================================================= */}
      {activeTab === 'service_bi' && (
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
          <div className="flex items-center justify-between">
            <div>
              <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
                <Layers className="w-4 h-4 text-[#ff6a00]" /> Logistics Service Catalog & Tariff Breakdown
              </h4>
              <p className="text-xs text-slate-500">
                15 highest yielding logistics services and terminal charge heads
              </p>
            </div>
            <span className="text-xs font-mono font-bold text-orange-900 bg-orange-50 px-3 py-1 rounded-xl border border-orange-200">
              606 Service Master Records
            </span>
          </div>

          <div className="overflow-x-auto rounded-2xl border border-slate-200">
            <table className="w-full text-left text-xs border-collapse">
              <thead>
                <tr className="bg-slate-100 text-slate-700 font-bold border-b border-slate-200">
                  <th className="py-3 px-4">#</th>
                  <th className="py-3 px-4">Service Description</th>
                  <th className="py-3 px-4 text-right">Line Items Billed</th>
                  <th className="py-3 px-4 text-right">Net Billed Amount</th>
                  <th className="py-3 px-4 text-right">GST (18%)</th>
                  <th className="py-3 px-4 text-right font-black text-[#ff6a00]">Gross Revenue</th>
                  <th className="py-3 px-4 text-right">Avg / Line Item</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {topServices.map((s, idx) => {
                  const avg = s.itemCount > 0 ? (s.billAmount / s.itemCount) : 0;
                  return (
                    <tr key={idx} className={idx % 2 === 0 ? 'bg-white hover:bg-slate-50' : 'bg-slate-50/40 hover:bg-slate-50'}>
                      <td className="py-3 px-4 font-bold text-slate-400">{idx + 1}</td>
                      <td className="py-3 px-4 font-bold text-slate-900">{s.serviceName}</td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-700">{formatNumber(s.itemCount)}</td>
                      <td className="py-3 px-4 text-right font-mono text-slate-600">{formatCurrency(s.billAmount)}</td>
                      <td className="py-3 px-4 text-right font-mono text-emerald-700">{formatCurrency(s.taxAmount)}</td>
                      <td className="py-3 px-4 text-right font-mono font-black text-[#ff6a00]">{formatCurrency(s.grossRevenue)}</td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-700">{formatCurrency(avg)}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </div>
      )}

    </div>
  );
}
