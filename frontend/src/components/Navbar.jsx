import React, { useState, useRef, useEffect } from 'react';
import { 
  BarChart3,
  TrendingUp, 
  Receipt, 
  Container, 
  Truck, 
  Layers, 
  LogOut, 
  User, 
  ShieldCheck,
  ChevronDown,
  Menu,
  X
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
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
  const menuRef = useRef(null);

  const navItems = [
    { id: 'analytics', label: 'Branch Wise Analytics', shortLabel: 'Branch Wise', icon: TrendingUp },
    { id: 'sales', label: 'Total Sales', shortLabel: 'Total Sales', icon: Receipt },
    { id: 'containers', label: 'Container / Volumes', shortLabel: 'Containers', icon: Container },
    { id: 'fleet', label: 'Fleet Operations', shortLabel: 'Fleet', icon: Truck },
    { id: 'operations', label: 'Yard Operations', shortLabel: 'Yard Ops', icon: Layers },
  ];

  const currentItem = navItems.find(item => item.id === activeTab) || navItems[0];
  const CurrentIcon = currentItem.icon;

  // Close menu on outside click
  useEffect(() => {
    function handleClickOutside(event) {
      if (menuRef.current && !menuRef.current.contains(event.target)) {
        setMobileMenuOpen(false);
      }
    }
    if (mobileMenuOpen) {
      document.addEventListener('mousedown', handleClickOutside);
      document.addEventListener('touchstart', handleClickOutside);
    }
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
      document.removeEventListener('touchstart', handleClickOutside);
    };
  }, [mobileMenuOpen]);

  return (
    <header className="sticky top-0 z-40 bg-white border-b border-slate-200 shadow-xs w-full max-w-full overflow-hidden">
      {/* Main Navbar */}
      <div className="max-w-[1700px] mx-auto px-2 sm:px-6 lg:px-8 w-full">
        <div className="flex items-center justify-between h-13 sm:h-20 gap-1.5 sm:gap-2">
          
          {/* Logo */}
          <div className="flex items-center gap-1.5 shrink-0">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-7 sm:h-11 lg:h-14 max-w-[95px] sm:max-w-[140px] md:max-w-none w-auto object-contain cursor-pointer" 
              onClick={() => {
                setActiveTab('analytics');
                setMobileMenuOpen(false);
              }}
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />
          </div>

          {/* 📱 MOBILE: Menu Dropdown Selector Button (Screen < lg) */}
          <div className="relative lg:hidden shrink-0" ref={menuRef}>
            <button
              onClick={() => setMobileMenuOpen(prev => !prev)}
              className="flex items-center gap-1 px-2.5 py-1.5 bg-[#2b1f55] text-white rounded-xl text-[11px] font-extrabold shadow-sm active:scale-95 transition-all cursor-pointer border border-purple-800/40"
            >
              <CurrentIcon className="w-3.5 h-3.5 text-amber-400 shrink-0" />
              <span className="truncate max-w-[88px] xs:max-w-[110px] sm:max-w-[160px]">{currentItem.shortLabel}</span>
              <ChevronDown className={`w-3 h-3 transition-transform duration-200 shrink-0 ${mobileMenuOpen ? 'rotate-180' : ''}`} />
            </button>

            {/* Mobile Dropdown Menu Card */}
            {mobileMenuOpen && (
              <div className="absolute right-0 sm:left-1/2 sm:-translate-x-1/2 mt-2 w-64 max-w-[calc(100vw-24px)] bg-white rounded-2xl shadow-2xl border border-slate-200 p-2 z-50 animate-scale-in">
                <div className="text-[10px] font-bold text-slate-400 uppercase tracking-wider px-3 py-1.5 border-b border-slate-100">
                  Select Dashboard Module
                </div>
                <div className="space-y-1 mt-1">
                  {navItems.map((item) => {
                    const Icon = item.icon;
                    const isActive = activeTab === item.id;
                    return (
                      <button
                        key={item.id}
                        onClick={() => {
                          setActiveTab(item.id);
                          setMobileMenuOpen(false);
                        }}
                        className={`w-full flex items-center justify-between px-3 py-2 rounded-xl text-xs font-bold transition-all cursor-pointer text-left ${
                          isActive 
                            ? 'bg-gradient-to-r from-[#2b1f55] to-[#453084] text-white shadow-sm' 
                            : 'text-slate-700 hover:bg-slate-100'
                        }`}
                      >
                        <div className="flex items-center gap-2.5">
                          <Icon className={`w-4 h-4 ${isActive ? 'text-amber-400' : 'text-slate-400'}`} />
                          <span>{item.label}</span>
                        </div>
                        {isActive && (
                          <span className="w-1.5 h-1.5 rounded-full bg-emerald-400 shadow-sm"></span>
                        )}
                      </button>
                    );
                  })}
                </div>
              </div>
            )}
          </div>

          {/* 💻 DESKTOP: Navigation Tabs (Screen >= lg) */}
          <nav className="hidden lg:flex items-center bg-slate-100/90 p-1.5 rounded-2xl border border-slate-200 gap-1">
            {navItems.map((item) => {
              const Icon = item.icon;
              const isActive = activeTab === item.id;
              return (
                <button
                  key={item.id}
                  onClick={() => setActiveTab(item.id)}
                  className={`flex items-center gap-2 px-3.5 py-2.5 rounded-xl text-xs font-bold transition-all duration-200 whitespace-nowrap cursor-pointer ${
                    isActive
                      ? 'bg-[#2b1f55] text-white shadow-md'
                      : 'text-slate-600 hover:text-[#2b1f55] hover:bg-white'
                  }`}
                >
                  <Icon className="w-4 h-4" />
                  <span>{item.label}</span>
                </button>
              );
            })}
          </nav>

          {/* Right Action: Admin User Profile & Sign Out */}
          <div className="flex items-center gap-1 sm:gap-3 shrink-0">
            {lastUpdated && (
              <span className="hidden 2xl:inline text-[11px] text-slate-400 font-medium tracking-tight">
                Updated: {lastUpdated}
              </span>
            )}

            {/* Admin User Capsule */}
            {currentUser && (
              <div className="flex items-center bg-slate-50 hover:bg-slate-100/90 transition-all border border-slate-200 rounded-xl sm:rounded-2xl p-0.5 sm:p-1.5 pl-1.5 sm:pl-3.5 gap-1 sm:gap-3 shadow-2xs shrink-0">
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

                <div className="w-6 h-6 sm:w-8 sm:h-8 rounded-lg sm:rounded-xl bg-gradient-to-br from-[#2b1f55] to-[#453084] text-white flex items-center justify-center font-black text-xs shadow-sm shrink-0">
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


