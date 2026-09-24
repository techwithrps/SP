import React from 'react';
import { Users, Layers } from 'lucide-react';
import { formatCurrency, formatNumber } from './analyticsUtils';

export function CustomerLeaderboardTable({
  topCustomers = [],
  dynamicMetrics = {},
  dbTotals = {},
}) {
  return (
    <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
      <div className="flex items-center justify-between">
        <div>
          <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
            <Users className="w-4 h-4 text-[#2b1f55]" /> Enterprise Customer Leaderboard
          </h4>
          <p className="text-xs text-slate-500">
            Highest gross sales generating accounts across all CFS terminals
          </p>
        </div>
        <span className="text-xs font-mono font-bold text-purple-900 bg-purple-50 px-3 py-1 rounded-xl border border-purple-200">
          {topCustomers.length} Active Accounts
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
              <th className="py-3 px-4 text-right font-black text-[#2b1f55]">Gross Sales</th>
              <th className="py-3 px-4 text-right">Contribution</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-100">
            {topCustomers.map((c, idx) => {
              const share = ((c.grossRevenue / (dynamicMetrics.grossSale || dbTotals.grandSystemRevenue || 1)) * 100).toFixed(2);
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
  );
}

export function ServiceCatalogTable({
  topServices = [],
}) {
  return (
    <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
      <div className="flex items-center justify-between">
        <div>
          <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2">
            <Layers className="w-4 h-4 text-[#ff6a00]" /> Logistics Service Catalog & Tariff Breakdown
          </h4>
          <p className="text-xs text-slate-500">
            Highest yielding logistics services and terminal charge heads
          </p>
        </div>
        <span className="text-xs font-mono font-bold text-orange-900 bg-orange-50 px-3 py-1 rounded-xl border border-orange-200">
          {topServices.length} Service Categories
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
              <th className="py-3 px-4 text-right font-black text-[#ff6a00]">Gross Sales</th>
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
  );
}
