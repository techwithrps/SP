import React from 'react';
import { 
  IndianRupee, 
  Receipt, 
  FileText, 
  Container, 
  Percent, 
  ArrowUpRight, 
  Globe2, 
  Ship, 
  Truck, 
  Users 
} from 'lucide-react';
import AnimatedCounter from './AnimatedCounter';
import { SkeletonKPICard } from './SkeletonLoader';

function formatCurrency(amount) {
  if (!amount && amount !== 0) return '₹ 0.00';
  const val = Math.abs(Number(amount));
  
  if (val >= 10000000) {
    return `₹ ${(val / 10000000).toFixed(2)} Cr`;
  } else if (val >= 100000) {
    return `₹ ${(val / 100000).toFixed(2)} Lakh`;
  }
  return `₹ ${val.toLocaleString('en-IN', { maximumFractionDigits: 2 })}`;
}

export default function KPICards({ kpis = {}, loading = false }) {
  const {
    totalGrossAmount = 0,
    totalBillAmount = 0,
    totalTax = 0,
    invoiceCount = 0,
    creditNoteCount = 0,
    containerCount = 0,
    teuCount = 0,
    totalRecords = 0,
  } = kpis;

  const cards = [
    {
      title: 'Gross Sale',
      subtitle: kpis.totalCreditAmount ? `Invoice Amt - Credit (₹ ${formatCurrency(kpis.totalCreditAmount)})` : 'Invoice Amt - Credit Amt',
      value: formatCurrency(totalGrossAmount),
      raw: totalGrossAmount,
      icon: IndianRupee,
      iconBg: 'bg-orange-50 text-orange-600 border border-orange-200',
      valueColor: 'text-[#2b1f55]',
      badge: 'Gross Sale',
      badgeColor: 'text-emerald-700 bg-emerald-50 border-emerald-200',
      isCurrency: true
    },
    {
      title: 'Net Bill Amount',
      subtitle: 'Pre-Tax Freight & Handling',
      value: formatCurrency(totalBillAmount),
      raw: totalBillAmount,
      icon: Receipt,
      iconBg: 'bg-blue-50 text-blue-600 border border-blue-200',
      valueColor: 'text-blue-900',
      badge: 'Base Revenue',
      badgeColor: 'text-blue-700 bg-blue-50 border-blue-200',
      isCurrency: true
    },
    {
      title: 'Tax Collected (GST)',
      subtitle: '18% Standard GST Rate',
      value: formatCurrency(totalTax),
      raw: totalTax,
      icon: Percent,
      iconBg: 'bg-emerald-50 text-emerald-600 border border-emerald-200',
      valueColor: 'text-emerald-800',
      badge: 'GST Output',
      badgeColor: 'text-emerald-700 bg-emerald-50 border-emerald-200',
      isCurrency: true
    },
    {
      title: 'Invoice & Credit Count',
      subtitle: `${invoiceCount} Invoices / ${creditNoteCount} Credit Notes`,
      value: `${totalRecords} Records`,
      raw: totalRecords,
      icon: FileText,
      iconBg: 'bg-purple-50 text-purple-600 border border-purple-200',
      valueColor: 'text-purple-900',
      badge: `${invoiceCount} Invoices`,
      badgeColor: 'text-purple-700 bg-purple-50 border-purple-200',
      suffix: ' Records'
    },
    {
      title: 'Containers Handled',
      subtitle: `${containerCount} Active Units in Yard`,
      value: `${containerCount} Containers`,
      raw: containerCount,
      icon: Container,
      iconBg: 'bg-amber-50 text-amber-600 border border-amber-200',
      valueColor: 'text-amber-900',
      badge: 'Multi-Modal',
      badgeColor: 'text-amber-700 bg-amber-50 border-amber-200',
      suffix: ' Containers'
    }
  ];

  const delayClasses = ['delay-1', 'delay-2', 'delay-3', 'delay-4', 'delay-5'];

  if (loading) {
    return (
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-5 gap-4 animate-fade-in">
        {Array.from({ length: 5 }).map((_, idx) => (
          <SkeletonKPICard key={idx} />
        ))}
      </div>
    );
  }

  return (
    <div className="space-y-4 animate-slide-up">
      {/* KPI Cards Grid */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-5 gap-4">
        {cards.map((card, idx) => {
          const Icon = card.icon;
          const delay = delayClasses[idx % delayClasses.length];
          return (
            <div
              key={idx}
              className={`bg-white p-5 rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all duration-300 animate-slide-up ${delay}`}
            >
              <div className="flex items-start justify-between">
                <div>
                  <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                    {card.title}
                  </p>
                  <div className="mt-2">
                    <h3 className={`text-2xl font-black font-display tracking-tight ${card.valueColor}`}>
                      <AnimatedCounter 
                        value={card.value} 
                        duration={700}
                        decimals={card.isCurrency ? 2 : 0}
                      />
                    </h3>
                  </div>
                </div>

                <div className={`p-3 rounded-2xl ${card.iconBg} animate-float transition-transform hover:scale-110`}>
                  <Icon className="w-5 h-5" />
                </div>
              </div>

              <div className="mt-3 pt-3 border-t border-slate-100 flex items-center justify-between text-[11px]">
                <span className="text-slate-500 font-medium truncate max-w-[130px]">
                  {card.subtitle}
                </span>
                <span className={`px-2 py-0.5 rounded-md border text-[10px] font-bold ${card.badgeColor}`}>
                  {card.badge}
                </span>
              </div>
            </div>
          );
        })}
      </div>

    </div>
  );
}
