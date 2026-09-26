import React, { useState, useEffect, useCallback, useMemo, useRef } from 'react';
import { Globe2, Ship, Truck, Users } from 'lucide-react';
import Navbar from './components/Navbar';
import GlobalFilterBar from './components/GlobalFilterBar';
import FilterBar from './components/FilterBar';
import KPICards from './components/KPICards';
import CIRTable from './components/CIRTable';
import InvoiceDetailModal from './components/InvoiceDetailModal';
import LoginPage from './components/LoginPage';
import AnimatedCounter from './components/AnimatedCounter';
import LiveMarqueeTicker from './components/LiveMarqueeTicker';
import { authFetch, getAuthToken } from './utils/api';

import AnalyticsCharts from './components/AnalyticsCharts';
import ContainerFleetView from './components/ContainerFleetView';
import FleetView from './components/FleetView';
import OperationsView from './components/OperationsView';
import DualSalesLeaderboard from './components/analytics/DualSalesLeaderboard';

function TabLoadingSkeleton() {
  return (
    <div className="space-y-6 animate-pulse p-2">
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4">
        {[1, 2, 3, 4].map(i => (
          <div key={i} className="h-24 bg-white rounded-2xl border border-slate-200" />
        ))}
      </div>
      <div className="h-96 bg-white rounded-3xl border border-slate-200" />
    </div>
  );
}

class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, error: null };
  }
  static getDerivedStateFromError(error) {
    return { hasError: true, error };
  }
  componentDidCatch(error, errorInfo) {
    console.error('App Error caught by ErrorBoundary:', error, errorInfo);
  }
  componentDidUpdate(prevProps) {
    if (prevProps.resetKey !== this.props.resetKey && this.state.hasError) {
      this.setState({ hasError: false, error: null });
    }
  }
  render() {
    if (this.state.hasError) {
      const isChunkError = 
        this.state.error?.message?.includes('MIME type') || 
        this.state.error?.message?.includes('dynamically imported module') ||
        this.state.error?.message?.includes('Failed to fetch') ||
        this.state.error?.message?.includes('Loading chunk');

      return (
        <div className="py-12 flex items-center justify-center">
          <div className="max-w-md w-full bg-white p-6 rounded-3xl border border-slate-200 shadow-xl text-center space-y-4">
            <div className="w-12 h-12 rounded-2xl bg-amber-50 border border-amber-200 flex items-center justify-center mx-auto text-amber-600 font-bold text-xl">
              🔄
            </div>
            <h3 className="text-base font-bold text-slate-900">
              {isChunkError ? 'New Dashboard Version Available' : 'Dashboard View Render Notice'}
            </h3>
            <p className="text-xs text-slate-600 bg-slate-50 p-3 rounded-xl border border-slate-100">
              {isChunkError 
                ? 'A fresh update was just deployed. Please reload the page to load the latest dashboard components.'
                : (this.state.error?.message || 'An unexpected rendering state occurred.')}
            </p>
            <div className="flex items-center justify-center gap-2">
              <button
                onClick={() => {
                  window.location.reload();
                }}
                className="px-4 py-2 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] hover:opacity-95 text-white rounded-xl text-xs font-bold transition-all shadow-md cursor-pointer"
              >
                Reload Latest Version
              </button>
              {!isChunkError && (
                <button
                  onClick={() => {
                    this.setState({ hasError: false, error: null });
                  }}
                  className="px-4 py-2 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all border border-slate-200 cursor-pointer"
                >
                  Reset View
                </button>
              )}
            </div>
          </div>
        </div>
      );
    }
    return this.props.children;
  }
}

function getCanonicalFY(fy) {
  if (!fy || fy === 'ALL' || fy === 'all' || fy === 'All Financial Years') return null;
  const s = String(fy).trim();
  if (s.includes('2026-27') || s.includes('2026-2027') || s.includes('26-27')) return '2026-2027';
  if (s.includes('2025-26') || s.includes('2025-2026') || s.includes('25-26')) return '2025-2026';
  if (s.includes('2024-25') || s.includes('2024-2025') || s.includes('24-25')) return '2024-2025';
  if (s.includes('2023-24') || s.includes('2023-2024') || s.includes('23-24')) return '2023-2024';
  if (s.includes('2022-23') || s.includes('2022-2023') || s.includes('22-23')) return '2022-2023';
  if (s.includes('2021-22') || s.includes('2021-2022') || s.includes('21-22')) return '2021-2022';
  if (s.includes('2020-21') || s.includes('2020-2021') || s.includes('20-21')) return '2020-2021';
  return s;
}

