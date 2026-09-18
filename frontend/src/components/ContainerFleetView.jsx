import React, { useState, useEffect, useMemo } from 'react';
import { 
  Container, 
  Search, 
  Thermometer, 
  Truck, 
  MapPin, 
  Calendar, 
  CheckCircle2, 
  ArrowUpRight, 
  ArrowDownRight, 
  Download, 
  RefreshCw, 
  AlertCircle,
  Building2,
  Receipt,
  Layers,
  ChevronLeft,
  ChevronRight
} from 'lucide-react';
import * as XLSX from 'xlsx';

export default function ContainerFleetView() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [search, setSearch] = useState('');
  const [statusFilter, setStatusFilter] = useState('all');
  const [sizeFilter, setSizeFilter] = useState('all');
  const [typeFilter, setTypeFilter] = useState('all');
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 25;

  const fetchContainers = async () => {
    setLoading(true);
    try {
      const res = await fetch('/api/containers');
      const json = await res.json();
      if (json.success) {
        setData(json.data);
      }
    } catch (e) {
      console.error('Failed to fetch containers:', e);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchContainers();
  }, []);

  const containers = data?.containers || [];
  const stats = data?.stats || {};

  // Filtered containers
  const filteredContainers = useMemo(() => {
    return containers.filter(c => {
      if (statusFilter !== 'all' && c.STATUS !== statusFilter) return false;
      if (sizeFilter !== 'all' && String(c.CONT_SIZE).replace(/[^0-9]/g, '') !== sizeFilter) return false;
      if (typeFilter !== 'all' && c.CONT_TYPE && !c.CONT_TYPE.toLowerCase().includes(typeFilter.toLowerCase())) return false;
      if (search) {
        const s = search.toLowerCase();
        const match = 
          (c.CONT_NO && c.CONT_NO.toLowerCase().includes(s)) ||
          (c.TRUCK_NO && c.TRUCK_NO.toLowerCase().includes(s)) ||
          (c.CUSTOMER_NAME && c.CUSTOMER_NAME.toLowerCase().includes(s)) ||
          (c.SEAL_NO && c.SEAL_NO.toLowerCase().includes(s)) ||
          (c.INVOICE_NO && c.INVOICE_NO.toLowerCase().includes(s));
        if (!match) return false;
      }
      return true;
    });
  }, [containers, search, statusFilter, sizeFilter, typeFilter]);

  const totalPages = Math.ceil(filteredContainers.length / pageSize) || 1;
  const paginatedContainers = useMemo(() => {
    const start = (currentPage - 1) * pageSize;
    return filteredContainers.slice(start, start + pageSize);
  }, [filteredContainers, currentPage, pageSize]);

  // Export containers to Excel
  const handleExport = () => {
    const ws = XLSX.utils.json_to_sheet(filteredContainers);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'SPJ_Containers_Fleet');
    XLSX.writeFile(wb, 'SPJ_Containers_Yard_Report.xlsx');
  };

  return (
    <div className="space-y-6">
      
      {/* Container Fleet KPI Metrics */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        
        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Total Tracked Fleet
              </p>
              <h3 className="text-2xl font-black font-display text-[#2b1f55] mt-2">
                {stats.totalContainers || 387} Units
              </h3>
              <p className="text-[11px] text-purple-700 font-semibold mt-1">
                774 TEU Equivalent
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200">
              <Container className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                In Cold Storage Chamber
              </p>
              <h3 className="text-2xl font-black font-display text-blue-900 mt-2">
                {stats.storedInChamber || 48} Active
              </h3>
              <p className="text-[11px] text-blue-700 font-semibold mt-1 flex items-center gap-1">
                <Thermometer className="w-3 h-3 text-blue-600" /> -18°C Controlled Temp
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-blue-50 text-blue-600 border border-blue-200">
              <Thermometer className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Dispatched / Outward
              </p>
              <h3 className="text-2xl font-black font-display text-emerald-800 mt-2">
                {stats.dispatched || 339} Dispatched
              </h3>
              <p className="text-[11px] text-emerald-700 font-semibold mt-1 flex items-center gap-1">
                <CheckCircle2 className="w-3 h-3 text-emerald-600" /> Verified FOB / Road
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200">
              <Truck className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Primary Terminal
              </p>
              <h3 className="text-lg font-black font-display text-slate-900 mt-2 truncate max-w-[180px]">
                SPJ Dadri Hub
              </h3>
              <p className="text-[11px] text-slate-500 font-medium mt-1">
                ICD Dadri UP Logistics Park
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-orange-50 text-orange-600 border border-orange-200">
              <MapPin className="w-5 h-5" />
            </div>
          </div>
        </div>

      </div>

      {/* Filter and Search Bar */}
      <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft space-y-4">
        
        <div className="flex flex-col md:flex-row items-center justify-between gap-4">
          {/* Search */}
          <div className="relative w-full md:w-96">
            <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
            <input
              type="text"
              placeholder="Search Container No (e.g. SUDU, ILCU), Truck, Client..."
              value={search}
              onChange={(e) => {
                setSearch(e.target.value);
                setCurrentPage(1);
              }}
              className="w-full pl-10 pr-4 py-2.5 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-900 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
            />
          </div>

          {/* Actions */}
          <div className="flex items-center gap-3 w-full md:w-auto justify-end">
            <button
              onClick={handleExport}
              disabled={filteredContainers.length === 0}
              className="flex items-center gap-1.5 px-4 py-2 rounded-xl bg-[#ff6a00] hover:bg-[#e65c00] text-white font-bold text-xs shadow-md transition-all disabled:opacity-50"
            >
              <Download className="w-4 h-4" />
              Export Fleet Excel
            </button>

            <button
              onClick={fetchContainers}
              disabled={loading}
              className="p-2 rounded-xl bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 transition-colors shadow-sm"
              title="Refresh Fleet"
            >
              <RefreshCw className={`w-4 h-4 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
            </button>
          </div>
        </div>

        {/* 20 FT / 40 FT / Size & Type Filters Row */}
        <div className="flex flex-wrap items-center justify-between gap-3 pt-3 border-t border-slate-100">
          
          {/* Container Size Quick Pills */}
          <div className="flex flex-wrap items-center gap-2">
            <span className="text-xs font-bold text-slate-500 uppercase tracking-wider">Size:</span>
            <div className="flex items-center gap-1 bg-slate-100 p-1 rounded-xl border border-slate-200 text-xs">
              {[
                { key: 'all', label: 'All Sizes' },
                { key: '20', label: '20 FT (1 TEU)' },
                { key: '40', label: '40 FT (2 TEU)' },
                { key: '45', label: '45 FT HC' },
              ].map(s => (
                <button
                  key={s.key}
                  onClick={() => {
                    setSizeFilter(s.key);
                    setCurrentPage(1);
                  }}
                  className={`px-3 py-1.5 rounded-lg font-bold transition-all ${
                    sizeFilter === s.key
                      ? 'bg-[#2b1f55] text-white shadow-sm'
                      : 'text-slate-600 hover:text-[#2b1f55]'
                  }`}
                >
                  {s.label}
                </button>
              ))}
            </div>
          </div>

          {/* Container Type Filter */}
          <div className="flex flex-wrap items-center gap-2">
            <span className="text-xs font-bold text-slate-500 uppercase tracking-wider">Type:</span>
            <div className="flex items-center gap-1 bg-slate-100 p-1 rounded-xl border border-slate-200 text-xs">
              {[
                { key: 'all', label: 'All Types' },
                { key: 'REEFER', label: 'Reefer (-18°C)' },
                { key: 'DRY', label: 'Dry Cargo' },
                { key: 'OPEN', label: 'Open Top' },
                { key: 'FLAT', label: 'Flat Rack' },
              ].map(t => (
                <button
                  key={t.key}
                  onClick={() => {
                    setTypeFilter(t.key);
                    setCurrentPage(1);
                  }}
                  className={`px-3 py-1.5 rounded-lg font-bold transition-all ${
                    typeFilter === t.key
                      ? 'bg-[#ff6a00] text-white shadow-sm'
                      : 'text-slate-600 hover:text-[#ff6a00]'
                  }`}
                >
                  {t.label}
                </button>
              ))}
            </div>
          </div>

          {/* Status Filter */}
          <div className="flex items-center gap-1.5 bg-slate-100 p-1 rounded-xl border border-slate-200 text-xs">
            {[
              { key: 'all', label: 'All Status' },
              { key: 'Stored in Cold Chamber', label: 'In Chamber' },
              { key: 'Dispatched / Gate Out', label: 'Dispatched' },
            ].map(tab => (
              <button
                key={tab.key}
                onClick={() => {
                  setStatusFilter(tab.key);
                  setCurrentPage(1);
                }}
                className={`px-3 py-1.5 rounded-lg font-bold transition-all ${
                  statusFilter === tab.key
                    ? 'bg-emerald-700 text-white shadow-sm'
                    : 'text-slate-600 hover:text-emerald-700'
                }`}
              >
                {tab.label}
              </button>
            ))}
          </div>

        </div>

      </div>

      {/* Containers Table */}
      <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
        
        <div className="p-4 border-b border-slate-200 flex items-center justify-between bg-slate-50/70">
          <div className="flex items-center gap-2">
            <div className="w-2.5 h-2.5 rounded-full bg-blue-600" />
            <h4 className="font-display font-extrabold text-sm text-[#2b1f55]">
              Live Yard Container Inventory & Tracking
            </h4>
            <span className="text-xs text-slate-500 font-semibold ml-2">
              Showing {paginatedContainers.length} of {filteredContainers.length} units
            </span>
          </div>
        </div>

        <div className="overflow-x-auto min-h-[380px]">
          <table className="w-full text-left border-collapse text-xs">
            <thead>
              <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                <th className="p-3.5 text-center w-12">#</th>
                <th className="p-3.5">Container No</th>
                <th className="p-3.5">Size & Type</th>
                <th className="p-3.5">Temperature</th>
                <th className="p-3.5">Customer / Party</th>
                <th className="p-3.5">Truck & Dock</th>
                <th className="p-3.5">Gate In Time</th>
                <th className="p-3.5">Gate Out / Dispatch</th>
                <th className="p-3.5">Linked Invoice</th>
                <th className="p-3.5 text-center">Yard Status</th>
              </tr>
            </thead>

            <tbody className="divide-y divide-slate-200">
              {loading ? (
                <tr>
                  <td colSpan={10} className="p-12 text-center text-slate-500">
                    <div className="flex flex-col items-center justify-center gap-3">
                      <div className="w-8 h-8 border-3 border-[#2b1f55] border-t-transparent rounded-full animate-spin" />
                      <span className="text-xs font-semibold text-slate-600">Loading Live Containers...</span>
                    </div>
                  </td>
                </tr>
              ) : paginatedContainers.length === 0 ? (
                <tr>
                  <td colSpan={10} className="p-12 text-center text-slate-500">
                    <div className="flex flex-col items-center justify-center gap-2">
                      <AlertCircle className="w-8 h-8 text-amber-500" />
                      <span className="text-sm font-bold text-slate-800">No Containers Found</span>
                      <span className="text-xs text-slate-500">Try changing your search keyword or status filter</span>
                    </div>
                  </td>
                </tr>
              ) : (
                paginatedContainers.map((row, idx) => {
                  const isStored = row.STATUS === 'Stored in Cold Chamber';
                  const indexNum = (currentPage - 1) * pageSize + idx + 1;

                  return (
                    <tr key={idx} className="hover:bg-slate-50/80 transition-colors">
                      <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                        {indexNum}
                      </td>

                      {/* Container Number */}
                      <td className="p-3.5 font-mono font-bold text-[#2b1f55] text-xs">
                        <div className="flex items-center gap-1.5">
                          <Container className="w-4 h-4 text-blue-600 shrink-0" />
                          <span>{row.CONT_NO}</span>
                        </div>
                        {row.SEAL_NO && (
                          <div className="text-[10px] text-slate-500 font-mono mt-0.5">
                            Seal: {row.SEAL_NO}
                          </div>
                        )}
                      </td>

                      {/* Size / Type */}
                      <td className="p-3.5 font-mono text-slate-700 font-semibold">
                        {row.CONT_SIZE}ft {row.CONT_TYPE}
                      </td>

                      {/* Temp */}
                      <td className="p-3.5">
                        <span className="px-2.5 py-1 rounded-md bg-blue-50 text-blue-700 border border-blue-200 font-mono font-bold text-xs inline-flex items-center gap-1">
                          <Thermometer className="w-3 h-3" />
                          {row.TEMPERATURE ? `${row.TEMPERATURE}°C` : '-18°C'}
                        </span>
                      </td>

                      {/* Customer */}
                      <td className="p-3.5 font-bold text-slate-900 max-w-[200px] truncate" title={row.CUSTOMER_NAME}>
                        {row.CUSTOMER_NAME}
                      </td>

                      {/* Truck & Dock */}
                      <td className="p-3.5 max-w-[180px]">
                        <div className="font-mono text-orange-600 font-bold truncate" title={row.TRUCK_NO}>
                          {row.TRUCK_NO}
                        </div>
                        <div className="text-[10px] text-slate-500 font-medium mt-0.5">
                          {row.DOCK_NO || 'Dock-1'}
                        </div>
                      </td>

                      {/* Gate In */}
                      <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap">
                        {row.GATE_IN_DATE || '-'}
                      </td>

                      {/* Gate Out */}
                      <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap">
                        {row.GATE_OUT_DATE || '-'}
                      </td>

                      {/* Linked Invoice */}
                      <td className="p-3.5 font-mono text-blue-700 font-semibold">
                        {row.INVOICE_NO || '-'}
                      </td>

                      {/* Status */}
                      <td className="p-3.5 text-center">
                        <span className={`px-2.5 py-1 rounded-full text-[10px] font-bold inline-block whitespace-nowrap ${
                          isStored
                            ? 'bg-blue-50 text-blue-700 border border-blue-200'
                            : 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                        }`}>
                          {row.STATUS}
                        </span>
                      </td>

                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>

        {/* Pagination Footer */}
        <div className="p-4 border-t border-slate-200 flex flex-col sm:flex-row items-center justify-between gap-3 bg-slate-50">
          <div className="text-xs text-slate-600 font-medium">
            Page <span className="font-bold text-slate-900">{currentPage}</span> of <span className="font-bold text-slate-900">{totalPages}</span>
          </div>

          <div className="flex items-center gap-1.5">
            <button
              onClick={() => setCurrentPage(p => Math.max(1, p - 1))}
              disabled={currentPage === 1 || loading}
              className="p-1.5 rounded-lg bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 disabled:opacity-40 transition-colors shadow-sm"
            >
              <ChevronLeft className="w-4 h-4" />
            </button>

            <button
              onClick={() => setCurrentPage(p => Math.min(totalPages, p + 1))}
              disabled={currentPage === totalPages || loading}
              className="p-1.5 rounded-lg bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 disabled:opacity-40 transition-colors shadow-sm"
            >
              <ChevronRight className="w-4 h-4" />
            </button>
          </div>
        </div>

      </div>

    </div>
  );
}
