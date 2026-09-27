import dataset from '../data/realOracleDataset.json';
import recentRecords from '../data/realRecentRecords.json';

// Helper to normalize date strings to YYYY-MM-DD
function toYMD(dStr) {
  if (!dStr) return null;
  const s = String(dStr).trim();
  if (s.match(/^\d{4}-\d{2}-\d{2}$/)) return s;
  if (s.match(/^\d{2}\/\d{2}\/\d{4}$/)) {
    const p = s.split('/');
    return `${p[2]}-${p[1]}-${p[0]}`;
  }
  return s;
}

export function computeFinancialAnalytics(filters = {}) {
  let { fromDate, toDate, financialYear, companyId, terminalId, customerId, serviceType, search } = filters;

  let fYMD = null;
  let tYMD = null;

  if (financialYear && financialYear !== 'ALL' && financialYear !== 'all' && financialYear !== 'All Financial Years' && financialYear !== 'CUSTOM_RANGE') {
    const s = String(financialYear).toLowerCase();
    if (s.includes('26-27') || s.includes('2026-27')) {
      fYMD = '2026-04-01';
      tYMD = '2027-03-31';
    } else if (s.includes('25-26') || s.includes('2025-26')) {
      fYMD = '2025-04-01';
      tYMD = '2026-03-31';
    } else if (s.includes('24-25') || s.includes('2024-25')) {
      fYMD = '2024-04-01';
      tYMD = '2025-03-31';
    }
  }

  if (fromDate && fromDate.trim() !== '') fYMD = toYMD(fromDate);
  if (toDate && toDate.trim() !== '') tYMD = toYMD(toDate);

  // Defaults if no dates provided
  if (!fYMD) fYMD = '2025-01-01';
  if (!tYMD) tYMD = '2026-12-31';

  let totalInvs = 0, totalConts = 0, totalJobs = 0, totalTeus = 0;
  let totalBase = 0, totalIgst = 0, totalCgst = 0, totalSgst = 0, totalGross = 0;

  const branchMap = {};
  const customerMap = {};
  const serviceMap = {};
  const monthMap = {};

  const cleanCompany = companyId && companyId !== 'ALL' && companyId !== 'all' ? String(companyId) : null;
  const cleanTerminal = terminalId && terminalId !== 'ALL' && terminalId !== 'all' ? String(terminalId) : null;
  const cleanCustomer = customerId && customerId !== 'ALL' && customerId !== 'all' ? String(customerId).toLowerCase() : null;
  const cleanService = serviceType && serviceType !== 'ALL' && serviceType !== 'all' ? String(serviceType) : null;

  for (let i = 0; i < dataset.length; i++) {
    const r = dataset[i];

    if (r.date < fYMD || r.date > tYMD) continue;
    if (cleanCompany && String(r.companyId) !== cleanCompany) continue;
    if (cleanTerminal && String(r.terminalId) !== cleanTerminal) continue;
    if (cleanCustomer && String(r.customerId) !== cleanCustomer && !r.customerName.toLowerCase().includes(cleanCustomer)) continue;
    if (cleanService && r.serviceType !== cleanService) continue;

    totalInvs += r.invoices;
    totalConts += r.containers;
    totalJobs += r.jobs;
    totalTeus += r.teus;
    totalBase += r.taxableBase;
    totalIgst += r.igst;
    totalCgst += r.cgst;
    totalSgst += r.sgst;
    totalGross += r.gross;

    // Terminal Breakdown
    const tId = r.terminalId;
    if (!branchMap[tId]) {
      branchMap[tId] = {
        terminalId: tId,
        terminalName: r.terminalName,
        grossSale: 0,
        grossRevenue: 0,
        netRevenue: 0,
        invoiceCount: 0,
        containerCount: 0,
        teus: 0,
        taxableBase: 0,
        gstTax: 0,
      };
    }
    branchMap[tId].grossSale += r.gross;
    branchMap[tId].grossRevenue += r.gross;
    branchMap[tId].netRevenue += r.gross;
    branchMap[tId].invoiceCount += r.invoices;
    branchMap[tId].containerCount += r.containers;
    branchMap[tId].teus += r.teus;
    branchMap[tId].taxableBase += r.taxableBase;
    branchMap[tId].gstTax += (r.igst + r.cgst + r.sgst);

    // Customer Breakdown
    const cId = r.customerId;
    if (!customerMap[cId]) {
      customerMap[cId] = {
        customerId: cId,
        customerName: r.customerName,
        name: r.customerName,
        grossAmount: 0,
        grossRevenue: 0,
        netRevenue: 0,
        invoiceCount: 0,
        containerCount: 0,
        billAmount: 0,
        taxAmount: 0,
        terminals: new Set(),
      };
    }
    customerMap[cId].grossAmount += r.gross;
    customerMap[cId].grossRevenue += r.gross;
    customerMap[cId].netRevenue += r.gross;
    customerMap[cId].invoiceCount += r.invoices;
    customerMap[cId].containerCount += r.containers;
    customerMap[cId].billAmount += r.taxableBase;
    customerMap[cId].taxAmount += (r.igst + r.cgst + r.sgst);
    customerMap[cId].terminals.add(r.terminalName);

    // Service Breakdown
    const sType = r.serviceType || 'OTHER';
    if (!serviceMap[sType]) {
      serviceMap[sType] = {
        serviceType: sType,
        serviceName: getServiceName(sType),
        grossRevenue: 0,
        invoiceCount: 0,
      };
    }
    serviceMap[sType].grossRevenue += r.gross;
    serviceMap[sType].invoiceCount += r.invoices;

    // Monthly Trend
    const ym = r.date.substring(0, 7);
    if (!monthMap[ym]) {
      monthMap[ym] = {
        month: ym,
        grossRevenue: 0,
        taxableBase: 0,
        gstTax: 0,
        invoices: 0,
        containers: 0,
      };
    }
    monthMap[ym].grossRevenue += r.gross;
    monthMap[ym].taxableBase += r.taxableBase;
    monthMap[ym].gstTax += (r.igst + r.cgst + r.sgst);
    monthMap[ym].invoices += r.invoices;
    monthMap[ym].containers += r.containers;
  }

  const totalTax = totalIgst + totalCgst + totalSgst;

  // Format Sorted Branches
  const sortedBranches = Object.values(branchMap)
    .map(b => ({
      ...b,
      grossSale: Math.round(b.grossSale * 100) / 100,
      grossRevenue: Math.round(b.grossRevenue * 100) / 100,
      netRevenue: Math.round(b.netRevenue * 100) / 100,
      taxableBase: Math.round(b.taxableBase * 100) / 100,
      gstTax: Math.round(b.gstTax * 100) / 100,
    }))
    .sort((a, b) => b.grossSale - a.grossSale);

  // Format Sorted Customers
  const sortedCustomers = Object.values(customerMap)
    .map(c => {
      const g = Math.round(c.grossAmount * 100) / 100;
      return {
        ...c,
        grossAmount: g,
        grossRevenue: g,
        netRevenue: g,
        billAmount: Math.round(c.billAmount * 100) / 100,
        taxAmount: Math.round(c.taxAmount * 100) / 100,
        terminalCount: c.terminals.size,
        terminals: Array.from(c.terminals),
        share: totalGross > 0 ? Number(((g / totalGross) * 100).toFixed(2)) : 0,
      };
    })
    .sort((a, b) => b.grossAmount - a.grossAmount);

  // Format Services
  const serviceList = Object.values(serviceMap)
    .map(s => ({
      ...s,
      grossRevenue: Math.round(s.grossRevenue * 100) / 100,
      billAmount: Math.round((s.grossRevenue / 1.18) * 100) / 100,
      taxAmount: Math.round((s.grossRevenue - (s.grossRevenue / 1.18)) * 100) / 100,
      itemCount: s.invoiceCount,
      share: totalGross > 0 ? Number(((s.grossRevenue / totalGross) * 100).toFixed(1)) : 0,
    }))
    .sort((a, b) => b.grossRevenue - a.grossRevenue);

  // Format Monthly Trend
  const monthlyList = Object.keys(monthMap)
    .sort()
    .map(ym => ({
      ...monthMap[ym],
      grossRevenue: Math.round(monthMap[ym].grossRevenue * 100) / 100,
      taxableBase: Math.round(monthMap[ym].taxableBase * 100) / 100,
      gstTax: Math.round(monthMap[ym].gstTax * 100) / 100,
    }));

  // Filter Recent Detailed Records
  const matchingRecords = recentRecords.filter(rec => {
    if (cleanTerminal && String(rec.TERMINAL_ID) !== cleanTerminal) return false;
    if (cleanCompany && String(rec.COMPANY_ID) !== cleanCompany) return false;
    if (cleanCustomer && String(rec.CUSTOMER_ID) !== cleanCustomer && !rec.CUSTOMER_NAME.toLowerCase().includes(cleanCustomer)) return false;
    if (cleanService && rec.SERVICE_TYPE !== cleanService) return false;
    if (search && search.trim() !== '') {
      const q = search.trim().toLowerCase();
      const match = (rec.INVOICE_NO && String(rec.INVOICE_NO).toLowerCase().includes(q)) ||
                    (rec.INVOICE_REF_NO && rec.INVOICE_REF_NO.toLowerCase().includes(q)) ||
                    (rec.CUSTOMER_NAME && rec.CUSTOMER_NAME.toLowerCase().includes(q)) ||
                    (rec.CONT_NO && rec.CONT_NO.toLowerCase().includes(q)) ||
                    (rec.BL_NO && rec.BL_NO.toLowerCase().includes(q));
      if (!match) return false;
    }
    return true;
  });

  return {
    success: true,
    source: 'ORACLE_SPJLIVE_STANDALONE_ENGINE',
    executionMode: 'CLIENT_HIGH_SPEED_ENGINE',
    matchedRows: totalInvs,
    matchedRowCount: totalInvs,
    filters: { fromDate: fYMD, toDate: tYMD, terminalId, companyId, customerId, serviceType },
    overallKPIs: {
      totalInvoices: totalInvs,
      totalTaxableAmount: Math.round(totalBase * 100) / 100,
      totalTaxAmount: Math.round(totalTax * 100) / 100,
      totalGrossAmount: Math.round(totalGross * 100) / 100,
      totalCreditAmount: 0,
      netRevenue: Math.round(totalGross * 100) / 100,
      totalContainers: totalConts,
      containerMovements: totalConts,
      jobOrders: totalJobs,
      totalTeus: totalTeus,
      totalCustomers: sortedCustomers.length,
      totalTerminals: sortedBranches.length,
      activeTerminalCount: sortedBranches.length,
      activeCustomerCount: sortedCustomers.length,
    },
    kpis: {
      totalGrossAmount: Math.round(totalGross * 100) / 100,
      grossRevenue: Math.round(totalGross * 100) / 100,
      netRevenue: Math.round(totalGross * 100) / 100,
      totalBillAmount: Math.round(totalBase * 100) / 100,
      totalTax: Math.round(totalTax * 100) / 100,
      totalIgst: Math.round(totalIgst * 100) / 100,
      totalCgst: Math.round(totalCgst * 100) / 100,
      totalSgst: Math.round(totalSgst * 100) / 100,
      invoiceCount: totalInvs,
      containerCount: totalConts,
      containerMovements: totalConts,
      jobOrders: totalJobs,
      teuCount: totalTeus,
      physicalContainers: totalConts,
    },
    terminalAnalytics: sortedBranches,
    customerAnalytics: sortedCustomers.slice(0, 15),
    topCustomers: sortedCustomers.slice(0, 15),
    customerWise: sortedCustomers,
    serviceAnalytics: serviceList,
    topServices: serviceList,
    monthlyTrend: monthlyList,
    records: matchingRecords.slice(0, 100),
  };
}

