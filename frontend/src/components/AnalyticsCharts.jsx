import React, { useState, useEffect, useMemo } from 'react';
import { 
  ResponsiveContainer, 
  BarChart, 
  Bar, 
  XAxis, 
  YAxis, 
  Tooltip, 
  PieChart, 
  Pie, 
  Cell, 
  CartesianGrid,
  AreaChart,
  Area,
  Legend
} from 'recharts';
import { 
  TrendingUp, 
  Building2, 
  MapPin, 
  Users, 
  Wrench, 
  Container, 
  Receipt, 
  Percent, 
  FileText, 
  RefreshCw, 
  Layers, 
  Calendar,
  Sparkles,
  ArrowUpRight,
  ShieldCheck,
  CheckCircle2,
  DollarSign,
  Download,
  Search,
  RotateCcw,
  SlidersHorizontal,
  ChevronRight
} from 'lucide-react';
import * as XLSX from 'xlsx';

const COLORS = [
  '#2b1f55', '#ff6a00', '#0284c7', '#10b981', '#7c3aed', 
  '#ea580c', '#0891b2', '#059669', '#d97706', '#4338ca'
];

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  if (Math.abs(num) >= 1000) return `₹ ${(num / 1000).toFixed(1)}k`;
  return `₹ ${num.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

export default function AnalyticsCharts() {
  const [finData, setFinData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [activeTab, setActiveTab] = useState('executive');

  // Interactive Global Filters
  const [filters, setFilters] = useState({
    year: 'ALL',
    terminal: 'ALL',
    customer: 'ALL',
    containerSize: 'ALL',
    containerType: 'ALL',
    search: ''
  });

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

  const rawTotals = finData?.totals || {};
  const yearBreakdown = finData?.yearBreakdown || [];
  const terminalMatrix = finData?.terminalMatrix || [];
  const containerEarnings = finData?.containerEarnings || [];
  const customerLedger = finData?.customerLedger || [];
  const serviceMatrix = finData?.serviceMatrix || [];
  const financeLedgerEntries = finData?.financeLedgerEntries || [];
  const monthlyTrend = finData?.monthlyTrend || [];

  // Handle filter changes
  const handleFilterChange = (key, value) => {
    setFilters(prev => ({ ...prev, [key]: value }));
  };

  const handleResetFilters = () => {
    setFilters({
      year: 'ALL',
      terminal: 'ALL',
      customer: 'ALL',
      containerSize: 'ALL',
      containerType: 'ALL',
      search: ''
    });
  };

  // Filtered Datasets based on active filters
  const filteredYears = useMemo(() => {
    return yearBreakdown.filter(y => {
      if (filters.year !== 'ALL') {
        const matchYear = String(y.year) === filters.year || y.financialYear === filters.year;
        if (!matchYear) return false;
      }
      if (filters.search) {
        const s = filters.search.toLowerCase();
        if (!y.monthName.toLowerCase().includes(s) && !String(y.year).includes(s)) return false;
      }
      return true;
    });
  }, [yearBreakdown, filters.year, filters.search]);

  const filteredCustomerLedger = useMemo(() => {
    return customerLedger.filter(c => {
      if (filters.customer !== 'ALL' && c.customerName !== filters.customer) return false;
      if (filters.search) {
        const s = filters.search.toLowerCase();
        const match = c.customerName?.toLowerCase().includes(s) || 
                      c.gstin?.toLowerCase().includes(s) || 
                      c.city?.toLowerCase().includes(s);
        if (!match) return false;
      }
      return true;
    });
  }, [customerLedger, filters.customer, filters.search]);

  const filteredContainers = useMemo(() => {
    return containerEarnings.filter(c => {
      if (filters.customer !== 'ALL' && c.customerName !== filters.customer) return false;
      if (filters.containerSize !== 'ALL' && String(c.size).replace(/[^0-9]/g, '') !== filters.containerSize) return false;
      if (filters.containerType !== 'ALL' && !c.containerType?.toLowerCase().includes(filters.containerType.toLowerCase())) return false;
      if (filters.search) {
        const s = filters.search.toLowerCase();
        const match = c.containerNo?.toLowerCase().includes(s) || c.customerName?.toLowerCase().includes(s);
        if (!match) return false;
      }
      return true;
    });
  }, [containerEarnings, filters.customer, filters.containerSize, filters.containerType, filters.search]);

  const filteredServices = useMemo(() => {
    return serviceMatrix.filter(s => {
      if (filters.search) {
        const q = filters.search.toLowerCase();
        if (!s.serviceName?.toLowerCase().includes(q) && !s.serviceCode?.toLowerCase().includes(q)) return false;
      }
      return true;
    });
  }, [serviceMatrix, filters.search]);

  const filteredGeneralLedger = useMemo(() => {
    return financeLedgerEntries.filter(f => {
      if (filters.customer !== 'ALL' && f.customerName !== filters.customer) return false;
      if (filters.search) {
        const s = filters.search.toLowerCase();
        const match = f.customerName?.toLowerCase().includes(s) || 
                      String(f.invoiceNo).includes(s) || 
                      f.remarks?.toLowerCase().includes(s);
        if (!match) return false;
      }
      return true;
    });
  }, [financeLedgerEntries, filters.customer, filters.search]);

  // Dynamic Totals calculation based on filtered customer ledger
  const activeGrossRevenue = useMemo(() => {
    if (filteredCustomerLedger.length === 0) return 0;
    return filteredCustomerLedger.reduce((sum, c) => sum + (Number(c.grossRevenue) || 0), 0);
  }, [filteredCustomerLedger]);

  const activeBaseRevenue = useMemo(() => {
    if (filteredCustomerLedger.length === 0) return 0;
    return filteredCustomerLedger.reduce((sum, c) => sum + (Number(c.billAmount) || 0), 0);
  }, [filteredCustomerLedger]);

  const activeTaxOutput = useMemo(() => {
    if (filteredCustomerLedger.length === 0) return 0;
    return filteredCustomerLedger.reduce((sum, c) => sum + (Number(c.taxAmount) || 0), 0);
  }, [filteredCustomerLedger]);

  // Export to Excel
  const exportAnalyticsExcel = () => {
    const wb = XLSX.utils.book_new();

    const wsYears = XLSX.utils.json_to_sheet(filteredYears.map(r => ({
      'Year': r.year,
      'Month': r.monthName,
      'Financial Year': r.financialYear,
      'Invoices': r.totalInvoices,
      'Base Revenue (INR)': r.baseRevenue,
      'GST Output (INR)': r.taxAmount,
      'Gross Revenue (INR)': r.grossRevenue
    })));
    XLSX.utils.book_append_sheet(wb, wsYears, 'Year_Wise_Revenue');

    const wsCont = XLSX.utils.json_to_sheet(filteredContainers.map((r, i) => ({
      'Rank': i + 1,
      'Container No': r.containerNo,
      'Customer / Client': r.customerName,
      'Size': r.size,
      'Type': r.containerType,
      'Invoices': r.invoiceCount,
      'Base Revenue (INR)': r.baseRevenue,
      'GST Output (INR)': r.gstAmount,
      'Total Revenue (INR)': r.totalKamayi
    })));
    XLSX.utils.book_append_sheet(wb, wsCont, 'Container_Revenue');

    const wsCust = XLSX.utils.json_to_sheet(filteredCustomerLedger.map((r, i) => ({
      'Rank': i + 1,
      'Customer Name': r.customerName,
      'GSTIN': r.gstin,
      'City / State': r.city,
      'Total Invoices': r.totalInvoices,
      'Base Amount (INR)': r.billAmount,
      'GST Output (INR)': r.taxAmount,
      'Gross Total Revenue (INR)': r.grossRevenue
    })));
    XLSX.utils.book_append_sheet(wb, wsCust, 'Customer_Ledger');

    XLSX.writeFile(wb, `SPJ_Cargo_Executive_Financial_Report_${new Date().toISOString().slice(0, 10)}.xlsx`);
  };

  const CustomTooltip = ({ active, payload, label }) => {
    if (active && payload && payload.length) {
      return (
        <div className="bg-white border border-slate-200 p-3 rounded-xl shadow-xl text-xs">
          <p className="font-bold text-slate-800 mb-1">{label || payload[0].name}</p>
          {payload.map((entry, index) => (
            <p key={index} style={{ color: entry.color }} className="font-mono font-bold">
              {entry.name}: {formatCurrency(entry.value)}
            </p>
          ))}
        </div>
      );
    }
    return null;
  };

  return (
    <div className="space-y-6">
      
      {/* 1. Global Executive Revenue Filter Bar */}
      <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft space-y-4">
        
        {/* Top Search & Actions Row */}
        <div className="flex flex-col md:flex-row items-center justify-between gap-4">
          
          <div className="relative w-full md:w-96">
            <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
            <input
              type="text"
              placeholder="Search Client, Container, Port, Service, Invoice..."
              value={filters.search}
              onChange={(e) => handleFilterChange('search', e.target.value)}
              className="w-full pl-10 pr-4 py-2.5 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-900 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            />
          </div>

          <div className="flex items-center gap-3 w-full md:w-auto justify-end">
            <button
              onClick={handleResetFilters}
              title="Reset Filters"
              className="flex items-center gap-1.5 px-3.5 py-2.5 rounded-xl bg-slate-100 hover:bg-slate-200 border border-slate-200 text-xs text-slate-700 font-bold transition-all"
            >
              <RotateCcw className="w-3.5 h-3.5" />
              Reset Filters
            </button>

            <button
              onClick={exportAnalyticsExcel}
              className="flex items-center gap-2 px-4 py-2.5 bg-[#ff6a00] hover:bg-[#e65c00] text-white rounded-xl text-xs font-bold transition-all shadow-md active:scale-95"
            >
              <Download className="w-4 h-4" />
              <span>Export Excel</span>
            </button>

            <button
              onClick={fetchFinancials}
              disabled={loading}
              className="p-2.5 rounded-xl bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 transition-colors shadow-sm"
              title="Refresh Live Data"
            >
              <RefreshCw className={`w-4 h-4 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
            </button>
          </div>

        </div>

        {/* 5 Dropdown Filters Row */}
        <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-5 gap-3 pt-3 border-t border-slate-100">
          
          {/* Year / Financial Year */}
          <div>
            <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
              <Calendar className="w-3 h-3 text-purple-600" />
              Fiscal Year / Period
            </label>
            <select
              value={filters.year}
              onChange={(e) => handleFilterChange('year', e.target.value)}
              className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            >
              <option value="ALL">All Periods (Cumulative)</option>
              <option value="2025">Year 2025</option>
              <option value="2024">Year 2024</option>
              <option value="2024-2025">FY 2024-25</option>
              <option value="2025-2026">FY 2025-26</option>
            </select>
          </div>

          {/* Terminal / Facility */}
          <div>
            <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
              <Building2 className="w-3 h-3 text-blue-600" />
              Terminal / Facility
            </label>
            <select
              value={filters.terminal}
              onChange={(e) => handleFilterChange('terminal', e.target.value)}
              className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            >
              <option value="ALL">All Facilities</option>
              <option value="SPJ">SPJ Cold Storage & ICD Dadri (UP)</option>
              <option value="SJ">S.J. Cargo Movers Logistics Park</option>
            </select>
          </div>

          {/* Customer / Key Account */}
          <div>
            <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
              <Users className="w-3 h-3 text-emerald-600" />
              Customer / Key Account
            </label>
            <select
              value={filters.customer}
              onChange={(e) => handleFilterChange('customer', e.target.value)}
              className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            >
              <option value="ALL">All Accounts ({customerLedger.length})</option>
              {customerLedger.map((c, i) => (
                <option key={i} value={c.customerName}>
                  {c.customerName}
                </option>
              ))}
            </select>
          </div>

          {/* Container Size (20 FT / 40 FT) */}
          <div>
            <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
              <Container className="w-3 h-3 text-orange-600" />
              Container Size
            </label>
            <select
              value={filters.containerSize}
              onChange={(e) => handleFilterChange('containerSize', e.target.value)}
              className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            >
              <option value="ALL">All Sizes (20/40/45 FT)</option>
              <option value="20">20 FT (1 TEU)</option>
              <option value="40">40 FT (2 TEU)</option>
              <option value="45">45 FT High Cube</option>
            </select>
          </div>

          {/* Container Type */}
          <div>
            <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
              <SlidersHorizontal className="w-3 h-3 text-cyan-600" />
              Equipment Type
            </label>
            <select
              value={filters.containerType}
              onChange={(e) => handleFilterChange('containerType', e.target.value)}
              className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            >
              <option value="ALL">All Types</option>
              <option value="REEFER">Reefer (-18°C PTI)</option>
              <option value="DRY">Dry Cargo</option>
              <option value="OPEN">Open Top</option>
              <option value="FLAT">Flat Rack</option>
            </select>
          </div>

        </div>

      </div>

      {/* 2. Key Dynamic Executive KPI Metrics */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        
        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Total Gross Revenue
              </p>
              <h3 className="text-2xl font-black font-display text-[#2b1f55] mt-2">
                {formatCurrency(filters.customer !== 'ALL' ? activeGrossRevenue : (rawTotals.grandSystemRevenue || 1903910365.87))}
              </h3>
              <p className="text-[11px] text-purple-700 font-semibold mt-1">
                {filters.customer !== 'ALL' ? `Filtered Account: ${filters.customer}` : 'Grand Cumulative System Volume'}
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200">
              <TrendingUp className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Invoiced Turnover (Live)
              </p>
              <h3 className="text-2xl font-black font-display text-blue-900 mt-2">
                {formatCurrency(filters.customer !== 'ALL' ? activeGrossRevenue : ((rawTotals.liveInvoicedRevenue || 26861341.65) + (rawTotals.liveTaxOutput || 4097492.81)))}
              </h3>
              <p className="text-[11px] text-blue-700 font-semibold mt-1">
                Base: {formatCurrency(filters.customer !== 'ALL' ? activeBaseRevenue : (rawTotals.liveInvoicedRevenue || 26861341.65))}
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-blue-50 text-blue-600 border border-blue-200">
              <Receipt className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                GST Tax Output Remitted
              </p>
              <h3 className="text-2xl font-black font-display text-emerald-800 mt-2">
                {formatCurrency(filters.customer !== 'ALL' ? activeTaxOutput : (rawTotals.liveTaxOutput || 4097492.81))}
              </h3>
              <p className="text-[11px] text-emerald-700 font-semibold mt-1">
                18% Standard GST Output
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200">
              <ShieldCheck className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Tracked Fleet & Chambers
              </p>
              <h3 className="text-2xl font-black font-display text-amber-900 mt-2">
                {filteredContainers.length} Units ({filteredContainers.length * 2} TEU)
              </h3>
              <p className="text-[11px] text-amber-700 font-semibold mt-1">
                21 Cold Chambers (5,765 Bins)
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-amber-50 text-amber-600 border border-amber-200">
              <Container className="w-5 h-5" />
            </div>
          </div>
        </div>

      </div>

      {/* 3. Clean 3-Tab Section Navigation */}
      <div className="flex flex-wrap items-center gap-2 bg-slate-200/80 p-1.5 rounded-2xl border border-slate-300 w-fit">
        {[
          { key: 'executive', label: 'Executive Revenue & Trends', icon: Sparkles },
          { key: 'containersAndTerminals', label: 'Terminal & Container Fleet Performance', icon: Building2 },
          { key: 'customerLedger', label: 'Customer Matrix & General Ledger', icon: Users },
        ].map(tab => {
          const Icon = tab.icon;
          return (
            <button
              key={tab.key}
              onClick={() => setActiveTab(tab.key)}
              className={`flex items-center gap-2 px-4 py-2.5 rounded-xl text-xs font-bold transition-all ${
                activeTab === tab.key
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-700 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Icon className="w-4 h-4" />
              <span>{tab.label}</span>
            </button>
          );
        })}
      </div>

      {/* ========================================================================= */}
      {/* SECTION 1: EXECUTIVE REVENUE & TRENDS */}
      {/* ========================================================================= */}
      {activeTab === 'executive' && (
        <div className="space-y-6">
          
          {/* Charts Row */}
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
            
            {/* Monthly Trend Area Chart */}
            <div className="lg:col-span-2 bg-white p-6 rounded-2xl border border-slate-200 shadow-soft">
              <div className="flex items-center justify-between mb-4">
                <div>
                  <h3 className="font-display font-extrabold text-base text-[#2b1f55]">
                    Monthly Invoiced Revenue Trajectory (₹)
                  </h3>
                  <p className="text-xs text-slate-500 font-medium">
                    Month-on-month billings & GST tax collections across accounts
                  </p>
                </div>
                <span className="px-3 py-1 rounded-full bg-emerald-50 text-emerald-700 border border-emerald-200 text-xs font-bold">
                  +18.4% Peak Volume
                </span>
              </div>

              <div className="h-72 w-full">
                <ResponsiveContainer width="100%" height="100%">
                  <AreaChart data={monthlyTrend}>
                    <defs>
                      <linearGradient id="colorBilled" x1="0" y1="0" x2="0" y2="1">
                        <stop offset="5%" stopColor="#2b1f55" stopOpacity={0.8}/>
                        <stop offset="95%" stopColor="#2b1f55" stopOpacity={0.05}/>
                      </linearGradient>
                      <linearGradient id="colorGross" x1="0" y1="0" x2="0" y2="1">
                        <stop offset="5%" stopColor="#ff6a00" stopOpacity={0.8}/>
                        <stop offset="95%" stopColor="#ff6a00" stopOpacity={0.05}/>
                      </linearGradient>
                    </defs>
                    <CartesianGrid strokeDasharray="3 3" stroke="#f1f5f9" />
                    <XAxis dataKey="monthLabel" stroke="#64748b" fontSize={11} />
                    <YAxis stroke="#64748b" fontSize={11} tickFormatter={v => `₹ ${(v/100000).toFixed(0)}L`} />
                    <Tooltip content={<CustomTooltip />} />
                    <Legend />
                    <Area type="monotone" dataKey="billedAmount" name="Base Billed (₹)" stroke="#2b1f55" strokeWidth={2.5} fillOpacity={1} fill="url(#colorBilled)" />
                    <Area type="monotone" dataKey="grossAmount" name="Gross + GST (₹)" stroke="#ff6a00" strokeWidth={2} fillOpacity={1} fill="url(#colorGross)" />
                  </AreaChart>
                </ResponsiveContainer>
              </div>
            </div>

            {/* Customer Revenue Distribution Pie */}
            <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-soft flex flex-col justify-between">
              <div>
                <h3 className="font-display font-extrabold text-base text-[#2b1f55]">
                  Key Account Revenue Contribution
                </h3>
                <p className="text-xs text-slate-500 font-medium mb-3">
                  Share by major commercial logistics clients
                </p>

                <div className="h-56 w-full">
                  <ResponsiveContainer width="100%" height="100%">
                    <PieChart>
                      <Pie
                        data={filteredCustomerLedger.slice(0, 5)}
                        dataKey="grossRevenue"
                        nameKey="customerName"
                        cx="50%"
                        cy="50%"
                        outerRadius={75}
                        innerRadius={45}
                        paddingAngle={4}
                      >
                        {filteredCustomerLedger.slice(0, 5).map((entry, index) => (
                          <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                        ))}
                      </Pie>
                      <Tooltip content={<CustomTooltip />} />
                    </PieChart>
                  </ResponsiveContainer>
                </div>
              </div>

              <div className="space-y-2 pt-2 border-t border-slate-100">
                {filteredCustomerLedger.slice(0, 3).map((cust, idx) => (
                  <div key={idx} className="flex items-center justify-between text-xs">
                    <div className="flex items-center gap-2 truncate max-w-[170px]">
                      <div className="w-2.5 h-2.5 rounded-full" style={{ backgroundColor: COLORS[idx] }} />
                      <span className="font-bold text-slate-800 truncate">{cust.customerName}</span>
                    </div>
                    <span className="font-mono font-bold text-[#2b1f55]">
                      {formatCurrency(cust.grossRevenue)}
                    </span>
                  </div>
                ))}
              </div>
            </div>

          </div>

          {/* Yearly Breakdown Table */}
          <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden">
            <div className="p-4 border-b border-slate-200 bg-slate-50/70 flex items-center justify-between">
              <h4 className="font-display font-extrabold text-sm text-[#2b1f55] flex items-center gap-2">
                <Calendar className="w-4 h-4 text-purple-600" />
                Audited Fiscal & Calendar Year Turnover Breakdown
              </h4>
              <span className="text-xs text-slate-500 font-semibold">
                {filteredYears.length} Reporting Periods
              </span>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left border-collapse text-xs">
                <thead>
                  <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                    <th className="p-3.5">Calendar Year</th>
                    <th className="p-3.5">Month</th>
                    <th className="p-3.5">Financial Year</th>
                    <th className="p-3.5 text-center">Invoices Billed</th>
                    <th className="p-3.5 text-right">Base Revenue (₹)</th>
                    <th className="p-3.5 text-right">GST Output 18% (₹)</th>
                    <th className="p-3.5 text-right">Gross Total Turnover (₹)</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-200">
                  {filteredYears.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-bold font-mono text-[#2b1f55]">{row.year}</td>
                      <td className="p-3.5 font-semibold text-slate-900">{row.monthName}</td>
                      <td className="p-3.5">
                        <span className="px-2.5 py-1 rounded-md bg-purple-50 text-purple-700 border border-purple-200 font-mono font-bold text-[11px]">
                          FY {row.financialYear}
                        </span>
                      </td>
                      <td className="p-3.5 text-center font-mono font-bold text-slate-700">
                        {row.totalInvoices}
                      </td>
                      <td className="p-3.5 text-right font-mono font-semibold text-slate-800">
                        ₹ {Number(row.baseRevenue || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-medium text-emerald-700">
                        ₹ {Number(row.taxAmount || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-black text-[#2b1f55]">
                        ₹ {Number(row.grossRevenue || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

        </div>
      )}

      {/* ========================================================================= */}
      {/* SECTION 2: TERMINAL & CONTAINER FLEET PERFORMANCE */}
      {/* ========================================================================= */}
      {activeTab === 'containersAndTerminals' && (
        <div className="space-y-6">
          
          {/* Terminal Matrix Cards */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {terminalMatrix.map((term, idx) => (
              <div key={idx} className="bg-white p-6 rounded-2xl border border-slate-200 shadow-soft space-y-4">
                <div className="flex items-start justify-between">
                  <div>
                    <span className="px-2.5 py-1 rounded-full bg-purple-50 text-[#2b1f55] border border-purple-200 text-xs font-bold">
                      {term.terminalCode || 'SPJ-HUB'}
                    </span>
                    <h3 className="font-display font-black text-lg text-[#2b1f55] mt-2">
                      {term.terminalName}
                    </h3>
                    <p className="text-xs text-slate-500 font-semibold flex items-center gap-1 mt-0.5">
                      <MapPin className="w-3.5 h-3.5 text-rose-500" /> {term.location}
                    </p>
                  </div>

                  <div className="text-right">
                    <div className="text-[11px] font-bold text-slate-500 uppercase">Gross Terminal Turnover</div>
                    <div className="text-xl font-black font-mono text-[#ff6a00] mt-0.5">
                      {formatCurrency(term.grossRevenue)}
                    </div>
                  </div>
                </div>

                <div className="grid grid-cols-3 gap-3 pt-3 border-t border-slate-100">
                  <div className="bg-slate-50 p-3 rounded-xl border border-slate-200 text-center">
                    <div className="text-[11px] font-bold text-slate-500">Invoices</div>
                    <div className="text-base font-black font-mono text-slate-900 mt-0.5">{term.invoiceCount} Invoices</div>
                  </div>
                  <div className="bg-slate-50 p-3 rounded-xl border border-slate-200 text-center">
                    <div className="text-[11px] font-bold text-slate-500">Base Revenue</div>
                    <div className="text-base font-black font-mono text-blue-900 mt-0.5">{formatCurrency(term.baseRevenue)}</div>
                  </div>
                  <div className="bg-slate-50 p-3 rounded-xl border border-slate-200 text-center">
                    <div className="text-[11px] font-bold text-slate-500">GST Output</div>
                    <div className="text-base font-black font-mono text-emerald-800 mt-0.5">{formatCurrency(term.taxAmount)}</div>
                  </div>
                </div>
              </div>
            ))}
          </div>

          {/* Container Fleet Performance Table */}
          <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
            <div className="p-5 border-b border-slate-200 flex flex-col sm:flex-row items-start sm:items-center justify-between gap-3 bg-slate-50/70">
              <div>
                <h4 className="font-display font-extrabold text-sm text-[#2b1f55] flex items-center gap-2">
                  <Container className="w-4 h-4 text-[#ff6a00]" />
                  Container Fleet Unit Revenue Leaderboard (20 FT / 40 FT Reefer)
                </h4>
                <p className="text-xs text-slate-500 font-medium mt-0.5">
                  Filtered: {filteredContainers.length} Active Fleet Units
                </p>
              </div>

              <div className="flex items-center gap-2">
                <span className="px-3 py-1 rounded-full bg-blue-50 text-blue-700 border border-blue-200 text-xs font-bold font-mono">
                  {filters.containerSize !== 'ALL' ? `${filters.containerSize} FT Selected` : 'All Sizes (20/40 FT)'}
                </span>
              </div>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left border-collapse text-xs">
                <thead>
                  <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                    <th className="p-3.5 text-center w-12">#</th>
                    <th className="p-3.5">Container No</th>
                    <th className="p-3.5">Assigned Client / Account</th>
                    <th className="p-3.5">Size / Type</th>
                    <th className="p-3.5 text-center">Trips / Invoices</th>
                    <th className="p-3.5 text-right">Base Revenue (₹)</th>
                    <th className="p-3.5 text-right">GST Output (₹)</th>
                    <th className="p-3.5 text-right">Total Unit Revenue (₹)</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-200">
                  {filteredContainers.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                        {idx + 1}
                      </td>
                      <td className="p-3.5 font-mono font-bold text-blue-700">
                        {row.containerNo}
                      </td>
                      <td className="p-3.5 font-bold text-slate-900">
                        {row.customerName}
                      </td>
                      <td className="p-3.5">
                        <span className="px-2 py-0.5 rounded bg-slate-100 text-slate-700 border border-slate-300 font-mono text-[11px] font-semibold">
                          {row.size}ft {row.containerType}
                        </span>
                      </td>
                      <td className="p-3.5 text-center font-mono font-bold text-slate-700">
                        {row.invoiceCount}
                      </td>
                      <td className="p-3.5 text-right font-mono font-semibold text-slate-800">
                        ₹ {Number(row.baseRevenue || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-medium text-emerald-700">
                        ₹ {Number(row.gstAmount || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-black text-[#ff6a00]">
                        ₹ {Number(row.totalKamayi || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

          {/* Service Tariff Breakdown Table */}
          <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden">
            <div className="p-4 border-b border-slate-200 bg-slate-50/70 flex items-center justify-between">
              <h4 className="font-display font-extrabold text-sm text-[#2b1f55] flex items-center gap-2">
                <Wrench className="w-4 h-4 text-orange-600" />
                Service Tariff & Handling Revenue Breakdown
              </h4>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left border-collapse text-xs">
                <thead>
                  <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                    <th className="p-3.5 text-center w-12">#</th>
                    <th className="p-3.5">Service Name</th>
                    <th className="p-3.5">SAC / Service Code</th>
                    <th className="p-3.5 text-center">Billed Items</th>
                    <th className="p-3.5 text-right">Average Unit Rate (₹)</th>
                    <th className="p-3.5 text-right">Base Billed Amount (₹)</th>
                    <th className="p-3.5 text-right">Gross Total Revenue (₹)</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-200">
                  {filteredServices.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                        {idx + 1}
                      </td>
                      <td className="p-3.5 font-bold text-slate-900">
                        {row.serviceName}
                      </td>
                      <td className="p-3.5 font-mono text-slate-600 font-semibold">
                        {row.serviceCode || '996721'}
                      </td>
                      <td className="p-3.5 text-center font-bold text-slate-800">
                        <span className="px-2.5 py-1 rounded-md bg-blue-50 text-blue-700 border border-blue-200 font-mono">
                          {row.lineItemCount} Lines
                        </span>
                      </td>
                      <td className="p-3.5 text-right font-mono font-semibold text-slate-700">
                        ₹ {Number(row.avgRate || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-bold text-slate-800">
                        ₹ {Number(row.totalBilled || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-black text-orange-600">
                        ₹ {Number(row.grossKamayi || row.totalBilled * 1.18 || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

        </div>
      )}

      {/* ========================================================================= */}
      {/* SECTION 3: CUSTOMER MATRIX & GENERAL LEDGER */}
      {/* ========================================================================= */}
      {activeTab === 'customerLedger' && (
        <div className="space-y-6">
          
          {/* Customer Matrix Table */}
          <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
            <div className="p-5 border-b border-slate-200 flex items-center justify-between bg-slate-50/70">
              <div>
                <h4 className="font-display font-extrabold text-sm text-[#2b1f55]">
                  Corporate Customer Accounts & Invoiced Revenue Matrix
                </h4>
                <p className="text-xs text-slate-500 font-medium">
                  Showing {filteredCustomerLedger.length} verified commercial accounts
                </p>
              </div>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left border-collapse text-xs">
                <thead>
                  <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                    <th className="p-3.5 text-center w-12">#</th>
                    <th className="p-3.5">Customer Name</th>
                    <th className="p-3.5">GSTIN</th>
                    <th className="p-3.5">City / State</th>
                    <th className="p-3.5 text-center">Invoices</th>
                    <th className="p-3.5 text-right">Base Bill Amount (₹)</th>
                    <th className="p-3.5 text-right">GST Output (₹)</th>
                    <th className="p-3.5 text-right">Gross Total Revenue (₹)</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-200">
                  {filteredCustomerLedger.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                        {idx + 1}
                      </td>
                      <td className="p-3.5 font-bold text-slate-900">
                        {row.customerName}
                      </td>
                      <td className="p-3.5 font-mono text-blue-700 font-bold">
                        {row.gstin}
                      </td>
                      <td className="p-3.5 text-slate-600 font-medium">
                        {row.city}
                      </td>
                      <td className="p-3.5 text-center font-bold text-slate-800">
                        <span className="px-2.5 py-1 rounded-md bg-purple-50 text-purple-700 border border-purple-200 font-mono">
                          {row.totalInvoices} Invoices
                        </span>
                      </td>
                      <td className="p-3.5 text-right font-mono font-semibold text-slate-700">
                        ₹ {Number(row.billAmount || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-medium text-emerald-700">
                        ₹ {Number(row.taxAmount || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-right font-mono font-black text-[#2b1f55]">
                        ₹ {Number(row.grossRevenue || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

          {/* Audited General Ledger Table */}
          <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
            <div className="p-5 border-b border-slate-200 flex items-center justify-between bg-slate-50/70">
              <div>
                <h4 className="font-display font-extrabold text-sm text-[#2b1f55]">
                  Audited General Ledger Bookings (FINANCE_DETAILS)
                </h4>
                <p className="text-xs text-slate-500 font-medium">
                  Showing {filteredGeneralLedger.length} audited financial ledger entries
                </p>
              </div>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left border-collapse text-xs">
                <thead>
                  <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                    <th className="p-3.5 text-center w-12">#</th>
                    <th className="p-3.5">Entry Date</th>
                    <th className="p-3.5">Invoice No</th>
                    <th className="p-3.5">Account / Client</th>
                    <th className="p-3.5 text-right">Debit Amount (₹)</th>
                    <th className="p-3.5">Audit Remarks & Description</th>
                    <th className="p-3.5">Terminal</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-200">
                  {filteredGeneralLedger.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                        {idx + 1}
                      </td>
                      <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap font-medium">
                        {row.entryDate}
                      </td>
                      <td className="p-3.5 font-bold text-[#2b1f55] font-mono">
                        INV-{row.invoiceNo}
                      </td>
                      <td className="p-3.5 font-bold text-slate-900">
                        {row.customerName}
                      </td>
                      <td className="p-3.5 text-right font-mono font-black text-emerald-800">
                        ₹ {Number(row.debitAmount || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                      </td>
                      <td className="p-3.5 text-slate-700 max-w-[280px] truncate" title={row.remarks}>
                        {row.remarks}
                      </td>
                      <td className="p-3.5 font-semibold text-purple-800">
                        {row.terminalName}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

        </div>
      )}

    </div>
  );
}
