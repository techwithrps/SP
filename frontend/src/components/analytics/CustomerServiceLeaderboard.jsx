import React, { useState, useMemo } from "react";
import { 
  Users, 
  Layers, 
  Search, 
  TrendingUp, 
  Award, 
  Receipt, 
  ArrowUpDown, 
  FileSpreadsheet, 
  Building2, 
  BarChart3, 
  PieChart, 
  ShieldCheck, 
  Sparkles,
  ArrowUp,
  ArrowDown
} from "lucide-react";
import { 
  ResponsiveContainer, 
  BarChart, 
  Bar, 
  XAxis, 
  YAxis, 
  Tooltip, 
  CartesianGrid, 
  Legend, 
  Cell 
} from "recharts";
import { formatCurrency, formatNumber, CustomChartTooltip } from "./analyticsUtils";
import AnimatedCounter from "../AnimatedCounter";

export function CustomerLeaderboardTable({
  topCustomers = [],
  dynamicMetrics = {},
  dbTotals = {},
}) {
  const [searchTerm, setSearchTerm] = useState("");
  const [sortBy, setSortBy] = useState("grossRevenue");
  const [sortOrder, setSortOrder] = useState("desc");

  const grandTotalGross = dynamicMetrics.grossSale || dbTotals.grandSystemRevenue || topCustomers.reduce((sum, c) => sum + (c.grossRevenue || 0), 0) || 1;
  const totalCustomerInvoices = topCustomers.reduce((sum, c) => sum + (c.invoiceCount || 0), 0);
  const totalCustomerGross = topCustomers.reduce((sum, c) => sum + (c.grossRevenue || 0), 0);
  const avgRevenuePerClient = topCustomers.length > 0 ? (totalCustomerGross / topCustomers.length) : 0;
  
  const top5Gross = topCustomers.slice(0, 5).reduce((sum, c) => sum + (c.grossRevenue || 0), 0);
  const top5Share = totalCustomerGross > 0 ? ((top5Gross / totalCustomerGross) * 100).toFixed(1) : 0;

  // Chart 1: Top 10 Customers by Gross Revenue
  const topCustomerRevenueChart = useMemo(() => {
    return topCustomers.slice(0, 10).map((c, idx) => {
      const name = c.customerName || c.name || "Client " + (idx + 1);
      const shortName = name.length > 15 ? name.substring(0, 13) + ".." : name;
      return {
        name: shortName,
        fullName: name,
        revenue: c.grossRevenue || 0,
        billAmount: c.billAmount || 0,
        invoices: c.invoiceCount || 0,
        share: ((c.grossRevenue / grandTotalGross) * 100).toFixed(1)
      };
    });
  }, [topCustomers, grandTotalGross]);

  // Chart 2: Top 10 Customers by Invoices Count & Base Amount
  const topCustomerVolumeChart = useMemo(() => {
    return [...topCustomers]
      .sort((a, b) => (b.invoiceCount || 0) - (a.invoiceCount || 0))
      .slice(0, 10)
      .map((c, idx) => {
        const name = c.customerName || c.name || "Client " + (idx + 1);
        const shortName = name.length > 15 ? name.substring(0, 13) + ".." : name;
        return {
          name: shortName,
          fullName: name,
          invoices: c.invoiceCount || 0,
          billAmount: c.billAmount || 0,
          revenue: c.grossRevenue || 0
        };
      });
  }, [topCustomers]);

  // Filtered and sorted table list
  const filteredCustomers = useMemo(() => {
    let list = [...topCustomers];
    if (searchTerm) {
      const q = searchTerm.toLowerCase().trim();
      list = list.filter(c => (c.customerName || c.name || "").toLowerCase().includes(q));
    }
    return list.sort((a, b) => {
      if (sortBy === "customerName") {
        return sortOrder === "asc"
          ? (a.customerName || "").localeCompare(b.customerName || "")
          : (b.customerName || "").localeCompare(a.customerName || "");
      }
      const valA = Number(a[sortBy]) || 0;
      const valB = Number(b[sortBy]) || 0;
      return sortOrder === "asc" ? valA - valB : valB - valA;
    });
  }, [topCustomers, searchTerm, sortBy, sortOrder]);

  const handleSort = (field) => {
    if (sortBy === field) {
      setSortOrder(prev => (prev === "asc" ? "desc" : "asc"));
    } else {
      setSortBy(field);
      setSortOrder("desc");
    }
  };

  const SortIcon = ({ field }) => {
    if (sortBy !== field) return <ArrowUpDown className="w-3 h-3 text-slate-400 inline ml-1 opacity-0 group-hover:opacity-100 transition-opacity" />;
    return sortOrder === "asc" 
      ? <ArrowUp className="w-3 h-3 text-purple-700 inline ml-1" />
      : <ArrowDown className="w-3 h-3 text-purple-700 inline ml-1" />;
  };

  return (
    <div className="space-y-6 animate-fade-in">
      {/* 1. TOP CUSTOMER KPI STRIP */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-2.5 sm:gap-4">
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Active Clients
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-[#2b1f55] mt-1 sm:mt-2 truncate">
                <AnimatedCounter value={topCustomers.length} duration={600} suffix=" Parties" />
              </h3>
              <p className="text-[9px] sm:text-[11px] text-purple-700 font-semibold mt-0.5 truncate">
                Audited Corporate Accounts
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200 shadow-xs shrink-0">
              <Users className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Top 5 Concentration
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-purple-900 mt-1 sm:mt-2 truncate">
                {top5Share}%
              </h3>
              <p className="text-[9px] sm:text-[11px] text-emerald-700 font-semibold mt-0.5 truncate">
                {formatCurrency(top5Gross)} Combined
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-purple-700 border border-purple-200 shadow-xs shrink-0">
              <TrendingUp className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Total Client Invoices
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-blue-900 mt-1 sm:mt-2 truncate">
                <AnimatedCounter value={totalCustomerInvoices} duration={600} suffix=" Invoices" />
              </h3>
              <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 truncate">
                Tax Bills Reconciled
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shadow-xs shrink-0">
              <Receipt className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Avg Gross / Client
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-emerald-800 mt-1 sm:mt-2 truncate">
                {formatCurrency(avgRevenuePerClient)}
              </h3>
              <p className="text-[9px] sm:text-[11px] text-slate-500 font-medium mt-0.5 truncate">
                Portfolio Mean Value
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 shadow-xs shrink-0">
              <Award className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>
      </div>

      {/* 2. VISUAL CHARTS: CUSTOMER SALES & INVOICES COMPARISON */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* Chart 1: Top 10 Clients by Gross Sales */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <BarChart3 className="w-4 h-4 text-[#2b1f55] shrink-0" />
              Top 10 Enterprise Clients by Sales Realization
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold shrink-0">
              Gross Realization
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Gross sales volume generated by lead export-import & logistics clients
          </p>

          <div className="h-72 w-full">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={topCustomerRevenueChart} margin={{ top: 15, right: 15, left: 15, bottom: 65 }}>
                <defs>
                  <linearGradient id="custGrossGrad" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#2b1f55" stopOpacity={1}/>
                    <stop offset="100%" stopColor="#4338ca" stopOpacity={0.85}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                <XAxis 
                  dataKey="name" 
                  angle={-30} 
                  textAnchor="end" 
                  height={60}
                  interval={0}
                  tick={{ fontSize: 10.5, fill: "#475569", fontWeight: 600 }} 
                />
                <YAxis 
                  tickFormatter={(val) => val >= 10000000 ? "₹" + (val/10000000).toFixed(0) + "Cr" : "₹" + (val/100000).toFixed(0) + "L"} 
                  tick={{ fontSize: 10, fill: "#64748b" }} 
                />
                <Tooltip content={<CustomChartTooltip />} />
                <Bar 
                  dataKey="revenue" 
                  name="Gross Sales (₹)" 
                  fill="url(#custGrossGrad)" 
                  radius={[6, 6, 0, 0]} 
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Chart 2: Top Clients by Billed Invoices & Base Sales */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Receipt className="w-4 h-4 text-[#ff6a00] shrink-0" />
              Top Clients by Billed Invoices & Base Sales
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-orange-100 text-[#ff6a00] rounded-full font-bold shrink-0">
              Activity & Throughput
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Total distinct tax invoices generated vs taxable base billing
          </p>

          <div className="h-72 w-full">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={topCustomerVolumeChart} margin={{ top: 15, right: 15, left: 15, bottom: 65 }}>
                <defs>
                  <linearGradient id="custInvsGrad" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#ff6a00" stopOpacity={1}/>
                    <stop offset="100%" stopColor="#ea580c" stopOpacity={0.85}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                <XAxis 
                  dataKey="name" 
                  angle={-30} 
                  textAnchor="end" 
                  height={60}
                  interval={0}
                  tick={{ fontSize: 10.5, fill: "#475569", fontWeight: 600 }} 
                />
                <YAxis 
                  tickFormatter={(val) => formatNumber(val)} 
                  tick={{ fontSize: 10, fill: "#64748b" }} 
                />
                <Tooltip content={<CustomChartTooltip />} />
                <Legend />
                <Bar 
                  dataKey="invoices" 
                  name="Invoices Audited" 
                  fill="url(#custInvsGrad)" 
                  radius={[6, 6, 0, 0]} 
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      {/* 3. CUSTOMER DATA TABLE WITH SEARCH & SORT */}
      <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
        <div className="flex flex-col sm:flex-row items-stretch sm:items-center justify-between gap-3">
          <div className="flex items-center gap-2 flex-1 max-w-md">
            <div className="relative w-full">
              <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
              <input
                type="text"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                placeholder="Search enterprise client by name or party..."
                className="w-full pl-9 pr-4 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:outline-none focus:ring-2 focus:ring-[#2b1f55] transition-all"
              />
            </div>
          </div>

          <div className="flex items-center gap-2">
            <span className="text-xs text-slate-500 font-medium">Sort By:</span>
            <select
              value={sortBy}
              onChange={(e) => setSortBy(e.target.value)}
              className="px-3 py-1.5 bg-slate-50 border border-slate-200 rounded-xl text-xs font-bold text-slate-700 focus:outline-none cursor-pointer"
            >
              <option value="grossRevenue">Gross Sales (₹)</option>
              <option value="invoiceCount">Invoices Count</option>
              <option value="billAmount">Net Billed (Base)</option>
              <option value="taxAmount">GST Tax (18%)</option>
              <option value="customerName">Client Name (A-Z)</option>
            </select>
            <button
              onClick={() => setSortOrder(prev => prev === "asc" ? "desc" : "asc")}
              className="px-3 py-1.5 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all border border-slate-200"
            >
              {sortOrder === "asc" ? "↑ Asc" : "↓ Desc"}
            </button>
          </div>
        </div>

        <div className="overflow-x-auto rounded-2xl border border-slate-200">
          <table className="w-full text-left text-xs border-collapse">
            <thead>
              <tr className="bg-slate-100 text-slate-700 font-bold border-b border-slate-200 select-none">
                <th className="py-3 px-4 w-12 text-center text-slate-500">#</th>
                <th 
                  onClick={() => handleSort("customerName")}
                  className="py-3 px-4 cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Customer Account Name <SortIcon field="customerName" />
                </th>
                <th 
                  onClick={() => handleSort("invoiceCount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Invoices <SortIcon field="invoiceCount" />
                </th>
                <th 
                  onClick={() => handleSort("billAmount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Net Billed (Base) <SortIcon field="billAmount" />
                </th>
                <th 
                  onClick={() => handleSort("taxAmount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  GST (18%) <SortIcon field="taxAmount" />
                </th>
                <th 
                  onClick={() => handleSort("grossRevenue")}
                  className="py-3 px-4 text-right font-black text-[#2b1f55] cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Gross Sales (₹) <SortIcon field="grossRevenue" />
                </th>
                <th className="py-3 px-4 text-right">Contribution & Share</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredCustomers.length === 0 ? (
                <tr>
                  <td colSpan="7" className="py-8 text-center text-slate-400 font-medium">
                    No customer accounts match your search.
                  </td>
                </tr>
              ) : (
                filteredCustomers.map((c, idx) => {
                  const share = ((c.grossRevenue / grandTotalGross) * 100).toFixed(2);
                  const isTopTier = idx < 3;
                  return (
                    <tr 
                      key={idx} 
                      className={`transition-colors ${
                        isTopTier 
                          ? "bg-purple-50/40 hover:bg-purple-50/80" 
                          : idx % 2 === 0 
                          ? "bg-white hover:bg-slate-50" 
                          : "bg-slate-50/40 hover:bg-slate-50"
                      }`}
                    >
                      <td className="py-3 px-4 text-center">
                        <span className={`w-6 h-6 rounded-full inline-flex items-center justify-center font-bold text-[10px] ${
                          idx === 0 ? "bg-amber-400 text-slate-900 shadow-sm" :
                          idx === 1 ? "bg-slate-300 text-slate-800" :
                          idx === 2 ? "bg-amber-700 text-white" :
                          "bg-slate-100 text-slate-600"
                        }`}>
                          {idx + 1}
                        </span>
                      </td>
                      <td className="py-3 px-4">
                        <div className="font-bold text-slate-900 text-xs flex items-center gap-1.5">
                          <span className="truncate max-w-[280px]" title={c.customerName || c.name}>
                            {c.customerName || c.name}
                          </span>
                          {isTopTier && (
                            <span className="text-[9px] px-1.5 py-0.2 bg-purple-100 text-[#2b1f55] rounded-md font-bold shrink-0">
                              Platinum Client
                            </span>
                          )}
                        </div>
                        {c.city && <span className="text-[10px] text-slate-400">{c.city}</span>}
                      </td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-700">
                        {formatNumber(c.invoiceCount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono text-slate-600">
                        {formatCurrency(c.billAmount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono text-emerald-700">
                        {formatCurrency(c.taxAmount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono font-black text-[#2b1f55] text-xs">
                        {formatCurrency(c.grossRevenue)}
                      </td>
                      <td className="py-3 px-4 text-right">
                        <div className="flex items-center justify-end gap-2">
                          <div className="w-16 bg-slate-100 rounded-full h-1.5 overflow-hidden hidden sm:block">
                            <div 
                              className="bg-purple-700 h-full rounded-full" 
                              style={{ width: Math.min(100, Math.max(2, Number(share) * 2)) + "%" }}
                            />
                          </div>
                          <span className="font-mono font-bold text-purple-700 text-xs shrink-0">{share}%</span>
                        </div>
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export function ServiceCatalogTable({
  topServices = [],
}) {
  const [searchTerm, setSearchTerm] = useState("");
  const [sortBy, setSortBy] = useState("grossRevenue");
  const [sortOrder, setSortOrder] = useState("desc");

  const totalServiceGross = topServices.reduce((sum, s) => sum + (s.grossRevenue || 0), 0) || 1;
  const totalLineItems = topServices.reduce((sum, s) => sum + (s.itemCount || 0), 0);
  const avgLineItemVal = totalLineItems > 0 ? (totalServiceGross / totalLineItems) : 0;

  // Chart 1: Top 10 Services by Gross Revenue
  const topServiceRevenueChart = useMemo(() => {
    return topServices.slice(0, 10).map((s, idx) => {
      const name = s.serviceName || "Service " + (idx + 1);
      const shortName = name.length > 16 ? name.substring(0, 14) + ".." : name;
      return {
        name: shortName,
        fullName: name,
        revenue: s.grossRevenue || 0,
        billAmount: s.billAmount || 0,
        itemCount: s.itemCount || 0
      };
    });
  }, [topServices]);

  // Chart 2: Top Services by Line Items Volume
  const topServiceVolumeChart = useMemo(() => {
    return [...topServices]
      .sort((a, b) => (b.itemCount || 0) - (a.itemCount || 0))
      .slice(0, 10)
      .map((s, idx) => {
        const name = s.serviceName || "Service " + (idx + 1);
        const shortName = name.length > 16 ? name.substring(0, 14) + ".." : name;
        return {
          name: shortName,
          fullName: name,
          itemCount: s.itemCount || 0,
          revenue: s.grossRevenue || 0
        };
      });
  }, [topServices]);

  const filteredServices = useMemo(() => {
    let list = [...topServices];
    if (searchTerm) {
      const q = searchTerm.toLowerCase().trim();
      list = list.filter(s => (s.serviceName || "").toLowerCase().includes(q));
    }
    return list.sort((a, b) => {
      if (sortBy === "serviceName") {
        return sortOrder === "asc"
          ? (a.serviceName || "").localeCompare(b.serviceName || "")
          : (b.serviceName || "").localeCompare(a.serviceName || "");
      }
      const valA = Number(a[sortBy]) || 0;
      const valB = Number(b[sortBy]) || 0;
      return sortOrder === "asc" ? valA - valB : valB - valA;
    });
  }, [topServices, searchTerm, sortBy, sortOrder]);

  const handleSort = (field) => {
    if (sortBy === field) {
      setSortOrder(prev => (prev === "asc" ? "desc" : "asc"));
    } else {
      setSortBy(field);
      setSortOrder("desc");
    }
  };

  const SortIcon = ({ field }) => {
    if (sortBy !== field) return <ArrowUpDown className="w-3 h-3 text-slate-400 inline ml-1 opacity-0 group-hover:opacity-100 transition-opacity" />;
    return sortOrder === "asc" 
      ? <ArrowUp className="w-3 h-3 text-orange-600 inline ml-1" />
      : <ArrowDown className="w-3 h-3 text-orange-600 inline ml-1" />;
  };

  return (
    <div className="space-y-6 animate-fade-in">
      {/* 1. SERVICE KPI STRIP */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-2.5 sm:gap-4">
        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Service Categories
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-orange-600 mt-1 sm:mt-2 truncate">
                <AnimatedCounter value={topServices.length} duration={600} suffix=" Tariff Heads" />
              </h3>
              <p className="text-[9px] sm:text-[11px] text-orange-700 font-semibold mt-0.5 truncate">
                Operational Billing Heads
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-orange-50 text-orange-600 border border-orange-200 shadow-xs shrink-0">
              <Layers className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Total Billed Items
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-blue-900 mt-1 sm:mt-2 truncate">
                <AnimatedCounter value={totalLineItems} duration={600} suffix=" Items" />
              </h3>
              <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 truncate">
                Distinct Job Line Entries
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shadow-xs shrink-0">
              <Receipt className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Total Service Gross
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-[#2b1f55] mt-1 sm:mt-2 truncate">
                {formatCurrency(totalServiceGross)}
              </h3>
              <p className="text-[9px] sm:text-[11px] text-purple-700 font-semibold mt-0.5 truncate">
                Catalog Turnover
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-purple-700 border border-purple-200 shadow-xs shrink-0">
              <TrendingUp className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
          <div className="flex items-start justify-between gap-1">
            <div className="min-w-0 flex-1">
              <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                Avg Ticket / Line Item
              </p>
              <h3 className="text-sm sm:text-2xl font-black font-display text-emerald-800 mt-1 sm:mt-2 truncate">
                {formatCurrency(avgLineItemVal)}
              </h3>
              <p className="text-[9px] sm:text-[11px] text-slate-500 font-medium mt-0.5 truncate">
                Yield per Operation
              </p>
            </div>
            <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 shadow-xs shrink-0">
              <Award className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
            </div>
          </div>
        </div>
      </div>

      {/* 2. VISUAL CHARTS: SERVICE SALES & LINE ITEMS */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* Chart 1: Top Services by Gross Sales */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <BarChart3 className="w-4 h-4 text-[#ff6a00] shrink-0" />
              Top 10 Logistics Services by Gross Realization
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-orange-100 text-[#ff6a00] rounded-full font-bold shrink-0">
              Revenue Yield
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Core revenue-generating tariff heads across road, rail, ocean, and CFS
          </p>

          <div className="h-72 w-full">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={topServiceRevenueChart} margin={{ top: 15, right: 15, left: 15, bottom: 65 }}>
                <defs>
                  <linearGradient id="serviceGrossGrad" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#ff6a00" stopOpacity={1}/>
                    <stop offset="100%" stopColor="#ea580c" stopOpacity={0.85}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                <XAxis 
                  dataKey="name" 
                  angle={-30} 
                  textAnchor="end" 
                  height={60}
                  interval={0}
                  tick={{ fontSize: 10.5, fill: "#475569", fontWeight: 600 }} 
                />
                <YAxis 
                  tickFormatter={(val) => val >= 10000000 ? "₹" + (val/10000000).toFixed(0) + "Cr" : "₹" + (val/100000).toFixed(0) + "L"} 
                  tick={{ fontSize: 10, fill: "#64748b" }} 
                />
                <Tooltip content={<CustomChartTooltip />} />
                <Bar 
                  dataKey="revenue" 
                  name="Gross Sales (₹)" 
                  fill="url(#serviceGrossGrad)" 
                  radius={[6, 6, 0, 0]} 
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Chart 2: Top Services by Line Items Count */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Layers className="w-4 h-4 text-[#2b1f55] shrink-0" />
              Service Line Items & Job Execution Volume
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold shrink-0">
              Operations Volume
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Total number of operational tasks and charge heads billed
          </p>

          <div className="h-72 w-full">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={topServiceVolumeChart} margin={{ top: 15, right: 15, left: 15, bottom: 65 }}>
                <defs>
                  <linearGradient id="serviceVolGrad" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#2b1f55" stopOpacity={1}/>
                    <stop offset="100%" stopColor="#4338ca" stopOpacity={0.85}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                <XAxis 
                  dataKey="name" 
                  angle={-30} 
                  textAnchor="end" 
                  height={60}
                  interval={0}
                  tick={{ fontSize: 10.5, fill: "#475569", fontWeight: 600 }} 
                />
                <YAxis 
                  tickFormatter={(val) => formatNumber(val)} 
                  tick={{ fontSize: 10, fill: "#64748b" }} 
                />
                <Tooltip content={<CustomChartTooltip />} />
                <Bar 
                  dataKey="itemCount" 
                  name="Line Items Billed" 
                  fill="url(#serviceVolGrad)" 
                  radius={[6, 6, 0, 0]} 
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      {/* 3. SERVICE CATALOG DATA TABLE */}
      <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
        <div className="flex flex-col sm:flex-row items-stretch sm:items-center justify-between gap-3">
          <div className="flex items-center gap-2 flex-1 max-w-md">
            <div className="relative w-full">
              <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
              <input
                type="text"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                placeholder="Search logistics service description or head..."
                className="w-full pl-9 pr-4 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:outline-none focus:ring-2 focus:ring-[#ff6a00] transition-all"
              />
            </div>
          </div>

          <div className="flex items-center gap-2">
            <span className="text-xs text-slate-500 font-medium">Sort By:</span>
            <select
              value={sortBy}
              onChange={(e) => setSortBy(e.target.value)}
              className="px-3 py-1.5 bg-slate-50 border border-slate-200 rounded-xl text-xs font-bold text-slate-700 focus:outline-none cursor-pointer"
            >
              <option value="grossRevenue">Gross Sales (₹)</option>
              <option value="itemCount">Line Items Billed</option>
              <option value="billAmount">Net Billed (Base)</option>
              <option value="taxAmount">GST Tax (18%)</option>
              <option value="serviceName">Service Name (A-Z)</option>
            </select>
            <button
              onClick={() => setSortOrder(prev => prev === "asc" ? "desc" : "asc")}
              className="px-3 py-1.5 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all border border-slate-200"
            >
              {sortOrder === "asc" ? "↑ Asc" : "↓ Desc"}
            </button>
          </div>
        </div>

        <div className="overflow-x-auto rounded-2xl border border-slate-200">
          <table className="w-full text-left text-xs border-collapse">
            <thead>
              <tr className="bg-slate-100 text-slate-700 font-bold border-b border-slate-200 select-none">
                <th className="py-3 px-4 w-12 text-center text-slate-500">#</th>
                <th 
                  onClick={() => handleSort("serviceName")}
                  className="py-3 px-4 cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Service Description <SortIcon field="serviceName" />
                </th>
                <th 
                  onClick={() => handleSort("itemCount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Line Items Billed <SortIcon field="itemCount" />
                </th>
                <th 
                  onClick={() => handleSort("billAmount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Net Billed (Base) <SortIcon field="billAmount" />
                </th>
                <th 
                  onClick={() => handleSort("taxAmount")}
                  className="py-3 px-4 text-right cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  GST (18%) <SortIcon field="taxAmount" />
                </th>
                <th 
                  onClick={() => handleSort("grossRevenue")}
                  className="py-3 px-4 text-right font-black text-[#ff6a00] cursor-pointer hover:bg-slate-200/80 transition-colors group"
                >
                  Gross Sales (₹) <SortIcon field="grossRevenue" />
                </th>
                <th className="py-3 px-4 text-right">Avg / Line Item</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredServices.length === 0 ? (
                <tr>
                  <td colSpan="7" className="py-8 text-center text-slate-400 font-medium">
                    No service heads match your search.
                  </td>
                </tr>
              ) : (
                filteredServices.map((s, idx) => {
                  const avg = s.itemCount > 0 ? (s.billAmount / s.itemCount) : 0;
                  const share = ((s.grossRevenue / totalServiceGross) * 100).toFixed(1);
                  return (
                    <tr 
                      key={idx} 
                      className={idx % 2 === 0 ? "bg-white hover:bg-slate-50" : "bg-slate-50/40 hover:bg-slate-50"}
                    >
                      <td className="py-3 px-4 text-center font-bold text-slate-400">{idx + 1}</td>
                      <td className="py-3 px-4 font-bold text-slate-900">
                        <div className="flex items-center gap-2">
                          <span className="truncate max-w-[280px]" title={s.serviceName}>{s.serviceName}</span>
                          <span className="text-[9px] px-1.5 py-0.2 bg-orange-50 text-orange-700 border border-orange-200 rounded font-semibold shrink-0">
                            {share}% Share
                          </span>
                        </div>
                      </td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-700">
                        {formatNumber(s.itemCount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono text-slate-600">
                        {formatCurrency(s.billAmount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono text-emerald-700">
                        {formatCurrency(s.taxAmount)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono font-black text-[#ff6a00] text-xs">
                        {formatCurrency(s.grossRevenue)}
                      </td>
                      <td className="py-3 px-4 text-right font-mono font-bold text-slate-800">
                        {formatCurrency(avg)}
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
