import React from 'react';
import { 
  BarChart3,
  TrendingUp, 
  Receipt, 
  Container, 
  Truck, 
  Layers, 
  RefreshCw,
  LogOut,
  User,
  ShieldCheck
} from 'lucide-react';

export default function Navbar({ 
  activeTab, 
  setActiveTab, 
  onRefresh, 
  loading, 
  lastUpdated,
  currentUser,
  onLogout
}) {
  return (
    <header className="sticky top-0 z-40 bg-white border-b border-slate-200 shadow-sm">
      {/* Main Navbar */}
      <div className="max-w-[1700px] mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-20">
          
          {/* Logo */}
          <div className="flex items-center gap-4">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-14 w-auto object-contain cursor-pointer" 
              onClick={() => setActiveTab('analytics')}
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />
          </div>

          {/* Navigation Tabs (Ordered: Branch Wise Analytics -> Total Sales -> Container / Volumes -> Fleet -> Yard Operations) */}
          <nav className="flex items-center bg-slate-100/90 p-1.5 rounded-2xl border border-slate-200 gap-1 overflow-x-auto">
            
            {/* 1. Branch Wise Analytics */}
            <button
              onClick={() => setActiveTab('analytics')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap ${
                activeTab === 'analytics'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <TrendingUp className="w-4 h-4" />
              Branch Wise Analytics
            </button>

            {/* 2. Total Sales */}
            <button
              onClick={() => setActiveTab('sales')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap ${
                activeTab === 'sales'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Receipt className="w-4 h-4" />
              Total Sales
            </button>

            {/* 3. Container / Volumes */}
            <button
              onClick={() => setActiveTab('containers')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap ${
                activeTab === 'containers'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Container className="w-4 h-4" />
              Container / Volumes
            </button>

            {/* 4. Fleet */}
            <button
              onClick={() => setActiveTab('fleet')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap ${
                activeTab === 'fleet'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Truck className="w-4 h-4" />
              Fleet
            </button>

            {/* 5. Yard Operations */}
            <button
              onClick={() => setActiveTab('operations')}
              className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap ${
                activeTab === 'operations'
                  ? 'bg-[#2b1f55] text-white shadow-md'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Layers className="w-4 h-4" />
              Yard Operations
            </button>

          </nav>

          {/* Right Action: User Profile, Refresh & Logout */}
          <div className="flex items-center gap-3">
            {lastUpdated && (
              <span className="hidden 2xl:inline text-[11px] text-slate-400 font-medium">
                Updated: {lastUpdated}
              </span>
            )}

            <button
              onClick={onRefresh}
              disabled={loading}
              title="Refresh Data"
              className="flex items-center gap-1.5 px-3.5 py-2 rounded-xl bg-slate-100 hover:bg-slate-200 border border-slate-200 text-xs font-semibold text-slate-700 transition-all disabled:opacity-50 cursor-pointer"
            >
              <RefreshCw className={`w-3.5 h-3.5 ${loading ? 'animate-spin text-[#2b1f55]' : ''}`} />
              <span className="hidden sm:inline">Refresh</span>
            </button>

            {/* User Profile Pill & Sign Out */}
            {currentUser && (
              <div className="flex items-center gap-2 pl-2 border-l border-slate-200">
                <div className="hidden md:flex flex-col items-end">
                  <span className="text-xs font-bold text-slate-800 leading-tight">
                    {currentUser.name || 'SPJ Officer'}
                  </span>
                  <span className="text-[10px] text-purple-700 font-semibold">
                    {currentUser.role || 'Executive'}
                  </span>
                </div>

                <div className="w-8 h-8 rounded-xl bg-[#2b1f55] text-white flex items-center justify-center font-bold text-xs shadow-sm">
                  {currentUser.name ? currentUser.name.charAt(0).toUpperCase() : 'A'}
                </div>

                <button
                  onClick={onLogout}
                  title="Sign Out"
                  className="p-2 rounded-xl text-slate-500 hover:text-rose-600 hover:bg-rose-50 border border-transparent hover:border-rose-200 transition-all cursor-pointer"
                >
                  <LogOut className="w-4 h-4" />
                </button>
              </div>
            )}
          </div>

        </div>
      </div>
    </header>
  );
}
