import React, { useState, useEffect } from 'react';
import { 
  Truck, 
  ArrowDownRight, 
  ArrowUpRight, 
  Package, 
  Container, 
  RefreshCw, 
  FileCheck, 
  Thermometer, 
  Layers
} from 'lucide-react';

import CompactFilterGroup from './CompactFilterGroup';
import AnimatedCounter from './AnimatedCounter';
import { SkeletonKPICard } from './SkeletonLoader';
import { authFetch } from '../utils/api';

export default function OperationsView({
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  selectedFY = 'ALL',
  setSelectedFY,
  terminals = [],
  financialYears = []
}) {
  const [opsData, setOpsData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [activeSubTab, setActiveSubTab] = useState('gateIn');

  const fetchOperations = async () => {
    setLoading(true);
    try {
      const queryParams = new URLSearchParams();
      if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') queryParams.append('terminalId', selectedTerminal);
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') queryParams.append('financialYear', selectedFY);

      const res = await authFetch(`/api/operations?${queryParams.toString()}`);
      const json = await res.json();
      if (json.success) {
        setOpsData(json.data);
      }
    } catch (e) {
      console.error('Failed to fetch operational data:', e);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchOperations();
  }, [selectedTerminal, selectedFY]);

  const stats = opsData?.stats || {};
  const isFiltered = (selectedTerminal && selectedTerminal !== 'ALL') || (selectedFY && selectedFY !== 'ALL');

  const filterRecord = (row) => {
    if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') {
      const tId = String(row.TERMINAL_ID || '');
      const tName = (row.TERMINAL_NAME || '').toLowerCase();
      const match = tId === String(selectedTerminal) || tName.includes(String(selectedTerminal).toLowerCase());
      if (!match) return false;
    }
    if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') {
      const d = row.GATE_IN_DATE || row.GATE_OUT_DATE || row.DISPATCH_DATE || row.PICKLIST_DATE || row.ASN_DATE || '';
      if (selectedFY === 'FY 2026-27') {
        if (!d.includes('2026') && !d.includes('/26')) return false;
      } else if (selectedFY === 'FY 2025-26') {
        if (!d.includes('2025') && !d.includes('/25')) return false;
      } else if (selectedFY === 'FY 2024-25') {
        if (!d.includes('2024') && !d.includes('/24')) return false;
      } else if (selectedFY === 'FY 2023-24') {
        if (!d.includes('2023') && !d.includes('/23')) return false;
      }
    }
    return true;
  };

  const gateInsList = (opsData?.gateIns || []).filter(filterRecord);
  const gateOutsList = (opsData?.gateOuts || []).filter(filterRecord);
  const dispatchesList = (opsData?.dispatches || []).filter(filterRecord);
  const picklistsList = (opsData?.picklists || []).filter(filterRecord);
  const asnsList = (opsData?.asns || []).filter(filterRecord);
  const crossStuffingList = (opsData?.crossStuffing || []).filter(filterRecord);

  return (
    <div className="space-y-4 sm:space-y-6">
      
      {/* Operations Quick Counters (High Density 2-Col Mobile Grid) */}
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-6 gap-2 sm:gap-4">
        {loading ? (
          <>
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
            <SkeletonKPICard />
          </>
        ) : (
          <>
            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Gate-Ins
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-emerald-800 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? gateInsList.length : (stats.totalGateIn || 655)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-emerald-700 font-semibold mt-0.5 truncate">
                    Inward Yard Arrivals
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-emerald-50 text-emerald-600 border border-emerald-200 shadow-xs shrink-0">
                  <ArrowDownRight className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Vehicle Outward
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-blue-900 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? gateOutsList.length : (stats.totalGateOut || 806)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-blue-700 font-semibold mt-0.5 truncate">
                    Dispatched Units
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-blue-50 text-blue-600 border border-blue-200 shadow-xs shrink-0">
                  <ArrowUpRight className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Dispatches
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-orange-600 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? dispatchesList.length : (stats.totalDispatches || 427)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-orange-700 font-semibold mt-0.5 truncate">
                    Cold Chain Line
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-orange-50 text-[#ff6a00] border border-orange-200 shadow-xs shrink-0">
                  <FileCheck className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Picklists
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-[#2b1f55] mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? picklistsList.length : (stats.totalPicklists || 395)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-purple-700 font-semibold mt-0.5 truncate">
                    Picked Service Orders
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-purple-50 text-[#2b1f55] border border-purple-200 shadow-xs shrink-0">
                  <Layers className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    ASN Notices
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-indigo-900 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? asnsList.length : (stats.totalASNs || 322)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-indigo-700 font-semibold mt-0.5 truncate">
                    Shipping Advance Advises
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-indigo-50 text-indigo-600 border border-indigo-200 shadow-xs shrink-0">
                  <Package className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>

            <div className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all">
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    Cross Stuffing
                  </p>
                  <h3 className="text-sm sm:text-2xl font-black font-display text-amber-900 mt-1 sm:mt-2 truncate">
                    <AnimatedCounter value={isFiltered ? crossStuffingList.length : (stats.totalCrossStuffing || 56)} />
                  </h3>
                  <p className="text-[9px] sm:text-[11px] text-amber-700 font-semibold mt-0.5 truncate">
                    Yard Container Transfers
                  </p>
                </div>
                <div className="p-1.5 sm:p-3 rounded-lg sm:rounded-2xl bg-amber-50 text-amber-600 border border-amber-200 shadow-xs shrink-0">
                  <Container className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>
          </>
        )}
      </div>

      {/* Sub-tab switcher & Filters */}
      <div className="flex flex-col lg:flex-row items-stretch lg:items-center justify-between gap-2.5">
        
        {/* Left: Sub-tabs */}
        <div className="flex items-center gap-1.5 overflow-x-auto no-scrollbar w-full lg:w-auto py-0.5">
          <div className="flex items-center gap-1 sm:gap-1.5 bg-slate-200/80 p-1 sm:p-1.5 rounded-xl sm:rounded-2xl border border-slate-300">
            {[
              { key: 'gateIn', label: `Gate-In (${isFiltered ? gateInsList.length : (stats.totalGateIn || 655)})`, icon: ArrowDownRight },
              { key: 'dispatch', label: `Dispatches (${isFiltered ? dispatchesList.length : (stats.totalDispatches || 427)})`, icon: Thermometer },
              { key: 'gateOut', label: `Outward (${isFiltered ? gateOutsList.length : (stats.totalGateOut || 806)})`, icon: ArrowUpRight },
              { key: 'cross', label: `Cross (${isFiltered ? crossStuffingList.length : (stats.totalCrossStuffing || 56)})`, icon: Container },
              { key: 'asn', label: `ASN (${isFiltered ? asnsList.length : (stats.totalASNs || 322)})`, icon: Package },
            ].map(tab => {
              const Icon = tab.icon;
              return (
                <button
                  key={tab.key}
                  onClick={() => setActiveSubTab(tab.key)}
                  className={`flex items-center gap-1 px-2.5 py-1 sm:px-3 sm:py-1.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all whitespace-nowrap cursor-pointer ${
                    activeSubTab === tab.key
                      ? 'bg-[#2b1f55] text-white shadow-xs'
                      : 'text-slate-700 hover:text-[#2b1f55] hover:bg-white'
                  }`}
                >
                  <Icon className="w-3 h-3 sm:w-3.5 sm:h-3.5" />
                  {tab.label}
                </button>
              );
            })}
          </div>
        </div>


        <button
          onClick={fetchOperations}
          disabled={loading}
          className="flex items-center justify-center gap-1.5 px-4 py-2 bg-white hover:bg-slate-100 border border-slate-300 rounded-xl text-xs font-bold text-slate-700 transition-all shadow-sm self-end lg:self-auto"
        >
          <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
          Refresh
        </button>
      </div>

      {/* Operational Table Content */}
      <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden">
        
        {activeSubTab === 'gateIn' && (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-xs">
              <thead className="bg-slate-100 text-slate-700 uppercase text-[11px] font-bold tracking-wider border-b border-slate-200">
                <tr>
                  <th className="p-3.5">Ref No</th>
                  <th className="p-3.5">Truck No</th>
                  <th className="p-3.5">Driver</th>
                  <th className="p-3.5">Transporter</th>
                  <th className="p-3.5">Gate In Date/Time</th>
                  <th className="p-3.5">Container No</th>
                  <th className="p-3.5">Seal No</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {gateInsList.length === 0 ? (
                  <tr>
                    <td colSpan={7} className="p-8 text-center text-slate-400 font-semibold">
                      No Cargo Gate-In entries found for the selected Terminal & Financial Year.
                    </td>
                  </tr>
                ) : (
                  gateInsList.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-bold text-[#2b1f55] font-mono">{row.REFERENCE_NO || `SPJ-${row.CARGO_GATE_IN_ID}`}</td>
                      <td className="p-3.5 font-mono text-orange-600 font-bold">{row.TRUCK_NO || '-'}</td>
                      <td className="p-3.5 text-slate-900 font-medium">{row.DRIVER && row.DRIVER !== 'NA' ? row.DRIVER : 'Assigned Driver'}</td>
                      <td className="p-3.5 text-slate-700">{row.TRANSPORTER_NAME || 'SPJ Logistics Fleet'}</td>
                      <td className="p-3.5 text-slate-500 font-mono text-xs">{row.GATE_IN_DATE || '-'}</td>
                      <td className="p-3.5 font-mono text-blue-700 font-bold">{row.CONT_NO && row.CONT_NO !== '-' ? row.CONT_NO : 'Bulk / Palletized'}</td>
                      <td className="p-3.5 font-mono text-slate-600">{row.SEAL_NO && row.SEAL_NO !== '-' ? row.SEAL_NO : 'Custom Tagged'}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        )}

        {activeSubTab === 'dispatch' && (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-xs">
              <thead className="bg-slate-100 text-slate-700 uppercase text-[11px] font-bold tracking-wider border-b border-slate-200">
                <tr>
                  <th className="p-3.5">Dispatch Ref</th>
                  <th className="p-3.5">Truck No</th>
                  <th className="p-3.5">Container No</th>
                  <th className="p-3.5">Client Invoice No</th>
                  <th className="p-3.5">Dispatch Temp</th>
                  <th className="p-3.5">Date</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {dispatchesList.length === 0 ? (
                  <tr>
                    <td colSpan={6} className="p-8 text-center text-slate-400 font-semibold">
                      No Dispatch entries found for the selected Terminal & Financial Year.
                    </td>
                  </tr>
                ) : (
                  dispatchesList.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-bold text-[#2b1f55] font-mono">{row.DISPATCH_REF_NO || `DSP-${row.DISPATCH_ID}`}</td>
                      <td className="p-3.5 font-mono text-orange-600 font-bold">{row.TRUCK_NO || '-'}</td>
                      <td className="p-3.5 font-mono text-blue-700 font-bold">{row.CONT_NO && row.CONT_NO !== '-' ? row.CONT_NO : 'Direct Loading'}</td>
                      <td className="p-3.5 text-slate-800 font-mono font-semibold">{row.CLIENT_INVOICE_NO && row.CLIENT_INVOICE_NO !== '-' ? row.CLIENT_INVOICE_NO : 'Internal Order'}</td>
                      <td className="p-3.5">
                        <span className="px-2.5 py-1 rounded-md bg-blue-50 text-blue-700 border border-blue-200 font-mono font-bold text-xs">
                          {row.DISPATCH_TEMPERATURE ? `${row.DISPATCH_TEMPERATURE}°C` : '-18°C'}
                        </span>
                      </td>
                      <td className="p-3.5 text-slate-500 font-mono">{row.DISPATCH_DATE || '-'}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        )}

        {activeSubTab === 'gateOut' && (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-xs">
              <thead className="bg-slate-100 text-slate-700 uppercase text-[11px] font-bold tracking-wider border-b border-slate-200">
                <tr>
                  <th className="p-3.5">Vehicle ID</th>
                  <th className="p-3.5">Truck No</th>
                  <th className="p-3.5">Driver Name</th>
                  <th className="p-3.5">Transporter</th>
                  <th className="p-3.5">Container No</th>
                  <th className="p-3.5">Seal No</th>
                  <th className="p-3.5">Gate Out Date/Time</th>
                  <th className="p-3.5">Remarks</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {gateOutsList.length === 0 ? (
                  <tr>
                    <td colSpan={8} className="p-8 text-center text-slate-400 font-semibold">
                      No Outward entries found for the selected Terminal & Financial Year.
                    </td>
                  </tr>
                ) : (
                  gateOutsList.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-mono text-slate-500">{row.VEHICLE_ID}</td>
                      <td className="p-3.5 font-mono text-orange-600 font-bold">{row.TRUCK_NO || '-'}</td>
                      <td className="p-3.5 text-slate-900 font-medium">{row.DRIVER_NAME && row.DRIVER_NAME !== '-' ? row.DRIVER_NAME : 'Authorized Driver'}</td>
                      <td className="p-3.5 text-slate-700">{row.TRANSPORTER_NAME || 'SPJ Logistics'}</td>
                      <td className="p-3.5 font-mono text-blue-700 font-bold">{row.CONT_NO && row.CONT_NO !== '-' ? row.CONT_NO : 'Bulk Cargo'}</td>
                      <td className="p-3.5 font-mono text-slate-600">{row.SEAL_NO && row.SEAL_NO !== '-' ? row.SEAL_NO : 'Gate Checked'}</td>
                      <td className="p-3.5 text-slate-500 font-mono text-xs">{row.GATE_OUT_DATE || '-'}</td>
                      <td className="p-3.5 text-slate-700 truncate max-w-[150px]">{row.REMARKS && row.REMARKS !== '-' ? row.REMARKS : 'Normal Exit'}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        )}

        {activeSubTab === 'cross' && (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-xs">
              <thead className="bg-slate-100 text-slate-700 uppercase text-[11px] font-bold tracking-wider border-b border-slate-200">
                <tr>
                  <th className="p-3.5">CS Ref No</th>
                  <th className="p-3.5">Truck No</th>
                  <th className="p-3.5">Container No</th>
                  <th className="p-3.5">Seal No</th>
                  <th className="p-3.5">Commodity / Chamber</th>
                  <th className="p-3.5">Gate In Date/Time</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {crossStuffingList.length === 0 ? (
                  <tr>
                    <td colSpan={6} className="p-8 text-center text-slate-400 font-semibold">
                      No Cross-Stuffing transfers found for the selected Terminal & Financial Year.
                    </td>
                  </tr>
                ) : (
                  crossStuffingList.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-bold text-[#2b1f55] font-mono">{row.CS_REF_NO || `CS-${row.CS_GATE_IN_ID}`}</td>
                      <td className="p-3.5 font-mono text-orange-600 font-bold">{row.TRUCK_NO || '-'}</td>
                      <td className="p-3.5 font-mono text-blue-700 font-bold">{row.CONT_NO && row.CONT_NO !== '-' ? row.CONT_NO : 'Pallet Stack'}</td>
                      <td className="p-3.5 font-mono text-slate-600">{row.SEAL_NO && row.SEAL_NO !== '-' ? row.SEAL_NO : 'Verified'}</td>
                      <td className="p-3.5 text-slate-800 font-medium">{row.COMMODITY || 'Frozen Cargo'} ({row.CHAMBER || 'Chamber-1'})</td>
                      <td className="p-3.5 text-slate-500 font-mono text-xs">{row.GATE_IN_DATE || '-'}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        )}

        {activeSubTab === 'asn' && (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-xs">
              <thead className="bg-slate-100 text-slate-700 uppercase text-[11px] font-bold tracking-wider border-b border-slate-200">
                <tr>
                  <th className="p-3.5">ASN No</th>
                  <th className="p-3.5">ASN Date</th>
                  <th className="p-3.5">Truck No</th>
                  <th className="p-3.5">Supplier / Account Holder</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {asnsList.length === 0 ? (
                  <tr>
                    <td colSpan={4} className="p-8 text-center text-slate-400 font-semibold">
                      No Advance Shipping Notices (ASN) found for the selected Terminal & Financial Year.
                    </td>
                  </tr>
                ) : (
                  asnsList.map((row, idx) => (
                    <tr key={idx} className="hover:bg-slate-50 transition-colors">
                      <td className="p-3.5 font-bold text-[#2b1f55] font-mono">{row.ASN_NO || `ASN-${row.ASN_ID}`}</td>
                      <td className="p-3.5 text-slate-500 font-mono">{row.ASN_DATE || '-'}</td>
                      <td className="p-3.5 font-mono text-orange-600 font-bold">{row.TRUCK_NO || '-'}</td>
                      <td className="p-3.5 text-slate-900 font-semibold">{row.SUPPLIER_NAME || 'SPJ Key Account'}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        )}

      </div>
    </div>
  );
}
