import React from 'react';
import { Calendar } from 'lucide-react';
import { ResponsiveContainer, AreaChart, Area, XAxis, YAxis, Tooltip, CartesianGrid, Legend } from 'recharts';
import { formatCurrency, formatNumber, CustomChartTooltip } from './analyticsUtils';

export default function YoYAnalyticsSection({
  yoyChartData = [],
  selectedTerminal = 'ALL',
  terminals = [],
}) {
  const terminalName = selectedTerminal === 'ALL'
    ? 'All Terminals'
    : terminals.find(t => t.terminalId === Number(selectedTerminal))?.terminalName || 'Selected Terminal';

  return (
    <div className="space-y-6">
      <div className="bg-white p-6 rounded-3xl border border-slate-200 shadow-soft">
        <h4 className="text-base font-bold text-slate-800 mb-1 flex items-center gap-2">
          <Calendar className="w-5 h-5 text-[#2b1f55]" /> Fiscal Year Growth & Invoiced Sales Trajectory
        </h4>
        <p className="text-xs text-slate-500 mb-6">
          Multi-year financial trend comparison for {terminalName}
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
              <Area type="monotone" dataKey="grossRevenue" name="Gross Invoiced Sales" stroke="#2b1f55" strokeWidth={3} fillOpacity={1} fill="url(#grossGrad)" />
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
  );
}
