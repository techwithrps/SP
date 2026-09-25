import React, { useMemo } from 'react';
import { Search, BarChart3, Container, Building2, Users, Award, TrendingUp, Sparkles, Receipt } from 'lucide-react';
import { ResponsiveContainer, BarChart, Bar, XAxis, YAxis, Tooltip, CartesianGrid, Legend } from 'recharts';
import { formatCurrency, formatNumber, CustomChartTooltip } from './analyticsUtils';

export default function BranchPerformanceTable({
  topRevenueChart = [],
  topVolumeChart = [],
  displayTerminals = [],
  topCustomers = [],
  dynamicMetrics = {},
  selectedFY = 'ALL',
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  searchTerminal = '',
  setSearchTerminal,
  sortBy = 'netRevenue',
  setSortBy,
  sortOrder = 'desc',
  setSortOrder,
  handleSortHeader,
  SortIcon,
  customerName = null,
  companyName = null,
}) {
  const totalGross = useMemo(() => {
    return dynamicMetrics?.grossSale || displayTerminals.reduce((s, t) => s + Number(t.grossSale || t.netRevenue || 0), 0) || 1;
  }, [dynamicMetrics, displayTerminals]);

  const top10Branches = useMemo(() => {
    return [...displayTerminals]
      .sort((a, b) => (Number(b.grossSale || b.netRevenue || 0) - Number(a.grossSale || a.netRevenue || 0)))
      .slice(0, 10);
  }, [displayTerminals]);

  const top10Customers = useMemo(() => {
    return [...(topCustomers || [])]
      .sort((a, b) => (Number(b.grossRevenue || 0) - Number(a.grossRevenue || 0)))
      .slice(0, 10);
  }, [topCustomers]);

  return (
    <div className="space-y-6">
      {/* DUAL EXECUTIVE LEADERBOARDS: LEFT = BRANCHES, RIGHT = CUSTOMERS */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* LEFT COLUMN: Top 10 Branches by Sales */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Building2 className="w-4 h-4 text-[#2b1f55] shrink-0" />
              Top 10 Branches by Sales
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold shrink-0">
              {displayTerminals.length} Active Branches
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Key railhead hubs, container freight stations, and ICD terminals
          </p>
          <div className="space-y-2.5">
            {top10Branches.map((b, idx) => {
              const gross = Number(b.grossSale || b.netRevenue || 0);
              const share = ((gross / totalGross) * 100).toFixed(1);
              const containers = Number(b.displayContainers || b.totalContainers || 0);
              const invoices = Number(b.invoiceCount || 0);
              return (
                <div key={idx} className="p-3 bg-slate-50 hover:bg-purple-50/40 rounded-2xl border border-slate-100 transition-colors flex items-center justify-between gap-2">
                  <div className="flex items-center gap-3 min-w-0">
                    <span className="w-6 h-6 rounded-full bg-[#2b1f55] text-white flex items-center justify-center font-bold text-[10px] shrink-0">
                      {idx + 1}
                    </span>
                    <div className="min-w-0">
                      <p className="font-bold text-slate-900 text-xs truncate uppercase" title={b.terminalName}>
                        {b.terminalName}
                      </p>
                      <p className="text-[10px] text-slate-500">
                        {formatNumber(containers)} Containers · {formatNumber(invoices)} Invoices
                      </p>
                    </div>
                  </div>
                  <div className="text-right shrink-0">
                    <p className="font-mono font-bold text-slate-900 text-xs">{formatCurrency(gross)}</p>
                    <p className="text-[10px] text-emerald-600 font-semibold">{share}% Share</p>
                  </div>
                </div>
              );
            })}
          </div>
        </div>

        {/* RIGHT COLUMN: Top 10 Enterprise Clients by Sales */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between mb-1">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Users className="w-4 h-4 text-[#ff6a00] shrink-0" />
              Top 10 Enterprise Clients by Sales
            </h4>
            <span className="text-[10px] px-2.5 py-0.5 bg-orange-100 text-[#ff6a00] rounded-full font-bold shrink-0">
              {topCustomers.length} Active Clients
            </span>
          </div>
          <p className="text-xs text-slate-500 mb-4">
            Key frozen food exporters, freight forwarders, and liner accounts
          </p>
          <div className="space-y-2.5">
            {top10Customers.map((c, idx) => {
              const gross = Number(c.grossRevenue || 0);
              const share = ((gross / totalGross) * 100).toFixed(1);
              return (
                <div key={idx} className="p-3 bg-slate-50 hover:bg-orange-50/40 rounded-2xl border border-slate-100 transition-colors flex items-center justify-between gap-2">
                  <div className="flex items-center gap-3 min-w-0">
                    <span className="w-6 h-6 rounded-full bg-[#ff6a00] text-white flex items-center justify-center font-bold text-[10px] shrink-0">
                      {idx + 1}
                    </span>
                    <div className="min-w-0">
                      <p className="font-bold text-slate-900 text-xs truncate uppercase" title={c.customerName || c.name}>
                        {c.customerName || c.name}
                      </p>
                      <p className="text-[10px] text-slate-500">
                        {formatNumber(c.invoiceCount)} Invoices Audited
                      </p>
                    </div>
                  </div>
                  <div className="text-right shrink-0">
                    <p className="font-mono font-bold text-slate-900 text-xs">{formatCurrency(gross)}</p>
                    <p className="text-[10px] text-emerald-600 font-semibold">{share}% Share</p>
                  </div>
                </div>
              );
            })}
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
              <option value="netRevenue">Net Sales (Gross Sale)</option>
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
                  Net Sales (Gross Sale) <SortIcon field="netRevenue" />
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
                          className={`px-3 py-1.5 rounded-lg text-[11px] font-bold transition-all shadow-sm cursor-pointer ${
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

                  <div className="grid grid-cols-2 gap-1.5 text-[11px] mb-2.5">
                    <div className="bg-purple-50/60 p-2 rounded-xl border border-purple-100/80">
                      <div className="text-[9px] text-slate-500 font-medium">Gross Sales</div>
                      <div className="font-extrabold text-xs text-[#2b1f55] truncate">
                        {hasData ? formatCurrency(t.netRevenue) : '₹ 0'}
                      </div>
                    </div>

                    <div className="bg-amber-50/60 p-2 rounded-xl border border-amber-100/80">
                      <div className="text-[9px] text-slate-500 font-medium">Containers (TEUs)</div>
                      <div className="font-extrabold text-xs text-amber-900 truncate">
                        {hasData ? `${formatNumber(t.displayContainers)} (${formatNumber(t.displayTeus)} T)` : '0 Units'}
                      </div>
                    </div>

                    <div className="bg-slate-50 p-2 rounded-xl border border-slate-100">
                      <div className="text-[9px] text-slate-500 font-medium">Invoices & Jobs</div>
                      <div className="font-bold text-xs text-slate-700 truncate">
                        {hasData ? `${formatNumber(t.invoiceCount)} Inv • ${formatNumber(t.displayJobs)} Jobs` : '0 Inv'}
                      </div>
                    </div>

                    <div className="bg-slate-50 p-2 rounded-xl border border-slate-100">
                      <div className="text-[9px] text-slate-500 font-medium">Base / GST</div>
                      <div className="font-bold text-xs text-emerald-700 truncate">
                        {hasData ? `${formatCurrency(t.billAmount)} • ${formatCurrency(t.taxAmount)}` : '₹ 0'}
                      </div>
                    </div>
                  </div>

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
  );
}
