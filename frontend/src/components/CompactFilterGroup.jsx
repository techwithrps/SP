import React from 'react';
import { Building2, Calendar, RotateCcw } from 'lucide-react';

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  return `₹ ${num.toLocaleString('en-IN')}`;
}

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
  financialYears = [
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'FY 2023-24', 
    'FY 2022-23 & Earlier'
  ]
}) {
  const isFilterActive = selectedTerminal !== 'ALL' || selectedFY !== 'ALL';

  const resetFilters = () => {
    if (setSelectedTerminal) setSelectedTerminal('ALL');
    if (setSelectedFY) setSelectedFY('ALL');
  };

  return (
    <div className="flex flex-wrap items-center gap-2">
      {/* 1. Compact Terminal Dropdown */}
      <div className="flex items-center gap-1.5 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl px-2.5 py-1.5 shadow-sm transition-all">
        <Building2 className="w-3.5 h-3.5 text-[#2b1f55] shrink-0" />
        <select
          value={selectedTerminal}
          onChange={(e) => setSelectedTerminal && setSelectedTerminal(e.target.value)}
          className="bg-transparent text-xs font-bold text-slate-800 focus:outline-none cursor-pointer max-w-[190px] sm:max-w-[220px] truncate"
        >
          <option value="ALL">🏢 All Terminals ({terminals.length || 39})</option>
          <optgroup label="── Active Hubs ──">
            {terminals
              .filter(t => t.totalContainers > 0)
              .sort((a, b) => (b.netRevenue || 0) - (a.netRevenue || 0))
              .map(t => (
                <option key={t.terminalId} value={String(t.terminalId)}>
                  {t.terminalName} ({formatNumber(t.totalContainers)} Cont)
                </option>
              ))}
          </optgroup>
          <optgroup label="── Other Stations ──">
            {terminals
              .filter(t => !t.totalContainers)
              .map(t => (
                <option key={t.terminalId} value={String(t.terminalId)}>
                  {t.terminalName}
                </option>
              ))}
          </optgroup>
        </select>
      </div>

      {/* 2. Compact FY Dropdown */}
      <div className="flex items-center gap-1.5 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl px-2.5 py-1.5 shadow-sm transition-all">
        <Calendar className="w-3.5 h-3.5 text-[#ff6a00] shrink-0" />
        <select
          value={selectedFY}
          onChange={(e) => setSelectedFY && setSelectedFY(e.target.value)}
          className="bg-transparent text-xs font-bold text-slate-800 focus:outline-none cursor-pointer"
        >
          <option value="ALL">📅 All FYs (Cumulative)</option>
          <option value="FY 2026-27">FY 2026-27</option>
          <option value="FY 2025-26">FY 2025-26</option>
          <option value="FY 2024-25">FY 2024-25</option>
          <option value="FY 2023-24">FY 2023-24</option>
          <option value="FY 2022-23 & Earlier">FY 2022-23 & Earlier</option>
        </select>
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
