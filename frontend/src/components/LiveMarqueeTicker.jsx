import React from 'react';
import { 
  TrendingUp, 
  Building2, 
  Container, 
  Truck, 
  Users, 
  CheckCircle2, 
  Ship,
  Zap,
  Clock
} from 'lucide-react';

export default function LiveMarqueeTicker({ stats = {} }) {
  const tickerItems = [
    // 1. SALES & ENTERPRISE HIGHLIGHTS
    {
      category: 'SALES',
      badgeColor: 'bg-emerald-500/20 text-emerald-400 border-emerald-500/30',
      icon: TrendingUp,
      iconColor: 'text-emerald-400',
      label: 'Gross Sales',
      value: '₹ 3,853.64 Cr'
    },
    {
      category: 'SALES',
      badgeColor: 'bg-purple-500/20 text-purple-300 border-purple-500/30',
      icon: Building2,
      iconColor: 'text-purple-400',
      label: '29 Terminals',
      value: '100% Active'
    },
    {
      category: 'SALES',
      badgeColor: 'bg-emerald-500/20 text-emerald-400 border-emerald-500/30',
      icon: Container,
      iconColor: 'text-emerald-400',
      label: 'Containers Handled',
      value: '85,313 Units (1,62,095 TEUs)'
    },

    // 2. TOP CLIENTS & BILLING
    {
      category: 'TOP CLIENT',
      badgeColor: 'bg-blue-500/20 text-blue-300 border-blue-500/30',
      icon: Ship,
      iconColor: 'text-blue-400',
      label: 'Transworld-Dadri',
      value: '₹ 4,969.8 Cr (49,412 TEU)'
    },
    {
      category: 'TOP CLIENT',
      badgeColor: 'bg-blue-500/20 text-blue-300 border-blue-500/30',
      icon: Users,
      iconColor: 'text-cyan-400',
      label: 'Allcargo Logistics',
      value: '₹ 842.1 Cr (14,210 TEU)'
    },
    {
      category: 'TOP CLIENT',
      badgeColor: 'bg-blue-500/20 text-blue-300 border-blue-500/30',
      icon: Building2,
      iconColor: 'text-indigo-400',
      label: 'Concor Intermodal',
      value: '₹ 612.4 Cr Invoiced'
    },

    // 3. REAL-TIME YARD & FLEET OPERATIONS
    {
      category: 'YARD OPS',
      badgeColor: 'bg-orange-500/20 text-orange-300 border-orange-500/30',
      icon: Truck,
      iconColor: 'text-[#ff8a3d]',
      label: 'Fleet Deployment',
      value: '1,272 Multi-Axle Vehicles'
    },
    {
      category: 'YARD OPS',
      badgeColor: 'bg-orange-500/20 text-orange-300 border-orange-500/30',
      icon: Zap,
      iconColor: 'text-amber-400',
      label: 'Job Orders Mapped',
      value: '88,361 Dispatches'
    },
    {
      category: 'YARD OPS',
      badgeColor: 'bg-emerald-500/20 text-emerald-400 border-emerald-500/30',
      icon: Clock,
      iconColor: 'text-emerald-400',
      label: 'Avg Turnaround TAT',
      value: '18 Mins Gate-to-Yard'
    },
    {
      category: 'YARD OPS',
      badgeColor: 'bg-purple-500/20 text-purple-300 border-purple-500/30',
      icon: CheckCircle2,
      iconColor: 'text-purple-400',
      label: 'Cold Chain Status',
      value: '100% Temp Verified'
    }
  ];

  return (
    <div className="w-full bg-[#160f2e] text-white border-b border-purple-900/40 relative overflow-hidden py-1.5 sm:py-2 select-none shadow-inner">
      <div className="flex items-center">
        
        {/* Fixed Left Live Indicator Badge */}
        <div className="relative z-20 flex items-center gap-1.5 sm:gap-2 pl-2.5 sm:pl-4 pr-2 sm:pr-3.5 py-0.5 bg-[#160f2e] border-r border-purple-800/50 shrink-0 shadow-lg">
          <span className="flex h-1.5 w-1.5 sm:h-2 sm:w-2 relative">
            <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-rose-400 opacity-75"></span>
            <span className="relative inline-flex rounded-full h-1.5 w-1.5 sm:h-2 sm:w-2 bg-rose-500"></span>
          </span>
          <span className="text-[9px] sm:text-[10px] font-black tracking-widest text-rose-400 uppercase">
            LIVE TICKER
          </span>
        </div>

        {/* Continuous Smooth Scrolling Marquee */}
        <div className="overflow-hidden whitespace-nowrap flex-1 relative">
          <div className="inline-flex gap-5 sm:gap-8 items-center animate-ticker hover:[animation-play-state:paused] cursor-pointer">
            {/* Double the list for seamless continuous infinite loop */}
            {[...tickerItems, ...tickerItems].map((item, idx) => {
              const Icon = item.icon;
              return (
                <div 
                  key={idx} 
                  className="inline-flex items-center gap-1.5 sm:gap-2 text-[11px] sm:text-xs text-slate-300 hover:text-white transition-colors"
                >
                  <span className={`px-1.5 py-0.2 rounded text-[8px] sm:text-[9px] font-black border uppercase tracking-tight ${item.badgeColor}`}>
                    {item.category}
                  </span>
                  
                  <Icon className={`w-3 h-3 sm:w-3.5 sm:h-3.5 ${item.iconColor} shrink-0`} />
                  
                  <span className="font-semibold text-slate-400">
                    {item.label}:
                  </span>
                  
                  <span className="font-bold text-white tracking-tight">
                    {item.value}
                  </span>

                  <span className="text-purple-800/80 mx-1.5 sm:mx-2">•</span>
                </div>
              );
            })}
          </div>
        </div>

      </div>
    </div>
  );
}

