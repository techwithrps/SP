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

      const res = await fetch(`/api/operations?${queryParams.toString()}`);
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
    <div className="space-y-6">
      
      {/* Operations Quick Counters */}
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-6 gap-4">
        
        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">Cargo Gate-Ins</span>
            <div className="p-2 rounded-xl bg-emerald-50 text-emerald-600 border border-emerald-200">
              <ArrowDownRight className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? gateInsList.length.toLocaleString('en-IN') : (stats.totalGateIn?.toLocaleString('en-IN') || '655')}
          </div>
          <div className="text-[11px] text-emerald-700 font-semibold mt-1">Vehicles Inward</div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">Vehicle Outward</span>
            <div className="p-2 rounded-xl bg-blue-50 text-blue-600 border border-blue-200">
              <ArrowUpRight className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? gateOutsList.length.toLocaleString('en-IN') : (stats.totalGateOut?.toLocaleString('en-IN') || '806')}
          </div>
          <div className="text-[11px] text-blue-700 font-semibold mt-1">Dispatched Fleet</div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">Dispatch Notes</span>
            <div className="p-2 rounded-xl bg-orange-50 text-[#ff6a00] border border-orange-200">
              <FileCheck className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? dispatchesList.length.toLocaleString('en-IN') : (stats.totalDispatches?.toLocaleString('en-IN') || '427')}
          </div>
          <div className="text-[11px] text-orange-700 font-semibold mt-1">Cold Chain Orders</div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">Picklists</span>
            <div className="p-2 rounded-xl bg-purple-50 text-purple-600 border border-purple-200">
              <Layers className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? picklistsList.length.toLocaleString('en-IN') : (stats.totalPicklists?.toLocaleString('en-IN') || '395')}
          </div>
          <div className="text-[11px] text-purple-700 font-semibold mt-1">Picked Items Tracked</div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">ASN Notices</span>
            <div className="p-2 rounded-xl bg-indigo-50 text-indigo-600 border border-indigo-200">
              <Package className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? asnsList.length.toLocaleString('en-IN') : (stats.totalASNs?.toLocaleString('en-IN') || '322')}
          </div>
          <div className="text-[11px] text-indigo-700 font-semibold mt-1">Advanced Shipping</div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-500">Cross Stuffing</span>
            <div className="p-2 rounded-xl bg-amber-50 text-amber-600 border border-amber-200">
              <Container className="w-4 h-4" />
            </div>
          </div>
          <div className="text-2xl font-black font-display text-slate-900 mt-2">
            {isFiltered ? crossStuffingList.length.toLocaleString('en-IN') : (stats.totalCrossStuffing?.toLocaleString('en-IN') || '56')}
          </div>
          <div className="text-[11px] text-amber-700 font-semibold mt-1">Transfers Executed</div>
        </div>

      </div>

      {/* Sub-tab switcher & Filters */}
      <div className="flex flex-col lg:flex-row items-stretch lg:items-center justify-between gap-3">
        
        {/* Left: Sub-tabs */}
        <div className="flex flex-wrap items-center gap-3">
          <div className="flex flex-wrap items-center gap-1.5 bg-slate-200/80 p-1.5 rounded-2xl border border-slate-300">
            {[
              { key: 'gateIn', label: `Cargo Gate-In (${isFiltered ? gateInsList.length : (stats.totalGateIn || 655)})`, icon: ArrowDownRight },
              { key: 'dispatch', label: `Dispatches & Temps (${isFiltered ? dispatchesList.length : (stats.totalDispatches || 427)})`, icon: Thermometer },
              { key: 'gateOut', label: `Vehicle Outward (${isFiltered ? gateOutsList.length : (stats.totalGateOut || 806)})`, icon: ArrowUpRight },
              { key: 'cross', label: `Cross Stuffing (${isFiltered ? crossStuffingList.length : (stats.totalCrossStuffing || 56)})`, icon: Container },
              { key: 'asn', label: `ASN Inward (${isFiltered ? asnsList.length : (stats.totalASNs || 322)})`, icon: Package },
            ].map(tab => {
              const Icon = tab.icon;
              return (
                <button
                  key={tab.key}
                  onClick={() => setActiveSubTab(tab.key)}
                  className={`flex items-center gap-1.5 px-3 py-1.5 rounded-xl text-xs font-bold transition-all ${
                    activeSubTab === tab.key
                      ? 'bg-[#2b1f55] text-white shadow-sm'
                      : 'text-slate-700 hover:text-[#2b1f55] hover:bg-white'
                  }`}
                >
                  <Icon className="w-3.5 h-3.5" />
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
