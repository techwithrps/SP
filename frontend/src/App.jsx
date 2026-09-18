import React, { useState, useEffect, useCallback } from 'react';
import Navbar from './components/Navbar';
import KPICards from './components/KPICards';
import FilterBar from './components/FilterBar';
import CIRTable from './components/CIRTable';
import ContainerFleetView from './components/ContainerFleetView';
import AnalyticsCharts from './components/AnalyticsCharts';
import OperationsView from './components/OperationsView';
import InvoiceDetailModal from './components/InvoiceDetailModal';

export default function App() {
  const [activeTab, setActiveTab] = useState('cir');
  const [loading, setLoading] = useState(true);
  const [masters, setMasters] = useState({});
  const [records, setRecords] = useState([]);
  const [kpis, setKpis] = useState({});
  const [selectedRecord, setSelectedRecord] = useState(null);
  const [lastUpdated, setLastUpdated] = useState(null);

  // Filters matching SP_CIR_NEW parameters
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

  // Fetch Masters (Dropdowns)
  const fetchMasters = async () => {
    try {
      const res = await fetch('/api/masters');
      const json = await res.json();
      if (json.success) {
        setMasters(json.data || {});
      }
    } catch (e) {
      console.error('Failed to load masters:', e);
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
    fetchMasters();
  }, []);

  useEffect(() => {
    const timer = setTimeout(() => {
      fetchCIRData();
    }, 250);
    return () => clearTimeout(timer);
  }, [fetchCIRData]);

  const handleResetFilters = () => {
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
        onRefresh={fetchCIRData}
        loading={loading}
        lastUpdated={lastUpdated}
      />

      {/* Main Container */}
      <main className="flex-1 max-w-[1700px] w-full mx-auto px-4 sm:px-6 lg:px-8 py-6 space-y-6">
        
        {/* Top KPI Cards & SPJ Stat Highlights Bar */}
        <KPICards kpis={kpis} loading={loading} />

        {/* Tab 1: CIR Revenue & Invoices */}
        {activeTab === 'cir' && (
          <div className="space-y-6">
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

        {/* Tab 2: Containers & Fleet Tracking (387 Units) */}
        {activeTab === 'containers' && (
          <div className="space-y-6">
            <ContainerFleetView />
          </div>
        )}

        {/* Tab 3: Financial & Terminal Analytics */}
        {activeTab === 'analytics' && (
          <div className="space-y-6">
            <AnalyticsCharts kpis={kpis} loading={loading} />
          </div>
        )}

        {/* Tab 4: Yard & Gate Operations */}
        {activeTab === 'operations' && (
          <div className="space-y-6">
            <OperationsView />
          </div>
        )}

      </main>

      {/* Footer */}
      <footer className="border-t border-slate-200 py-6 bg-white text-center text-xs text-slate-500 mt-12">
        <div className="max-w-[1700px] mx-auto px-4 flex flex-col sm:flex-row items-center justify-between gap-3">
          <div className="flex items-center gap-3">
            <img src="/elogisol-logo.png" alt="Team eLogisol" className="h-6 w-auto object-contain" />
            <img src="/logo.png" alt="SPJ Logo" className="h-6 w-auto object-contain" />
            <span>© {new Date().getFullYear()} <strong>TEAM ELOGISOL PVT. LTD.</strong> & <strong>SPJ Cargo</strong> — All Rights Reserved.</span>
          </div>
          <div className="flex items-center gap-4 text-xs font-semibold text-slate-600">
            <span>E-6, Third Floor, Kalkaji, New Delhi-110019</span>
            <span>Support: support@elogisol.in</span>
            <span className="text-emerald-700 font-bold">● Active Operational Portal</span>
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
