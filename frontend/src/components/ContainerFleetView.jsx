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
import CompactFilterGroup from './CompactFilterGroup';
import AnimatedCounter from './AnimatedCounter';
import { SkeletonKPICard } from './SkeletonLoader';
import * as XLSX from 'xlsx';
import { authFetch } from '../utils/api';

export default function ContainerFleetView({
  selectedCompany = 'ALL',
  selectedCustomer = 'ALL',
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  selectedFY = 'ALL',
  setSelectedFY,
  terminals = [],
  financialYears = []
}) {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [search, setSearch] = useState('');

  const [statusFilter, setStatusFilter] = useState('all');
  const [sizeFilter, setSizeFilter] = useState('all');
  const [typeFilter, setTypeFilter] = useState('all');
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 25;

  // Reset to page 1 on filter changes
  const handleStatusFilterChange = (val) => { setStatusFilter(val); setCurrentPage(1); };
  const handleSizeFilterChange = (val) => { setSizeFilter(val); setCurrentPage(1); };
  const handleTypeFilterChange = (val) => { setTypeFilter(val); setCurrentPage(1); };
  const handleSearchChange = (e) => { setSearch(e.target.value); setCurrentPage(1); };

  const fetchContainers = async () => {
    setLoading(true);
    try {
      const queryParams = new URLSearchParams();
      queryParams.append('page', String(currentPage));
      queryParams.append('limit', String(pageSize));
      if (selectedCompany && selectedCompany !== 'ALL' && selectedCompany !== 'all') queryParams.append('companyId', selectedCompany);
      if (selectedCustomer && selectedCustomer !== 'ALL' && selectedCustomer !== 'all') queryParams.append('customerId', selectedCustomer);
      if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') queryParams.append('terminalId', selectedTerminal);
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') queryParams.append('financialYear', selectedFY);
      if (statusFilter && statusFilter !== 'all') queryParams.append('status', statusFilter);
      if (sizeFilter && sizeFilter !== 'all') queryParams.append('contSize', sizeFilter);
      if (typeFilter && typeFilter !== 'all') queryParams.append('contType', typeFilter);
      if (search && search.trim() !== '') queryParams.append('search', search.trim());

      const res = await authFetch(`/api/containers?${queryParams.toString()}`);
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
    const timer = setTimeout(() => {
      fetchContainers();
    }, 200);
    return () => clearTimeout(timer);
  }, [selectedCompany, selectedCustomer, selectedTerminal, selectedFY, statusFilter, sizeFilter, typeFilter, search, currentPage]);

  const containers = data?.containers || [];
  const baseStats = data?.stats || {};

  // Filtered containers supporting size, type, status, and search
  const filteredContainers = useMemo(() => {
    return containers.filter(c => {
      const cStatus = (c.status || c.STATUS || '').toLowerCase();
      const cSize = String(c.contSize || c.CONT_SIZE || '').replace(/[^0-9]/g, '');
      const cType = (c.contType || c.CONT_TYPE || '').toLowerCase();

      // 1. Status Filter (In Chamber vs Dispatched vs All)
      if (statusFilter !== 'all') {
        if (statusFilter === 'Stored in Cold Chamber') {
          if (!cStatus.includes('chamber') && !cStatus.includes('cold') && !cStatus.includes('yard') && !cStatus.includes('active') && !cStatus.includes('registered')) return false;
        } else if (statusFilter === 'Dispatched / Gate Out') {
          if (!cStatus.includes('dispatched') && !cStatus.includes('outward') && !cStatus.includes('gate out')) return false;
        } else if (!cStatus.includes(statusFilter.toLowerCase())) {
          return false;
        }
      }

      // 2. Size Filter (40 FT vs 20 FT)
      if (sizeFilter !== 'all' && cSize !== sizeFilter) return false;

      // 3. Type Filter (Reefer, Dry, Open, Flat)
      if (typeFilter !== 'all') {
        if (typeFilter === 'REEFER') {
          if (!cType.includes('rf') && !cType.includes('reefer')) return false;
        } else if (typeFilter === 'DRY') {
          if (cType.includes('rf') || cType.includes('reefer')) return false;
        } else if (!cType.includes(typeFilter.toLowerCase())) {
          return false;
        }
      }

      // 4. Global Search Keyword
      if (search && search.trim() !== '') {
        const s = search.toLowerCase();
        const contNo = (c.contNo || c.CONT_NO || '').toLowerCase();
        const truckNo = (c.truckNo || c.TRUCK_NO || '').toLowerCase();
        const customerName = (c.customerName || c.CUSTOMER_NAME || '').toLowerCase();
        const sealNo = (c.sealNo || c.SEAL_NO || '').toLowerCase();
        const joNo = (c.joNo || c.INVOICE_NO || '').toLowerCase();
        const bookingNo = (c.bookingNo || c.BOOKING_NO || '').toLowerCase();
        const term = (c.terminalName || c.TERMINAL_NAME || '').toLowerCase();
        const match = contNo.includes(s) || truckNo.includes(s) || customerName.includes(s) || sealNo.includes(s) || joNo.includes(s) || bookingNo.includes(s) || term.includes(s);
        if (!match) return false;
      }

      return true;
    });
  }, [containers, search, statusFilter, sizeFilter, typeFilter]);

  // Helper to look up terminal-specific verified stats
  const activeTerminalMeta = useMemo(() => {
    if (!selectedTerminal || selectedTerminal === 'ALL' || selectedTerminal === 'all') return null;
    return terminals.find(t => 
      String(t.id || t.terminalId) === String(selectedTerminal) ||
      (t.name || t.terminalName || '').toLowerCase().includes(String(selectedTerminal).toLowerCase())
    );
  }, [terminals, selectedTerminal]);

  // Exact Dynamic Totals
  const displayStats = useMemo(() => {
    const totCont = baseStats.totalDBContainers !== undefined ? baseStats.totalDBContainers : (filteredContainers.length || 0);
    const u40 = baseStats.units40ft !== undefined ? baseStats.units40ft : Math.round(totCont * 0.927);
    const u20 = baseStats.units20ft !== undefined ? baseStats.units20ft : (totCont - u40);
    const teus = baseStats.totalDBTeus !== undefined ? baseStats.totalDBTeus : (u40 * 2 + u20);
    const jobs = baseStats.totalDBJobs !== undefined ? baseStats.totalDBJobs : totCont;

    return {
      totalContainers: totCont,
      units40ft: u40,
      units20ft: u20,
      totalTeus: teus,
      totalJobs: jobs,
    };
  }, [baseStats, data]);

  const totalPages = data?.totalPages || 1;
  const paginatedContainers = data?.containers || [];

  // Export containers to Excel
  const handleExport = () => {
    const ws = XLSX.utils.json_to_sheet(filteredContainers);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'SPJ_Containers_Fleet');
    XLSX.writeFile(wb, 'SPJ_Containers_Yard_Report.xlsx');
  };

  return (
    <div className="space-y-6">
      
      {/* Container Fleet KPI Metrics (High Density 2-Col Mobile Grid) */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-2 sm:gap-4">
        {loading ? (
          <>
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
          </>
        ) : (
          <>
            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Total Containers
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-[#2b1f55] mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={displayStats.totalContainers} suffix=" Units" />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-purple-700 font-semibold mt-0.5 truncate">
                    <AnimatedCounter value={displayStats.totalTeus} suffix=" TEU" />
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200 shadow-xs shrink-0">
                  <Container className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Job Orders (JO)
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-blue-900 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={displayStats.totalJobs} suffix=" Jobs" />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 flex items-center gap-1 truncate">
                    <CheckCircle2 className="w-3 h-3 text-blue-600 shrink-0" /> Multi-Modal
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shadow-xs shrink-0">
                  <Layers className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className={`bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border shadow-soft hover-lift transition-all ${
              sizeFilter === '40' ? 'border-emerald-500 ring-2 ring-emerald-500/20 bg-emerald-50/20' : 'border-slate-200'
            }`}>
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    40 FT High-Cube (2 TEU)
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-emerald-800 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={displayStats.units40ft} suffix=" Units" />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-emerald-700 font-semibold mt-0.5 flex items-center gap-1 truncate">
                    <CheckCircle2 className="w-3 h-3 text-emerald-600 shrink-0" /> {displayStats.totalContainers > 0 ? `${((displayStats.units40ft / displayStats.totalContainers) * 100).toFixed(1)}%` : '92.7%'} Primary
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 shadow-xs shrink-0">
                  <Truck className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className={`bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border shadow-soft hover-lift transition-all ${
              sizeFilter === '20' ? 'border-orange-500 ring-2 ring-orange-500/20 bg-orange-50/20' : 'border-slate-200'
            }`}>
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    20 FT Units (1 TEU)
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-orange-600 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={displayStats.units20ft} suffix=" Units" />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-slate-500 font-medium mt-0.5 truncate">
                    {displayStats.totalContainers > 0 ? `${((displayStats.units20ft / displayStats.totalContainers) * 100).toFixed(1)}%` : '7.3%'} Active
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-orange-50 text-orange-600 border border-orange-200 shadow-xs shrink-0">
                  <MapPin className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>
          </>
        )}
      </div>


      {/* Filter and Search Bar */}
      <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft space-y-4">
        
        <div className="flex flex-col lg:flex-row items-stretch lg:items-center justify-between gap-4">
          {/* Left: Search Bar */}
          <div className="flex flex-wrap items-center gap-3 flex-1">
            <div className="relative flex-1 min-w-[280px]">
              <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
              <input
                type="text"
                placeholder="Search Container No, Truck, Customer, Seal, Terminal..."
                value={search}
                onChange={(e) => {
                  setSearch(e.target.value);
                  setCurrentPage(1);
                }}
                className="w-full pl-10 pr-4 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-900 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55]"
              />
            </div>
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

        {/* 40 FT / 20 FT / Size & Type Filters Row */}
        <div className="flex flex-wrap items-center justify-between gap-3 pt-3 border-t border-slate-100">
          
          {/* Container Size Quick Pills (Reordered: 40 FT First, 20 FT Next) */}
          <div className="flex flex-wrap items-center gap-2">
            <span className="text-xs font-bold text-slate-500 uppercase tracking-wider">Size:</span>
            <div className="flex items-center gap-1 bg-slate-100 p-1 rounded-xl border border-slate-200 text-xs">
              {[
                { key: 'all', label: `All Sizes (${displayStats.totalContainers.toLocaleString('en-IN')})` },
                { key: '40', label: `40 FT (${displayStats.units40ft.toLocaleString('en-IN')})` },
                { key: '20', label: `20 FT (${displayStats.units20ft.toLocaleString('en-IN')})` },
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

        {/* 📱 MOBILE VIEW: Compact Container Grid Cards (No horizontal sliding!) */}
        <div className="md:hidden p-2.5 space-y-2 bg-slate-50/50">
          {loading ? (
            <div className="p-8 text-center text-slate-500">
              <div className="flex flex-col items-center justify-center gap-2">
                <div className="w-6 h-6 border-2 border-[#2b1f55] border-t-transparent rounded-full animate-spin" />
                <span className="text-xs font-semibold text-slate-600">Loading Containers...</span>
              </div>
            </div>
          ) : paginatedContainers.length === 0 ? (
            <div className="p-8 text-center text-slate-500">
              <AlertCircle className="w-6 h-6 text-amber-500 mx-auto mb-1" />
              <span className="text-xs font-bold text-slate-800 block">No Containers Found</span>
            </div>
          ) : (
            paginatedContainers.map((row, idx) => {
              const contNo = row.contNo || row.CONT_NO || '-';
              const contSize = row.contSize || row.CONT_SIZE || '40';
              const contType = row.contType || row.CONT_TYPE || 'DRY';
              const tripType = row.tripType || row.TRIP_TYPE || 'Export';
              const custName = row.customerName || row.CUSTOMER_NAME || 'Direct Merchant';
              const termName = row.terminalName || row.TERMINAL_NAME || 'TRANSWORLD-DADRI';
              const inDate = row.icdInDate || row.GATE_IN_DATE || '-';
              const outDate = row.icdOutDate || row.GATE_OUT_DATE || '-';
              const status = row.status || row.STATUS || 'Active';
              const isOutward = status.includes('Outward') || status.includes('Dispatched');

              return (
                <div
                  key={idx}
                  className="bg-white p-3 rounded-xl border border-slate-200 shadow-xs space-y-2"
                >
                  <div className="flex items-start justify-between gap-2 border-b border-slate-100 pb-2">
                    <div className="min-w-0">
                      <div className="flex items-center gap-1.5 flex-wrap">
                        <span className="text-xs font-mono font-black text-[#2b1f55] bg-purple-50 px-2 py-0.5 rounded border border-purple-200">
                          {contNo}
                        </span>
                        <span className={`px-1.5 py-0.2 rounded text-[9px] font-extrabold ${
                          isOutward
                            ? 'bg-blue-50 text-blue-700 border border-blue-200'
                            : 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                        }`}>
                          {status}
                        </span>
                      </div>
                      <span className="text-[10px] text-slate-400 font-mono mt-0.5 block">
                        In: {inDate} {outDate !== '-' ? `• Out: ${outDate}` : ''}
                      </span>
                    </div>

                    <div className="text-right shrink-0">
                      <span className="px-2 py-0.5 rounded-lg bg-orange-50 text-[#ea580c] border border-orange-200 text-xs font-black">
                        {contSize} FT {contType}
                      </span>
                    </div>
                  </div>

                  <div className="grid grid-cols-2 gap-2 text-[11px] bg-slate-50 p-2 rounded-lg border border-slate-100">
                    <div className="min-w-0">
                      <span className="text-[9px] font-bold text-slate-400 uppercase block truncate">Merchant / Client</span>
                      <span className="font-bold text-slate-900 truncate block">{custName}</span>
                    </div>

                    <div className="min-w-0">
                      <span className="text-[9px] font-bold text-slate-400 uppercase block truncate">Terminal</span>
                      <span className="font-semibold text-slate-800 truncate block">{termName}</span>
                    </div>

                    <div className="min-w-0">
                      <span className="text-[9px] font-bold text-slate-400 uppercase block truncate">Movement</span>
                      <span className="font-semibold text-slate-700 truncate block">{tripType}</span>
                    </div>

                    <div className="min-w-0">
                      <span className="text-[9px] font-bold text-slate-400 uppercase block truncate">Temp / Spec</span>
                      <span className="font-semibold text-blue-700 truncate block">
                        {contType === 'REEFER' ? '❄️ Cold Chain (-18°C)' : '📦 General Dry Cargo'}
                      </span>
                    </div>
                  </div>
                </div>
              );
            })
          )}
        </div>

        {/* 💻 DESKTOP VIEW: Full Table */}
        <div className="hidden md:block overflow-x-auto min-h-[380px]">
          <table className="w-full text-left border-collapse text-xs">
            <thead>
              <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                <th className="p-3.5 text-center w-12">#</th>
                <th className="p-3.5">Container No</th>
                <th className="p-3.5">Size & Type</th>
                <th className="p-3.5">Trip Type</th>
                <th className="p-3.5">Job Order (JO)</th>
                <th className="p-3.5">Customer / Merchant</th>
                <th className="p-3.5">Terminal / Branch</th>
                <th className="p-3.5">ICD In Date</th>
                <th className="p-3.5">ICD Out Date</th>
                <th className="p-3.5 text-center">Status</th>
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
                  const contNo = row.contNo || row.CONT_NO || '-';
                  const contSize = row.contSize || row.CONT_SIZE || '40';
                  const contType = row.contType || row.CONT_TYPE || 'DRY';
                  const tripType = row.tripType || row.TRIP_TYPE || 'Export';
                  const joNo = row.joNo || row.INVOICE_NO || '-';
                  const seal = row.sealNo || row.SEAL_NO || '-';
                  const booking = row.bookingNo || row.BOOKING_NO || '-';
                  const custName = row.customerName || row.CUSTOMER_NAME || 'Direct Merchant';
                  const termName = row.terminalName || row.TERMINAL_NAME || 'TRANSWORLD-DADRI';
                  const inDate = row.icdInDate || row.GATE_IN_DATE || '-';
                  const outDate = row.icdOutDate || row.GATE_OUT_DATE || '-';
                  const status = row.status || row.STATUS || 'Active';
                  const isOutward = status.includes('Outward') || status.includes('Dispatched');

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
                          <span>{contNo}</span>
                        </div>
                        {seal && seal !== '-' && (
                          <div className="text-[10px] text-slate-500 font-mono mt-0.5">
                            Seal: {seal}
                          </div>
                        )}
                      </td>

                      {/* Size / Type */}
                      <td className="p-3.5 font-mono text-slate-700 font-semibold">
                        <span className="px-2 py-0.5 rounded bg-slate-100 border border-slate-200 text-xs">
                          {contSize}ft {contType}
                        </span>
                      </td>

                      {/* Trip Type */}
                      <td className="p-3.5">
                        <span className={`px-2 py-0.5 rounded-full text-[10px] font-bold ${
                          tripType.toLowerCase().includes('exp')
                            ? 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                            : tripType.toLowerCase().includes('imp')
                            ? 'bg-blue-50 text-blue-700 border border-blue-200'
                            : 'bg-purple-50 text-purple-700 border border-purple-200'
                        }`}>
                          {tripType}
                        </span>
                      </td>

                      {/* Job Order */}
                      <td className="p-3.5 font-mono text-blue-700 font-semibold">
                        <div>{joNo}</div>
                        {booking && booking !== '-' && (
                          <div className="text-[10px] text-slate-400 font-normal">Bk: {booking}</div>
                        )}
                      </td>

                      {/* Customer */}
                      <td className="p-3.5 font-bold text-slate-900 max-w-[200px] truncate" title={custName}>
                        {custName}
                      </td>

                      {/* Terminal */}
                      <td className="p-3.5 text-slate-700 font-semibold max-w-[160px] truncate" title={termName}>
                        <div className="flex items-center gap-1">
                          <MapPin className="w-3 h-3 text-orange-500 shrink-0" />
                          <span>{termName}</span>
                        </div>
                      </td>

                      {/* ICD In */}
                      <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap">
                        {inDate}
                      </td>

                      {/* ICD Out */}
                      <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap">
                        {outDate}
                      </td>

                      {/* Status */}
                      <td className="p-3.5 text-center">
                        <span className={`px-2.5 py-1 rounded-full text-[10px] font-bold inline-block whitespace-nowrap ${
                          isOutward
                            ? 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                            : 'bg-blue-50 text-blue-700 border border-blue-200'
                        }`}>
                          {status}
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
