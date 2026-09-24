import React, { useState, useMemo } from 'react';
import {
  PieChart,
  Pie,
  Cell,
  ResponsiveContainer,
  Tooltip
} from 'recharts';
import {
  PieChart as PieIcon,
  Layers,
  ArrowUpRight,
  TrendingUp,
  Percent,
  CheckCircle2,
  DollarSign,
  Package,
  Boxes
} from 'lucide-react';

function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 1000000000) return `₹ ${(num / 1000000000).toFixed(2)} bn`;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  return `₹ ${num.toLocaleString('en-IN')}`;
}

function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

// Power BI Coral / Crimson Color Palette matching user screenshot
const COLORS = [
  '#b91c1c', // Dark Crimson (Electronics / Reefer)
  '#e11d48', // Coral Red (Solar / Multimodal)
  '#f43f5e', // Rose Coral (Appliances / ICD Ops)
  '#fda4af', // Light Coral (Industrial Consumables)
  '#fecdd3'  // Soft Rose (General Cargo & Ancillary)
];

// Custom Label with Leader Line matching Power BI Donut Screenshot
const renderCustomizedLabel = (props) => {
  const {
    cx,
    cy,
    midAngle,
    outerRadius,
    percent,
    value,
    name
  } = props;

  const RADIAN = Math.PI / 180;
  const sin = Math.sin(-RADIAN * midAngle);
  const cos = Math.cos(-RADIAN * midAngle);

  const sx = cx + (outerRadius + 8) * cos;
  const sy = cy + (outerRadius + 8) * sin;
  const mx = cx + (outerRadius + 26) * cos;
  const my = cy + (outerRadius + 26) * sin;
  const ex = mx + (cos >= 0 ? 1 : -1) * 20;
  const ey = my;
  const textAnchor = cos >= 0 ? 'start' : 'end';

  const valBn = (value >= 1000000000) 
    ? `${(value / 1000000000).toFixed(2)}bn` 
    : (value >= 10000000) 
    ? `₹${(value / 10000000).toFixed(0)}Cr` 
    : `₹${(value / 100000).toFixed(0)}L`;

  return (
    <g>
      <path
        d={`M${sx},${sy}L${mx},${my}L${ex},${ey}`}
        stroke="#94a3b8"
        strokeWidth={1.2}
        fill="none"
      />
      <circle cx={ex} cy={ey} r={2} fill="#94a3b8" />
      <text
        x={ex + (cos >= 0 ? 1 : -1) * 6}
        y={ey}
        textAnchor={textAnchor}
        fill="#334155"
        fontSize={10}
        fontWeight={700}
        dominantBaseline="central"
      >
        {`${valBn} (${(percent * 100).toFixed(1)}%)`}
      </text>
    </g>
  );
};

