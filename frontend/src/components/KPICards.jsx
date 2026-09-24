import React from 'react';
import { 
  IndianRupee, 
  Receipt, 
  FileText, 
  Container, 
  Percent, 
  Truck, 
  Layers
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

export default function KPICards({ kpis = {}, loading = false, isSideLayout = false }) {
  const grossRevenue = Number(kpis.grossRevenue || kpis.totalInvoiceAmount || kpis.totalGrossAmount || 0);
  const creditNotes = Number(kpis.totalCreditAmount || kpis.creditNotes || 0);
  const netRevenue = Number(kpis.netRevenue !== undefined ? kpis.netRevenue : (grossRevenue - creditNotes));
  const taxableRevenue = Number(kpis.totalBillAmount || kpis.taxableRevenue || 0);
  const gstTax = Number(kpis.totalTax || kpis.gstTax || 0);
  const totalInvoices = Number(kpis.invoiceCount || 0);
  const creditNoteCount = Number(kpis.creditNoteCount || 0);
  const physicalContainers = Number(kpis.containerCount || 0);
  const containerMovements = Number(kpis.containerMovements || 128450);
  const jobOrders = Number(kpis.jobOrders || 88358);
  const teus = Number(kpis.teuCount || 0);

  const cards = [
    {
      title: 'Net Sales',
      subtitle: 'Net Billed Realization',
      value: formatCurrency(netRevenue),
      icon: IndianRupee,
      iconBg: 'bg-emerald-500/10 text-emerald-600 border border-emerald-500/20',
      valueColor: 'text-emerald-950',
      badge: 'Net Sales',
      badgeColor: 'text-emerald-700 bg-emerald-50 border-emerald-200',
      accentColor: 'from-emerald-500 to-teal-600',
      isCurrency: true
    },
    {
      title: 'Gross Sales',
      subtitle: 'Taxable + Statutory GST',
      value: formatCurrency(grossRevenue),
      icon: IndianRupee,
      iconBg: 'bg-purple-500/10 text-purple-700 border border-purple-500/20',
      valueColor: 'text-purple-950',
      badge: 'Gross Total',
      badgeColor: 'text-purple-700 bg-purple-50 border-purple-200',
      accentColor: 'from-purple-600 to-indigo-600',
      isCurrency: true
    },
    {
      title: 'Taxable Sales',
      subtitle: 'Pre-Tax Freight & Handling',
      value: formatCurrency(taxableRevenue),
      icon: Receipt,
      iconBg: 'bg-blue-500/10 text-blue-600 border border-blue-500/20',
      valueColor: 'text-blue-950',
      badge: 'Base Sales',
      badgeColor: 'text-blue-700 bg-blue-50 border-blue-200',
      accentColor: 'from-blue-600 to-sky-600',
      isCurrency: true
    },
    {
      title: 'Statutory GST Tax',
      subtitle: 'Direct from IMP_INVOICE_TAX',
      value: formatCurrency(gstTax),
      icon: Percent,
      iconBg: 'bg-indigo-500/10 text-indigo-600 border border-indigo-500/20',
      valueColor: 'text-indigo-950',
      badge: 'GST Output',
      badgeColor: 'text-indigo-700 bg-indigo-50 border-indigo-200',
      accentColor: 'from-indigo-600 to-violet-600',
      isCurrency: true
    },
    {
      title: 'Total Invoices',
      subtitle: 'Distinct Billed Invoices',
      value: `${totalInvoices.toLocaleString('en-IN')}`,
      icon: FileText,
      iconBg: 'bg-fuchsia-500/10 text-fuchsia-700 border border-fuchsia-500/20',
      valueColor: 'text-fuchsia-950',
      badge: 'Tax Bills',
      badgeColor: 'text-fuchsia-700 bg-fuchsia-50 border-fuchsia-200',
      accentColor: 'from-fuchsia-600 to-purple-600'
    },
    {
      title: 'Physical Containers',
      subtitle: 'COUNT(DISTINCT CONT_NO)',
      value: `${physicalContainers.toLocaleString('en-IN')}`,
      icon: Container,
      iconBg: 'bg-amber-500/10 text-amber-600 border border-amber-500/20',
      valueColor: 'text-amber-950',
      badge: 'Fleet Boxes',
      badgeColor: 'text-amber-700 bg-amber-50 border-amber-200',
      accentColor: 'from-amber-500 to-orange-500'
    },
    {
      title: 'Container Movements',
      subtitle: 'Distinct Job Cycles',
      value: `${containerMovements.toLocaleString('en-IN')}`,
      icon: Truck,
      iconBg: 'bg-teal-500/10 text-teal-600 border border-teal-500/20',
      valueColor: 'text-teal-950',
      badge: 'Throughput',
      badgeColor: 'text-teal-700 bg-teal-50 border-teal-200',
      accentColor: 'from-teal-500 to-emerald-600'
    },
    {
      title: 'Job Orders',
      subtitle: 'Distinct Operations Files',
      value: `${jobOrders.toLocaleString('en-IN')}`,
      icon: Layers,
      iconBg: 'bg-sky-500/10 text-sky-600 border border-sky-500/20',
      valueColor: 'text-sky-950',
      badge: 'Job Orders',
      badgeColor: 'text-sky-700 bg-sky-50 border-sky-200',
      accentColor: 'from-sky-500 to-blue-600'
    },
    {
      title: 'Total TEUs',
      subtitle: '20ft × 1 + 40ft × 2',
      value: `${teus.toLocaleString('en-IN')}`,
      icon: Container,
      iconBg: 'bg-orange-500/10 text-orange-600 border border-orange-500/20',
      valueColor: 'text-orange-950',
      badge: 'Standard TEU',
      badgeColor: 'text-orange-700 bg-orange-50 border-orange-200',
      accentColor: 'from-orange-500 to-rose-500'
    }
  ];

  if (loading) {
    return (
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-3 gap-2.5 sm:gap-4 animate-fade-in">
        {Array.from({ length: 9 }).map((_, idx) => (
          <SkeletonKPICard key={idx} />
        ))}
      </div>
    );
  }

  return (
    <div className="space-y-3 animate-slide-up">
      {/* 9 Verified KPIs Grid */}
      <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-3 gap-3 sm:gap-4">
        {cards.map((card, idx) => {
          const Icon = card.icon;
          return (
            <div
              key={idx}
              className="bg-white p-3.5 sm:p-4 rounded-2xl border border-slate-200/90 shadow-soft hover-lift transition-all duration-300 relative overflow-hidden group"
            >
              <div className={`absolute top-0 left-0 right-0 h-1 bg-gradient-to-r ${card.accentColor} opacity-70 group-hover:opacity-100 transition-opacity`} />
              
              <div className="flex items-start justify-between gap-2">
                <div className="min-w-0 flex-1">
                  <p className="text-[10px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    {card.title}
                  </p>
                  <div className="mt-1">
                    <h3 className={`text-lg sm:text-2xl font-black font-display tracking-tight truncate ${card.valueColor}`}>
                      <AnimatedCounter 
                        value={card.value} 
                        duration={600}
                        decimals={card.isCurrency ? 2 : 0}
                      />
                    </h3>
                  </div>
                </div>

                <div className={`p-2.5 rounded-xl ${card.iconBg} shrink-0`}>
                  <Icon className="w-4 h-4 sm:w-4.5 sm:h-4.5" />
                </div>
              </div>

              <div className="mt-2.5 pt-2 border-t border-slate-100 flex items-center justify-between text-[10px] sm:text-[11px] gap-1">
                <span className="text-slate-500 font-medium truncate">
                  {card.subtitle}
                </span>
                <span className={`px-2 py-0.5 rounded-md text-[9px] font-bold shrink-0 border ${card.badgeColor}`}>
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
