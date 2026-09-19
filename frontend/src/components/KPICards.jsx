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
      raw: `₹ ${Number(totalGrossAmount).toLocaleString('en-IN')}`,
      icon: IndianRupee,
      iconBg: 'bg-orange-50 text-orange-600 border border-orange-200',
      valueColor: 'text-[#2b1f55]',
      badge: 'Gross Sale',
      badgeColor: 'text-emerald-700 bg-emerald-50 border-emerald-200'
    },
    {
      title: 'Net Bill Amount',
      subtitle: 'Pre-Tax Freight & Handling',
      value: formatCurrency(totalBillAmount),
      raw: `₹ ${Number(totalBillAmount).toLocaleString('en-IN')}`,
      icon: Receipt,
      iconBg: 'bg-blue-50 text-blue-600 border border-blue-200',
      valueColor: 'text-blue-900',
      badge: 'Base Revenue',
      badgeColor: 'text-blue-700 bg-blue-50 border-blue-200'
    },
    {
      title: 'Tax Collected (GST)',
      subtitle: '18% Standard GST Rate',
      value: formatCurrency(totalTax),
      raw: `₹ ${Number(totalTax).toLocaleString('en-IN')}`,
      icon: Percent,
      iconBg: 'bg-emerald-50 text-emerald-600 border border-emerald-200',
      valueColor: 'text-emerald-800',
      badge: 'GST Output',
      badgeColor: 'text-emerald-700 bg-emerald-50 border-emerald-200'
    },
    {
      title: 'Invoice & Credit Count',
      subtitle: `${invoiceCount} Invoices / ${creditNoteCount} Credit Notes`,
      value: `${totalRecords} Records`,
      raw: `${invoiceCount} Active`,
      icon: FileText,
      iconBg: 'bg-purple-50 text-purple-600 border border-purple-200',
      valueColor: 'text-purple-900',
      badge: `${invoiceCount} Invoices`,
      badgeColor: 'text-purple-700 bg-purple-50 border-purple-200'
    },
    {
      title: 'Containers Handled',
      subtitle: `${containerCount} Active Units in Yard`,
      value: `${containerCount} Containers`,
      raw: `${teuCount} TEU`,
      icon: Container,
      iconBg: 'bg-amber-50 text-amber-600 border border-amber-200',
      valueColor: 'text-amber-900',
      badge: 'Multi-Modal',
      badgeColor: 'text-amber-700 bg-amber-50 border-amber-200'
    }
  ];

  return (
    <div className="space-y-4">
      {/* KPI Cards Grid */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-5 gap-4">
        {cards.map((card, idx) => {
          const Icon = card.icon;
          return (
            <div
              key={idx}
              className="bg-white p-5 rounded-2xl border border-slate-200 shadow-soft hover:shadow-card hover:border-slate-300 transition-all duration-200"
            >
              <div className="flex items-start justify-between">
                <div>
                  <p className="text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                    {card.title}
                  </p>
                  <div className="mt-2">
                    <h3 className={`text-2xl font-black font-display tracking-tight ${card.valueColor}`}>
                      {loading ? (
                        <span className="inline-block w-24 h-7 bg-slate-100 animate-pulse rounded"></span>
                      ) : (
                        card.value
                      )}
                    </h3>
                  </div>
                </div>

                <div className={`p-3 rounded-2xl ${card.iconBg}`}>
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
