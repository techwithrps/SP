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
  X,
  Ship
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

  return (
    <header className="sticky top-0 z-40 bg-white border-b border-slate-200 shadow-xs w-full">
      {/* Main Navbar */}
      <div className="max-w-[1700px] mx-auto px-3 sm:px-6 lg:px-8 w-full">
        <div className="flex items-center justify-between h-14 sm:h-20 gap-2">
          
          {/* Logo */}
          <div className="flex items-center gap-2 shrink-0">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-8 sm:h-12 lg:h-14 w-auto object-contain cursor-pointer" 
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

          {/* 📱 MOBILE: Clean Menu Toggle Button (Screen < lg) */}
          <div className="flex items-center gap-2 lg:hidden">
            {/* Active Tab Name Pill */}
            <div className="hidden xs:flex items-center gap-1.5 px-2.5 py-1 bg-purple-50 text-[#2b1f55] rounded-xl border border-purple-200/80 text-[11px] font-bold">
              <CurrentIcon className="w-3.5 h-3.5 text-[#ff6a00]" />
              <span className="truncate max-w-[100px]">{currentItem.shortLabel}</span>
            </div>

            {/* Hamburger / Close Menu Button */}
            <button
              type="button"
              onClick={(e) => {
                e.stopPropagation();
                setMobileMenuOpen(prev => !prev);
              }}
              className="flex items-center gap-1.5 px-3.5 py-2 bg-[#2b1f55] hover:bg-[#3b2b73] active:bg-[#1f1540] text-white rounded-xl text-xs font-extrabold shadow-sm active:scale-95 transition-all cursor-pointer border border-purple-800/50 select-none"
              title="Open Navigation Menu"
            >
              {mobileMenuOpen ? (
                <>
                  <X className="w-4 h-4 text-amber-400 shrink-0" />
                  <span>Close</span>
                </>
              ) : (
                <>
                  <Menu className="w-4 h-4 text-amber-400 shrink-0" />
                  <span>Menu</span>
                </>
              )}
            </button>
          </div>

          {/* 📱 Mobile Menu Dropdown Modal Drawer (Portaled / Fixed with Backdrop) */}
          {mobileMenuOpen && (
            <div className="fixed inset-0 z-[100] lg:hidden">
              {/* Dimmed Backdrop */}
              <div 
                className="fixed inset-0 bg-slate-950/60 backdrop-blur-xs transition-opacity duration-200"
                onClick={() => setMobileMenuOpen(false)}
              />

              {/* Menu Modal Drawer */}
              <div 
                ref={menuRef}
                onClick={(e) => e.stopPropagation()}
                className="fixed top-16 right-3 left-3 sm:left-auto sm:right-6 sm:w-96 bg-white rounded-3xl shadow-2xl border border-slate-200 p-4 z-[101] animate-scale-in space-y-3.5 max-h-[calc(100vh-80px)] overflow-y-auto"
              >
                
                {/* 1. Admin Profile Header in Menu */}
                {currentUser && (
                  <div className="flex items-center justify-between p-3 bg-gradient-to-r from-slate-900 via-[#1e133d] to-[#2b1f55] rounded-2xl text-white shadow-md">
                    <div className="flex items-center gap-3">
                      <div className="w-10 h-10 rounded-xl bg-white/15 border border-white/20 flex items-center justify-center font-black text-xs text-purple-200 shrink-0">
                        <ShieldCheck className="w-5 h-5 text-amber-400" />
                      </div>
                      <div>
                        <div className="flex items-center gap-2">
                          <span className="text-sm font-extrabold text-white">
                            {currentUser.name || 'Admin'}
                          </span>
                          <span className="text-[9px] font-black bg-emerald-500/20 text-emerald-300 px-2 py-0.5 rounded-full border border-emerald-500/30">
                            LIVE
                          </span>
                        </div>
                        <span className="text-xs text-purple-200 block">
                          {currentUser.role || 'System Administrator'}
                        </span>
                      </div>
                    </div>

                    <button 
                      onClick={() => setMobileMenuOpen(false)}
                      className="p-1.5 rounded-xl bg-white/10 hover:bg-white/20 text-slate-300 hover:text-white transition-colors cursor-pointer"
                    >
                      <X className="w-4 h-4" />
                    </button>
                  </div>
                )}

                {/* 2. Navigation Modules List */}
                <div className="space-y-1.5">
                  <div className="text-[10px] font-bold text-slate-400 uppercase tracking-wider px-2 py-0.5">
                    Select Dashboard Module
                  </div>
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
                        className={`w-full flex items-center justify-between px-3.5 py-3 rounded-2xl text-xs font-bold transition-all cursor-pointer text-left ${
                          isActive 
                            ? 'bg-gradient-to-r from-[#2b1f55] to-[#453084] text-white shadow-md' 
                            : 'text-slate-700 hover:bg-slate-100'
                        }`}
                      >
                        <div className="flex items-center gap-3">
                          <Icon className={`w-4 h-4 ${isActive ? 'text-amber-400' : 'text-slate-400'}`} />
                          <span className="text-xs font-bold">{item.label}</span>
                        </div>
                        {isActive && (
                          <span className="w-2 h-2 rounded-full bg-emerald-400 shadow-sm"></span>
                        )}
                      </button>
                    );
                  })}
                </div>

                {/* 3. Logout / Sign Out Button inside Mobile Menu */}
                {currentUser && (
                  <div className="pt-2 border-t border-slate-100">
                    <button
                      onClick={() => {
                        setMobileMenuOpen(false);
                        if (onLogout) onLogout();
                      }}
                      className="w-full flex items-center justify-center gap-2 px-4 py-3 rounded-2xl text-xs font-extrabold bg-rose-50 hover:bg-rose-100 text-rose-700 border border-rose-200 active:scale-[0.99] transition-all cursor-pointer shadow-xs"
                    >
                      <LogOut className="w-4 h-4 text-rose-600" />
                      <span>Sign Out from Dashboard</span>
                    </button>
                  </div>
                )}

              </div>
            </div>
          )}

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

          {/* 💻 DESKTOP Right Action: Admin User Profile & Sign Out (Screen >= lg) */}
          <div className="hidden lg:flex items-center gap-3 shrink-0">
            {lastUpdated && (
              <span className="hidden 2xl:inline text-[11px] text-slate-400 font-medium tracking-tight">
                Updated: {lastUpdated}
              </span>
            )}

            {/* Admin User Capsule */}
            {currentUser && (
              <div className="flex items-center bg-slate-50 hover:bg-slate-100/90 transition-all border border-slate-200 rounded-2xl p-1.5 pl-3.5 gap-3 shadow-2xs shrink-0">
                <div className="flex flex-col text-left">
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

                <div className="w-8 h-8 rounded-xl bg-gradient-to-br from-[#2b1f55] to-[#453084] text-white flex items-center justify-center font-black text-xs shadow-sm shrink-0">
                  <ShieldCheck className="w-4 h-4 text-purple-200" />
                </div>

                <button
                  onClick={onLogout}
                  title="Sign Out"
                  className="p-1.5 rounded-xl text-slate-400 hover:text-rose-600 hover:bg-rose-50 border border-transparent hover:border-rose-200 transition-all cursor-pointer"
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


