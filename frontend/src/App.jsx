import React, { useState, useEffect, useCallback } from 'react';
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

export default function App() {
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
      if (filters.companyId && filters.companyId !== 'all') queryParams.append('companyId', filters.companyId);
      if (filters.terminalId && filters.terminalId !== 'all') queryParams.append('terminalId', filters.terminalId);
      if (filters.customerId && filters.customerId !== 'all') queryParams.append('customerId', filters.customerId);
      if (filters.serviceId && filters.serviceId !== 'all') queryParams.append('serviceId', filters.serviceId);
      if (filters.tripType && filters.tripType !== 'all') queryParams.append('tripType', filters.tripType);
      if (filters.contNo) queryParams.append('contNo', filters.contNo);
      if (filters.blNo) queryParams.append('blNo', filters.blNo);
      if (filters.search) queryParams.append('search', filters.search);

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
  }, [filters]);

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
      />

      {/* Main Container */}
      <main className="flex-1 max-w-[1700px] w-full mx-auto px-4 sm:px-6 lg:px-8 py-6 space-y-6">
        
        {/* Persistent Global Filter Bar across ALL pages/tabs */}
        <GlobalFilterBar
          selectedTerminal={selectedTerminal}
          setSelectedTerminal={handleSetSelectedTerminal}
          selectedFY={selectedFY}
          setSelectedFY={setSelectedFY}
          terminals={allTerminals.length > 0 ? allTerminals : (masters.terminals || [])}
          financialYears={financialYears}
          onRefresh={() => {
            fetchCIRData();
            fetchInitialData();
          }}
          loading={loading}
          activeTab={activeTab}
        />

        {/* Tab 1: Branch Wise Analytics (Initial Default Page) */}
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
            {/* Top KPI Cards & SPJ Stat Highlights Bar */}
            <KPICards kpis={kpis} loading={loading} />

            <FilterBar
              filters={filters}
              setFilters={setFilters}
              masters={masters}
              onReset={handleResetFilters}
              onExport={handleExportExcel}
              loading={loading}
              totalRecords={records.length}
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
              selectedFY={selectedFY}
            />
          </div>
        )}

        {/* Tab 4: Fleet */}
        {activeTab === 'fleet' && (
          <div className="space-y-6">
            <FleetView
              selectedTerminal={selectedTerminal}
              selectedFY={selectedFY}
            />
          </div>
        )}

        {/* Tab 5: Yard Operations */}
        {activeTab === 'operations' && (
          <div className="space-y-6">
            <OperationsView
              selectedTerminal={selectedTerminal}
              selectedFY={selectedFY}
            />
          </div>
        )}

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
