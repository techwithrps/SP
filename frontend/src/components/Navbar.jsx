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
    <header className="sticky top-0 z-40 bg-white border-b border-slate-200 shadow-xs">
      {/* Main Navbar */}
      <div className="max-w-[1700px] mx-auto px-2.5 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-14 sm:h-20 gap-2">
          
          {/* Logo */}
          <div className="flex items-center gap-2 shrink-0">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-8 sm:h-12 lg:h-14 w-auto object-contain cursor-pointer" 
              onClick={() => setActiveTab('analytics')}
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />
          </div>

          {/* Navigation Tabs (Smooth horizontal touch scroll on mobile with no ugly scrollbars) */}
          <nav className="flex items-center bg-slate-100/90 p-1 sm:p-1.5 rounded-xl sm:rounded-2xl border border-slate-200 gap-0.5 sm:gap-1 overflow-x-auto no-scrollbar max-w-[60%] sm:max-w-none">
            
            {/* 1. Branch Wise Analytics */}
            <button
              onClick={() => setActiveTab('analytics')}
              className={`flex items-center gap-1.5 sm:gap-2 px-2.5 py-1.5 sm:px-3.5 sm:py-2.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                activeTab === 'analytics'
                  ? 'bg-[#2b1f55] text-white shadow-sm'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <TrendingUp className="w-3.5 h-3.5 sm:w-4 sm:h-4 shrink-0" />
              <span>Branch Wise</span>
              <span className="hidden md:inline">Analytics</span>
            </button>

            {/* 2. Total Sales */}
            <button
              onClick={() => setActiveTab('sales')}
              className={`flex items-center gap-1.5 sm:gap-2 px-2.5 py-1.5 sm:px-3.5 sm:py-2.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                activeTab === 'sales'
                  ? 'bg-[#2b1f55] text-white shadow-sm'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Receipt className="w-3.5 h-3.5 sm:w-4 sm:h-4 shrink-0" />
              <span>Total Sales</span>
            </button>

            {/* 3. Container / Volumes */}
            <button
              onClick={() => setActiveTab('containers')}
              className={`flex items-center gap-1.5 sm:gap-2 px-2.5 py-1.5 sm:px-3.5 sm:py-2.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                activeTab === 'containers'
                  ? 'bg-[#2b1f55] text-white shadow-sm'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Container className="w-3.5 h-3.5 sm:w-4 sm:h-4 shrink-0" />
              <span>Containers</span>
            </button>

            {/* 4. Fleet */}
            <button
              onClick={() => setActiveTab('fleet')}
              className={`flex items-center gap-1.5 sm:gap-2 px-2.5 py-1.5 sm:px-3.5 sm:py-2.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                activeTab === 'fleet'
                  ? 'bg-[#2b1f55] text-white shadow-sm'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Truck className="w-3.5 h-3.5 sm:w-4 sm:h-4 shrink-0" />
              <span>Fleet</span>
            </button>

            {/* 5. Yard Operations */}
            <button
              onClick={() => setActiveTab('operations')}
              className={`flex items-center gap-1.5 sm:gap-2 px-2.5 py-1.5 sm:px-3.5 sm:py-2.5 rounded-lg sm:rounded-xl text-[11px] sm:text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                activeTab === 'operations'
                  ? 'bg-[#2b1f55] text-white shadow-sm'
                  : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
              }`}
            >
              <Layers className="w-3.5 h-3.5 sm:w-4 sm:h-4 shrink-0" />
              <span>Yard Ops</span>
            </button>

          </nav>

          {/* Right Action: Admin User Profile & Sign Out */}
          <div className="flex items-center gap-1.5 sm:gap-3 shrink-0">
            {lastUpdated && (
              <span className="hidden 2xl:inline text-[11px] text-slate-400 font-medium tracking-tight">
                Updated: {lastUpdated}
              </span>
            )}

            {/* Admin User Capsule */}
            {currentUser && (
              <div className="flex items-center bg-slate-50 hover:bg-slate-100/90 transition-all border border-slate-200/90 rounded-xl sm:rounded-2xl p-1 sm:p-1.5 pl-2 sm:pl-3.5 gap-1.5 sm:gap-3 shadow-2xs">
                <div className="hidden sm:flex flex-col text-left">
                  <div className="flex items-center gap-1.5">
                    <span className="text-xs font-extrabold text-slate-900 tracking-tight leading-none">
                      Admin
                    </span>
                    <span className="inline-flex items-center px-1.5 py-0.5 rounded-full text-[9px] font-black bg-purple-100 text-[#2b1f55] border border-purple-200 leading-none">
                      LIVE
                    </span>
                  </div>
                  <span className="text-[10px] text-slate-500 font-semibold mt-0.5 leading-none">
                    System Administrator
                  </span>
                </div>

                <div className="w-7 h-7 sm:w-8 sm:h-8 rounded-lg sm:rounded-xl bg-gradient-to-br from-[#2b1f55] to-[#453084] text-white flex items-center justify-center font-black text-xs shadow-sm shrink-0">
                  <ShieldCheck className="w-3.5 h-3.5 sm:w-4 sm:h-4 text-purple-200" />
                </div>

                <button
                  onClick={onLogout}
                  title="Sign Out"
                  className="p-1 sm:p-1.5 rounded-lg sm:rounded-xl text-slate-400 hover:text-rose-600 hover:bg-rose-50 border border-transparent hover:border-rose-200 transition-all cursor-pointer"
                >
                  <LogOut className="w-3.5 h-3.5 sm:w-4 sm:h-4" />
                </button>
              </div>
            )}
          </div>

        </div>
      </div>
    </header>
  );
}

