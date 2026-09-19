import React, { useState, useEffect, useCallback } from 'react';
import { Globe2, Ship, Truck, Users } from 'lucide-react';
import Navbar from './components/Navbar';
import GlobalFilterBar from './components/GlobalFilterBar';
import KPICards from './components/KPICards';
import FilterBar from './components/FilterBar';
import CIRTable from './components/CIRTable';
import ContainerFleetView from './components/ContainerFleetView';
import FleetView from './components/FleetView';
import AnalyticsCharts from './components/AnalyticsCharts';
import OperationsView from './components/OperationsView';
import InvoiceDetailModal from './components/InvoiceDetailModal';
import LoginPage from './components/LoginPage';

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
  render() {
    if (this.state.hasError) {
      return (
        <div className="min-h-screen bg-slate-900 text-white flex items-center justify-center p-6">
          <div className="max-w-md w-full bg-slate-800 p-6 rounded-3xl border border-slate-700 text-center space-y-4">
            <h3 className="text-lg font-bold text-rose-400">Dashboard View Render Warning</h3>
            <p className="text-xs text-slate-300">
              {this.state.error?.message || 'An unexpected rendering state occurred while updating views.'}
            </p>
            <button
              onClick={() => {
                this.setState({ hasError: false, error: null });
                window.location.reload();
              }}
              className="px-4 py-2 bg-[#ff6a00] hover:bg-[#e05d00] text-white rounded-xl text-xs font-bold transition-all shadow-md"
            >
              Reload Dashboard
            </button>
          </div>
        </div>
      );
    }
    return this.props.children;
  }
}

