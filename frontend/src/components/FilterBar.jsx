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
    const invDate = String(item.INVOICE_DATE || item.CREATED_DATE || item.CREATED_ON || item.LINE_HANDOVER_DATE || '');
    const invRef = String(item.INVOICE_REF_NO || item.PARTY_INV_NO || '');
    if (invRef.includes('26-27') || invDate.includes('2026') || invDate.includes('2027') || invDate.includes('/26') || invDate.includes('-26')) return 'FY 2026-27';
    if (invRef.includes('25-26') || invDate.includes('2025') || invDate.includes('/25') || invDate.includes('-25')) return 'FY 2025-26';
    if (invRef.includes('24-25') || invDate.includes('2024') || invDate.includes('/24') || invDate.includes('-24')) return 'FY 2024-25';
    if (invRef.includes('23-24') || invDate.includes('2023') || invDate.includes('/23') || invDate.includes('-23')) return 'FY 2023-24';
    return 'FY 2022-23 & Earlier';
  };

  // 1. Cascading Customers: Active customers in scope at top with revenue, plus all master customers
  const availableCustomers = useMemo(() => {
    const custMap = {};
    if (records && records.length > 0) {
      records.forEach(r => {
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
    }

    const activeList = Object.values(custMap).sort((a, b) => b.revenue - a.revenue);
    const activeIds = new Set(activeList.map(a => String(a.id)));
    const activeNames = new Set(activeList.map(a => String(a.name).toLowerCase().trim()));

    const otherList = (customers || [])
      .filter(c => !activeIds.has(String(c.id)) && !activeNames.has(String(c.name).toLowerCase().trim()))
      .map(c => ({ id: c.id, name: c.name, revenue: 0, count: 0 }));

    return {
      active: activeList,
      others: otherList,
      all: [...activeList, ...otherList]
    };
  }, [records, customers]);

  // 2. Cascading Services: Active services in scope at top, plus all master services
  const availableServices = useMemo(() => {
    const sMap = {};
    if (records && records.length > 0) {
      records.forEach(r => {
        const sId = r.SERVICE_ID || r.SERVICE_NAME;
        const sName = r.SERVICE_NAME || 'Transportation & Handling';
        const amt = Number(r.AMOUNT) || Number(r.BILL_AMOUNT) || 0;

        if (!sMap[sId]) {
          sMap[sId] = { id: sId, name: sName, count: 0, revenue: 0 };
        }
        sMap[sId].count++;
        sMap[sId].revenue += amt;
      });
    }

    const activeList = Object.values(sMap).sort((a, b) => b.revenue - a.revenue);
    const activeIds = new Set(activeList.map(a => String(a.id)));
    const activeNames = new Set(activeList.map(a => String(a.name).toLowerCase().trim()));

    const otherList = (services || [])
      .filter(s => !activeIds.has(String(s.id)) && !activeNames.has(String(s.name).toLowerCase().trim()))
      .map(s => ({ id: s.id, name: s.name, count: 0, revenue: 0 }));

    return {
      active: activeList,
      others: otherList,
      all: [...activeList, ...otherList]
    };
  }, [records, services]);

  // 3. Cascading Trip Types: Standard operational categories
  const availableTripTypes = useMemo(() => {
    const standard = [
      { code: 'Export', name: 'Export Movement' },
      { code: 'Import', name: 'Import Movement' },
      { code: 'Domestic', name: 'Domestic / Inter-ICD' },
      { code: 'Empty Return', name: 'Empty Return & Repositioning' },
      { code: 'Clearance', name: 'Customs Clearance' },
      { code: 'Credit Note', name: 'Credit Note Reversals' },
      { code: 'REBATE', name: 'Terminal Rebate' }
    ];
    return standard;
  }, []);

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
            Total Results: <span className="text-[#2b1f55] font-black">{Number(totalRecords || 0).toLocaleString('en-IN')}</span>
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

      {/* Grid of Parameter Filters (6 Columns: Customer -> Service -> Trip -> Container -> Size -> BL) */}
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-6 gap-3 pt-3 border-t border-slate-100">
        
        {/* 1. Customer / Bill-to (Cascaded with 🟢 Active Indicator and Sales Revenue Amount) */}
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
            <option value="all">🏢 All Customers ({availableCustomers.all?.length || 'All'})</option>
            {availableCustomers.active?.length > 0 && (
              <optgroup label="── 🟢 Active in Current Scope ──">
                {availableCustomers.active.map((c) => (
                  <option key={c.id} value={c.id}>
                    🟢 {c.name}{formatRevenueBadge(c.revenue)} ({c.count} Bills)
                  </option>
                ))}
              </optgroup>
            )}
            {availableCustomers.others?.length > 0 && (
              <optgroup label="── All Master Customers ──">
                {availableCustomers.others.map((c) => (
                  <option key={c.id} value={c.id}>
                    {c.name}
                  </option>
                ))}
              </optgroup>
            )}
          </select>
        </div>

        {/* 2. Service Type (Cascaded based on Terminal & Customer) */}
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
            <option value="all">⚡ All Services ({availableServices.all?.length || 'All'})</option>
            {availableServices.active?.length > 0 && (
              <optgroup label="── 🟢 Active in Current Scope ──">
                {availableServices.active.map((s) => (
                  <option key={s.id} value={s.id}>
                    🟢 {s.name}{formatRevenueBadge(s.revenue)} ({s.count} Items)
                  </option>
                ))}
              </optgroup>
            )}
            {availableServices.others?.length > 0 && (
              <optgroup label="── All Master Services ──">
                {availableServices.others.map((s) => (
                  <option key={s.id} value={s.id}>
                    {s.name}
                  </option>
                ))}
              </optgroup>
            )}
          </select>
        </div>

        {/* 3. Trip Type (Cascaded based on earlier selections) */}
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

        {/* 4. Container Number */}
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

        {/* 5. Container Size (40 FT First, 20 FT Next) */}
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

        {/* 6. Bill of Lading (BL) */}
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