function getServiceName(code) {
  switch (code) {
    case 'F': return 'Ocean Freight (Bill of Supply)';
    case 'A': return 'All Services (Tax Invoice)';
    case 'T': return 'Transportation Charges';
    case 'R': return 'Rebate / SSR Charges';
    case 'B': return 'B/L Surrender Charges';
    case 'S': return 'Terminal Handling Charges';
    case 'V': return 'Line Detention Charges';
    case 'D': return 'De-stuffing / Stuffing Charges';
    case 'E': return 'Export Storage Charges';
    case 'X': return 'Re-export Charges';
    case 'O': return 'Overseas Charges';
    case 'C': return 'Clearance Charges';
    default: return `Service Charge (${code})`;
  }
}

export function computeCIRReport(params = {}) {
  const analytics = computeFinancialAnalytics(params);
  const page = parseInt(params.page || '1', 10);
  const limit = parseInt(params.limit || '50', 10);
  const startIndex = (page - 1) * limit;
  const pagedRecords = analytics.records.slice(startIndex, startIndex + limit);

  return {
    success: true,
    data: pagedRecords,
    records: pagedRecords,
    kpis: analytics.kpis,
    pagination: {
      currentPage: page,
      limit,
      totalRecords: analytics.records.length,
      totalPages: Math.ceil(analytics.records.length / limit) || 1,
      hasMore: startIndex + limit < analytics.records.length,
    }
  };
}

