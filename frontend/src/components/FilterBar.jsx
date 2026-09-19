import React, { useMemo } from 'react';
import { 
  Search, 
  RotateCcw, 
  Download, 
  Building2, 
  Calendar,
  Users, 
  Wrench, 
  Navigation, 
  FileText,
  SlidersHorizontal
} from 'lucide-react';

// Format currency into Indian Lacs / Crores
const formatRevenueBadge = (amount) => {
  if (!amount || amount <= 0) return '';
  if (amount >= 10000000) return ` (₹ ${(amount / 10000000).toFixed(2)} Cr)`;
  if (amount >= 100000) return ` (₹ ${(amount / 100000).toFixed(2)} L)`;
  if (amount >= 1000) return ` (₹ ${(amount / 1000).toFixed(1)} K)`;
  return ` (₹ ${Math.round(amount).toLocaleString('en-IN')})`;
};

export default function FilterBar({
  filters,
  setFilters,
  masters = {},
  records = [],
  selectedTerminal = 'ALL',
  setSelectedTerminal,
  selectedFY = 'ALL',
  setSelectedFY,
  financialYears = [
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'FY 2023-24', 
    'FY 2022-23 & Earlier'
  ],
  onReset,
  onExport,
  loading = false,
  totalRecords = 0
}) {
  const {
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

  const handleTerminalChange = (val) => {
    handleChange('terminalId', val === 'ALL' ? 'all' : val);
    // Reset subordinate filters when terminal changes
    handleChange('customerId', 'all');
    handleChange('serviceId', 'all');
    if (setSelectedTerminal) setSelectedTerminal(val);
  };

  const handleFYChange = (val) => {
    handleChange('financialYear', val);
    handleChange('customerId', 'all');
    handleChange('serviceId', 'all');
    if (setSelectedFY) setSelectedFY(val);
  };

  // Helper to extract fiscal year from record
  const getRecordFY = (item) => {
    const invDate = item.INVOICE_DATE || '';
    const invRef = item.INVOICE_REF_NO || item.PARTY_INV_NO || '';
    if (invRef.includes('26-27') || invDate.includes('/2026') || invDate.includes('-2026') || invDate.includes('/2027')) return 'FY 2026-27';
    if (invRef.includes('25-26') || invDate.includes('/2025') || invDate.includes('-2025')) return 'FY 2025-26';
    if (invRef.includes('24-25') || invDate.includes('/2024') || invDate.includes('-2024')) return 'FY 2024-25';
    if (invRef.includes('23-24') || invDate.includes('/2023') || invDate.includes('-2023')) return 'FY 2023-24';
    return 'FY 2022-23 & Earlier';
  };

  // 1. Cascading Customers: Dynamic customer list active for selected Terminal & FY with Revenue Amount
  const availableCustomers = useMemo(() => {
    if (!records || records.length === 0) {
      return customers.map(c => ({ id: c.id, name: c.name, revenue: 0, count: 0 }));
    }

    const custMap = {};
    records.forEach(r => {
      // Check Terminal
      if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') {
        const tMatch = (r.TERMINAL_ID && String(r.TERMINAL_ID) === String(selectedTerminal)) ||
                       (r.TERMINAL_NAME && r.TERMINAL_NAME.toLowerCase().includes(String(selectedTerminal).toLowerCase()));
        if (!tMatch) return;
      }

      // Check FY
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') {
        const recFY = getRecordFY(r);
        if (recFY !== selectedFY) return;
      }

      const cId = r.CUSTOMER_ID || r.CUSTOMER_NAME;
      const cName = r.CUSTOMER_NAME || 'SPJ Account Party';
      const rev = Number(r.AMOUNT) || Number(r.BILL_AMOUNT) || 0;

      if (!custMap[cId]) {
        custMap[cId] = {
          id: cId,
          name: cName,
          revenue: 0,
          count: 0
        };
      }
      custMap[cId].revenue += rev;
      custMap[cId].count++;
    });

    const activeList = Object.values(custMap).sort((a, b) => b.revenue - a.revenue);

    if (activeList.length > 0) return activeList;
    return customers.map(c => ({ id: c.id, name: c.name, revenue: 0, count: 0 }));
  }, [records, customers, selectedTerminal, selectedFY]);

  // 2. Cascading Services: Filtered to services under the selected Terminal, FY, and Customer
  const availableServices = useMemo(() => {
    if (!records || records.length === 0) {
      return services.map(s => ({ id: s.id, name: s.name, count: 0 }));
    }

    const sMap = {};
    records.forEach(r => {
      if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') {
        const tMatch = (r.TERMINAL_ID && String(r.TERMINAL_ID) === String(selectedTerminal)) ||
                       (r.TERMINAL_NAME && r.TERMINAL_NAME.toLowerCase().includes(String(selectedTerminal).toLowerCase()));
        if (!tMatch) return;
      }
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') {
        if (getRecordFY(r) !== selectedFY) return;
      }
      if (filters.customerId && filters.customerId !== 'all' && filters.customerId !== 'ALL') {
        const cMatch = (r.CUSTOMER_ID && String(r.CUSTOMER_ID) === String(filters.customerId)) ||
                       (r.CUSTOMER_NAME && r.CUSTOMER_NAME.toLowerCase().includes(String(filters.customerId).toLowerCase()));
        if (!cMatch) return;
      }

      const sId = r.SERVICE_ID || r.SERVICE_NAME;
      const sName = r.SERVICE_NAME || 'Transportation & Handling';
      const amt = Number(r.AMOUNT) || Number(r.BILL_AMOUNT) || 0;

      if (!sMap[sId]) {
        sMap[sId] = { id: sId, name: sName, count: 0, revenue: 0 };
      }
      sMap[sId].count++;
      sMap[sId].revenue += amt;
    });

    const list = Object.values(sMap).sort((a, b) => b.revenue - a.revenue);
    if (list.length > 0) return list;
    return services.map(s => ({ id: s.id, name: s.name, count: 0 }));
  }, [records, services, selectedTerminal, selectedFY, filters.customerId]);

  // 3. Cascading Trip Types: Filtered to trip types under current selection
  const availableTripTypes = useMemo(() => {
    if (!records || records.length === 0) return tripTypes;

    const trips = new Set();
    records.forEach(r => {
      if (selectedTerminal && selectedTerminal !== 'ALL' && selectedTerminal !== 'all') {
        const tMatch = (r.TERMINAL_ID && String(r.TERMINAL_ID) === String(selectedTerminal)) ||
                       (r.TERMINAL_NAME && r.TERMINAL_NAME.toLowerCase().includes(String(selectedTerminal).toLowerCase()));
        if (!tMatch) return;
      }
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') {
        if (getRecordFY(r) !== selectedFY) return;
      }
      if (filters.customerId && filters.customerId !== 'all' && filters.customerId !== 'ALL') {
        const cMatch = (r.CUSTOMER_ID && String(r.CUSTOMER_ID) === String(filters.customerId)) ||
                       (r.CUSTOMER_NAME && r.CUSTOMER_NAME.toLowerCase().includes(String(filters.customerId).toLowerCase()));
        if (!cMatch) return;
      }
      if (r.TRIP_TYPE) trips.add(r.TRIP_TYPE);
    });

    if (trips.size > 0) {
      return Array.from(trips).map(t => ({ code: t, name: t }));
    }
    return tripTypes;
  }, [records, tripTypes, selectedTerminal, selectedFY, filters.customerId]);

  return (
    <div className="bg-white p-5 rounded-3xl border border-slate-200 shadow-soft space-y-4">
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
            className="flex items-center gap-2 px-4 py-2 rounded-xl bg-gradient-to-r from-[#2b1f55] to-[#4338ca] hover:opacity-95 text-white font-bold text-xs shadow-md transition-all disabled:opacity-50"
          >
            <Download className="w-4 h-4 text-emerald-400" />
            Export Excel
          </button>
        </div>
      </div>

      {/* Grid of Parameter Filters (Cascading: Terminal -> FY -> Customer -> Service -> Trip -> Container -> Size -> BL) */}
      <div className="grid grid-cols-2 sm:grid-cols-4 lg:grid-cols-8 gap-3 pt-3 border-t border-slate-100">
        
        {/* 1. Branch / Terminal Selection (SABSE AAGEY - Column 1) */}
        <div>
          <label className="block text-[11px] font-bold text-[#2b1f55] mb-1 flex items-center gap-1">
            <Building2 className="w-3 h-3 text-[#2b1f55]" />
            Terminal / Branch
          </label>
          <select
            value={selectedTerminal !== 'ALL' ? selectedTerminal : (filters.terminalId || 'all')}
            onChange={(e) => handleTerminalChange(e.target.value)}
            className="w-full px-2.5 py-2 bg-purple-50/70 border border-purple-200 rounded-xl text-xs font-bold text-slate-900 focus:outline-none focus:bg-white focus:border-[#2b1f55] cursor-pointer"
          >
            <option value="ALL">🏢 All Terminals ({terminals.length || 39})</option>
            
            {/* 🟢 Active Hubs */}
            <optgroup label="── 🟢 Active Hubs with Data ──">
              {terminals
                .filter(t => (t.totalContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0))
                .map((t) => (
                  <option key={t.id || t.terminalId} value={String(t.id || t.terminalId)}>
                    🟢 {t.name || t.terminalName}
                  </option>
                ))}
            </optgroup>

            {/* 🔴 Inactive / Zero Data */}
            <optgroup label="── 🔴 Inactive / Zero Data ──">
              {terminals
                .filter(t => !(t.totalContainers > 0 || t.netRevenue > 0 || t.billAmount > 0 || t.invoiceCount > 0))
                .map((t) => (
                  <option key={t.id || t.terminalId} value={String(t.id || t.terminalId)} className="text-rose-600 font-semibold bg-rose-50">
                    🔴 {t.name || t.terminalName} (No Data)
                  </option>
                ))}
            </optgroup>
          </select>
        </div>

        {/* 2. Financial Year Filter (SABSE AAGEY - Column 2) */}
        <div>
          <label className="block text-[11px] font-bold text-[#ff6a00] mb-1 flex items-center gap-1">
            <Calendar className="w-3 h-3 text-[#ff6a00]" />
            Financial Year
          </label>
          <select
            value={selectedFY}
            onChange={(e) => handleFYChange(e.target.value)}
            className="w-full px-2.5 py-2 bg-orange-50/70 border border-orange-200 rounded-xl text-xs font-bold text-slate-900 focus:outline-none focus:bg-white focus:border-[#ff6a00] cursor-pointer"
          >
            <option value="ALL">📅 All FYs (Cumulative)</option>
            <option value="FY 2026-27">FY 2026-27</option>
            <option value="FY 2025-26">FY 2025-26</option>
            <option value="FY 2024-25">FY 2024-25</option>
            <option value="FY 2023-24">FY 2023-24</option>
            <option value="FY 2022-23 & Earlier">FY 2022-23 & Earlier</option>
          </select>
        </div>

        {/* 3. Customer / Bill-to (Cascaded with 🟢 Active Indicator and Sales Revenue Amount) */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Users className="w-3 h-3 text-blue-600" />
            Customer
          </label>
          <select
            value={filters.customerId || 'all'}
            onChange={(e) => handleChange('customerId', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-semibold text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55] cursor-pointer truncate"
          >
            <option value="all">All Customers ({availableCustomers.length})</option>
            {availableCustomers.map((c) => (
              <option key={c.id} value={c.id}>
                {c.revenue > 0 ? `🟢 ${c.name}${formatRevenueBadge(c.revenue)}` : c.name}
              </option>
            ))}
          </select>
        </div>

        {/* 4. Service Type (Cascaded based on Terminal & Customer) */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Wrench className="w-3 h-3 text-orange-600" />
            Service Charge
          </label>
          <select
            value={filters.serviceId || 'all'}
            onChange={(e) => handleChange('serviceId', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55] cursor-pointer truncate"
          >
            <option value="all">All Services ({availableServices.length})</option>
            {availableServices.map((s) => (
              <option key={s.id} value={s.id}>
                {s.name}{s.count ? ` (${s.count} Invoices)` : ''}
              </option>
            ))}
          </select>
        </div>

        {/* 5. Trip Type (Cascaded based on earlier selections) */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <Navigation className="w-3 h-3 text-emerald-600" />
            Trip Type
          </label>
          <select
            value={filters.tripType || 'all'}
            onChange={(e) => handleChange('tripType', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55] cursor-pointer"
          >
            <option value="all">All Trip Types</option>
            {availableTripTypes.map((t) => (
              <option key={t.code} value={t.code}>
                {t.name}
              </option>
            ))}
          </select>
        </div>

        {/* 6. Container Number */}
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

        {/* 7. Container Size (40 FT First, 20 FT Next, 45 FT Removed) */}
        <div>
          <label className="block text-[11px] font-bold text-slate-700 mb-1 flex items-center gap-1">
            <SlidersHorizontal className="w-3 h-3 text-cyan-600" />
            Size (20/40 FT)
          </label>
          <select
            value={filters.size || 'all'}
            onChange={(e) => handleChange('size', e.target.value)}
            className="w-full px-2.5 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs font-medium text-slate-800 focus:outline-none focus:bg-white focus:border-[#2b1f55] cursor-pointer"
          >
            <option value="all">All Sizes</option>
            <option value="40">40 FT (2 TEU)</option>
            <option value="20">20 FT (1 TEU)</option>
          </select>
        </div>

        {/* 8. Bill of Lading (BL) */}
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

      </div>
    </div>
  );
}

