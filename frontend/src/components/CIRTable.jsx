import React, { useState, useMemo } from 'react';
import { 
  ChevronLeft, 
  ChevronRight, 
  ArrowUpDown, 
  Eye, 
  FileSpreadsheet, 
  Receipt, 
  Container, 
  AlertCircle
} from 'lucide-react';

export default function CIRTable({ 
  records = [], 
  loading = false, 
  onSelectRecord 
}) {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(25);
  const [sortField, setSortField] = useState('INVOICE_DATE');
  const [sortOrder, setSortOrder] = useState('desc');

  const handleSort = (field) => {
    if (sortField === field) {
      setSortOrder(sortOrder === 'asc' ? 'desc' : 'asc');
    } else {
      setSortField(field);
      setSortOrder('asc');
    }
  };

  const sortedRecords = useMemo(() => {
    const data = [...records];
    if (!sortField) return data;

    return data.sort((a, b) => {
      let aVal = a[sortField] || '';
      let bVal = b[sortField] || '';

      if (typeof aVal === 'number' && typeof bVal === 'number') {
        return sortOrder === 'asc' ? aVal - bVal : bVal - aVal;
      }
      return sortOrder === 'asc'
        ? String(aVal).localeCompare(String(bVal))
        : String(bVal).localeCompare(String(aVal));
    });
  }, [records, sortField, sortOrder]);

  const totalPages = Math.ceil(sortedRecords.length / pageSize) || 1;
  const paginatedRecords = useMemo(() => {
    const start = (currentPage - 1) * pageSize;
    return sortedRecords.slice(start, start + pageSize);
  }, [sortedRecords, currentPage, pageSize]);

  return (
    <div className="bg-white rounded-2xl border border-slate-200 shadow-soft overflow-hidden flex flex-col">
      
      {/* Table Top Info */}
      <div className="p-4 border-b border-slate-200 flex flex-col sm:flex-row items-center justify-between gap-3 bg-slate-50/70">
        <div className="flex items-center gap-2">
          <div className="w-2.5 h-2.5 rounded-full bg-[#ff6a00]" />
          <h4 className="font-display font-extrabold text-sm text-[#2b1f55]">
            Container Invoice & Revenue Ledger (CIR Data Grid)
          </h4>
          <span className="text-xs text-slate-500 font-semibold ml-2">
            Showing {paginatedRecords.length} of {records.length} records
          </span>
        </div>

        <div className="flex items-center gap-2 text-xs">
          <span className="text-slate-500 font-medium">Rows per page:</span>
          <select
            value={pageSize}
            onChange={(e) => {
              setPageSize(Number(e.target.value));
              setCurrentPage(1);
            }}
            className="px-2.5 py-1 bg-white border border-slate-300 rounded-lg text-slate-800 text-xs font-semibold focus:outline-none focus:border-[#2b1f55]"
          >
            <option value={15}>15</option>
            <option value={25}>25</option>
            <option value={50}>50</option>
            <option value={100}>100</option>
          </select>
        </div>
      </div>

      {/* Table Container */}
      <div className="overflow-x-auto min-h-[420px]">
        <table className="w-full text-left border-collapse text-xs">
          <thead>
            <tr className="bg-slate-100 border-b border-slate-200 text-slate-700 font-bold uppercase tracking-wider text-[11px]">
              <th className="p-3.5 text-center w-12 text-slate-500">#</th>
              
              <th 
                onClick={() => handleSort('INVOICE_REF_NO')}
                className="p-3.5 cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center gap-1">
                  Invoice Ref No
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('INVOICE_DATE')}
                className="p-3.5 cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center gap-1">
                  Date
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('CUSTOMER_NAME')}
                className="p-3.5 cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center gap-1">
                  Customer / Billed To
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('SERVICE_NAME')}
                className="p-3.5 cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center gap-1">
                  Service Charge
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th className="p-3.5">Container No</th>

              <th 
                onClick={() => handleSort('TRIP_TYPE')}
                className="p-3.5 cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center gap-1">
                  Trip Type
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('BILL_AMOUNT')}
                className="p-3.5 text-right cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center justify-end gap-1">
                  Bill Amount (₹)
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('TAX')}
                className="p-3.5 text-right cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center justify-end gap-1">
                  Tax (₹)
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th 
                onClick={() => handleSort('AMOUNT')}
                className="p-3.5 text-right cursor-pointer hover:text-[#2b1f55] transition-colors"
              >
                <div className="flex items-center justify-end gap-1">
                  Total Amount (₹)
                  <ArrowUpDown className="w-3 h-3 text-slate-400" />
                </div>
              </th>

              <th className="p-3.5 text-center">Type</th>
              <th className="p-3.5 text-center">Action</th>
            </tr>
          </thead>

          <tbody className="divide-y divide-slate-200">
            {loading ? (
              <tr>
                <td colSpan={12} className="p-12 text-center text-slate-500">
                  <div className="flex flex-col items-center justify-center gap-3">
                    <div className="w-8 h-8 border-3 border-[#2b1f55] border-t-transparent rounded-full animate-spin" />
                    <span className="text-xs font-semibold text-slate-600">Loading Live Data...</span>
                  </div>
                </td>
              </tr>
            ) : paginatedRecords.length === 0 ? (
              <tr>
                <td colSpan={12} className="p-12 text-center text-slate-500">
                  <div className="flex flex-col items-center justify-center gap-2">
                    <AlertCircle className="w-8 h-8 text-amber-500" />
                    <span className="text-sm font-bold text-slate-800">No Matching Records Found</span>
                    <span className="text-xs text-slate-500">Try changing your search terms or filter selections</span>
                  </div>
                </td>
              </tr>
            ) : (
              paginatedRecords.map((row, idx) => {
                const isCreditNote = row.INVOICE_TYPE === 'Credit Note' || Number(row.AMOUNT) < 0;
                const indexNum = (currentPage - 1) * pageSize + idx + 1;

                return (
                  <tr
                    key={idx}
                    onClick={() => onSelectRecord(row)}
                    className="hover:bg-slate-50/80 transition-colors cursor-pointer group"
                  >
                    <td className="p-3.5 text-center font-mono text-xs text-slate-400 font-medium">
                      {indexNum}
                    </td>

                    {/* Invoice Ref */}
                    <td className="p-3.5 font-bold text-[#2b1f55] group-hover:text-blue-700 transition-colors">
                      <div className="flex items-center gap-1.5">
                        <span>{row.INVOICE_REF_NO || row.INVOICE_NO || '-'}</span>
                      </div>
                      {row.JOB_NO && (
                        <div className="text-[10px] text-slate-500 font-mono mt-0.5">
                          Job: {row.JOB_NO}
                        </div>
                      )}
                    </td>

                    {/* Date */}
                    <td className="p-3.5 text-slate-600 font-mono text-xs whitespace-nowrap font-medium">
                      {row.INVOICE_DATE || '-'}
                    </td>

                    {/* Customer */}
                    <td className="p-3.5 max-w-[220px]">
                      <div className="font-bold text-slate-900 truncate" title={row.CUSTOMER_NAME}>
                        {row.CUSTOMER_NAME || 'SPJ Account Party'}
                      </div>
                      {row.INVOICE_NOTE && (
                        <div className="text-[11px] text-slate-500 truncate mt-0.5" title={row.INVOICE_NOTE}>
                          {row.INVOICE_NOTE}
                        </div>
                      )}
                    </td>

                    {/* Service */}
                    <td className="p-3.5 max-w-[180px]">
                      <span className="px-2.5 py-1 rounded-md bg-purple-50 text-purple-700 border border-purple-200 text-[11px] font-bold truncate block" title={row.SERVICE_NAME}>
                        {row.SERVICE_NAME || 'Logistics'}
                      </span>
                    </td>

                    {/* Container */}
                    <td className="p-3.5 font-mono text-xs">
                      {row.CONT_NO ? (
                        <div className="flex items-center gap-1 text-slate-800 font-bold">
                          <Container className="w-3.5 h-3.5 text-blue-600" />
                          <span>{row.CONT_NO}</span>
                        </div>
                      ) : (
                        <span className="text-slate-400 font-sans">-</span>
                      )}
                    </td>

                    {/* Trip Type */}
                    <td className="p-3.5">
                      <span className={`px-2 py-0.5 rounded text-[10px] font-bold uppercase tracking-wider ${
                        row.TRIP_TYPE === 'Export' ? 'bg-emerald-50 text-emerald-700 border border-emerald-200' :
                        row.TRIP_TYPE === 'Import' ? 'bg-blue-50 text-blue-700 border border-blue-200' :
                        row.TRIP_TYPE === 'REBATE' ? 'bg-purple-50 text-purple-700 border border-purple-200' :
                        'bg-amber-50 text-amber-700 border border-amber-200'
                      }`}>
                        {row.TRIP_TYPE || 'Standard'}
                      </span>
                    </td>

                    {/* Bill Amount */}
                    <td className="p-3.5 text-right font-mono font-semibold text-slate-700">
                      ₹ {Number(row.BILL_AMOUNT || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                    </td>

                    {/* Tax */}
                    <td className="p-3.5 text-right font-mono font-medium text-emerald-700">
                      ₹ {Number(row.TAX || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                    </td>

                    {/* Total Amount */}
                    <td className={`p-3.5 text-right font-mono font-black ${
                      isCreditNote ? 'text-rose-600' : 'text-[#2b1f55]'
                    }`}>
                      ₹ {Number(row.AMOUNT || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                    </td>

                    {/* Type Badge */}
                    <td className="p-3.5 text-center">
                      <span className={`px-2.5 py-0.5 rounded-full text-[10px] font-extrabold ${
                        isCreditNote
                          ? 'bg-rose-50 text-rose-700 border border-rose-200'
                          : 'bg-emerald-50 text-emerald-700 border border-emerald-200'
                      }`}>
                        {isCreditNote ? 'Credit Note' : 'Invoice'}
                      </span>
                    </td>

                    {/* View Button */}
                    <td className="p-3.5 text-center">
                      <button
                        onClick={(e) => {
                          e.stopPropagation();
                          onSelectRecord(row);
                        }}
                        className="p-1.5 rounded-lg bg-slate-100 hover:bg-[#2b1f55] hover:text-white text-slate-600 transition-colors"
                        title="View Details"
                      >
                        <Eye className="w-3.5 h-3.5" />
                      </button>
                    </td>
                  </tr>
                );
              })
            )}
          </tbody>
        </table>
      </div>

      {/* Pagination Footer */}
      <div className="p-4 border-t border-slate-200 flex flex-col sm:flex-row items-center justify-between gap-3 bg-slate-50">
        <div className="text-xs text-slate-600 font-medium">
          Page <span className="font-bold text-slate-900">{currentPage}</span> of <span className="font-bold text-slate-900">{totalPages}</span>
        </div>

        <div className="flex items-center gap-1.5">
          <button
            onClick={() => setCurrentPage(p => Math.max(1, p - 1))}
            disabled={currentPage === 1 || loading}
            className="p-1.5 rounded-lg bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 disabled:opacity-40 transition-colors shadow-sm"
          >
            <ChevronLeft className="w-4 h-4" />
          </button>

          <div className="flex items-center gap-1 px-2 text-xs">
            {Array.from({ length: Math.min(5, totalPages) }, (_, i) => {
              const p = i + 1;
              return (
                <button
                  key={p}
                  onClick={() => setCurrentPage(p)}
                  className={`w-7 h-7 rounded-lg text-xs font-bold transition-colors shadow-sm ${
                    currentPage === p
                      ? 'bg-[#2b1f55] text-white'
                      : 'bg-white text-slate-700 hover:bg-slate-100 border border-slate-200'
                  }`}
                >
                  {p}
                </button>
              );
            })}
          </div>

          <button
            onClick={() => setCurrentPage(p => Math.min(totalPages, p + 1))}
            disabled={currentPage === totalPages || loading}
            className="p-1.5 rounded-lg bg-white hover:bg-slate-100 border border-slate-300 text-slate-700 disabled:opacity-40 transition-colors shadow-sm"
          >
            <ChevronRight className="w-4 h-4" />
          </button>
        </div>
      </div>

    </div>
  );
}