export function getClientMasters() {
  const terminals = {};
  const customers = {};

  for (let i = 0; i < dataset.length; i++) {
    const r = dataset[i];
    if (r.terminalId && !terminals[r.terminalId]) {
      terminals[r.terminalId] = {
        TERMINAL_ID: r.terminalId,
        TERMINAL_NAME: r.terminalName,
      };
    }
    if (r.customerId && !customers[r.customerId]) {
      customers[r.customerId] = {
        CUSTOMER_ID: r.customerId,
        CUSTOMER_NAME: r.customerName,
      };
    }
  }

  return {
    success: true,
    terminals: Object.values(terminals).sort((a, b) => a.TERMINAL_NAME.localeCompare(b.TERMINAL_NAME)),
    customers: Object.values(customers).sort((a, b) => a.CUSTOMER_NAME.localeCompare(b.CUSTOMER_NAME)),
    companies: [
      { COMPANY_ID: 2, COMPANY_NAME: 'SPJ CARGO PVT LTD' },
      { COMPANY_ID: 1, COMPANY_NAME: 'S.J. CARGO MOVERS' },
      { COMPANY_ID: 5, COMPANY_NAME: 'PURAN JOSHI' },
      { COMPANY_ID: 3, COMPANY_NAME: 'PURAN JOSHI OLD' },
    ],
  };
}
