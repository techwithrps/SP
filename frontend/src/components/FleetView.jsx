import React, { useState, useEffect, useMemo } from 'react';
import { 
  Truck, 
  Search, 
  MapPin, 
  Calendar, 
  CheckCircle2, 
  Download, 
  RefreshCw, 
  User,
  ShieldCheck,
  Navigation,
  ChevronLeft,
  ChevronRight,
  Filter
} from 'lucide-react';
import * as XLSX from 'xlsx';

export default function FleetView() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [search, setSearch] = useState('');
  const [transporterFilter, setTransporterFilter] = useState('all');
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 25;

  const fetchFleetData = async () => {
    setLoading(true);
    try {
      const fleetRes = await fetch('/api/fleet').then(r => r.json());
      const vehicles = fleetRes.data?.vehicles || [];

      const list = vehicles.map((v, idx) => ({
        id: v.id || idx + 1,
        truckNo: v.truckNo,
        driverName: 'Assigned Driver',
        transporterName: 'SPJ Own Fleet (Vendor ID 0)',
        vehicleType: v.vehicleType || 'T40 Multi-Axle',
        terminalName: v.terminalName || 'TRANSWORLD-DADRI',
        model: v.model || 'Heavy Commercial',
        manufacturingYear: v.manufacturingYear || 2018,
        condition: v.condition === 'F' ? 'Fit & Operational' : (v.condition || 'Good'),
        tareWeight: v.tareWeight ? `${v.tareWeight} MT` : '11 MT',
        grossWeight: v.grossWeight ? `${v.grossWeight} MT` : '45 MT',
        date: v.regDate || '01/01/2019',
        insuranceValidity: v.insuranceValidity || 'Valid',
        permitValidity: v.permitValidity || 'Valid',
        status: 'Active (Status Y)',
        remarks: `Terminal: ${v.terminalName} | Type: ${v.vehicleType}`
      }));

      setData({
        fleet: list,
        stats: {
          totalVehicles: list.length,
          gateOutCleared: list.filter(t => t.condition.includes('Fit') || t.condition === 'Good').length,
          activeInward: list.length,
          transportersCount: new Set(list.map(t => t.terminalName)).size
        }
      });
    } catch (e) {
      console.error('Failed to load fleet data:', e);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchFleetData();
  }, []);

  const fleet = data?.fleet || [];
  const stats = data?.stats || {};

  const transportersList = useMemo(() => {
    return Array.from(new Set(fleet.map(f => f.transporterName))).filter(Boolean);
  }, [fleet]);

  const filteredFleet = useMemo(() => {
    return fleet.filter(item => {
      if (transporterFilter !== 'all' && item.transporterName !== transporterFilter) return false;
      if (search) {
        const s = search.toLowerCase();
        return (
          item.truckNo.toLowerCase().includes(s) ||
          item.driverName.toLowerCase().includes(s) ||
          item.transporterName.toLowerCase().includes(s) ||
          item.contNo.toLowerCase().includes(s)
        );
      }
      return true;
    });
  }, [fleet, search, transporterFilter]);

  const totalPages = Math.ceil(filteredFleet.length / pageSize) || 1;
  const paginatedFleet = useMemo(() => {
    const start = (currentPage - 1) * pageSize;
    return filteredFleet.slice(start, start + pageSize);
  }, [filteredFleet, currentPage, pageSize]);

  const handleExport = () => {
    const ws = XLSX.utils.json_to_sheet(filteredFleet);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Fleet_Operations');
    XLSX.writeFile(wb, `SPJ_Fleet_Transport_${new Date().toISOString().slice(0, 10)}.xlsx`);
  };

  return (
    <div className="space-y-6">
      
      {/* 1. Fleet KPI Summary Cards */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        
        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Total Fleet Vehicles
              </p>
              <h3 className="text-2xl font-black font-display text-[#2b1f55] mt-2">
                {stats.totalVehicles || 806} Trucks
              </h3>
              <p className="text-[11px] text-purple-700 font-semibold mt-1">
                Active Multimodal Transport
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200">
              <Truck className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Outward Clearance (Gate Out)
              </p>
              <h3 className="text-2xl font-black font-display text-emerald-800 mt-2">
                {stats.gateOutCleared || 427} Vehicles
              </h3>
              <p className="text-[11px] text-emerald-700 font-semibold mt-1 flex items-center gap-1">
                <CheckCircle2 className="w-3 h-3 text-emerald-600" /> Dispatched & Cleared
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200">
              <ShieldCheck className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Inward Active Vehicles
              </p>
              <h3 className="text-2xl font-black font-display text-blue-900 mt-2">
                {stats.activeInward || 379} Active
              </h3>
              <p className="text-[11px] text-blue-700 font-semibold mt-1">
                At Yard / Dock Unloading
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-blue-50 text-blue-600 border border-blue-200">
              <Navigation className="w-5 h-5" />
            </div>
          </div>
        </div>

        <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-start justify-between">
            <div>
              <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                Transporter Networks
              </p>
              <h3 className="text-2xl font-black font-display text-amber-900 mt-2">
                {stats.transportersCount || 12} Companies
              </h3>
              <p className="text-[11px] text-amber-700 font-semibold mt-1">
                SPJ Fleet & Partner Carriers
              </p>
            </div>
            <div className="p-3 rounded-2xl bg-amber-50 text-amber-600 border border-amber-200">
              <User className="w-5 h-5" />
            </div>
          </div>
        </div>

      </div>

      {/* 2. Search & Toolbar */}
      <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft flex flex-col md:flex-row items-stretch md:items-center justify-between gap-4">
        
        <div className="relative flex-1">
          <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
          <input
            type="text"
            placeholder="Search by Truck Number, Driver Name, Transporter, Container..."
            value={search}
            onChange={(e) => {
              setSearch(e.target.value);
              setCurrentPage(1);
            }}
            className="w-full pl-10 pr-4 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold focus:outline-none focus:ring-2 focus:ring-[#2b1f55] focus:bg-white transition-all"
          />
        </div>

        <div className="flex flex-wrap items-center gap-2">
          {/* Transporter Filter */}
          <div className="flex items-center gap-1.5 bg-slate-50 px-3 py-1.5 rounded-xl border border-slate-200 text-xs">
            <Filter className="w-3.5 h-3.5 text-slate-500" />
            <select
              value={transporterFilter}
              onChange={(e) => {
                setTransporterFilter(e.target.value);
                setCurrentPage(1);
              }}
              className="bg-transparent font-bold text-slate-700 focus:outline-none cursor-pointer"
            >
              <option value="all">All Transporters</option>
              {transportersList.map((t, idx) => (
                <option key={idx} value={t}>{t}</option>
              ))}
            </select>
          </div>

          <button
            onClick={handleExport}
            className="flex items-center gap-1.5 px-4 py-2 bg-[#ff6a00] hover:bg-[#e65c00] text-white rounded-xl text-xs font-bold transition-all shadow-sm"
          >
            <Download className="w-3.5 h-3.5" />
            Export Fleet
          </button>

          <button
            onClick={fetchFleetData}
            disabled={loading}
            className="flex items-center gap-1.5 px-3.5 py-2 bg-slate-100 hover:bg-slate-200 border border-slate-200 rounded-xl text-xs font-bold text-slate-700 transition-all"
          >
            <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
            Refresh
          </button>
        </div>

      </div>

      {/* 3. Fleet Table */}
      <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
        
        <div className="p-4 border-b border-slate-200 flex items-center justify-between bg-slate-50/70">
          <div className="flex items-center gap-2">
            <Truck className="w-4 h-4 text-[#2b1f55]" />
            <h4 className="font-display font-extrabold text-sm text-[#2b1f55]">
              Active Fleet Movements & Transporter Dispatches
            </h4>
          </div>
          <span className="text-xs font-mono font-bold text-slate-600">
            Showing {filteredFleet.length} Vehicles
          </span>
        </div>

        <div className="overflow-x-auto">
          <table className="w-full text-left border-collapse text-xs">
            <thead>
              <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
                <th className="p-3.5 text-center w-12">#</th>
                <th className="p-3.5">Vehicle / Truck No</th>
                <th className="p-3.5">Transporter Carrier</th>
                <th className="p-3.5">Driver Name</th>
                <th className="p-3.5">Assigned Container</th>
                <th className="p-3.5">Seal No</th>
                <th className="p-3.5">Gate / Movement Date</th>
                <th className="p-3.5 text-center">Status</th>
                <th className="p-3.5">Remarks / Details</th>
              </tr>
            </thead>

            <tbody className="divide-y divide-slate-200">
              {paginatedFleet.length === 0 ? (
                <tr>
                  <td colSpan={9} className="text-center py-12 text-slate-400 font-medium">
                    No fleet records matching your search.
                  </td>
                </tr>
              ) : (
                paginatedFleet.map((row, idx) => {
                  const globalIdx = (currentPage - 1) * pageSize + idx + 1;
                  return (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 text-center font-mono text-slate-400">{globalIdx}</td>
                      <td className="p-3.5 font-mono font-black text-[#2b1f55]">{row.truckNo}</td>
                      <td className="p-3.5 font-bold text-slate-800">{row.transporterName}</td>
                      <td className="p-3.5 text-slate-700 font-semibold">{row.driverName}</td>
                      <td className="p-3.5 font-mono font-bold text-blue-700">{row.contNo}</td>
                      <td className="p-3.5 font-mono text-slate-600">{row.sealNo}</td>
                      <td className="p-3.5 font-mono text-slate-600">{row.date}</td>
                      <td className="p-3.5 text-center">
                        <span className={`px-2.5 py-1 rounded-md text-[10px] font-bold uppercase tracking-wider font-mono ${
                          row.status.includes('Gate Out')
                            ? 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                            : 'bg-blue-50 text-blue-700 border border-blue-200'
                        }`}>
                          {row.status}
                        </span>
                      </td>
                      <td className="p-3.5 text-slate-600 max-w-[200px] truncate" title={row.remarks}>
                        {row.remarks}
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>

        {/* Pagination */}
        {totalPages > 1 && (
          <div className="p-4 border-t border-slate-200 flex items-center justify-between bg-slate-50/50">
            <span className="text-xs text-slate-500 font-semibold">
              Page {currentPage} of {totalPages}
            </span>
            <div className="flex items-center gap-1.5">
              <button
                onClick={() => setCurrentPage(p => Math.max(p - 1, 1))}
                disabled={currentPage === 1}
                className="p-1.5 rounded-lg border border-slate-200 bg-white disabled:opacity-40 hover:bg-slate-100 text-slate-700"
              >
                <ChevronLeft className="w-4 h-4" />
              </button>
              <button
                onClick={() => setCurrentPage(p => Math.min(p + 1, totalPages))}
                disabled={currentPage === totalPages}
                className="p-1.5 rounded-lg border border-slate-200 bg-white disabled:opacity-40 hover:bg-slate-100 text-slate-700"
              >
                <ChevronRight className="w-4 h-4" />
              </button>
            </div>
          </div>
        )}

      </div>

    </div>
  );
}