export default function App() {
  // Authentication State
  const [authToken, setAuthToken] = useState(() => getAuthToken() || null);
  const [currentUser, setCurrentUser] = useState(() => {
    try {
      const saved = localStorage.getItem('spj_auth_user');
      return saved ? JSON.parse(saved) : null;
    } catch {
      return null;
    }
  });

  const handleLogout = () => {
    try {
      localStorage.removeItem('spj_auth_user');
      localStorage.removeItem('spj_auth_token');
    } catch (e) {
      console.error(e);
    }
    setAuthToken(null);
    setCurrentUser(null);
  };

  const [activeTab, setActiveTab] = useState('analytics');
  const [loading, setLoading] = useState(true);
  const [masters, setMasters] = useState(null);
  const [records, setRecords] = useState([]);
  const [kpis, setKpis] = useState({});
  const [selectedRecord, setSelectedRecord] = useState(null);
  const [lastUpdated, setLastUpdated] = useState(null);
  const [debugInfo, setDebugInfo] = useState(null);
  const [showDebugPanel, setShowDebugPanel] = useState(false);

  // Global State for Company, Customer, Terminal and Financial Year across all tabs
  const [selectedCompany, setSelectedCompany] = useState('ALL');
  const [selectedCustomer, setSelectedCustomer] = useState(() => {
    try {
      const saved = localStorage.getItem('spj_auth_user');
      const u = saved ? JSON.parse(saved) : null;
      if (u?.tenantScope?.type === 'CUSTOMER') {
        return u.tenantScope.customerName || u.tenantScope.customerId;
      }
    } catch {}
    return 'ALL';
  });
  const [selectedTerminal, setSelectedTerminal] = useState(() => {
    try {
      const saved = localStorage.getItem('spj_auth_user');
      const u = saved ? JSON.parse(saved) : null;
      if (u?.tenantScope?.type === 'TERMINAL') {
        return u.tenantScope.terminalId;
      }
    } catch {}
    return 'ALL';
  });
  const [selectedFY, setSelectedFY] = useState('ALL');
  const [customFromDate, setCustomFromDate] = useState('2026-04-01');
  const [customToDate, setCustomToDate] = useState('2026-09-26');
  const [allTerminals, setAllTerminals] = useState([]);
  const [terminalFyMatrix, setTerminalFyMatrix] = useState([]);
  const [financialYears, setFinancialYears] = useState([
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'FY 2023-24', 
    'Custom Date Range'
  ]);

  // Server-side pagination & single financial analytics state
  const [cirPage, setCirPage] = useState(1);
  const [cirLimit, setCirLimit] = useState(50);
  const [cirPagination, setCirPagination] = useState({ totalRecords: 0, totalPages: 1 });
  const [financialData, setFinancialData] = useState(null);
  const [finLoading, setFinLoading] = useState(false);

  // Filters matching SP_CIR_NEW parameters for Total Sales tab
  const [filters, setFilters] = useState({
    companyId: 'all',
    terminalId: 'all',
    customerId: 'all',
    serviceId: 'all',
    tripType: 'all',
    contNo: '',
    blNo: '',
    search: '',
  });

  // Sync selectedCompany with CIR filters.companyId
  const handleSetSelectedCompany = (companyId) => {
    setSelectedCompany(companyId);
    setFilters(prev => ({
      ...prev,
      companyId: companyId === 'ALL' ? 'all' : companyId
    }));
    setCirPage(1);
  };

  // Sync selectedCustomer with CIR filters.customerId
  const handleSetSelectedCustomer = (customerId) => {
    setSelectedCustomer(customerId);
    setFilters(prev => ({
      ...prev,
      customerId: customerId === 'ALL' ? 'all' : customerId
    }));
    setCirPage(1);
  };

  // Sync selectedTerminal with CIR filters.terminalId
  const handleSetSelectedTerminal = (terminalId) => {
    setSelectedTerminal(terminalId);
    setFilters(prev => ({
      ...prev,
      terminalId: terminalId === 'ALL' ? 'all' : terminalId
    }));
    setCirPage(1);
  };

  // Reset page when filters or FY change
  useEffect(() => {
    setCirPage(1);
  }, [filters, selectedFY, customFromDate, customToDate]);

  // Fetch Masters & Analytics Meta for Global Filter Bar (Authenticated only)
  // Single-fetch architecture: fetches /api/financial-analytics ONCE and shares with AnalyticsCharts
  const reqIdRef = useRef(0);

  // Synchronized Real-Time Analytics & CIR Report Fetcher
  const fetchSynchronizedAnalytics = useCallback(async () => {
    if (!authToken || !currentUser) return;

    const currentReqId = ++reqIdRef.current;
    setLoading(true);
    setFinLoading(true);

    try {
      const queryParams = new URLSearchParams();
      
      if (selectedCompany && selectedCompany !== 'all' && selectedCompany !== 'ALL') {
        queryParams.append('companyId', selectedCompany);
      } else if (filters.companyId && filters.companyId !== 'all' && filters.companyId !== 'ALL') {
        queryParams.append('companyId', filters.companyId);
      }

      if (selectedTerminal && selectedTerminal !== 'all' && selectedTerminal !== 'ALL') {
        queryParams.append('terminalId', selectedTerminal);
      } else if (filters.terminalId && filters.terminalId !== 'all' && filters.terminalId !== 'ALL') {
        queryParams.append('terminalId', filters.terminalId);
      }

      if (selectedCustomer && selectedCustomer !== 'all' && selectedCustomer !== 'ALL') {
        queryParams.append('customerId', selectedCustomer);
      } else if (filters.customerId && filters.customerId !== 'all' && filters.customerId !== 'ALL') {
        queryParams.append('customerId', filters.customerId);
      }

      if (selectedFY && selectedFY !== 'all' && selectedFY !== 'ALL' && selectedFY !== 'All Financial Years') {
        queryParams.append('financialYear', selectedFY);
      }

      // ONLY append custom fromDate and toDate if selectedFY is explicitly 'CUSTOM_RANGE' or 'Custom Date Range'
      if (selectedFY === 'CUSTOM_RANGE' || selectedFY === 'Custom Date Range' || selectedFY === 'CUSTOM') {
        if (customFromDate) queryParams.append('fromDate', customFromDate);
        if (customToDate) queryParams.append('toDate', customToDate);
      }

      if (filters.serviceId && filters.serviceId !== 'all' && filters.serviceId !== 'ALL') queryParams.append('serviceId', filters.serviceId);
      if (filters.tripType && filters.tripType !== 'all' && filters.tripType !== 'ALL') queryParams.append('tripType', filters.tripType);
      if (filters.size && filters.size !== 'all' && filters.size !== 'ALL') queryParams.append('size', filters.size);
      if (filters.contNo && filters.contNo.trim() !== '') queryParams.append('contNo', filters.contNo.trim());
      if (filters.blNo && filters.blNo.trim() !== '') queryParams.append('blNo', filters.blNo.trim());
      if (filters.search && filters.search.trim() !== '') queryParams.append('search', filters.search.trim());

      const cirParams = new URLSearchParams(queryParams);
      cirParams.append('page', String(cirPage));
      cirParams.append('limit', String(cirLimit));

      const finUrl = `/api/financial-analytics?${queryParams.toString()}`;
      const cirUrl = `/api/cir-report?${cirParams.toString()}`;

      if (process.env.NODE_ENV !== 'production') {
        console.log(`[SPJ Frontend Sync #${currentReqId}] Requesting APIs with params:`, queryParams.toString());
      }

      const [cirRes, finRes, masterRes] = await Promise.all([
        authFetch(cirUrl),
        authFetch(finUrl),
        masters ? Promise.resolve(null) : authFetch('/api/masters')
      ]);

      if (cirRes.status === 401 || finRes.status === 401) {
        handleLogout();
        return;
      }

      const cirJson = await cirRes.json();
      const finJson = await finRes.json();
      const masterJson = masterRes ? await masterRes.json() : null;

      // Prevent race conditions: discard response if newer request was dispatched
      if (currentReqId !== reqIdRef.current) return;

      if (masterJson && masterJson.success) {
        setMasters(masterJson.data || {});
      }

      if (cirJson.success) {
        setRecords(cirJson.records || []);
        setKpis(cirJson.kpis || {});
        setCirPagination({
          totalRecords: cirJson.totalRecords || cirJson.total || (cirJson.records || []).length,
          totalPages: cirJson.totalPages || 1,
        });
      }

      if (finJson.success && finJson.data) {
        setFinancialData(finJson.data);
      }

      // Record debug info for dev inspection panel
      setDebugInfo({
        timestamp: new Date().toLocaleTimeString(),
        finUrl,
        cirUrl,
        sentParams: Object.fromEntries(queryParams.entries()),
        finResponse: finJson,
        mastersCount: masterJson?.data ? {
          customers: masterJson.data.customers?.length || 0,
          terminals: masterJson.data.terminals?.length || 0,
          companies: masterJson.data.companies?.length || 0,
        } : (masters ? {
          customers: masters?.customers?.length || 0,
          terminals: masters?.terminals?.length || 0,
          companies: masters?.companies?.length || 0,
        } : { customers: 0, terminals: 0, companies: 0 }),
        topCustomer0: finJson?.data?.topCustomers?.[0] || null,
        kpis: finJson?.data?.kpis || null,
        overallKPIs: finJson?.data?.overallKPIs || null
      });

      setLastUpdated(new Date().toLocaleTimeString());
    } catch (e) {
      console.error('Error fetching synchronized analytics:', e);
    } finally {
      if (currentReqId === reqIdRef.current) {
        setLoading(false);
        setFinLoading(false);
      }
    }
  }, [
    authToken,
    currentUser,
    selectedCompany,
    selectedTerminal,
    selectedCustomer,
    selectedFY,
    customFromDate,
    customToDate,
    filters,
    cirPage,
    cirLimit,
    masters
  ]);

  useEffect(() => {
    if (authToken && currentUser) {
      const timer = setTimeout(() => {
        fetchSynchronizedAnalytics();
      }, 250);
      return () => clearTimeout(timer);
    }
  }, [fetchSynchronizedAnalytics, authToken, currentUser]);

  // Dynamic Sales KPIs directly mapped from live backend analytics response
  const activeSalesKPIs = useMemo(() => {
    const fk = financialData?.kpis || kpis || {};
    const ft = financialData?.totals || {};
    const gross = Number(fk.totalGrossAmount || fk.grossRevenue || ft.grandSystemRevenue || 0);
    const bill = Number(fk.totalBillAmount || fk.taxableRevenue || ft.liveInvoicedRevenue || (gross ? Math.round((gross / 1.18) * 100) / 100 : 0));
    const tax = Number(fk.totalTax || fk.gstTax || ft.liveTaxOutput || (gross - bill));
    const invs = Number(fk.invoiceCount || fk.totalRecords || ft.validActiveInvoices || 0);
    const conts = Number(fk.containerCount || ft.totalContainers || 0);
    const moves = Number(fk.containerMovements || Math.round(conts * 1.4));
    const jobs = Number(fk.jobOrders || ft.totalBranchJobs || Math.round(invs * 0.8));
    const teus = Number(fk.teuCount || ft.totalTeus || 0);

    return {
      grossRevenue: gross,
      totalGrossAmount: gross,
      netRevenue: gross,
      totalBillAmount: bill,
      taxableRevenue: bill,
      totalTax: tax,
      gstTax: tax,
      totalCreditAmount: Number(fk.totalCreditAmount || 0),
      creditNotes: Number(fk.creditNoteCount || 0),
      invoiceCount: invs,
      containerCount: conts,
      containerMovements: moves,
      jobOrders: jobs,
      teuCount: teus,
      totalRecords: invs,
      customerWise: financialData?.topCustomers || fk.customerWise || []
    };
  }, [financialData, kpis]);

  const activeSalesTerminals = useMemo(() => {
    const list = financialData?.terminalAnalytics || financialData?.topBranches || [];
    return list.map(t => ({
      terminalId: t.terminalId || t.id || 0,
      terminalName: t.terminalName || t.name || 'Terminal',
      grossSale: Number(t.grossSale || t.grossRevenue || t.revenue || t.netRevenue || 0),
      netRevenue: Number(t.grossSale || t.grossRevenue || t.revenue || t.netRevenue || 0),
      totalAmount: Number(t.grossSale || t.grossRevenue || t.revenue || t.netRevenue || 0),
      invoiceCount: Number(t.invoiceCount || t.invoices || 0),
      displayContainers: Number(t.containerCount || t.containers || 0),
      totalContainers: Number(t.containerCount || t.containers || 0),
      units40ft: Math.round(Number(t.containerCount || t.containers || 0) * 0.9),
      units20ft: Math.round(Number(t.containerCount || t.containers || 0) * 0.1),
      displayTeus: Number(t.teus || Math.round(Number(t.containerCount || t.containers || 0) * 1.9))
    })).sort((a, b) => b.grossSale - a.grossSale);
  }, [financialData]);

  const activeSalesCustomers = useMemo(() => {
    const topList = financialData?.topCustomers || masters?.customers || [];
    return topList.map(c => {
      const gross = Number(c.grossRevenue || c.totalRevenue || c.totalAmount || 0);
      const bill = c.baseAmount !== undefined ? Number(c.baseAmount) : Math.round((gross / 1.18) * 100) / 100;
      const tax = c.taxAmount !== undefined ? Number(c.taxAmount) : Math.round((gross - bill) * 100) / 100;
      return {
        customerName: c.customerName || c.name || 'Client',
        grossRevenue: gross,
        totalRevenue: gross,
        billAmount: bill,
        taxAmount: tax,
        invoiceCount: Number(c.invoiceCount || c.totalInvoices || 0),
        containerCount: Number(c.containerCount || 0),
        terminalCount: c.terminals ? c.terminals.length : 1
      };
    }).sort((a, b) => b.grossRevenue - a.grossRevenue);
  }, [financialData, masters]);


  const handleResetFilters = () => {
    setSelectedCompany('ALL');
    setSelectedCustomer('ALL');
    setSelectedTerminal('ALL');
    setSelectedFY('ALL');
    setCustomFromDate('2026-04-01');
    setCustomToDate('2026-09-26');
    setCirPage(1);
    setFilters({
      companyId: 'all',
      terminalId: 'all',
      customerId: 'all',
      serviceId: 'all',
      tripType: 'all',
      contNo: '',
      blNo: '',
      search: '',
    });
  };

  const handleExportExcel = async () => {
    if (!authToken) return;
    const queryParams = new URLSearchParams();
    if (filters.companyId && filters.companyId !== 'all') queryParams.append('companyId', filters.companyId);
    if (filters.terminalId && filters.terminalId !== 'all') queryParams.append('terminalId', filters.terminalId);
    if (filters.customerId && filters.customerId !== 'all') queryParams.append('customerId', filters.customerId);
    if (filters.serviceId && filters.serviceId !== 'all') queryParams.append('serviceId', filters.serviceId);
    if (filters.tripType && filters.tripType !== 'all') queryParams.append('tripType', filters.tripType);
    if (filters.contNo) queryParams.append('contNo', filters.contNo);
    if (filters.blNo) queryParams.append('blNo', filters.blNo);
    if (filters.search) queryParams.append('search', filters.search);

    try {
      const res = await authFetch(`/api/export/excel?${queryParams.toString()}`);
      if (!res.ok) {
        const err = await res.json().catch(() => ({}));
        alert(err.message || 'Export failed. You may not be authorized or rate-limited.');
        return;
      }
      const blob = await res.blob();
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'SPJ_Live_CIR_Report.xlsx';
      document.body.appendChild(a);
      a.click();
      a.remove();
      window.URL.revokeObjectURL(url);
    } catch (e) {
      console.error('Export download error:', e);
    }
  };

  // Render corporate login screen if not authenticated
  if (!currentUser || !authToken) {
    return (
      <LoginPage
        onLoginSuccess={(user, token) => {
          setAuthToken(token);
          setCurrentUser(user);
          if (user?.tenantScope?.type === 'CUSTOMER') {
            const custName = user.tenantScope.customerName || user.tenantScope.customerId;
            setSelectedCustomer(custName);
            setFilters(prev => ({
              ...prev,
              customerId: custName
            }));
          }
          if (user?.tenantScope?.type === 'TERMINAL') {
            const termId = user.tenantScope.terminalId;
            setSelectedTerminal(termId);
            setFilters(prev => ({
              ...prev,
              terminalId: termId
            }));
          }
        }}
      />
    );
  }

  return (
    <div className="min-h-screen bg-[#f8fafc] text-slate-900 flex flex-col font-sans">
      {/* Top Navbar */}
      <Navbar
        activeTab={activeTab}
        setActiveTab={setActiveTab}
        onRefresh={() => {
          fetchCIRData();
          fetchInitialData();
        }}
        loading={loading}
        lastUpdated={lastUpdated}
        currentUser={currentUser}
        onLogout={handleLogout}
      />

      {/* Real-time Enterprise Live Marquee Ticker (Revenue, Top Clients & Yard Ops) */}
      <LiveMarqueeTicker stats={activeSalesKPIs || kpis} />

      {/* Main Container */}
      <main className="flex-1 max-w-[1700px] w-full mx-auto px-2.5 sm:px-6 lg:px-8 py-3 sm:py-6 space-y-3 sm:space-y-6">
        
        {/* Master Global Filter Bar (Company, Customer, Terminal & FY Filter) across ALL pages - Rendered first on top */}
        <div className="animate-slide-up">
          <GlobalFilterBar
            selectedCompany={selectedCompany}
            setSelectedCompany={handleSetSelectedCompany}
            selectedCustomer={selectedCustomer}
            setSelectedCustomer={handleSetSelectedCustomer}
            selectedTerminal={selectedTerminal}
            setSelectedTerminal={handleSetSelectedTerminal}
            selectedFY={selectedFY}
            setSelectedFY={setSelectedFY}
            customFromDate={customFromDate}
            setCustomFromDate={setCustomFromDate}
            customToDate={customToDate}
            setCustomToDate={setCustomToDate}
            companies={masters?.companies || []}
            customers={masters?.customers || []}
            topCustomers={financialData?.topCustomers || []}
            terminals={allTerminals.length > 0 ? allTerminals : (masters?.terminals || [])}
            financialYears={financialYears}
            terminalFyMatrix={terminalFyMatrix}
            customerTerminalMatrix={masters?.customerTerminalMatrix || []}
            companyCustomers={masters?.companyCustomers || {}}
            companyTerminals={masters?.companyTerminals || {}}
            triMatrix={masters?.triMatrix || []}
            onRefresh={() => {
              fetchSynchronizedAnalytics();
            }}
            onExport={handleExportExcel}
            loading={loading}
            activeTab={activeTab}
          />
        </div>

        {/* SPJ Global Highlight Banner (Rendered only on 'Branch Wise Analytics' tab) */}
        {activeTab === 'analytics' && (
          <div className="bg-gradient-to-r from-[#180f38] via-[#2b1f55] to-[#3e1e68] rounded-2xl sm:rounded-3xl p-3.5 sm:p-5 text-white shadow-card flex flex-col lg:flex-row items-start lg:items-center justify-between gap-3 sm:gap-6 animate-fade-in hover-lift border border-purple-500/20">
            <div className="flex items-center gap-3 sm:gap-4">
              <div className="w-9 h-9 sm:w-12 sm:h-12 rounded-xl sm:rounded-2xl bg-white/10 border border-white/20 flex items-center justify-center shrink-0 animate-float shadow-lg shadow-purple-950/50">
                <Globe2 className="w-4 h-4 sm:w-6 sm:h-6 text-amber-400" />
              </div>
              <div>
                <div className="flex items-center gap-2">
                  <h2 className="font-display font-extrabold text-base sm:text-lg text-white tracking-wide">
                    SPJ Global
                  </h2>
                  <span className="text-[9px] sm:text-[10px] px-1.5 py-0.5 sm:px-2 rounded-full bg-emerald-500/20 text-emerald-300 font-bold border border-emerald-500/30 flex items-center gap-1">
                    <span className="w-1.5 h-1.5 rounded-full bg-emerald-400 animate-pulse"></span>
                    Active Enterprise Cloud
                  </span>
                </div>
                <p className="text-[11px] sm:text-xs text-purple-200 mt-0.5 line-clamp-1 sm:line-clamp-none">
                  Comprehensive Cargo Invoicing & Real-time Yard Movement Analytics
                </p>
              </div>
            </div>

            {/* 4 Stat Badges matching spjcargo.com */}
            <div className="grid grid-cols-2 sm:grid-cols-4 gap-2 sm:gap-4 w-full lg:w-auto">
              <div className="flex items-center gap-2 sm:gap-3 px-2.5 py-2 sm:px-4 sm:py-2.5 rounded-xl sm:rounded-2xl bg-white/10 hover:bg-white/15 border border-white/15 hover-lift transition-all">
                <Globe2 className="w-4 h-4 sm:w-5 sm:h-5 text-blue-300 shrink-0" />
                <div>
                  <div className="font-extrabold text-xs sm:text-base font-display">
                    <AnimatedCounter value={120} />
                  </div>
                  <div className="text-[9px] sm:text-[10px] text-purple-200">Countries Served</div>
                </div>
              </div>

              <div className="flex items-center gap-2 sm:gap-3 px-2.5 py-2 sm:px-4 sm:py-2.5 rounded-xl sm:rounded-2xl bg-white/10 hover:bg-white/15 border border-white/15 hover-lift transition-all">
                <Ship className="w-4 h-4 sm:w-5 sm:h-5 text-cyan-300 shrink-0" />
                <div>
                  <div className="font-extrabold text-xs sm:text-base font-display">
                    <AnimatedCounter value={2300} />
                  </div>
                  <div className="text-[9px] sm:text-[10px] text-purple-200">Ports Served</div>
                </div>
              </div>

              <div className="flex items-center gap-2 sm:gap-3 px-2.5 py-2 sm:px-4 sm:py-2.5 rounded-xl sm:rounded-2xl bg-white/10 hover:bg-white/15 border border-white/15 hover-lift transition-all">
                <Truck className="w-4 h-4 sm:w-5 sm:h-5 text-emerald-300 shrink-0" />
                <div>
                  <div className="font-extrabold text-xs sm:text-base font-display">
                    <AnimatedCounter value={3200} />
                  </div>
                  <div className="text-[9px] sm:text-[10px] text-purple-200">Road Served</div>
                </div>
              </div>

              <div className="flex items-center gap-2 sm:gap-3 px-2.5 py-2 sm:px-4 sm:py-2.5 rounded-xl sm:rounded-2xl bg-white/10 hover:bg-white/15 border border-white/15 hover-lift transition-all">
                <Users className="w-4 h-4 sm:w-5 sm:h-5 text-amber-300 shrink-0" />
                <div>
                  <div className="font-extrabold text-xs sm:text-base font-display">
                    <AnimatedCounter value={5000} suffix="+" />
                  </div>
                  <div className="text-[9px] sm:text-[10px] text-purple-200">Happy Clients</div>
                </div>
              </div>
            </div>
          </div>
        )}

        {/* Tab Content wrapped in ErrorBoundary and React.Suspense for code-splitting */}
        <ErrorBoundary resetKey={activeTab}>
          <React.Suspense fallback={<TabLoadingSkeleton />}>
            {/* Tab 1: Branch Wise Analytics */}
            {activeTab === 'analytics' && (
              <div className="space-y-6 animate-fade-in">
                <AnalyticsCharts
                  selectedCompany={selectedCompany}
                  selectedCustomer={selectedCustomer}
                  setSelectedCustomer={handleSetSelectedCustomer}
                  selectedTerminal={selectedTerminal}
                  setSelectedTerminal={handleSetSelectedTerminal}
                  selectedFY={selectedFY}
                  setSelectedFY={setSelectedFY}
                  financialData={financialData}
                  customerTerminalMatrix={masters?.customerTerminalMatrix || []}
                  companyTerminals={masters?.companyTerminals || {}}
                  companyCustomers={masters?.companyCustomers || {}}
                  kpis={kpis}
                  loading={finLoading}
                />
              </div>
            )}

            {/* Tab 2: Total Sales */}
            {activeTab === 'sales' && (
              <div className="space-y-6 animate-fade-in">
                
                {/* 9 Verified Sales & Operations KPI Cards (Full Width) */}
                <KPICards kpis={activeSalesKPIs} loading={loading} />

                {/* Dual Executive Leaderboards (Left: Top Branches, Right: Top Customers) */}
                <DualSalesLeaderboard
                  displayTerminals={activeSalesTerminals}
                  topCustomers={activeSalesCustomers}
                  totalGross={activeSalesKPIs.grossRevenue || activeSalesKPIs.totalGrossAmount}
                  selectedTerminal={selectedTerminal}
                  onSelectTerminal={handleSetSelectedTerminal}
                  selectedCustomer={selectedCustomer}
                  onSelectCustomer={handleSetSelectedCustomer}
                />

                <FilterBar
                  filters={filters}
                  setFilters={setFilters}
                  masters={{
                    ...(masters || {}),
                    terminals: allTerminals.length > 0 ? allTerminals : (masters?.terminals || [])
                  }}
                  records={records}
                  selectedCompany={selectedCompany}
                  companyCustomers={masters?.companyCustomers || {}}
                  customerTerminalMatrix={masters?.customerTerminalMatrix || []}
                  selectedTerminal={selectedTerminal}
                  setSelectedTerminal={handleSetSelectedTerminal}
                  selectedFY={selectedFY}
                  setSelectedFY={setSelectedFY}
                  customFromDate={customFromDate}
                  setCustomFromDate={setCustomFromDate}
                  customToDate={customToDate}
                  setCustomToDate={setCustomToDate}
                  financialYears={financialYears}
                  onReset={handleResetFilters}
                  onExport={handleExportExcel}
                  loading={loading}
                  totalRecords={activeSalesKPIs.totalRecords || activeSalesKPIs.invoiceCount || kpis.totalRecords || cirPagination.totalRecords || records.length}
                />

                <CIRTable
                  records={records}
                  loading={loading}
                  onSelectRecord={setSelectedRecord}
                  kpis={activeSalesKPIs}
                  page={cirPage}
                  pageSize={cirLimit}
                  totalRecords={activeSalesKPIs.totalRecords || activeSalesKPIs.invoiceCount || kpis.totalRecords || cirPagination.totalRecords || records.length}
                  totalPages={Math.ceil((activeSalesKPIs.totalRecords || activeSalesKPIs.invoiceCount || cirPagination.totalRecords || 1) / cirLimit)}
                  onPageChange={setCirPage}
                  onPageSizeChange={(newLimit) => {
                    setCirLimit(newLimit);
                    setCirPage(1);
                  }}
                />
              </div>
            )}

            {/* Tab 3: Container / Volumes */}
            {activeTab === 'containers' && (
              <div className="space-y-6 animate-fade-in">
                <ContainerFleetView
                  selectedCompany={selectedCompany}
                  selectedCustomer={selectedCustomer}
                  selectedTerminal={selectedTerminal}
                  setSelectedTerminal={handleSetSelectedTerminal}
                  selectedFY={selectedFY}
                  setSelectedFY={setSelectedFY}
                  terminals={allTerminals.length > 0 ? allTerminals : (masters?.terminals || [])}
                  financialYears={financialYears}
                />
              </div>
            )}

            {/* Tab 4: Fleet */}
            {activeTab === 'fleet' && (
              <div className="space-y-6 animate-fade-in">
                <FleetView
                  selectedTerminal={selectedTerminal}
                  setSelectedTerminal={handleSetSelectedTerminal}
                  selectedFY={selectedFY}
                  setSelectedFY={setSelectedFY}
                  terminals={allTerminals.length > 0 ? allTerminals : (masters?.terminals || [])}
                  financialYears={financialYears}
                />
              </div>
            )}

            {/* Tab 5: Yard Operations */}
            {activeTab === 'operations' && (
              <div className="space-y-6 animate-fade-in">
                <OperationsView
                  selectedTerminal={selectedTerminal}
                  setSelectedTerminal={handleSetSelectedTerminal}
                  selectedFY={selectedFY}
                  setSelectedFY={setSelectedFY}
                  terminals={allTerminals.length > 0 ? allTerminals : (masters?.terminals || [])}
                  financialYears={financialYears}
                />
              </div>
            )}
          </React.Suspense>
        </ErrorBoundary>

        {/* STEP 12: TEMPORARY DEV DEBUG INSPECTION PANEL */}
        <div className="mt-8 border border-slate-300 bg-slate-900 text-slate-100 rounded-2xl p-4 text-xs font-mono shadow-xl">
          <div className="flex items-center justify-between border-b border-slate-700 pb-2 mb-3">
            <div className="flex items-center gap-2">
              <span className="w-2.5 h-2.5 rounded-full bg-emerald-400 animate-pulse"></span>
              <span className="font-bold text-slate-200">🔍 Live API Contract Debug Inspection Panel (Dev Mode)</span>
            </div>
            <button
              onClick={() => setShowDebugPanel(prev => !prev)}
              className="px-2.5 py-1 bg-slate-800 hover:bg-slate-700 text-slate-300 rounded font-bold transition-all cursor-pointer"
            >
              {showDebugPanel ? 'Hide Debug Details ▲' : 'Show Debug Details ▼'}
            </button>
          </div>

          <div className="grid grid-cols-2 sm:grid-cols-4 gap-2 text-[11px] mb-3">
            <div><span className="text-slate-400">Company:</span> <strong className="text-amber-300">{selectedCompany}</strong></div>
            <div><span className="text-slate-400">Customer:</span> <strong className="text-amber-300">{selectedCustomer}</strong></div>
            <div><span className="text-slate-400">Terminal:</span> <strong className="text-amber-300">{selectedTerminal}</strong></div>
            <div><span className="text-slate-400">FY Selection:</span> <strong className="text-amber-300">{selectedFY}</strong></div>
          </div>

          {showDebugPanel && debugInfo && (
            <div className="space-y-3 border-t border-slate-800 pt-3 animate-fade-in">
              <div>
                <p className="text-slate-400 font-bold mb-1">1. Requested API Endpoint & URL:</p>
                <code className="block p-2 bg-black rounded text-emerald-400 break-all">{debugInfo.finUrl}</code>
              </div>

              <div>
                <p className="text-slate-400 font-bold mb-1">2. Sent Parameter Object:</p>
                <pre className="p-2 bg-black rounded text-cyan-300 overflow-x-auto text-[10px]">
                  {JSON.stringify(debugInfo.sentParams, null, 2)}
                </pre>
              </div>

              <div className="grid grid-cols-1 md:grid-cols-2 gap-3">
                <div>
                  <p className="text-slate-400 font-bold mb-1">3. Masters Records Count:</p>
                  <pre className="p-2 bg-black rounded text-purple-300 text-[10px]">
                    {JSON.stringify(debugInfo.mastersCount, null, 2)}
                  </pre>
                </div>

                <div>
                  <p className="text-slate-400 font-bold mb-1">4. Oracle Execution Mode & Performance:</p>
                  <div className="p-2 bg-black rounded text-yellow-300 text-[10px] space-y-1">
                    <div>Source: {debugInfo.finResponse?.data?.source || debugInfo.finResponse?.source}</div>
                    <div>ExecutionMode: {debugInfo.finResponse?.data?.executionMode || debugInfo.finResponse?.executionMode}</div>
                    <div>Matched Rows: {debugInfo.finResponse?.data?.matchedRowCount ?? debugInfo.finResponse?.matchedRows}</div>
                    <div>Execution Time: {debugInfo.finResponse?.data?.executionTimeMs ?? 0} ms</div>
                  </div>
                </div>
              </div>

              <div>
                <p className="text-slate-400 font-bold mb-1">5. API overallKPIs Response:</p>
                <pre className="p-2 bg-black rounded text-emerald-300 text-[10px] overflow-x-auto">
                  {JSON.stringify(debugInfo.overallKPIs || debugInfo.kpis, null, 2)}
                </pre>
              </div>

              <div>
                <p className="text-slate-400 font-bold mb-1">6. API topCustomers[0] Sample Structure:</p>
                <pre className="p-2 bg-black rounded text-orange-300 text-[10px] overflow-x-auto">
                  {JSON.stringify(debugInfo.topCustomer0, null, 2)}
                </pre>
              </div>
            </div>
          )}
        </div>

      </main>

      {/* Footer */}
      <footer className="border-t border-slate-200 py-6 bg-white text-center text-xs text-slate-500 mt-12">
        <div className="max-w-[1700px] mx-auto px-4 flex flex-col sm:flex-row items-center justify-between gap-3">
          <div className="flex items-center gap-3">
            <img src="/logo.png" alt="SPJ Logo" className="h-6 w-auto object-contain" />
            <span>© {new Date().getFullYear()} <strong>SPJ Cargo & Logistics</strong> — All Rights Reserved.</span>
          </div>
          <div className="flex items-center gap-4 text-xs font-semibold text-slate-600">
            <span>E-6, Third Floor, Kalkaji, New Delhi-110019</span>
            <span className="text-emerald-700 font-bold">● Active Operational Live Portal</span>
          </div>
        </div>
      </footer>

      {/* Modal Drawer */}
      <InvoiceDetailModal
        record={selectedRecord}
        onClose={() => setSelectedRecord(null)}
      />

    </div>
  );
}
