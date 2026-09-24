import React from 'react';
import { Award, CheckCircle2, ShieldCheck, Users, Layers } from 'lucide-react';
import { formatCurrency, formatNumber } from './analyticsUtils';

export default function ExecutiveDecisionBI({
  topCustomers = [],
  topServices = [],
  dynamicMetrics = {},
  dbTotals = {},
}) {
  return (
    <div className="space-y-4 sm:space-y-6">
      {/* Executive Strategic Highlights (2-Column Grid on Mobile/Tablet) */}
      <div className="grid grid-cols-1 sm:grid-cols-3 gap-2.5 sm:gap-6">
        <div className="bg-gradient-to-br from-purple-900 to-[#2b1f55] text-white p-3.5 sm:p-6 rounded-2xl sm:rounded-3xl shadow-xl">
          <div className="p-2 sm:p-3 bg-white/10 rounded-xl sm:rounded-2xl w-fit mb-2 sm:mb-4">
            <Award className="w-4 h-4 sm:w-6 sm:h-6 text-orange-400" />
          </div>
          <h4 className="text-sm sm:text-lg font-bold mb-1 sm:mb-2">Key Sales Driver: Dadri CFS</h4>
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
        {/* Top Sales Contributing Customers */}
        <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
          <h4 className="text-sm font-bold text-slate-800 mb-1 flex items-center gap-2">
            <Users className="w-4 h-4 text-[#2b1f55]" /> Top 10 Enterprise Clients by Sales
          </h4>
          <p className="text-xs text-slate-500 mb-4">
            Key frozen food exporters, freight forwarders, and liner accounts
          </p>
          <div className="space-y-3">
            {topCustomers.slice(0, 8).map((c, idx) => {
              const share = ((c.grossRevenue / (dynamicMetrics.grossSale || dbTotals.grandSystemRevenue || 1)) * 100).toFixed(1);
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
            Core billing service heads and operational sales streams
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
  );
}
