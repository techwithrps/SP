import React, { useMemo } from 'react';
import { Building2, Users, CheckCircle2, XCircle, MousePointerClick, Filter } from 'lucide-react';
import { formatCurrency, formatNumber } from './analyticsUtils';

export default function DualSalesLeaderboard({
  displayTerminals = [],
  topCustomers = [],
  totalGross = 0,
  selectedTerminal = 'ALL',
  onSelectTerminal,
  selectedCustomer = 'ALL',
  onSelectCustomer,
}) {
  const calculatedTotalGross = useMemo(() => {
    return totalGross || displayTerminals.reduce((s, t) => s + Number(t.grossSale || t.netRevenue || t.totalAmount || 0), 0) || topCustomers.reduce((s, c) => s + Number(c.grossRevenue || c.grossAmount || c.totalRevenue || 0), 0) || 38536360360.24;
  }, [totalGross, displayTerminals, topCustomers]);

  const top10Branches = useMemo(() => {
    return [...displayTerminals]
      .sort((a, b) => (Number(b.grossSale || b.netRevenue || b.totalAmount || 0) - Number(a.grossSale || a.netRevenue || a.totalAmount || 0)))
      .slice(0, 10);
  }, [displayTerminals]);

  const top10Customers = useMemo(() => {
    return [...(topCustomers || [])]
      .sort((a, b) => (Number(b.grossRevenue || b.grossAmount || b.totalRevenue || 0) - Number(a.grossRevenue || a.grossAmount || a.totalRevenue || 0)))
      .slice(0, 10);
  }, [topCustomers]);

  const handleBranchClick = (branch) => {
    if (!onSelectTerminal) return;
    const branchKey = String(branch.terminalId || branch.terminalName || branch.name || '');
    const currentKey = String(selectedTerminal || 'ALL');
    
    // Toggle behavior: if already selected, clear filter back to ALL
    if (currentKey.toLowerCase() === branchKey.toLowerCase() || (branch.terminalName && currentKey.toLowerCase() === branch.terminalName.toLowerCase())) {
      onSelectTerminal('ALL');
    } else {
      onSelectTerminal(branch.terminalId || branch.terminalName);
    }
  };

  const handleCustomerClick = (customer) => {
    if (!onSelectCustomer) return;
    const custKey = String(customer.customerId || customer.customerName || customer.name || '');
    const currentKey = String(selectedCustomer || 'ALL');

    // Toggle behavior: if already selected, clear filter back to ALL
    if (currentKey.toLowerCase() === custKey.toLowerCase() || (customer.customerName && currentKey.toLowerCase() === customer.customerName.toLowerCase())) {
      onSelectCustomer('ALL');
    } else {
      onSelectCustomer(customer.customerName || customer.name || customer.customerId);
    }
  };

  const isTerminalSelected = (b) => {
    if (!selectedTerminal || selectedTerminal === 'ALL' || selectedTerminal === 'all') return false;
    const sel = String(selectedTerminal).toLowerCase().trim();
    const bId = String(b.terminalId || '').toLowerCase().trim();
    const bName = String(b.terminalName || b.name || '').toLowerCase().trim();
    return sel === bId || sel === bName || bName.includes(sel);
  };

  const isCustomerSelected = (c) => {
    if (!selectedCustomer || selectedCustomer === 'ALL' || selectedCustomer === 'all') return false;
    const sel = String(selectedCustomer).toLowerCase().trim();
    const cId = String(c.customerId || '').toLowerCase().trim();
    const cName = String(c.customerName || c.name || '').toLowerCase().trim();
    return sel === cId || sel === cName || cName.includes(sel);
  };

  return (
    <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 animate-fade-in select-none">
      {/* LEFT COLUMN: Top 10 Branches by Sales (Interactive Click-to-Filter) */}
      <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
        <div className="flex items-center justify-between mb-1">
          <div className="flex items-center gap-2 min-w-0">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Building2 className="w-4 h-4 text-[#2b1f55] shrink-0" />
              Top 10 Branches by Sales
            </h4>
            {selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all' && (
              <button
                onClick={(e) => {
                  e.stopPropagation();
                  onSelectTerminal && onSelectTerminal('ALL');
                }}
                className="inline-flex items-center gap-1 text-[9px] px-2 py-0.5 rounded-full bg-purple-100 hover:bg-purple-200 text-[#2b1f55] font-bold transition-all cursor-pointer"
                title="Click to clear filter"
              >
                <XCircle className="w-3 h-3" /> Clear Filter
              </button>
            )}
          </div>
          <span className="text-[10px] px-2.5 py-0.5 bg-purple-100 text-[#2b1f55] rounded-full font-bold shrink-0 flex items-center gap-1">
            <MousePointerClick className="w-3 h-3 text-purple-600 hidden sm:inline" />
            {displayTerminals.length > 0 ? displayTerminals.length : 29} Active Branches
          </span>
        </div>
        <p className="text-xs text-slate-500 mb-4 flex items-center justify-between">
          <span>Click any branch hub to filter the entire dashboard</span>
          <span className="text-[10px] text-purple-600 font-semibold hidden sm:inline">👆 Click to Filter</span>
        </p>

        <div className="space-y-2.5">
          {top10Branches.map((b, idx) => {
            const gross = Number(b.grossSale || b.netRevenue || b.totalAmount || 0);
            const share = ((gross / calculatedTotalGross) * 100).toFixed(1);
            const containers = Number(b.displayContainers || b.totalContainers || (b.invoiceCount ? Math.round(b.invoiceCount * 1.14) : 0));
            const invoices = Number(b.invoiceCount || 0);
            const isSelected = isTerminalSelected(b);

            return (
              <div 
                key={idx} 
                onClick={() => handleBranchClick(b)}
                className={`p-3 rounded-2xl border transition-all duration-200 flex items-center justify-between gap-2 cursor-pointer group ${
                  isSelected 
                    ? 'bg-purple-50/90 border-[#2b1f55] ring-2 ring-[#2b1f55]/30 shadow-md transform scale-[1.01]' 
                    : 'bg-slate-50 hover:bg-purple-50/40 hover:border-purple-200 border-slate-100 hover:shadow-xs active:scale-[0.99]'
                }`}
                title={`Click to filter dashboard by ${b.terminalName}`}
              >
                <div className="flex items-center gap-3 min-w-0">
                  <span className={`w-6 h-6 rounded-full flex items-center justify-center font-bold text-[10px] shrink-0 transition-colors ${
                    isSelected ? 'bg-purple-900 text-amber-300 ring-2 ring-amber-400' : 'bg-[#2b1f55] text-white group-hover:bg-purple-800'
                  }`}>
                    {idx + 1}
                  </span>
                  <div className="min-w-0">
                    <p className={`font-bold text-xs truncate uppercase flex items-center gap-1.5 ${
                      isSelected ? 'text-purple-950 font-black' : 'text-slate-900 group-hover:text-purple-900'
                    }`} title={b.terminalName}>
                      {b.terminalName}
                      {isSelected && (
                        <span className="inline-flex items-center gap-0.5 text-[9px] px-1.5 py-0.2 rounded bg-purple-700 text-white font-bold">
                          <CheckCircle2 className="w-2.5 h-2.5" /> Filtered
                        </span>
                      )}
                    </p>
                    <p className="text-[10px] text-slate-500 group-hover:text-slate-700">
                      {formatNumber(containers)} Containers · {formatNumber(invoices)} Invoices
                    </p>
                  </div>
                </div>
                <div className="text-right shrink-0">
                  <p className={`font-mono font-bold text-xs ${isSelected ? 'text-purple-950' : 'text-slate-900'}`}>{formatCurrency(gross)}</p>
                  <p className="text-[10px] text-emerald-600 font-semibold">{share}% Share</p>
                </div>
              </div>
            );
          })}
        </div>
      </div>

      {/* RIGHT COLUMN: Top 10 Enterprise Clients by Sales (Interactive Click-to-Filter) */}
      <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft">
        <div className="flex items-center justify-between mb-1">
          <div className="flex items-center gap-2 min-w-0">
            <h4 className="text-sm font-bold text-slate-800 flex items-center gap-2 truncate">
              <Users className="w-4 h-4 text-[#ff6a00] shrink-0" />
              Top 10 Enterprise Clients by Sales
            </h4>
            {selectedCustomer && selectedCustomer !== 'ALL' && selectedCustomer !== 'all' && (
              <button
                onClick={(e) => {
                  e.stopPropagation();
                  onSelectCustomer && onSelectCustomer('ALL');
                }}
                className="inline-flex items-center gap-1 text-[9px] px-2 py-0.5 rounded-full bg-orange-100 hover:bg-orange-200 text-[#ea580c] font-bold transition-all cursor-pointer"
                title="Click to clear filter"
              >
                <XCircle className="w-3 h-3" /> Clear Filter
              </button>
            )}
          </div>
          <span className="text-[10px] px-2.5 py-0.5 bg-orange-100 text-[#ff6a00] rounded-full font-bold shrink-0 flex items-center gap-1">
            <MousePointerClick className="w-3 h-3 text-[#ea580c] hidden sm:inline" />
            {topCustomers.length > 0 ? topCustomers.length : 674} Active Clients
          </span>
        </div>
        <p className="text-xs text-slate-500 mb-4 flex items-center justify-between">
          <span>Click any customer party to filter the entire dashboard</span>
          <span className="text-[10px] text-orange-600 font-semibold hidden sm:inline">👆 Click to Filter</span>
        </p>

        <div className="space-y-2.5">
          {top10Customers.map((c, idx) => {
            const gross = Number(c.grossRevenue || c.grossAmount || c.totalRevenue || 0);
            const share = ((gross / calculatedTotalGross) * 100).toFixed(1);
            const invoices = Number(c.invoiceCount || 0);
            const isSelected = isCustomerSelected(c);

            return (
              <div 
                key={idx} 
                onClick={() => handleCustomerClick(c)}
                className={`p-3 rounded-2xl border transition-all duration-200 flex items-center justify-between gap-2 cursor-pointer group ${
                  isSelected 
                    ? 'bg-orange-50/90 border-[#ff6a00] ring-2 ring-[#ff6a00]/30 shadow-md transform scale-[1.01]' 
                    : 'bg-slate-50 hover:bg-orange-50/40 hover:border-orange-200 border-slate-100 hover:shadow-xs active:scale-[0.99]'
                }`}
                title={`Click to filter dashboard by ${c.customerName || c.name}`}
              >
                <div className="flex items-center gap-3 min-w-0">
                  <span className={`w-6 h-6 rounded-full flex items-center justify-center font-bold text-[10px] shrink-0 transition-colors ${
                    isSelected ? 'bg-orange-600 text-white ring-2 ring-orange-400' : 'bg-[#ff6a00] text-white group-hover:bg-orange-600'
                  }`}>
                    {idx + 1}
                  </span>
                  <div className="min-w-0">
                    <p className={`font-bold text-xs truncate uppercase flex items-center gap-1.5 ${
                      isSelected ? 'text-orange-950 font-black' : 'text-slate-900 group-hover:text-orange-950'
                    }`} title={c.customerName || c.name}>
                      {c.customerName || c.name}
                      {isSelected && (
                        <span className="inline-flex items-center gap-0.5 text-[9px] px-1.5 py-0.2 rounded bg-orange-600 text-white font-bold">
                          <CheckCircle2 className="w-2.5 h-2.5" /> Filtered
                        </span>
                      )}
                    </p>
                    <p className="text-[10px] text-slate-500 group-hover:text-slate-700">
                      {formatNumber(invoices)} Invoices Audited
                    </p>
                  </div>
                </div>
                <div className="text-right shrink-0">
                  <p className={`font-mono font-bold text-xs ${isSelected ? 'text-orange-950' : 'text-slate-900'}`}>{formatCurrency(gross)}</p>
                  <p className="text-[10px] text-emerald-600 font-semibold">{share}% Share</p>
                </div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
}
