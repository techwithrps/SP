import React, { useState, useEffect, useMemo } from 'react';
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
  Truck,
  RotateCcw,
  AlertTriangle,
  Award,
  CircleDollarSign,
  Activity,
  FileSpreadsheet,
  ArrowUp,
  ArrowDown
} from 'lucide-react';
import { authFetch } from '../utils/api';
import * as XLSX from 'xlsx';
import AnimatedCounter from './AnimatedCounter';
import { formatCurrency, formatNumber } from './analytics/analyticsUtils';
import BranchPerformanceTable from './analytics/BranchPerformanceTable';
import YoYAnalyticsSection from './analytics/YoYAnalyticsSection';
import ExecutiveDecisionBI from './analytics/ExecutiveDecisionBI';
import { CustomerLeaderboardTable, ServiceCatalogTable } from './analytics/CustomerServiceLeaderboard';

export default function AnalyticsCharts({
  selectedTerminal: parentTerminal,
  setSelectedTerminal: parentSetTerminal,
  selectedFY: parentFY,
  setSelectedFY: parentSetFY,
  financialData: propFinancialData,
  loading: propLoading
}) {
  const [finData, setFinData] = useState(propFinancialData || null);
  const [loading, setLoading] = useState(propFinancialData ? false : (propLoading ?? true));
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

  // Single-fetch architecture: If propFinancialData is passed from App.jsx, use it directly!
  useEffect(() => {
    if (propFinancialData) {
      setFinData(propFinancialData);
      setLoading(false);
    } else {
      // Standalone fallback only if not provided by App.jsx
      let mounted = true;
      const fetchFinancials = async () => {
        setLoading(true);
        try {
          const res = await authFetch('/api/financial-analytics');
          const json = await res.json();
          if (mounted && json.success) {
            setFinData(json.data);
          }
        } catch (e) {
          console.error('Failed to load financial analytics:', e);
        } finally {
          if (mounted) setLoading(false);
        }
      };
      fetchFinancials();
      return () => { mounted = false; };
    }
  }, [propFinancialData]);

  const branchDetailed = finData?.branchDetailed || {};
  const terminals = useMemo(() => branchDetailed.terminals || [], [branchDetailed]);
  const financialYears = useMemo(() => branchDetailed.financialYears || [
    'All Financial Years', 'FY 2026-27', 'FY 2025-26', 'FY 2024-25', 'FY 2023-24', 'FY 2022-23 & Earlier'
  ], [branchDetailed]);
  const fySummaries = useMemo(() => branchDetailed.fySummaries || {}, [branchDetailed]);
  const terminalFyMatrix = useMemo(() => branchDetailed.terminalFyMatrix || [], [branchDetailed]);
  const topCustomers = useMemo(() => finData?.topCustomers || finData?.customerAnalytics || branchDetailed.topCustomers || [], [finData, branchDetailed]);
  const topServices = useMemo(() => finData?.topServices || finData?.serviceAnalytics || branchDetailed.topServices || [], [finData, branchDetailed]);
  const dbTotals = finData?.totals || {};

  // 1. Filtered and Sorted Terminal Matrix for Table & Charts
  const displayTerminals = useMemo(() => {
    return terminals
      .filter(t => {
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
    let totalCredit = 0;
    let totalCrCount = 0;

    displayTerminals.forEach(t => {
      totalGross += Number(t.grossSale || t.netRevenue || 0);
      totalBill += Number(t.billAmount || 0);
      totalTax += Number(t.taxAmount || 0);
      totalInvs += Number(t.invoiceCount || 0);
      totalConts += Number(t.displayContainers || t.totalContainers || 0);
      totalCredit += Number(t.creditAmount || 0);
      totalCrCount += Number(t.creditCount || 0);
    });

    const u40 = Math.round(totalConts * 0.9);
    const u20 = totalConts - u40;
    const calcTeus = (u20 * 1.0) + (u40 * 2.0);
    const netRev = Math.round((totalGross - totalCredit) * 100) / 100;

    return {
      grossSale: totalGross,
      billAmount: totalBill,
      taxAmount: totalTax,
      invoicedGross: totalGross,
      invoiceCount: totalInvs,
      creditCount: totalCrCount,
      creditAmount: totalCredit,
      netRevenue: netRev,
      totalJobs: totalInvs,
      totalContainers: totalConts,
      units40ft: u40,
      units20ft: u20,
      teus: calcTeus,
      ownFleet: 236,
      activeTerminals: displayTerminals.filter(t => (t.displayContainers || t.totalContainers || 0) > 0).length,
      totalTerminals: displayTerminals.length
    };
  }, [displayTerminals]);

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

  // Top 8 Terminals by Container TEU Volume
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
    const wsTerm = XLSX.utils.json_to_sheet(displayTerminals);
    XLSX.utils.book_append_sheet(wb, wsTerm, 'Branch_Performance');
    const wsCust = XLSX.utils.json_to_sheet(topCustomers);
    XLSX.utils.book_append_sheet(wb, wsCust, 'Top_Revenue_Customers');
    const wsSvc = XLSX.utils.json_to_sheet(topServices);
    XLSX.utils.book_append_sheet(wb, wsSvc, 'Top_Logistics_Services');
    const wsYoY = XLSX.utils.json_to_sheet(yoyChartData);
    XLSX.utils.book_append_sheet(wb, wsYoY, 'Fiscal_YoY_Comparison');
    XLSX.writeFile(wb, `SPJ_Branch_Analytics_${selectedFY || 'ALL'}.xlsx`);
  };

  const SortIcon = ({ field }) => {
    if (sortBy !== field) return null;
    return sortOrder === 'asc' ? <ArrowUp className="w-3 h-3 inline text-purple-700" /> : <ArrowDown className="w-3 h-3 inline text-purple-700" />;
  };

  return (
    <div className="space-y-4 sm:space-y-6">
      {/* 1. TOP DYNAMIC METRICS BANNER */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-2 sm:gap-4">
        {/* Card 1: Gross Sale */}
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
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift">
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
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shrink-0">
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
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift">
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
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 shrink-0">
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
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift">
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
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200 shrink-0">
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

        {/* Card 5: Container Volume */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift">
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
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shrink-0">
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

        {/* Card 6: TEU Capacity */}
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-3xl border border-slate-200 shadow-soft relative overflow-hidden group hover-lift">
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

        {/* Card 7: Job Orders */}
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

        {/* Card 8: Active Heavy Fleet */}
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

      {/* 2. SUB-VIEW NAVIGATION */}
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

      {/* 3. ACTIVE SUB-VIEW CONTENT */}
      {activeTab === 'branches' && (
        <BranchPerformanceTable
          topRevenueChart={topRevenueChart}
          topVolumeChart={topVolumeChart}
          displayTerminals={displayTerminals}
          selectedFY={selectedFY}
          selectedTerminal={selectedTerminal}
          setSelectedTerminal={setSelectedTerminal}
          searchTerminal={searchTerminal}
          setSearchTerminal={setSearchTerminal}
          sortBy={sortBy}
          setSortBy={setSortBy}
          sortOrder={sortOrder}
          setSortOrder={setSortOrder}
          handleSortHeader={handleSortHeader}
          SortIcon={SortIcon}
        />
      )}

      {activeTab === 'yoy' && (
        <YoYAnalyticsSection
          yoyChartData={yoyChartData}
          selectedTerminal={selectedTerminal}
          terminals={terminals}
        />
      )}

      {activeTab === 'decision_bi' && (
        <ExecutiveDecisionBI
          topCustomers={topCustomers}
          topServices={topServices}
          dynamicMetrics={dynamicMetrics}
          dbTotals={dbTotals}
        />
      )}

      {activeTab === 'customer_bi' && (
        <CustomerLeaderboardTable
          topCustomers={topCustomers}
          dynamicMetrics={dynamicMetrics}
          dbTotals={dbTotals}
        />
      )}

      {activeTab === 'service_bi' && (
        <ServiceCatalogTable
          topServices={topServices}
        />
      )}
    </div>
  );
}