export default function SalesRevenueDonutSection({
  totalGrossRevenue = 38536360360.24,
  selectedCompany = 'ALL',
  selectedCustomer = 'ALL',
  selectedTerminal = 'ALL',
  selectedFY = 'ALL',
  topServices = [],
  companyName = null,
  customerName = null
}) {
  const [hoveredIndex, setHoveredIndex] = useState(null);

  // Category Distribution scaled to active total revenue
  const categoryData = useMemo(() => {
    const total = totalGrossRevenue || 38536360360.24;

    const baseCategories = [
      {
        name: 'Electronics & Reefer Cargo',
        shortName: 'Electronics',
        share: 0.4812,
        invoicesPct: 0.46,
        description: 'Cold storage, temperature-controlled pharma, electronics & meat exports'
      },
      {
        name: 'Solar & Multimodal Rail Ops',
        shortName: 'Solar',
        share: 0.2641,
        invoicesPct: 0.28,
        description: 'Dedicated container train movements & heavy multimodal haulage'
      },
      {
        name: 'Appliances & ICD Terminals',
        shortName: 'Appliances',
        share: 0.2081,
        invoicesPct: 0.21,
        description: 'Yard operations, CFS handling, stuffing & de-stuffing at Dadri/Kanpur'
      },
      {
        name: 'Industrial Consumables & Port',
        shortName: 'Industrial Consum...',
        share: 0.0466,
        invoicesPct: 0.05,
        description: 'Port clearance, line demurrage, bonded warehousing & documentation'
      }
    ];

    return baseCategories.map((cat, idx) => {
      const catSales = Math.round(total * cat.share * 100) / 100;
      return {
        ...cat,
        value: catSales,
        salesFormatted: formatCurrency(catSales),
        color: COLORS[idx % COLORS.length]
      };
    });
  }, [totalGrossRevenue]);

  const totalValueBn = (totalGrossRevenue >= 1000000000)
    ? `${(totalGrossRevenue / 1000000000).toFixed(2)}bn`
    : `${(totalGrossRevenue / 10000000).toFixed(2)} Cr`;

  return (
    <div className="bg-white rounded-2xl sm:rounded-3xl border border-slate-200 shadow-soft p-4 sm:p-6 transition-all animate-fade-in">
      
      {/* Top Header */}
      <div className="flex flex-col sm:flex-row sm:items-center justify-between gap-2 pb-4 border-b border-slate-100">
        <div>
          <h3 className="font-display font-extrabold text-base sm:text-lg text-slate-900 flex items-center gap-2">
            <PieIcon className="w-5 h-5 text-[#b91c1c]" />
            <span>Sum of Net_Sales_INR</span>
            <span className="text-xs font-semibold text-slate-500 bg-slate-100 px-2 py-0.5 rounded-md border border-slate-200">
              by Product_Category
            </span>
          </h3>
          <p className="text-xs text-slate-500 mt-0.5">
            {customerName
              ? `Category breakdown for ${customerName} (${selectedFY === 'ALL' ? 'All Fiscal Years' : selectedFY})`
              : companyName
              ? `Category distribution for ${companyName} (${selectedFY === 'ALL' ? 'All Fiscal Years' : selectedFY})`
              : `Consolidated logistics service line sales distribution (${selectedFY === 'ALL' ? 'All FYs Cumulative' : selectedFY})`}
          </p>
        </div>

        <div className="flex items-center gap-2">
          <span className="inline-flex items-center gap-1 text-[11px] font-bold text-emerald-700 bg-emerald-50 px-2.5 py-1 rounded-lg border border-emerald-200">
            <CheckCircle2 className="w-3.5 h-3.5" />
            Active Scope: {formatCurrency(totalGrossRevenue)}
          </span>
        </div>
      </div>

      {/* Main 2-Column Grid matching Power BI Layout */}
      <div className="grid grid-cols-1 lg:grid-cols-12 gap-6 mt-4 items-center">
        
        {/* Left: Donut Chart with Center Total and Callout Lines (7 Columns) */}
        <div className="lg:col-span-7 flex flex-col items-center justify-center relative min-h-[300px] sm:min-h-[340px]">
          
          <div className="w-full h-[280px] sm:h-[320px]">
            <ResponsiveContainer width="100%" height="100%">
              <PieChart margin={{ top: 10, right: 30, bottom: 10, left: 30 }}>
                <Pie
                  data={categoryData}
                  cx="50%"
                  cy="50%"
                  innerRadius={70}
                  outerRadius={105}
                  paddingAngle={2}
                  dataKey="value"
                  label={renderCustomizedLabel}
                  labelLine={false}
                  onMouseEnter={(_, index) => setHoveredIndex(index)}
                  onMouseLeave={() => setHoveredIndex(null)}
                >
                  {categoryData.map((entry, index) => (
                    <Cell
                      key={`cell-${index}`}
                      fill={entry.color}
                      opacity={hoveredIndex === null || hoveredIndex === index ? 1 : 0.4}
                      stroke="#ffffff"
                      strokeWidth={2}
                      className="transition-all duration-300 cursor-pointer"
                    />
                  ))}
                </Pie>
                <Tooltip
                  formatter={(val, name) => [formatCurrency(val), name]}
                  contentStyle={{
                    backgroundColor: '#1e293b',
                    borderRadius: '12px',
                    border: 'none',
                    color: '#fff',
                    fontSize: '12px',
                    boxShadow: '0 10px 25px -5px rgba(0, 0, 0, 0.3)'
                  }}
                />
              </PieChart>
            </ResponsiveContainer>
          </div>

          {/* Central Donut Total Value */}
          <div className="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 text-center pointer-events-none">
            <span className="text-xl sm:text-2xl font-black font-display text-slate-900 tracking-tight block">
              {totalValueBn}
            </span>
            <span className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider block">
              TOTAL SALES
            </span>
          </div>
        </div>

        {/* Right: Legend & Performance Breakdown (5 Columns) */}
        <div className="lg:col-span-5 space-y-3">
          <div className="text-xs font-bold text-slate-700 uppercase tracking-wider mb-2 flex items-center justify-between">
            <span>Product & Service Lines</span>
            <span>Contribution</span>
          </div>

          <div className="space-y-2">
            {categoryData.map((cat, idx) => {
              const isHovered = hoveredIndex === idx;
              return (
                <div
                  key={cat.name}
                  onMouseEnter={() => setHoveredIndex(idx)}
                  onMouseLeave={() => setHoveredIndex(null)}
                  className={`p-3 rounded-xl border transition-all cursor-pointer ${
                    isHovered
                      ? 'bg-rose-50/60 border-rose-300 shadow-sm translate-x-1'
                      : 'bg-slate-50/70 border-slate-200/80 hover:bg-slate-100/70'
                  }`}
                >
                  <div className="flex items-center justify-between gap-2">
                    <div className="flex items-center gap-2 min-w-0">
                      <span
                        className="w-3 h-3 rounded-full shrink-0 shadow-xs"
                        style={{ backgroundColor: cat.color }}
                      ></span>
                      <span className="text-xs font-bold text-slate-800 truncate" title={cat.name}>
                        {cat.name}
                      </span>
                    </div>
                    <div className="text-right shrink-0">
                      <span className="text-xs font-mono font-black text-slate-900">
                        {cat.salesFormatted || cat.revenueFormatted}
                      </span>
                    </div>
                  </div>

                  {/* Progress Bar & Percentage */}
                  <div className="mt-2 flex items-center gap-2">
                    <div className="flex-1 h-1.5 bg-slate-200 rounded-full overflow-hidden">
                      <div
                        className="h-full rounded-full transition-all duration-500"
                        style={{
                          width: `${(cat.share * 100).toFixed(1)}%`,
                          backgroundColor: cat.color
                        }}
                      ></div>
                    </div>
                    <span className="text-[10px] font-mono font-bold text-slate-600 shrink-0">
                      {(cat.share * 100).toFixed(1)}%
                    </span>
                  </div>

                  <p className="text-[10px] text-slate-500 mt-1 line-clamp-1">
                    {cat.description}
                  </p>
                </div>
              );
            })}
          </div>
        </div>

      </div>

    </div>
  );
}
