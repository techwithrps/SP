import React from 'react';
import { 
  Search, 
  RotateCcw, 
  Download, 
  Building2, 
  MapPin, 
  Users, 
  Wrench, 
  Navigation, 
  FileText,
  SlidersHorizontal
} from 'lucide-react';

export default function FilterBar({
  filters,
  setFilters,
  masters = {},
  onReset,
  onExport,
  loading = false,
  totalRecords = 0
}) {
  const {
    companies = [],
    terminals = [],
    customers = [],
    services = [],
    tripTypes = []
  } = masters;

  const handleChange = (field, value) => {
    setFilters(prev => ({
      ...prev,
      [field]: value
    }));
  };

  return (
    <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft space-y-4">
      {/* Top Search and Action Header */}
      <div className="flex flex-col md:flex-row items-center justify-between gap-4">
        
        {/* Global Search Input */}
        <div className="relative w-full md:w-96">
          <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
          <input
            type="text"
            placeholder="Search Container, Invoice No, Customer, Port, Notes..."
            value={filters.search || ''}
            onChange={(e) => handleChange('search', e.target.value)}
            className="w-full pl-10 pr-4 py-2.5 bg-slate-50 border border-slate-200 rounded-xl text-xs text-slate-900 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55] focus:ring-1 focus:ring-[#2b1f55] transition-all font-medium"
          />
          {filters.search && (
            <button
              onClick={() => handleChange('search', '')}
              className="absolute right-3 top-1/2 -translate-y-1/2 text-slate-400 hover:text-slate-600 text-xs font-bold"
            >
              ×
            </button>
          )}
        </div>

        {/* Counter and Action Buttons */}
        <div className="flex items-center gap-3 w-full md:w-auto justify-end">
          <div className="text-xs text-slate-600 font-semibold bg-slate-100 px-3.5 py-2 rounded-xl border border-slate-200">
            Total Results: <span className="text-[#2b1f55] font-black">{totalRecords}</span>
          </div>

          <button
            onClick={onReset}
            title="Reset Filters"
            className="flex items-center gap-1.5 px-3.5 py-2 rounded-xl bg-slate-100 hover:bg-slate-200 border border-slate-200 text-xs text-slate-700 font-bold transition-all"
          >
            <RotateCcw className="w-3.5 h-3.5" />
            Reset
          </button>

          <button
            onClick={onExport}
            disabled={loading || totalRecords === 0}
            className="flex items-center gap-2 px-4 py-2 rounded-xl bg-[#ff6a00] hover:bg-[#e65c00] text-white font-bold text-xs shadow-md transition-all disabled:opacity-50"
          >
            <Download className="w-4 h-4" />
            Export Excel
          </button>
        </div>
      </div>

      {/* Grid of SP_CIR_NEW Parameter Filters */}
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-6 gap-3 pt-3 border-t border-slate-100">
        
        {/* Customer / Bill-to */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Users className="w-3 h-3 text-blue-600" />
            Customer
          </label>
          <select
            value={filters.customerId || 'all'}
            onChange={(e) => handleChange('customerId', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          >
            <option value="all">All Customers ({customers.length})</option>
            {customers.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </select>
        </div>

        {/* Service Type */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Wrench className="w-3 h-3 text-orange-600" />
            Service Charge
          </label>
          <select
            value={filters.serviceId || 'all'}
            onChange={(e) => handleChange('serviceId', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          >
            <option value="all">All Services ({services.length})</option>
            {services.map((s) => (
              <option key={s.id} value={s.id}>
                {s.name}
              </option>
            ))}
          </select>
        </div>

        {/* Trip Type */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Navigation className="w-3 h-3 text-emerald-600" />
            Trip Type
          </label>
          <select
            value={filters.tripType || 'all'}
            onChange={(e) => handleChange('tripType', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          >
            <option value="all">All Trip Types</option>
            {tripTypes.map((t) => (
              <option key={t.code} value={t.code}>
                {t.name}
              </option>
            ))}
          </select>
        </div>

        {/* Container Number */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <SlidersHorizontal className="w-3 h-3 text-purple-600" />
            Container No
          </label>
          <input
            type="text"
            placeholder="e.g. MSCU, HLBU"
            value={filters.contNo || ''}
            onChange={(e) => handleChange('contNo', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          />
        </div>

        {/* Bill of Lading (BL) */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <FileText className="w-3 h-3 text-indigo-600" />
            BL No / Bilty
          </label>
          <input
            type="text"
            placeholder="e.g. BL/Bilty No"
            value={filters.blNo || ''}
            onChange={(e) => handleChange('blNo', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          />
        </div>

        {/* Terminal ID */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <MapPin className="w-3 h-3 text-rose-600" />
            Terminal
          </label>
          <select
            value={filters.terminalId || 'all'}
            onChange={(e) => handleChange('terminalId', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
          >
            <option value="all">All Terminals</option>
            {terminals.map((t) => (
              <option key={t.id} value={t.id}>
                {t.name}
              </option>
            ))}
          </select>
        </div>

      </div>
    </div>
  );
}