export default function App() {
  // Authentication State
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
    } catch (e) {
      console.error(e);
    }
    setCurrentUser(null);
  };

  // Default Initial Page: Branch Wise Analytics
  const [activeTab, setActiveTab] = useState('analytics');
  const [loading, setLoading] = useState(true);
  const [masters, setMasters] = useState({});
  const [records, setRecords] = useState([]);
  const [kpis, setKpis] = useState({});
  const [selectedRecord, setSelectedRecord] = useState(null);
  const [lastUpdated, setLastUpdated] = useState(null);

  // Global State for Terminal and Financial Year across all tabs
  const [selectedTerminal, setSelectedTerminal] = useState('ALL');
  const [selectedFY, setSelectedFY] = useState('ALL');
  const [allTerminals, setAllTerminals] = useState([]);
  const [terminalFyMatrix, setTerminalFyMatrix] = useState([]);
  const [financialYears, setFinancialYears] = useState([
    'All Financial Years', 
    'FY 2026-27', 
    'FY 2025-26', 
    'FY 2024-25', 
    'FY 2023-24', 
    'FY 2022-23 & Earlier'
  ]);

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

  // Sync selectedTerminal with CIR filters.terminalId
  const handleSetSelectedTerminal = (terminalId) => {
    setSelectedTerminal(terminalId);
    setFilters(prev => ({
      ...prev,
      terminalId: terminalId === 'ALL' ? 'all' : terminalId
    }));
  };

  // Fetch Masters & Analytics Meta for Global Filter Bar
  const fetchInitialData = async () => {
    try {
      // 1. Masters
      const mRes = await fetch('/api/masters').then(r => r.json()).catch(() => ({}));
      if (mRes.success) {
        setMasters(mRes.data || {});
      }

      // 2. Financial Analytics Terminals & FYs
      const fRes = await fetch('/api/financial-analytics').then(r => r.json()).catch(() => ({}));
      if (fRes.success && fRes.data?.branchDetailed) {
        const bd = fRes.data.branchDetailed;
        if (bd.terminals) setAllTerminals(bd.terminals);
        if (bd.financialYears) setFinancialYears(bd.financialYears);
        if (bd.terminalFyMatrix) setTerminalFyMatrix(bd.terminalFyMatrix);
      }
    } catch (e) {
      console.error('Failed to load initial metadata:', e);
    }
  };

  // Fetch Live CIR Report Data
  const fetchCIRData = useCallback(async () => {
    setLoading(true);
    try {
      const queryParams = new URLSearchParams();
      if (filters.companyId && filters.companyId !== 'all' && filters.companyId !== 'ALL') queryParams.append('companyId', filters.companyId);
      if (filters.terminalId && filters.terminalId !== 'all' && filters.terminalId !== 'ALL') queryParams.append('terminalId', filters.terminalId);
      if (filters.customerId && filters.customerId !== 'all' && filters.customerId !== 'ALL') queryParams.append('customerId', filters.customerId);
      if (filters.serviceId && filters.serviceId !== 'all' && filters.serviceId !== 'ALL') queryParams.append('serviceId', filters.serviceId);
      if (filters.tripType && filters.tripType !== 'all' && filters.tripType !== 'ALL') queryParams.append('tripType', filters.tripType);
      if (filters.size && filters.size !== 'all' && filters.size !== 'ALL') queryParams.append('size', filters.size);
      if (selectedFY && selectedFY !== 'ALL' && selectedFY !== 'all') queryParams.append('financialYear', selectedFY);
      if (filters.contNo && filters.contNo.trim() !== '') queryParams.append('contNo', filters.contNo.trim());
      if (filters.blNo && filters.blNo.trim() !== '') queryParams.append('blNo', filters.blNo.trim());
      if (filters.search && filters.search.trim() !== '') queryParams.append('search', filters.search.trim());

      const res = await fetch(`/api/cir-report?${queryParams.toString()}`);
      const json = await res.json();
      if (json.success) {
        setRecords(json.records || []);
        setKpis(json.kpis || {});
        setLastUpdated(new Date().toLocaleTimeString());
      }
    } catch (e) {
      console.error('Error fetching live CIR report:', e);
    } finally {
      setLoading(false);
    }
  }, [filters, selectedFY]);

  useEffect(() => {
    fetchInitialData();
  }, []);

  useEffect(() => {
    const timer = setTimeout(() => {
      fetchCIRData();
    }, 250);
    return () => clearTimeout(timer);
  }, [fetchCIRData]);

  const handleResetFilters = () => {
    setSelectedTerminal('ALL');
    setSelectedFY('ALL');
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

  const handleExportExcel = () => {
    const queryParams = new URLSearchParams();
    if (filters.companyId && filters.companyId !== 'all') queryParams.append('companyId', filters.companyId);
    if (filters.terminalId && filters.terminalId !== 'all') queryParams.append('terminalId', filters.terminalId);
    if (filters.customerId && filters.customerId !== 'all') queryParams.append('customerId', filters.customerId);
    if (filters.serviceId && filters.serviceId !== 'all') queryParams.append('serviceId', filters.serviceId);
    if (filters.tripType && filters.tripType !== 'all') queryParams.append('tripType', filters.tripType);
    if (filters.contNo) queryParams.append('contNo', filters.contNo);
    if (filters.blNo) queryParams.append('blNo', filters.blNo);
    if (filters.search) queryParams.append('search', filters.search);

    window.open(`/api/export/excel?${queryParams.toString()}`, '_blank');
  };

  // Render corporate login screen if not authenticated
  if (!currentUser) {
    return <LoginPage onLoginSuccess={(user) => setCurrentUser(user)} />;
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

      {/* Main Container */}
      <main className="flex-1 max-w-[1700px] w-full mx-auto px-4 sm:px-6 lg:px-8 py-6 space-y-6">
        
        {/* SPJ Global Highlight Banner across all pages */}
        <div className="bg-gradient-to-r from-[#1e1346] via-[#2b1f55] to-[#3a2872] rounded-3xl p-5 text-white shadow-card flex flex-col lg:flex-row items-center justify-between gap-6">
          <div className="flex items-center gap-4">
            <div className="w-12 h-12 rounded-2xl bg-white/10 border border-white/20 flex items-center justify-center shrink-0">
              <Globe2 className="w-6 h-6 text-amber-400" />
            </div>
            <div>
              <div className="flex items-center gap-2">
                <h2 className="font-display font-extrabold text-lg text-white tracking-wide">
                  SPJ Global
                </h2>
              </div>
              <p className="text-xs text-purple-200 mt-0.5">
                Comprehensive Cargo Invoicing & Real-time Yard Movement Analytics
              </p>
            </div>
          </div>

          {/* 4 Stat Badges matching spjcargo.com */}
          <div className="grid grid-cols-2 sm:grid-cols-4 gap-4 w-full lg:w-auto">
            <div className="flex items-center gap-3 px-4 py-2.5 rounded-2xl bg-white/10 border border-white/15">
              <Globe2 className="w-5 h-5 text-blue-300" />
              <div>
                <div className="font-extrabold text-base font-display">120</div>
                <div className="text-[10px] text-purple-200">Countries Served</div>
              </div>
            </div>

            <div className="flex items-center gap-3 px-4 py-2.5 rounded-2xl bg-white/10 border border-white/15">
              <Ship className="w-5 h-5 text-cyan-300" />
              <div>
                <div className="font-extrabold text-base font-display">2,300</div>
                <div className="text-[10px] text-purple-200">Ports Served</div>
              </div>
            </div>

            <div className="flex items-center gap-3 px-4 py-2.5 rounded-2xl bg-white/10 border border-white/15">
              <Truck className="w-5 h-5 text-emerald-300" />
              <div>
                <div className="font-extrabold text-base font-display">3,200</div>
                <div className="text-[10px] text-purple-200">Road Served</div>
              </div>
            </div>

            <div className="flex items-center gap-3 px-4 py-2.5 rounded-2xl bg-white/10 border border-white/15">
              <Users className="w-5 h-5 text-amber-300" />
              <div>
                <div className="font-extrabold text-base font-display">5,000+</div>
                <div className="text-[10px] text-purple-200">Happy Clients</div>
              </div>
            </div>
          </div>
        </div>

        {/* Master Global Filter Bar (Terminal & FY Filter) across ALL pages */}
        <GlobalFilterBar
          selectedTerminal={selectedTerminal}
          setSelectedTerminal={handleSetSelectedTerminal}
          selectedFY={selectedFY}
          setSelectedFY={setSelectedFY}
          terminals={allTerminals.length > 0 ? allTerminals : (masters.terminals || [])}
          financialYears={financialYears}
          terminalFyMatrix={terminalFyMatrix}
          onRefresh={() => {
            fetchCIRData();
            fetchInitialData();
          }}
          loading={loading}
          activeTab={activeTab}
        />

        {/* Tab Content wrapped in ErrorBoundary */}
        <ErrorBoundary>
          {/* Tab 1: Branch Wise Analytics */}
          {activeTab === 'analytics' && (
            <div className="space-y-6">
              <AnalyticsCharts
                selectedTerminal={selectedTerminal}
                setSelectedTerminal={handleSetSelectedTerminal}
                selectedFY={selectedFY}
                setSelectedFY={setSelectedFY}
              />
            </div>
          )}

          {/* Tab 2: Total Sales */}
          {activeTab === 'sales' && (
            <div className="space-y-6">
              <KPICards kpis={kpis} loading={loading} />

              <FilterBar
                filters={filters}
                setFilters={setFilters}
                masters={{
                  ...masters,
                  terminals: allTerminals.length > 0 ? allTerminals : (masters.terminals || [])
                }}
                records={records}
                selectedTerminal={selectedTerminal}
                setSelectedTerminal={handleSetSelectedTerminal}
                selectedFY={selectedFY}
                setSelectedFY={setSelectedFY}
                financialYears={financialYears}
                onReset={handleResetFilters}
                onExport={handleExportExcel}
                loading={loading}
                totalRecords={kpis.totalRecords || records.length}
              />

              <CIRTable
                records={records}
                loading={loading}
                onSelectRecord={setSelectedRecord}
              />
            </div>
          )}

          {/* Tab 3: Container / Volumes */}
          {activeTab === 'containers' && (
            <div className="space-y-6">
              <ContainerFleetView
                selectedTerminal={selectedTerminal}
                setSelectedTerminal={handleSetSelectedTerminal}
                selectedFY={selectedFY}
                setSelectedFY={setSelectedFY}
                terminals={allTerminals.length > 0 ? allTerminals : (masters.terminals || [])}
                financialYears={financialYears}
              />
            </div>
          )}

          {/* Tab 4: Fleet */}
          {activeTab === 'fleet' && (
            <div className="space-y-6">
              <FleetView
                selectedTerminal={selectedTerminal}
                setSelectedTerminal={handleSetSelectedTerminal}
                selectedFY={selectedFY}
                setSelectedFY={setSelectedFY}
                terminals={allTerminals.length > 0 ? allTerminals : (masters.terminals || [])}
                financialYears={financialYears}
              />
            </div>
          )}

          {/* Tab 5: Yard Operations */}
          {activeTab === 'operations' && (
            <div className="space-y-6">
              <OperationsView
                selectedTerminal={selectedTerminal}
                setSelectedTerminal={handleSetSelectedTerminal}
                selectedFY={selectedFY}
                setSelectedFY={setSelectedFY}
                terminals={allTerminals.length > 0 ? allTerminals : (masters.terminals || [])}
                financialYears={financialYears}
              />
            </div>
          )}
        </ErrorBoundary>

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
