import React, { useState } from 'react';
import { 
  Users, 
  Building2, 
  FileText, 
  IndianRupee, 
  ChevronDown, 
  ChevronUp, 
  Filter, 
  CheckCircle2, 
  Layers,
  ArrowRight
} from 'lucide-react';

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  return `₹ ${num.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

export default function CustomerWiseSalesSummary({
  customerWise = [],
  selectedCustomer = 'ALL',
  onSelectCustomer,
  kpis = {}
}) {
  const [isOpen, setIsOpen] = useState(true);
  const [searchFilter, setSearchFilter] = useState('');

  if (!customerWise || customerWise.length === 0) return null;

  const filteredList = customerWise.filter(c => {
    if (!searchFilter) return true;
    return (c.customerName || '').toLowerCase().includes(searchFilter.toLowerCase());
  });

  return (
    <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden transition-all animate-fade-in">
      
      {/* Header Bar */}
      <div 
        onClick={() => setIsOpen(!isOpen)}
        className="p-4 sm:p-5 bg-gradient-to-r from-slate-50 via-purple-50/30 to-slate-50 border-b border-slate-200 flex items-center justify-between cursor-pointer select-none hover:bg-slate-100/60 transition-colors"
      >
        <div className="flex items-center gap-3">
          <div className="w-10 h-10 rounded-xl bg-purple-100 text-[#2b1f55] border border-purple-200 flex items-center justify-center shrink-0 shadow-xs">
            <Users className="w-5 h-5 text-[#2b1f55]" />
          </div>
          <div>
            <div className="flex items-center gap-2">
              <h3 className="font-display font-extrabold text-sm sm:text-base text-[#2b1f55]">
                Customer-Wise Sales & Branch Ledger Summary
              </h3>
              <span className="px-2 py-0.5 rounded-full text-[10px] font-extrabold bg-[#2b1f55] text-white">
                {customerWise.length} Active Clients
              </span>
            </div>
            <p className="text-xs text-slate-500 mt-0.5">
              Consolidated sales revenue, GST statutory output, and branch terminal presence per customer
            </p>
          </div>
        </div>

        <div className="flex items-center gap-3">
          <div className="hidden md:flex items-center gap-2 text-xs font-semibold text-slate-600 bg-white px-3 py-1.5 rounded-xl border border-slate-200 shadow-xs">
            <span>Scope Total:</span>
            <span className="text-emerald-700 font-bold font-mono">
              {formatCurrency(kpis.netRevenue || kpis.grossRevenue || kpis.totalGrossAmount)}
            </span>
          </div>

          <button className="p-2 rounded-xl bg-white hover:bg-slate-100 border border-slate-200 text-slate-600 transition-colors">
            {isOpen ? <ChevronUp className="w-4 h-4" /> : <ChevronDown className="w-4 h-4" />}
          </button>
        </div>
      </div>

      {/* Collapsible Content */}
      {isOpen && (
        <div className="p-4 sm:p-5 space-y-4">
          
          {/* Quick Search inside customer summary */}
          {customerWise.length > 5 && (
            <div className="flex items-center justify-between gap-3">
              <input
                type="text"
                placeholder="Filter customer in this ledger..."
                value={searchFilter}
                onChange={(e) => setSearchFilter(e.target.value)}
                onClick={(e) => e.stopPropagation()}
                className="w-full sm:w-80 px-3.5 py-1.5 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
              />
              <span className="text-[11px] text-slate-500 font-medium">
                Showing {filteredList.length} of {customerWise.length} customers
              </span>
            </div>
          )}

          {/* Table Grid */}
          <div className="overflow-x-auto border border-slate-200 rounded-xl max-h-[380px] overflow-y-auto">
            <table className="w-full text-left text-xs border-collapse">
              <thead className="bg-slate-100/80 sticky top-0 z-10 text-slate-600 font-bold uppercase tracking-wider text-[10px] border-b border-slate-200">
                <tr>
                  <th className="p-3 w-10 text-center">#</th>
                  <th className="p-3">Customer / Account Party</th>
                  <th className="p-3">Active Branch Terminals</th>
                  <th className="p-3 text-right">Bills / Invoices</th>
                  <th className="p-3 text-right">Taxable Base</th>
                  <th className="p-3 text-right">GST (18%)</th>
                  <th className="p-3 text-right">Gross Total Sales</th>
                  <th className="p-3 text-center w-24">Action</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filteredList.map((c, idx) => {
                  const isCurrent = 
                    selectedCustomer && 
                    selectedCustomer !== 'ALL' && 
                    (String(selectedCustomer).toLowerCase() === String(c.customerId).toLowerCase() || 
                     String(selectedCustomer).toLowerCase() === String(c.customerName).toLowerCase());

                  return (
                    <tr 
                      key={c.customerId || idx} 
                      className={`transition-colors hover:bg-purple-50/40 ${
                        isCurrent ? 'bg-purple-50/80 font-semibold' : 'bg-white'
                      }`}
                    >
                      <td className="p-3 text-center text-slate-400 font-mono text-[11px]">
                        {idx + 1}
                      </td>

                      <td className="p-3">
                        <div className="flex items-center gap-2">
                          <span className="w-2 h-2 rounded-full bg-emerald-500 shrink-0"></span>
                          <span className="font-bold text-slate-900 line-clamp-1" title={c.customerName}>
                            {c.customerName}
                          </span>
                        </div>
                      </td>

                      <td className="p-3">
                        <div className="flex flex-wrap items-center gap-1">
                          <span className="px-2 py-0.5 rounded-md text-[10px] font-bold bg-purple-100 text-purple-800 border border-purple-200 shrink-0">
                            {c.terminalCount || (c.terminals ? c.terminals.length : 1)} Hubs
                          </span>
                          <span className="text-[11px] text-slate-600 line-clamp-1 max-w-[220px]" title={(c.terminals || []).join(', ')}>
                            {(c.terminals && c.terminals.length > 0) ? c.terminals.slice(0, 3).join(', ') : 'SPJ Live'}
                            {c.terminals && c.terminals.length > 3 ? ` +${c.terminals.length - 3} more` : ''}
                          </span>
                        </div>
                      </td>

                      <td className="p-3 text-right font-mono font-semibold text-slate-700">
                        {formatNumber(c.invoiceCount)}
                      </td>

                      <td className="p-3 text-right font-mono text-slate-600">
                        {formatCurrency(c.billAmount)}
                      </td>

                      <td className="p-3 text-right font-mono text-emerald-700 font-medium">
                        {formatCurrency(c.taxAmount)}
                      </td>

                      <td className="p-3 text-right font-mono font-black text-[#2b1f55]">
                        {formatCurrency(c.grossAmount || c.netRevenue)}
                      </td>

                      <td className="p-3 text-center">
                        <button
                          onClick={(e) => {
                            e.stopPropagation();
                            if (onSelectCustomer) {
                              onSelectCustomer(isCurrent ? 'ALL' : (c.customerId || c.customerName));
                            }
                          }}
                          className={`inline-flex items-center gap-1 px-2.5 py-1 rounded-lg text-[10px] font-bold transition-all shadow-xs cursor-pointer ${
                            isCurrent 
                              ? 'bg-rose-100 hover:bg-rose-200 text-rose-700 border border-rose-300'
                              : 'bg-slate-100 hover:bg-[#2b1f55] hover:text-white text-slate-700 border border-slate-200'
                          }`}
                        >
                          {isCurrent ? 'Clear' : 'Filter'}
                        </button>
                      </td>
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
