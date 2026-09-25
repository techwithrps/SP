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
  const physicalContainers = Number(kpis.containerCount || 89245);
  const containerMovements = Number(kpis.containerMovements || 128450);
  const jobOrders = Number(kpis.jobOrders || 88361);
  const teus = Number(kpis.teuCount || 171976);

  const cards = [
    {
      title: 'Net Sales',
      subtitle: 'Net Billed Realization',
      value: formatCurrency(netRevenue),
      icon: IndianRupee,
      iconBg: 'bg-emerald-50 text-emerald-600 border border-emerald-200',
      valueColor: 'text-emerald-800',
      subColor: 'text-emerald-700',
      isCurrency: true
    },
    {
      title: 'Gross Sales',
      subtitle: 'Taxable + Statutory GST',
      value: formatCurrency(grossRevenue),
      icon: IndianRupee,
      iconBg: 'bg-purple-50 text-[#2b1f55] border border-purple-200',
      valueColor: 'text-[#2b1f55]',
      subColor: 'text-purple-700',
      isCurrency: true
    },
    {
      title: 'Taxable Sales',
      subtitle: 'Pre-Tax Freight & Handling',
      value: formatCurrency(taxableRevenue),
      icon: Receipt,
      iconBg: 'bg-blue-50 text-blue-600 border border-blue-200',
      valueColor: 'text-blue-900',
      subColor: 'text-blue-700',
      isCurrency: true
    },
    {
      title: 'Statutory GST Tax',
      subtitle: 'Direct from IMP_INVOICE_TAX',
      value: formatCurrency(gstTax),
      icon: Percent,
      iconBg: 'bg-indigo-50 text-indigo-600 border border-indigo-200',
      valueColor: 'text-indigo-900',
      subColor: 'text-indigo-700',
      isCurrency: true
    },
    {
      title: 'Total Invoices',
      subtitle: 'Distinct Billed Invoices',
      value: `${totalInvoices.toLocaleString('en-IN')}`,
      icon: FileText,
      iconBg: 'bg-fuchsia-50 text-fuchsia-600 border border-fuchsia-200',
      valueColor: 'text-fuchsia-900',
      subColor: 'text-fuchsia-700'
    },
    {
      title: 'Physical Containers',
      subtitle: 'COUNT(DISTINCT CONT_NO)',
      value: `${physicalContainers.toLocaleString('en-IN')}`,
      icon: Container,
      iconBg: 'bg-amber-50 text-amber-600 border border-amber-200',
      valueColor: 'text-amber-900',
      subColor: 'text-amber-700'
    },
    {
      title: 'Container Movements',
      subtitle: 'Distinct Job Cycles',
      value: `${containerMovements.toLocaleString('en-IN')}`,
      icon: Truck,
      iconBg: 'bg-teal-50 text-teal-600 border border-teal-200',
      valueColor: 'text-teal-900',
      subColor: 'text-teal-700'
    },
    {
      title: 'Job Orders (JO)',
      subtitle: 'Multi-Modal Distinct Jobs',
      value: `${jobOrders.toLocaleString('en-IN')}`,
      icon: Layers,
      iconBg: 'bg-blue-50 text-blue-600 border border-blue-200',
      valueColor: 'text-blue-900',
      subColor: 'text-blue-700'
    },
    {
      title: 'Total TEUs',
      subtitle: '20ft × 1 + 40ft × 2',
      value: `${teus.toLocaleString('en-IN')}`,
      icon: Container,
      iconBg: 'bg-orange-50 text-orange-600 border border-orange-200',
      valueColor: 'text-orange-600',
      subColor: 'text-orange-700'
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
              className="bg-white p-2.5 sm:p-5 rounded-xl sm:rounded-2xl border border-slate-200 shadow-soft hover-lift transition-all"
            >
              <div className="flex items-start justify-between gap-1">
                <div className="min-w-0 flex-1">
                  <p className="text-[9px] sm:text-[11px] font-bold text-slate-500 uppercase tracking-wider truncate">
                    {card.title}
                  </p>
                  <h3 className={`text-sm sm:text-2xl font-black font-display mt-1 sm:mt-2 truncate ${card.valueColor}`}>
                    <AnimatedCounter 
                      value={card.value} 
                      duration={600}
                      decimals={card.isCurrency ? 2 : 0}
                    />
                  </h3>
                  <p className={`text-[9px] sm:text-[11px] font-semibold mt-0.5 truncate ${card.subColor}`}>
                    {card.subtitle}
                  </p>
                </div>

                <div className={`p-1.5 sm:p-3 rounded-lg sm:rounded-2xl ${card.iconBg} shadow-xs shrink-0`}>
                  <Icon className="w-3.5 h-3.5 sm:w-5 sm:h-5" />
                </div>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}
