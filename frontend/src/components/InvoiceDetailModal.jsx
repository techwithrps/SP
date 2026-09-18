import React from 'react';
import { 
  X, 
  Receipt, 
  Container, 
  Building2, 
  Printer, 
  CheckCircle2 
} from 'lucide-react';

export default function InvoiceDetailModal({ record, onClose }) {
  if (!record) return null;

  const isCreditNote = record.INVOICE_TYPE === 'Credit Note' || Number(record.AMOUNT) < 0;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/60 backdrop-blur-sm animate-fadeIn">
      <div 
        onClick={(e) => e.stopPropagation()}
        className="bg-white w-full max-w-3xl rounded-3xl border border-slate-200 shadow-2xl overflow-hidden flex flex-col max-h-[90vh]"
      >
        {/* Modal Header */}
        <div className="p-5 border-b border-slate-200 bg-slate-50 flex items-center justify-between">
          <div className="flex items-center gap-3">
            <div className={`p-3 rounded-2xl ${
              isCreditNote ? 'bg-rose-50 text-rose-600 border border-rose-200' : 'bg-orange-50 text-orange-600 border border-orange-200'
            }`}>
              <Receipt className="w-5 h-5" />
            </div>
            <div>
              <div className="flex items-center gap-2">
                <h3 className="text-lg font-bold font-display text-[#2b1f55]">
                  {record.INVOICE_REF_NO || record.INVOICE_NO || 'Invoice Details'}
                </h3>
                <span className={`px-2.5 py-0.5 rounded-full text-xs font-bold ${
                  isCreditNote
                    ? 'bg-rose-50 text-rose-700 border border-rose-200'
                    : 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                }`}>
                  {isCreditNote ? 'Credit Note' : 'Tax Invoice'}
                </span>
              </div>
              <p className="text-xs text-slate-500 font-mono mt-0.5 font-medium">
                Date: {record.INVOICE_DATE || '-'} | Job: {record.JOB_NO || '-'}
              </p>
            </div>
          </div>

          <div className="flex items-center gap-2">
            <button
              onClick={() => window.print()}
              className="p-2 rounded-xl bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 transition-colors shadow-sm"
              title="Print Record"
            >
              <Printer className="w-4 h-4" />
            </button>

            <button
              onClick={onClose}
              className="p-2 rounded-xl bg-white hover:bg-rose-50 hover:text-rose-600 border border-slate-300 text-slate-500 transition-colors shadow-sm"
            >
              <X className="w-4 h-4" />
            </button>
          </div>
        </div>

        {/* Modal Body */}
        <div className="p-6 overflow-y-auto space-y-6 text-xs">
          
          {/* Section 1: Customer & Logistics Info */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            
            <div className="bg-slate-50 p-5 rounded-2xl border border-slate-200 space-y-2.5">
              <div className="text-[11px] font-bold uppercase tracking-wider text-[#ff6a00] flex items-center gap-1.5">
                <Building2 className="w-3.5 h-3.5" /> Billed Account & Party
              </div>
              <div>
                <div className="text-slate-500 font-medium">Customer Name:</div>
                <div className="font-bold text-slate-900 text-sm mt-0.5">{record.CUSTOMER_NAME}</div>
              </div>
              <div>
                <div className="text-slate-500 font-medium">Service Category:</div>
                <div className="font-bold text-[#2b1f55]">{record.SERVICE_NAME || 'Standard Logistics'}</div>
              </div>
              <div>
                <div className="text-slate-500 font-medium">Trip Classification:</div>
                <div className="font-bold text-emerald-700">{record.TRIP_TYPE || 'Export'}</div>
              </div>
            </div>

            <div className="bg-slate-50 p-5 rounded-2xl border border-slate-200 space-y-2.5">
              <div className="text-[11px] font-bold uppercase tracking-wider text-blue-700 flex items-center gap-1.5">
                <Container className="w-3.5 h-3.5" /> Container & Port Routing
              </div>
              <div className="grid grid-cols-2 gap-2">
                <div>
                  <div className="text-slate-500 font-medium">Container No:</div>
                  <div className="font-mono font-bold text-slate-900">{record.CONT_NO || 'N/A (LCL/Direct)'}</div>
                </div>
                <div>
                  <div className="text-slate-500 font-medium">Size & Type:</div>
                  <div className="font-mono text-slate-700 font-medium">{record.CONT_SIZE ? `${record.CONT_SIZE}ft ${record.CONT_TYPE || ''}` : '-'}</div>
                </div>
                <div>
                  <div className="text-slate-500 font-medium">Port / ICD:</div>
                  <div className="text-slate-800 font-medium">{record.PORT || 'SPJ ICD Dadri'}</div>
                </div>
                <div>
                  <div className="text-slate-500 font-medium">Shipping Line:</div>
                  <div className="text-slate-800 font-medium">{record.LINE || 'SPJ Express'}</div>
                </div>
              </div>
            </div>

          </div>

          {/* Section 2: Financial & Tax Ledger */}
          <div className="bg-slate-50 p-5 rounded-2xl border border-slate-200 space-y-3">
            <div className="text-[11px] font-bold uppercase tracking-wider text-emerald-700 flex items-center gap-1.5">
              <Receipt className="w-3.5 h-3.5" /> Financial & GST Computation
            </div>

            <div className="grid grid-cols-3 gap-3 pt-2">
              <div className="p-3.5 rounded-xl bg-white border border-slate-200 shadow-sm">
                <div className="text-slate-500 text-[11px] font-medium">Base Bill Amount:</div>
                <div className="text-base font-bold font-mono text-slate-900 mt-1">
                  ₹ {Number(record.BILL_AMOUNT || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                </div>
              </div>

              <div className="p-3.5 rounded-xl bg-white border border-slate-200 shadow-sm">
                <div className="text-slate-500 text-[11px] font-medium">GST / Output Tax:</div>
                <div className="text-base font-bold font-mono text-emerald-700 mt-1">
                  ₹ {Number(record.TAX || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                </div>
              </div>

              <div className="p-3.5 rounded-xl bg-white border border-slate-200 shadow-sm">
                <div className="text-slate-500 text-[11px] font-medium">Gross Total Amount:</div>
                <div className={`text-base font-black font-mono mt-1 ${
                  isCreditNote ? 'text-rose-600' : 'text-[#2b1f55]'
                }`}>
                  ₹ {Number(record.AMOUNT || 0).toLocaleString('en-IN', { minimumFractionDigits: 2 })}
                </div>
              </div>
            </div>

            {record.INVOICE_NOTE && (
              <div className="mt-3 p-3.5 bg-white rounded-xl border border-slate-200 shadow-sm">
                <span className="text-slate-500 font-bold block mb-1">Invoice Notes & Billing Remarks:</span>
                <p className="text-slate-800 text-xs leading-relaxed font-sans">{record.INVOICE_NOTE}</p>
              </div>
            )}
          </div>

        </div>

        {/* Modal Footer */}
        <div className="p-4 border-t border-slate-200 bg-slate-50 flex items-center justify-between text-xs">
          <div className="text-slate-600 font-medium flex items-center gap-1.5">
            <CheckCircle2 className="w-4 h-4 text-emerald-600" />
            Official Verified SPJ Invoice & Container Record
          </div>
          <button
            onClick={onClose}
            className="px-5 py-2 bg-[#2b1f55] hover:bg-[#3b2a74] text-white font-bold rounded-xl transition-colors shadow-sm"
          >
            Close
          </button>
        </div>

      </div>
    </div>
  );
}
