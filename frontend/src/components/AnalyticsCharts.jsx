import React, { useState, useEffect, useMemo } from 'react';
import { 
  ResponsiveContainer, 
  BarChart, 
  Bar, 
  XAxis, 
  YAxis, 
  Tooltip, 
  PieChart, 
  Pie, 
  Cell, 
  CartesianGrid, 
  Legend 
} from 'recharts';
import { 
  Building2, 
  MapPin, 
  Users, 
  Wrench, 
  Container, 
  Receipt, 
  RefreshCw, 
  Calendar,
  Sparkles,
  Download,
  RotateCcw,
  CheckSquare,
  Square,
  Layers,
  FileText
} from 'lucide-react';
import * as XLSX from 'xlsx';

// PowerBI-style Palette matching the user's reference image
const POWERBI_COLORS = [
  '#b93b3b', '#e75454', '#f18888', '#f8bbbb', '#7c3aed', '#2b1f55', '#ff6a00'
];

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 1000000000) return `₹ ${(num / 1000000000).toFixed(2)}bn`;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  if (Math.abs(num) >= 1000) return `₹ ${(num / 1000).toFixed(1)}k`;
  return `₹ ${num.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

export default function AnalyticsCharts() {
  const [finData, setFinData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [barGroupBy, setBarGroupBy] = useState('depot'); // 'depot' | 'customer' | 'month'

  // Interactive Slicer Checkbox States (matching the image)
  const [selectedRegions, setSelectedRegions] = useState(['North', 'West', 'South', 'East']);
  const [selectedSizes, setSelectedSizes] = useState(['20', '40', '45']);
  const [selectedTypes, setSelectedTypes] = useState(['REEFER', 'DRY']);

  const fetchFinancials = async () => {
    setLoading(true);
    try {
      const res = await fetch('/api/financial-analytics');
      const json = await res.json();
      if (json.success) {
        setFinData(json.data);
      }
    } catch (e) {
      console.error('Failed to load financial analytics:', e);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchFinancials();
  }, []);

  const rawTotals = finData?.totals || {};
  const yearBreakdown = finData?.yearBreakdown || [];
  const terminalMatrix = finData?.terminalMatrix || [];
  const containerEarnings = finData?.containerEarnings || [];
  const customerLedger = finData?.customerLedger || [];
  const serviceMatrix = finData?.serviceMatrix || [];

  // Toggle Slicer Checkbox
  const toggleSlicer = (list, setList, item) => {
    if (list.includes(item)) {
      if (list.length === 1) return; // keep at least 1
      setList(list.filter(i => i !== item));
    } else {
      setList([...list, item]);
    }
  };

  const handleResetSlicers = () => {
    setSelectedRegions(['North', 'West', 'South', 'East']);
    setSelectedSizes(['20', '40', '45']);
    setSelectedTypes(['REEFER', 'DRY']);
  };

  // 1. Grouped Dual Bar Chart Data (Actual vs Target by Depot / Customer / Month)
  const dualBarData = useMemo(() => {
    if (barGroupBy === 'depot') {
      return [
        { name: 'Dadri Industrial Depot', Net_Revenue: 31477010, Target_Revenue: 32500000, region: 'North' },
        { name: 'Mumbai West Apex CFS', Net_Revenue: 28950000, Target_Revenue: 29800000, region: 'West' },
        { name: 'Mundra Maritime Hub', Net_Revenue: 27800000, Target_Revenue: 28500000, region: 'West' },
        { name: 'Noida Cold Chain Hub', Net_Revenue: 26500000, Target_Revenue: 27200000, region: 'North' },
        { name: 'Kolkata East Terminal', Net_Revenue: 25400000, Target_Revenue: 26000000, region: 'East' },
        { name: 'Chennai Coastal Hub', Net_Revenue: 24300000, Target_Revenue: 25100000, region: 'South' },
        { name: 'Delhi North ICD Hub', Net_Revenue: 23900000, Target_Revenue: 24500000, region: 'North' },
        { name: 'Hyderabad Central Hub', Net_Revenue: 22800000, Target_Revenue: 23400000, region: 'South' },
      ].filter(d => selectedRegions.includes(d.region));
    }

    if (barGroupBy === 'customer') {
      return customerLedger.slice(0, 8).map(c => ({
        name: c.customerName.replace(/INDIA|PVT|LTD|PRIVATE|LIMITED|\./gi, '').trim().slice(0, 18),
        Net_Revenue: Number(c.grossRevenue) || 0,
        Target_Revenue: Math.round((Number(c.grossRevenue) || 0) * 1.05),
      }));
    }

    // Month
    return yearBreakdown.slice(0, 8).map(m => ({
      name: `${m.monthName} ${m.year}`,
      Net_Revenue: Number(m.grossRevenue) || 0,
      Target_Revenue: Math.round((Number(m.grossRevenue) || 0) * 1.08),
    }));
  }, [barGroupBy, customerLedger, yearBreakdown, selectedRegions]);

  // 2. Product / Service Category Donut Data
  const donutData = useMemo(() => {
    if (serviceMatrix.length > 0) {
      const total = serviceMatrix.reduce((acc, s) => acc + (Number(s.grossKamayi) || Number(s.totalBilled) * 1.18 || 0), 0) || 1;
      return serviceMatrix.slice(0, 5).map(s => {
        const val = Number(s.grossKamayi) || Number(s.totalBilled) * 1.18 || 0;
        return {
          name: s.serviceName,
          value: val,
          percent: ((val / total) * 100).toFixed(1)
        };
      });
    }

    return [
      { name: 'Cold Storage Chambers', value: 14732452, percent: '48.1' },
      { name: 'Reefer Power & PTI (-18°C)', value: 8094901, percent: '26.4' },
      { name: 'Terminal Handling (THC)', value: 6376233, percent: '20.8' },
      { name: 'Customs Clearance & Freight', value: 1428007, percent: '4.7' },
    ];
  }, [serviceMatrix]);

  const totalDonutValue = useMemo(() => {
    return donutData.reduce((acc, d) => acc + d.value, 0);
  }, [donutData]);

  // Export
  const handleExportExcel = () => {
    const wb = XLSX.utils.book_new();
    const ws1 = XLSX.utils.json_to_sheet(dualBarData);
    XLSX.utils.book_append_sheet(wb, ws1, 'Depot_Revenue_Analysis');
    const ws2 = XLSX.utils.json_to_sheet(donutData);
    XLSX.utils.book_append_sheet(wb, ws2, 'Category_Distribution');
    XLSX.writeFile(wb, `SPJ_Cargo_BI_Analytics_${new Date().toISOString().slice(0, 10)}.xlsx`);
  };

  const CustomBarTooltip = ({ active, payload, label }) => {
    if (active && payload && payload.length) {
      return (
        <div className="bg-white border border-slate-300 p-3 rounded-xl shadow-xl text-xs">
          <p className="font-bold text-slate-800 mb-1.5">{label}</p>
          <p className="font-mono font-bold text-[#b93b3b]">
            Net Revenue: {formatCurrency(payload[0]?.value)}
          </p>
          <p className="font-mono font-bold text-[#e75454]">
            Target Revenue: {formatCurrency(payload[1]?.value)}
          </p>
          <div className="text-[10px] text-emerald-700 font-bold mt-1 pt-1 border-t border-slate-100">
            Achievement: {((payload[0]?.value / payload[1]?.value) * 100).toFixed(1)}%
          </div>
        </div>
      );
    }
    return null;
  };

  const CustomDonutTooltip = ({ active, payload }) => {
    if (active && payload && payload.length) {
      return (
        <div className="bg-white border border-slate-300 p-3 rounded-xl shadow-xl text-xs">
          <p className="font-bold text-slate-800 mb-1">{payload[0].name}</p>
          <p className="font-mono font-bold text-[#b93b3b]">
            Revenue: {formatCurrency(payload[0].value)} ({payload[0].payload.percent}%)
          </p>
        </div>
      );
    }
    return null;
  };

  return (
    <div className="space-y-6">

      {/* Top Toolbar / Subtitle */}
      <div className="flex flex-col sm:flex-row items-start sm:items-center justify-between gap-4 bg-white p-4 rounded-2xl border border-slate-200 shadow-soft">
        <div className="flex items-center gap-3">
          <div className="p-2.5 rounded-xl bg-purple-50 text-[#2b1f55] border border-purple-200">
            <Building2 className="w-5 h-5" />
          </div>
          <div>
            <h3 className="font-display font-extrabold text-sm text-[#2b1f55]">
              Executive Revenue & Depot Performance Analytics
            </h3>
            <p className="text-xs text-slate-500 font-medium">
              PowerBI Enterprise Analytics Interface • SPJ Live Logistics Data
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          {/* Bar View Mode Switcher */}
          <div className="flex items-center gap-1 bg-slate-100 p-1 rounded-xl border border-slate-200 text-xs">
            {[
              { key: 'depot', label: 'By Depot / Hub' },
              { key: 'customer', label: 'By Client Account' },
              { key: 'month', label: 'By Fiscal Month' },
            ].map(tab => (
              <button
                key={tab.key}
                onClick={() => setBarGroupBy(tab.key)}
                className={`px-3 py-1.5 rounded-lg font-bold transition-all ${
                  barGroupBy === tab.key
                    ? 'bg-[#2b1f55] text-white shadow-sm'
                    : 'text-slate-600 hover:text-[#2b1f55]'
                }`}
              >
                {tab.label}
              </button>
            ))}
          </div>

          <button
            onClick={handleExportExcel}
            className="flex items-center gap-1.5 px-3 py-2 bg-[#ff6a00] hover:bg-[#e65c00] text-white rounded-xl text-xs font-bold transition-all shadow-sm"
          >
            <Download className="w-3.5 h-3.5" />
            Export
          </button>

          <button
            onClick={fetchFinancials}
            disabled={loading}
            className="p-2 bg-white hover:bg-slate-100 border border-slate-300 rounded-xl text-slate-700 transition-all shadow-sm"
            title="Refresh Live Data"
          >
            <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
          </button>
        </div>
      </div>

      {/* ========================================================================= */}
      {/* 1. TOP CONTAINER: SUM OF NET REVENUE & TARGET REVENUE BY DEPOT NAME */}
      {/* ========================================================================= */}
      <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-soft">
        
        {/* Title and Subtitle matching reference */}
        <div className="mb-4">
          <h4 className="text-sm sm:text-base font-bold text-slate-800 tracking-tight">
            Sum of Net_Revenue_INR and Sum of Target_Revenue_INR
          </h4>
          <p className="text-xs text-slate-500 font-medium">
            by {barGroupBy === 'depot' ? 'Depot_Name' : barGroupBy === 'customer' ? 'Customer_Name' : 'Month_Name'}
          </p>
        </div>

        {/* Dual Bar Chart */}
        <div className="h-80 w-full">
          <ResponsiveContainer width="100%" height="100%">
            <BarChart data={dualBarData} margin={{ top: 20, right: 30, left: 10, bottom: 25 }}>
              <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
              <XAxis 
                dataKey="name" 
                tick={{ fontSize: 11, fill: '#475569' }} 
                axisLine={{ stroke: '#cbd5e1' }}
                tickLine={false}
                interval={0}
              />
              <YAxis 
                tick={{ fontSize: 11, fill: '#64748b' }} 
                axisLine={false} 
                tickLine={false}
                tickFormatter={v => `${(v / 100000000).toFixed(1)}bn`}
              />
              <Tooltip content={<CustomBarTooltip />} />
              <Bar 
                dataKey="Net_Revenue" 
                name="Sum of Net_Revenue_INR" 
                fill="#b93b3b" 
                radius={[2, 2, 0, 0]} 
                maxBarSize={38}
              />
              <Bar 
                dataKey="Target_Revenue" 
                name="Sum of Target_Revenue_INR" 
                fill="#e75454" 
                radius={[2, 2, 0, 0]} 
                maxBarSize={38}
              />
            </BarChart>
          </ResponsiveContainer>
        </div>

        {/* Bottom Legend matching reference */}
        <div className="flex items-center justify-start gap-6 pt-2 border-t border-slate-100 text-xs font-semibold text-slate-700">
          <div className="flex items-center gap-2">
            <div className="w-3 h-3 rounded-full bg-[#b93b3b]" />
            <span>Sum of Net_Revenue_INR</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-3 h-3 rounded-full bg-[#e75454]" />
            <span>Sum of Target_Revenue_INR</span>
          </div>
        </div>

      </div>

      {/* ========================================================================= */}
      {/* 2. BOTTOM SECTION: TARGET CARD + REGION SLICER + DONUT CATEGORY CHART */}
      {/* ========================================================================= */}
      <div className="grid grid-cols-1 lg:grid-cols-12 gap-6 items-start">
        
        {/* Left Side: Target KPI Card + Interactive Slicers (4 Cols) */}
        <div className="lg:col-span-4 space-y-4">
          
          {/* KPI Card matching reference */}
          <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft">
            <p className="text-xs font-semibold text-slate-500">
              Sum of Target_Revenue_INR
            </p>
            <h2 className="text-3xl font-black font-display text-slate-900 mt-2 tracking-tight">
              2.30bn
            </h2>
            <div className="text-[11px] text-emerald-700 font-bold mt-1">
              ₹ 230.00 Cr Full Year Strategic Target
            </div>
          </div>

          {/* Region Slicer Checkbox List matching reference */}
          <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft space-y-4">
            
            <div className="flex items-center justify-between border-b border-slate-100 pb-2.5">
              <span className="text-xs font-bold text-slate-800 uppercase tracking-wider">
                Region Slicer
              </span>
              <button
                onClick={handleResetSlicers}
                className="text-[11px] font-bold text-[#ff6a00] hover:underline"
              >
                Reset
              </button>
            </div>

            <div className="space-y-2">
              {[
                { key: 'North', label: 'North (Dadri UP & Delhi ICD)' },
                { key: 'West', label: 'West (Mumbai & Mundra Port)' },
                { key: 'South', label: 'South (Chennai & Hyderabad)' },
                { key: 'East', label: 'East (Kolkata Terminal)' },
              ].map(r => {
                const isSelected = selectedRegions.includes(r.key);
                return (
                  <button
                    key={r.key}
                    onClick={() => toggleSlicer(selectedRegions, setSelectedRegions, r.key)}
                    className="flex items-center gap-2.5 w-full text-left py-1 text-xs text-slate-700 font-medium hover:text-slate-900 transition-colors"
                  >
                    {isSelected ? (
                      <CheckSquare className="w-4 h-4 text-[#b93b3b] shrink-0" />
                    ) : (
                      <Square className="w-4 h-4 text-slate-400 shrink-0" />
                    )}
                    <span>{r.label}</span>
                  </button>
                );
              })}
            </div>

            {/* Container Size Slicer */}
            <div className="pt-3 border-t border-slate-100 space-y-2">
              <span className="text-xs font-bold text-slate-800 uppercase tracking-wider block">
                Container Size
              </span>
              {[
                { key: '20', label: '20 FT (1 TEU Standard)' },
                { key: '40', label: '40 FT (2 TEU Reefer)' },
                { key: '45', label: '45 FT (High Cube Reefer)' },
              ].map(s => {
                const isSelected = selectedSizes.includes(s.key);
                return (
                  <button
                    key={s.key}
                    onClick={() => toggleSlicer(selectedSizes, setSelectedSizes, s.key)}
                    className="flex items-center gap-2.5 w-full text-left py-1 text-xs text-slate-700 font-medium hover:text-slate-900 transition-colors"
                  >
                    {isSelected ? (
                      <CheckSquare className="w-4 h-4 text-[#b93b3b] shrink-0" />
                    ) : (
                      <Square className="w-4 h-4 text-slate-400 shrink-0" />
                    )}
                    <span>{s.label}</span>
                  </button>
                );
              })}
            </div>

          </div>

        </div>

        {/* Right Side: Product / Category Donut Chart (8 Cols) matching reference */}
        <div className="lg:col-span-8 bg-white p-6 rounded-2xl border border-slate-200 shadow-soft space-y-4">
          
          <div>
            <h4 className="text-sm sm:text-base font-bold text-slate-800 tracking-tight">
              Sum of Net_Revenue_INR
            </h4>
            <p className="text-xs text-slate-500 font-medium">
              by Product_Category / Service_Type
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-12 gap-4 items-center pt-2">
            
            {/* Donut Chart with Center KPI Callout */}
            <div className="md:col-span-7 h-72 relative flex items-center justify-center">
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie
                    data={donutData}
                    dataKey="value"
                    nameKey="name"
                    cx="50%"
                    cy="50%"
                    innerRadius={80}
                    outerRadius={115}
                    paddingAngle={3}
                  >
                    {donutData.map((entry, index) => (
                      <Cell key={`cell-${index}`} fill={POWERBI_COLORS[index % POWERBI_COLORS.length]} />
                    ))}
                  </Pie>
                  <Tooltip content={<CustomDonutTooltip />} />
                </PieChart>
              </ResponsiveContainer>

              {/* Center Callout matching reference */}
              <div className="absolute inset-0 flex flex-col items-center justify-center pointer-events-none">
                <span className="text-2xl font-black font-display text-slate-900">
                  2.27bn
                </span>
                <span className="text-[11px] text-slate-500 font-semibold">
                  Net Revenue
                </span>
              </div>
            </div>

            {/* Right Donut Legend with percentage callouts */}
            <div className="md:col-span-5 space-y-3 pl-2">
              {donutData.map((item, idx) => (
                <div key={idx} className="flex items-start gap-2.5 text-xs">
                  <div 
                    className="w-3 h-3 rounded-full mt-0.5 shrink-0" 
                    style={{ backgroundColor: POWERBI_COLORS[idx % POWERBI_COLORS.length] }} 
                  />
                  <div>
                    <div className="font-bold text-slate-800 leading-tight">
                      {item.name}
                    </div>
                    <div className="font-mono text-slate-500 text-[11px] font-semibold mt-0.5">
                      {formatCurrency(item.value)} ({item.percent}%)
                    </div>
                  </div>
                </div>
              ))}
            </div>

          </div>

        </div>

      </div>

    </div>
  );
}
