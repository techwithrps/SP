import React from 'react';
import { 
  Building2, 
  Calendar, 
  RotateCcw, 
  RefreshCw, 
  Layers, 
  Sparkles,
  ShieldCheck,
  FileSpreadsheet,
  CheckCircle2
} from 'lucide-react';
import * as XLSX from 'xlsx';

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

export default function GlobalFilterBar({
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
  ],
  onRefresh,
  loading = false,
  activeTab = 'analytics'
}) {
  const isFilterActive = selectedTerminal !== 'ALL' || selectedFY !== 'ALL';

  const resetFilters = () => {
    if (setSelectedTerminal) setSelectedTerminal('ALL');
    if (setSelectedFY) setSelectedFY('ALL');
  };

  const selectedTerminalObj = terminals.find(t => String(t.terminalId) === String(selectedTerminal));
  const hasData = (t) => (t.totalContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0);

  const activeTerminals = terminals.filter(hasData).sort((a, b) => (b.netRevenue || 0) - (a.netRevenue || 0));
  const inactiveTerminals = terminals.filter(t => !hasData(t));

  const handleQuickExport = () => {
    const wb = XLSX.utils.book_new();
    const dataToExport = terminals.map(t => ({
      'Terminal ID': t.terminalId,
      'Terminal / Branch': t.terminalName,
      'Status': hasData(t) ? 'Active with Data' : 'Zero Data / Inactive',
      'Code': t.terminalCode || `T-${t.terminalId}`,
      'Job Orders': t.totalJobs || 0,
      'Containers': t.totalContainers || 0,
      '40ft Units': t.units40ft || 0,
      '20ft Units': t.units20ft || 0,
      'TEUs': t.teus || 0,
      'Invoices': t.invoiceCount || 0,
      'Base Bill Amount (INR)': t.billAmount || 0,
      'Tax GST (INR)': t.taxAmount || 0,
      'Net Revenue (Gross Sale INR)': t.netRevenue || 0
    }));
    const ws = XLSX.utils.json_to_sheet(dataToExport);
    XLSX.utils.book_append_sheet(wb, ws, 'Branch_Overview');
    XLSX.writeFile(wb, `SPJ_Enterprise_Overview_${new Date().toISOString().slice(0, 10)}.xlsx`);
  };

  return (
    <div className="bg-white rounded-3xl border border-slate-200 shadow-soft overflow-hidden transition-all">
      {/* Top Filter & Actions Row */}
      <div className="p-5">
        <div className="flex flex-col lg:flex-row items-start lg:items-end justify-between gap-4">
          
          {/* Controls Group */}
          <div className="flex flex-wrap items-end gap-3.5 w-full lg:w-auto">
            
            {/* 1. Terminal / Branch Selector */}
            <div className="flex flex-col min-w-[290px] flex-1 sm:flex-initial">
              <label className="text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-2 flex items-center gap-1.5">
                <Building2 className="w-3.5 h-3.5 text-[#2b1f55]" />
                Branch / Terminal Selection
              </label>
              <div className="relative">
                <select
                  value={selectedTerminal}
                  onChange={(e) => setSelectedTerminal(e.target.value)}
                  className="w-full h-11 pl-3.5 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-[#2b1f55] transition-all cursor-pointer shadow-sm"
                >
                  <option value="ALL">🏢 All Terminals & Regional Hubs ({terminals.length || 39} Total)</option>
                  
                  {/* 🟢 Active Operational Hubs */}
                  <optgroup label="── 🟢 Active Hubs with Data ──">
                    {activeTerminals.map(t => (
                      <option key={t.terminalId} value={String(t.terminalId)}>
                        🟢 {t.terminalName} ({formatNumber(t.totalContainers)} Cont | {formatCurrency(t.netRevenue)})
                      </option>
                    ))}
                  </optgroup>

                  {/* 🔴 Inactive / Zero Data Terminals */}
                  <optgroup label="── 🔴 Inactive / Zero Data Terminals ──">
                    {inactiveTerminals.map(t => (
                      <option key={t.terminalId} value={String(t.terminalId)} className="text-rose-600 font-semibold bg-rose-50/50">
                        🔴 {t.terminalName} (No Data / Inactive)
                      </option>
                    ))}
                  </optgroup>
                </select>
              </div>
            </div>

            {/* 2. Financial Year Selector */}
            <div className="flex flex-col min-w-[240px] flex-1 sm:flex-initial">
              <label className="text-[11px] font-bold text-slate-500 uppercase tracking-wider mb-2 flex items-center gap-1.5">
                <Calendar className="w-3.5 h-3.5 text-[#ff6a00]" />
                Financial Year Filter
              </label>
              <div className="relative">
                <select
                  value={selectedFY}
                  onChange={(e) => setSelectedFY(e.target.value)}
                  className="w-full h-11 pl-3.5 pr-8 bg-slate-50 hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-800 focus:outline-none focus:ring-2 focus:ring-[#ff6a00] transition-all cursor-pointer shadow-sm"
                >
                  <option value="ALL">📅 All Financial Years (Cumulative)</option>
                  <option value="FY 2026-27">FY 2026-27 (Current Fiscal)</option>
                  <option value="FY 2025-26">FY 2025-26 (Past Year 1)</option>
                  <option value="FY 2024-25">FY 2024-25 (Past Year 2)</option>
                  <option value="FY 2023-24">FY 2023-24 (Past Year 3)</option>
                  <option value="FY 2022-23 & Earlier">FY 2022-23 & Earlier (Historical)</option>
                </select>
              </div>
            </div>

            {/* 3. Reset Button */}
            {isFilterActive && (
              <button
                onClick={resetFilters}
                className="h-11 inline-flex items-center gap-1.5 px-4 bg-rose-50 text-rose-700 hover:bg-rose-100 border border-rose-200 rounded-xl text-xs font-bold transition-all shadow-sm shrink-0"
                title="Reset to All Terminals and All Financial Years"
              >
                <RotateCcw className="w-3.5 h-3.5" />
                <span>Reset Filters</span>
              </button>
            )}

          </div>

          {/* Action Buttons Group */}
          <div className="flex items-center gap-2.5 w-full lg:w-auto justify-end">
            <button
              onClick={onRefresh}
              disabled={loading}
              className="h-11 inline-flex items-center justify-center gap-2 px-4 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all border border-slate-200 shadow-sm disabled:opacity-50"
            >
              <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
              <span>Sync DB</span>
            </button>

            <button
              onClick={handleQuickExport}
              className="h-11 inline-flex items-center justify-center gap-2 px-5 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] text-white hover:opacity-95 rounded-xl text-xs font-bold shadow-md shadow-purple-900/20 transition-all shrink-0"
            >
              <FileSpreadsheet className="w-4 h-4 text-emerald-400" />
              <span>Export Excel (.xlsx)</span>
            </button>
          </div>

        </div>
      </div>

      {/* Bottom Context & Status Bar */}
      <div className="px-5 py-3 bg-slate-50/80 border-t border-slate-100 flex flex-wrap items-center justify-between gap-3 text-xs">
        
        {/* Left: Active Scope Pills */}
        <div className="flex flex-wrap items-center gap-2">
          <span className="flex items-center gap-1.5 text-slate-500 font-medium">
            <span className="w-2 h-2 rounded-full bg-emerald-500 animate-pulse"></span>
            Displaying Analytics for:
          </span>

          <span className={`inline-flex items-center font-bold px-2.5 py-1 rounded-lg border ${
            selectedTerminal === 'ALL'
              ? 'text-[#2b1f55] bg-purple-100/70 border-purple-200'
              : (selectedTerminalObj && !hasData(selectedTerminalObj)
                  ? 'text-rose-700 bg-rose-100/80 border-rose-300'
                  : 'text-[#2b1f55] bg-purple-100/70 border-purple-200')
          }`}>
            {selectedTerminal === 'ALL' 
              ? 'All 39 Terminals & Ports' 
              : `${selectedTerminalObj && !hasData(selectedTerminalObj) ? '🔴 ' : '🟢 '}${selectedTerminalObj?.terminalName || `Terminal ${selectedTerminal}`}`}
          </span>

          <span className="text-slate-400 font-bold">&bull;</span>

          <span className="inline-flex items-center font-bold text-[#ea580c] bg-orange-100/70 border border-orange-200 px-2.5 py-1 rounded-lg">
            {selectedFY === 'ALL' ? 'All Financial Years (Cumulative)' : selectedFY}
          </span>
        </div>

        {/* Right: Database Source */}
        <div className="flex items-center gap-2 text-[11px] text-slate-500 font-mono">
          <ShieldCheck className="w-3.5 h-3.5 text-emerald-600" />
          <span>Source: Oracle Cloud Live</span>
          <span className="font-bold text-emerald-700 bg-emerald-50 px-1.5 py-0.5 rounded border border-emerald-200">SPJLIVE</span>
        </div>

      </div>

    </div>
  );
}
