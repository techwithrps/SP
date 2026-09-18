import React from 'react';
import { 
  FileSpreadsheet, 
  TrendingUp, 
  Truck, 
  Container,
  RefreshCw,
  Phone,
  Mail
} from 'lucide-react';

export default function Navbar({ 
  activeTab, 
  setActiveTab, 
  onRefresh, 
  loading,
  lastUpdated 
}) {
  return (
    <header className="sticky top-0 z-40 bg-white border-b border-slate-200 shadow-sm">
      
      {/* Top eLOGISOL Contact Bar */}
      <div className="bg-[#2b1f55] text-white text-[11px] py-1.5 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[1700px] mx-auto flex flex-wrap items-center justify-between gap-2">
          
          <div className="flex items-center gap-4 text-purple-200">
            <div className="flex items-center gap-1.5 font-medium">
              <Phone className="w-3 h-3 text-amber-400" />
              <span>+91-9810296622</span>
              <span className="text-purple-400">•</span>
              <span>011-49061530</span>
            </div>
            <div className="hidden md:flex items-center gap-1.5">
              <Mail className="w-3 h-3 text-amber-400" />
              <span>support@elogisol.in</span>
            </div>
          </div>

          <div className="hidden lg:flex items-center gap-3 text-purple-200 text-[11px]">
            <span className="font-semibold text-white">Group Divisions:</span>
            <span>SPJ Cargo</span> • 
            <span>SPJ Cold Storage</span> • 
            <span>S.J. Cargo Movers</span> • 
            <span>Puran Joshi Custom's Broker</span>
          </div>

        </div>
      </div>

      {/* Main Navbar */}
      <div className="max-w-[1700px] mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-20">
          
          {/* Logos */}
          <div className="flex items-center gap-4">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-14 w-auto object-contain"
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />

            <div className="h-9 w-px bg-slate-200 hidden sm:block" />

            <div className="hidden sm:flex items-center gap-2.5">
              <img 
                src="/elogisol-logo.png" 
                alt="Team eLogisol" 
                className="h-9 w-auto object-contain"
                onError={(e) => {
                  e.target.onerror = null;
                  e.target.style.display = 'none';
                }}
              />
              <div className="leading-tight">
                <h1 className="text-xs font-black uppercase tracking-wider text-[#2b1f55]">
                  Intelligence & CIR Portal
                </h1>
                <p className="text-[10px] text-slate-500 font-medium">
                  Terminal & Container Inventory (SP_CIR_NEW)
                </p>
              </div>
            </div>
          </div>

          {/* Navigation Tabs */}
          <nav className="flex items-center bg-slate-100/90 p-1.5 rounded-2xl border border-slate-200 gap-1">
            <button
              onClick={() => setActiveTab('cir')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 ${
                activeTab === 'cir'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <FileSpreadsheet className="w-4 h-4" />
              CIR Invoices
            </button>

            <button
              onClick={() => setActiveTab('containers')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 ${
                activeTab === 'containers'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Container className="w-4 h-4" />
              Containers & Fleet (387)
            </button>

            <button
              onClick={() => setActiveTab('analytics')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 ${
                activeTab === 'analytics'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <TrendingUp className="w-4 h-4" />
              Terminal & Financial Analytics
            </button>

            <button
              onClick={() => setActiveTab('operations')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 ${
                activeTab === 'operations'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Truck className="w-4 h-4" />
              Yard Operations
            </button>
          </nav>

          {/* Right Action & Refresh */}
          <div className="flex items-center gap-3">
            {lastUpdated && (
              <span className="hidden xl:inline text-[11px] text-slate-500 font-medium">
                Updated: {lastUpdated}
              </span>
            )}

            <button
              onClick={onRefresh}
              disabled={loading}
              title="Refresh Data"
              className="flex items-center gap-1.5 px-3.5 py-2 rounded-xl bg-slate-100 hover:bg-slate-200 border border-slate-200 text-xs font-semibold text-slate-700 transition-all disabled:opacity-50"
            >
              <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
              <span className="hidden sm:inline">Refresh</span>
            </button>
          </div>

        </div>
      </div>
    </header>
  );
}
