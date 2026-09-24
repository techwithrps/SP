import React from 'react';

export function formatCurrency(val) {
  const num = Number(val) || 0;
  if (Math.abs(num) >= 10000000) return `₹ ${(num / 10000000).toFixed(2)} Cr`;
  if (Math.abs(num) >= 100000) return `₹ ${(num / 100000).toFixed(2)} Lakh`;
  if (Math.abs(num) >= 1000) return `₹ ${(num / 1000).toFixed(1)}k`;
  return `₹ ${num.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

export function formatNumber(val) {
  const num = Number(val) || 0;
  return num.toLocaleString('en-IN');
}

export function CustomChartTooltip({ active, payload, label }) {
  if (active && payload && payload.length) {
    return (
      <div className="bg-slate-900/95 text-white p-3 rounded-xl shadow-xl text-xs backdrop-blur-md border border-slate-700">
        <p className="font-bold text-slate-200 mb-1.5 pb-1 border-b border-slate-700">{label}</p>
        {payload.map((entry, index) => (
          <div key={`item-${index}`} className="flex items-center justify-between gap-4 py-0.5">
            <span className="flex items-center gap-1.5 text-slate-400">
              <span className="w-2 h-2 rounded-full" style={{ backgroundColor: entry.color }} />
              {entry.name}:
            </span>
            <span className="font-mono font-bold text-white">
              {typeof entry.value === 'number' && entry.name.toLowerCase().includes('revenue') || entry.name.toLowerCase().includes('gross') || entry.name.toLowerCase().includes('billed') || entry.name.toLowerCase().includes('amount') || entry.name.toLowerCase().includes('sale')
                ? formatCurrency(entry.value)
                : formatNumber(entry.value)}
            </span>
          </div>
        ))}
      </div>
    );
  }
  return null;
}
