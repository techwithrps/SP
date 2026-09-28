import React from 'react';
import { Building2, Calendar, RotateCcw } from 'lucide-react';

function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

export default function CompactFilterGroup({
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  selectedFY = 'ALL',
  setSelectedFY,
  terminals = [],
  customFromDate = '2026-04-01',
  setCustomFromDate,
  customToDate = '2026-09-26',
  setCustomToDate,
  financialYears = [
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'Custom Date Range'
  ]
}) {
  const isFilterActive = selectedTerminal !== 'ALL' || selectedFY !== 'ALL';

  const resetFilters = () => {
    if (setSelectedTerminal) setSelectedTerminal('ALL');
    if (setSelectedFY) setSelectedFY('ALL');
  };

  const hasData = (t) => (t.totalContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0);
  const activeTerminals = terminals.filter(hasData).sort((a, b) => (b.netRevenue || 0) - (a.netRevenue || 0));
  const inactiveTerminals = terminals.filter(t => !hasData(t));

  return (
    <div className="flex flex-wrap items-center gap-2">
      {/* 1. Compact Terminal Dropdown */}
      <div className="flex items-center gap-1.5 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl px-2.5 py-1.5 shadow-sm transition-all">
        <Building2 className="w-3.5 h-3.5 text-[#2b1f55] shrink-0" />
        <select
          value={selectedTerminal}
          onChange={(e) => setSelectedTerminal && setSelectedTerminal(e.target.value)}
          className="bg-transparent text-xs font-bold text-slate-800 focus:outline-none cursor-pointer max-w-[200px] sm:max-w-[240px] truncate"
        >
          <option value="ALL">🏢 All Terminals ({terminals.length || 39})</option>
          
          {/* 🟢 Active Hubs with Data */}
          <optgroup label="── 🟢 Active Hubs with Data ──">
            {activeTerminals.map(t => (
              <option key={t.terminalId} value={String(t.terminalId)}>
                🟢 {t.terminalName} ({formatNumber(t.totalContainers)} Cont)
              </option>
            ))}
          </optgroup>

          {/* 🔴 Inactive / Zero Data Terminals */}
          <optgroup label="── 🔴 Inactive / Zero Data ──">
            {inactiveTerminals.map(t => (
              <option key={t.terminalId} value={String(t.terminalId)} className="text-rose-600 font-semibold bg-rose-50">
                🔴 {t.terminalName} (No Data)
              </option>
            ))}
          </optgroup>
        </select>
      </div>

      {/* 2. Compact Date Range Inputs */}
      <div className="flex items-center gap-1.5 bg-slate-50 border border-slate-300 rounded-xl px-2.5 py-1 shadow-xs">
        <Calendar className="w-3.5 h-3.5 text-[#ff6a00] shrink-0" />
        <div className="flex items-center gap-1">
          <input
            type="date"
            value={customFromDate || ''}
            onChange={(e) => {
              if (setCustomFromDate) setCustomFromDate(e.target.value);
              if (setSelectedFY) setSelectedFY('CUSTOM_RANGE');
            }}
            className="h-7 px-1.5 bg-white border border-slate-200 rounded-lg text-xs font-bold text-slate-800 focus:outline-none focus:ring-1 focus:ring-[#ff6a00]"
          />
          <span className="text-[10px] font-bold text-slate-400">→</span>
          <input
            type="date"
            value={customToDate || ''}
            onChange={(e) => {
              if (setCustomToDate) setCustomToDate(e.target.value);
              if (setSelectedFY) setSelectedFY('CUSTOM_RANGE');
            }}
            className="h-7 px-1.5 bg-white border border-slate-200 rounded-lg text-xs font-bold text-slate-800 focus:outline-none focus:ring-1 focus:ring-[#ff6a00]"
          />
        </div>
      </div>

      {/* 3. Reset Button (If active) */}
      {isFilterActive && (
        <button
          onClick={resetFilters}
          className="inline-flex items-center gap-1 px-2.5 py-1.5 bg-rose-50 text-rose-700 hover:bg-rose-100 border border-rose-200 rounded-xl text-xs font-bold transition-all shadow-sm"
          title="Reset to All Terminals & All FYs"
        >
          <RotateCcw className="w-3 h-3" />
          <span>Reset</span>
        </button>
      )}
    </div>
  );
}
