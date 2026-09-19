import React from 'react';

export function SkeletonBox({ className = '', height = 'h-6', width = 'w-full' }) {
  return (
    <div className={`relative overflow-hidden bg-slate-200/70 rounded-xl ${height} ${width} ${className}`}>
      <div className="absolute inset-0 -translate-x-full bg-gradient-to-r from-transparent via-white/60 to-transparent animate-[shimmer_1.5s_infinite]"></div>
    </div>
  );
}

export function SkeletonKPICard() {
  return (
    <div className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft relative overflow-hidden space-y-3">
      <div className="flex items-start justify-between">
        <div className="space-y-2">
          <SkeletonBox width="w-24" height="h-3" />
          <SkeletonBox width="w-32" height="h-7" />
        </div>
        <SkeletonBox width="w-11" height="h-11 rounded-2xl" />
      </div>
      <div className="pt-3 border-t border-slate-100 flex items-center justify-between">
        <SkeletonBox width="w-20" height="h-3" />
        <SkeletonBox width="w-14" height="h-4 rounded-md" />
      </div>
    </div>
  );
}

export function SkeletonTableRow() {
  return (
    <tr className="border-b border-slate-100 animate-pulse">
      <td className="py-3.5 px-3"><SkeletonBox width="w-24" height="h-4" /></td>
      <td className="py-3.5 px-3"><SkeletonBox width="w-20" height="h-4" /></td>
      <td className="py-3.5 px-3"><SkeletonBox width="w-16" height="h-4" /></td>
      <td className="py-3.5 px-3"><SkeletonBox width="w-32" height="h-4" /></td>
      <td className="py-3.5 px-3"><SkeletonBox width="w-24" height="h-4" /></td>
      <td className="py-3.5 px-3"><SkeletonBox width="w-16" height="h-4" /></td>
      <td className="py-3.5 px-3 text-right"><SkeletonBox width="w-20" height="h-4" className="ml-auto" /></td>
    </tr>
  );
}

export default function SkeletonGrid({ count = 5 }) {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-5 gap-4">
      {Array.from({ length: count }).map((_, i) => (
        <SkeletonKPICard key={i} />
      ))}
    </div>
  );
}
