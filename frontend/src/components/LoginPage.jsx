import React, { useState } from 'react';
import { 
  Lock, 
  User, 
  Eye, 
  EyeOff, 
  ShieldCheck, 
  Globe2, 
  Ship, 
  Truck, 
  Container,
  ArrowRight, 
  CheckCircle2, 
  AlertCircle,
  KeyRound,
  TrendingUp,
  BarChart3,
  Layers
} from 'lucide-react';

// Master Administrator Account
export const MASTER_USER = {
  id: 'admin',
  altId: 'admin@spjcargo.com',
  username: 'admin',
  password: 'admin',
  altPassword: 'SPJ@Cargo2026',
  name: 'Admin',
  role: 'System Administrator',
  badge: 'Master Admin'
};

export default function LoginPage({ onLoginSuccess }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [rememberMe, setRememberMe] = useState(true);
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleLogin = (e) => {
    if (e) e.preventDefault();
    setError('');

    const cleanUser = username.trim().toLowerCase();
    const cleanPass = password.trim();

    if (!cleanUser || !cleanPass) {
      setError('Please enter both User ID and Password.');
      return;
    }

    setLoading(true);

    setTimeout(() => {
      const isUserMatch = (
        cleanUser === MASTER_USER.username.toLowerCase() ||
        cleanUser === MASTER_USER.id.toLowerCase() ||
        cleanUser === MASTER_USER.altId.toLowerCase()
      );
      const isPassMatch = (
        cleanPass === MASTER_USER.password ||
        cleanPass === MASTER_USER.altPassword
      );

      if (isUserMatch && isPassMatch) {
        if (rememberMe) {
          localStorage.setItem('spj_auth_user', JSON.stringify({
            id: 'admin',
            name: 'Admin',
            role: 'System Administrator',
            badge: 'Master Admin',
            loginTime: new Date().toISOString()
          }));
        }
        setLoading(false);
        onLoginSuccess(MASTER_USER);
      } else {
        setLoading(false);
        setError('Invalid credentials. Please enter valid Admin details.');
      }
    }, 300);
  };

  return (
    <div className="min-h-screen w-full max-w-full overflow-x-hidden flex flex-col lg:flex-row bg-slate-950 font-sans selection:bg-[#ff6a00] selection:text-white">
      
      {/* Left Hero Brand Panel */}
      <div className="relative lg:w-[58%] xl:w-[62%] min-h-[180px] sm:min-h-[260px] lg:min-h-screen bg-slate-950 flex flex-col justify-between p-3.5 sm:p-8 lg:p-14 overflow-hidden">
        
        {/* Background Port Image with Smooth Rich Gradient */}
        <div 
          className="absolute inset-0 bg-cover bg-center bg-no-repeat transition-transform duration-1000 scale-105"
          style={{ backgroundImage: "url('/login-bg.jpg')" }}
        >
          <div className="absolute inset-0 bg-gradient-to-t lg:bg-gradient-to-r from-slate-950 via-slate-950/80 to-[#2b1f55]/60"></div>
        </div>

        {/* Ambient Subtle Glow */}
        <div className="absolute top-1/4 left-1/4 w-96 h-96 bg-[#ff6a00]/15 rounded-full blur-[140px] pointer-events-none"></div>

        {/* Top Header on Left Panel */}
        <div className="relative z-10 flex items-center justify-between gap-2">
          <div className="bg-white/95 backdrop-blur-md px-2.5 py-1 sm:px-4 sm:py-2 rounded-xl sm:rounded-2xl shadow-lg flex items-center shrink-0">
            <img 
              src="/logo.png" 
              alt="SPJ Group of Companies" 
              className="h-6 sm:h-9 lg:h-11 max-w-[100px] sm:max-w-none w-auto object-contain" 
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />
          </div>

          <div className="flex items-center gap-1 sm:gap-2 shrink-0">
            <span className="inline-flex items-center gap-1 px-1.5 py-0.5 sm:px-3 sm:py-1 rounded-full bg-white/10 backdrop-blur-md border border-white/20 text-[8px] sm:text-xs font-semibold text-purple-200">
              <ShieldCheck className="w-2.5 h-2.5 sm:w-3.5 sm:h-3.5 text-emerald-400" />
              256-Bit SSL
            </span>
            <span className="inline-flex items-center gap-1 px-1.5 py-0.5 sm:px-3 sm:py-1 rounded-full bg-emerald-500/20 border border-emerald-500/40 text-emerald-300 text-[8px] sm:text-xs font-bold">
              <span className="w-1.5 h-1.5 rounded-full bg-emerald-400 animate-pulse"></span>
              LIVE
            </span>
          </div>
        </div>

        {/* Middle Value Proposition Hero Content */}
        <div className="relative z-10 max-w-xl my-auto py-2.5 sm:py-8 space-y-2 sm:space-y-5">
          <div className="inline-flex items-center gap-1.5 px-2.5 py-0.5 sm:px-3 sm:py-1 rounded-lg sm:rounded-xl bg-orange-500/20 border border-orange-500/30 text-[#ff8a3d] text-[10px] sm:text-[11px] font-black tracking-wide uppercase">
            <TrendingUp className="w-3 h-3 sm:w-3.5 sm:h-3.5" />
            Intelligence & Revenue Dashboard
          </div>

          <h1 className="text-xl sm:text-3xl lg:text-5xl font-black font-display text-white tracking-tight leading-[1.15]">
            Global Logistics & Real-time Yard Movement
          </h1>

          <p className="text-[11px] sm:text-sm lg:text-base text-slate-300 font-normal leading-relaxed line-clamp-2 sm:line-clamp-none">
            Live multimodal container operations, freight invoicing analytics, and fleet intelligence across 39 terminals nationwide.
          </p>

          {/* Quick Metrics Grid */}
          <div className="grid grid-cols-3 gap-1.5 sm:gap-3 pt-1 sm:pt-3">
            <div className="p-2 sm:p-3.5 rounded-xl sm:rounded-2xl bg-white/10 backdrop-blur-md border border-white/10">
              <div className="text-sm sm:text-2xl font-black text-white font-display">89,249</div>
              <div className="text-[8px] sm:text-[11px] font-medium text-slate-300">Active Units</div>
            </div>

            <div className="p-2 sm:p-3.5 rounded-xl sm:rounded-2xl bg-white/10 backdrop-blur-md border border-white/10">
              <div className="text-sm sm:text-2xl font-black text-white font-display">₹ 7,423 Cr</div>
              <div className="text-[8px] sm:text-[11px] font-medium text-slate-300">Sales Tracked</div>
            </div>

            <div className="p-2 sm:p-3.5 rounded-xl sm:rounded-2xl bg-white/10 backdrop-blur-md border border-white/10">
              <div className="text-sm sm:text-2xl font-black text-white font-display">39</div>
              <div className="text-[8px] sm:text-[11px] font-medium text-slate-300">Terminals</div>
            </div>
          </div>
        </div>

        {/* Footer Left */}
        <div className="relative z-10 text-[10px] sm:text-xs text-slate-400 pt-2 sm:pt-3 border-t border-white/10 hidden sm:flex items-center justify-between">
          <span>© {new Date().getFullYear()} SPJ Group of Companies</span>
          <span className="text-slate-500">Enterprise Edition v2.4</span>
        </div>

      </div>

      {/* Right Login Form Panel */}
      <div className="lg:w-[42%] xl:w-[38%] bg-white flex flex-col justify-between p-4 sm:p-8 lg:p-14 rounded-t-2xl sm:rounded-t-3xl lg:rounded-none -mt-3 sm:-mt-6 lg:mt-0 relative z-20 shadow-2xl">
        
        {/* Top Spacer */}
        <div className="hidden lg:block"></div>

        {/* Form Container */}
        <div className="w-full max-w-sm mx-auto space-y-4 sm:space-y-7 my-auto py-2 sm:py-6">
          
          <div className="space-y-0.5 sm:space-y-1.5 text-center lg:text-left">
            <h2 className="text-xl sm:text-3xl font-black font-display text-slate-900 tracking-tight">
              Admin Portal
            </h2>
            <p className="text-[11px] sm:text-sm text-slate-500 font-medium">
              Enter your administrative credentials to continue
            </p>
          </div>

          {/* Error Message */}
          {error && (
            <div className="p-3 sm:p-4 rounded-xl sm:rounded-2xl bg-rose-50 border border-rose-200 flex items-start gap-2.5 text-xs text-rose-700 animate-shake">
              <AlertCircle className="w-4 h-4 text-rose-600 shrink-0 mt-0.5" />
              <span className="font-semibold">{error}</span>
            </div>
          )}

          {/* Form */}
          <form onSubmit={handleLogin} className="space-y-3.5 sm:space-y-5">
            
            {/* User ID */}
            <div className="space-y-1">
              <label className="text-[11px] sm:text-xs font-bold text-slate-700 uppercase tracking-wider flex items-center gap-1.5">
                <User className="w-3.5 h-3.5 text-[#2b1f55]" />
                User ID
              </label>
              <input
                type="text"
                value={username}
                onChange={(e) => {
                  setUsername(e.target.value);
                  setError('');
                }}
                placeholder="Enter User ID"
                className="w-full h-10 sm:h-12 px-3 sm:px-4 bg-slate-50 hover:bg-slate-100/80 focus:bg-white border-2 border-slate-200 focus:border-[#ff6a00] rounded-xl sm:rounded-2xl text-xs sm:text-sm font-semibold text-slate-900 placeholder-slate-400 focus:outline-none focus:ring-4 focus:ring-[#ff6a00]/15 transition-all"
                required
              />
            </div>

            {/* Password */}
            <div className="space-y-1">
              <label className="text-[11px] sm:text-xs font-bold text-slate-700 uppercase tracking-wider flex items-center gap-1.5">
                <KeyRound className="w-3.5 h-3.5 text-[#2b1f55]" />
                Password
              </label>
              <div className="relative">
                <input
                  type={showPassword ? 'text' : 'password'}
                  value={password}
                  onChange={(e) => {
                    setPassword(e.target.value);
                    setError('');
                  }}
                  placeholder="Enter Password"
                  className="w-full h-10 sm:h-12 pl-3 sm:pl-4 pr-10 sm:pr-11 bg-slate-50 hover:bg-slate-100/80 focus:bg-white border-2 border-slate-200 focus:border-[#ff6a00] rounded-xl sm:rounded-2xl text-xs sm:text-sm font-semibold text-slate-900 placeholder-slate-400 focus:outline-none focus:ring-4 focus:ring-[#ff6a00]/15 transition-all"
                  required
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-3 top-1/2 -translate-y-1/2 text-slate-400 hover:text-slate-700 transition-colors cursor-pointer"
                >
                  {showPassword ? <EyeOff className="w-4 h-4" /> : <Eye className="w-4 h-4" />}
                </button>
              </div>
            </div>

            {/* Remember Me & Protection Badge */}
            <div className="flex items-center justify-between pt-0.5">
              <label className="flex items-center gap-2 cursor-pointer text-[11px] sm:text-xs font-semibold text-slate-600 hover:text-slate-900 select-none">
                <input
                  type="checkbox"
                  checked={rememberMe}
                  onChange={(e) => setRememberMe(e.target.checked)}
                  className="w-3.5 h-3.5 sm:w-4 sm:h-4 rounded border-slate-300 text-[#ff6a00] focus:ring-[#ff6a00] cursor-pointer"
                />
                <span>Remember session</span>
              </label>

              <span className="text-[10px] sm:text-[11px] font-bold text-purple-800 bg-purple-50 px-2 py-0.5 sm:px-2.5 sm:py-1 rounded-lg border border-purple-200 flex items-center gap-1">
                <ShieldCheck className="w-3 h-3 sm:w-3.5 sm:h-3.5 text-purple-700" />
                Protected
              </span>
            </div>

            {/* Submit Button */}
            <button
              type="submit"
              disabled={loading}
              className="w-full h-10 sm:h-12 bg-gradient-to-r from-[#2b1f55] to-[#ff6a00] hover:opacity-95 text-white font-black text-xs sm:text-sm rounded-xl sm:rounded-2xl shadow-lg shadow-purple-950/20 flex items-center justify-center gap-2 transition-all duration-200 cursor-pointer disabled:opacity-50 hover-lift active:scale-[0.98]"
            >
              {loading ? (
                <div className="w-4 h-4 sm:w-5 sm:h-5 border-2 border-white/40 border-t-white rounded-full animate-spin"></div>
              ) : (
                <>
                  <span>Sign In to Dashboard</span>
                  <ArrowRight className="w-3.5 h-3.5 sm:w-4 sm:h-4" />
                </>
              )}
            </button>

          </form>

        </div>

        {/* Bottom Note */}
        <div className="text-center text-[10px] sm:text-xs text-slate-400 font-medium pt-2">
          Authorized personnel only • SPJ Live Enterprise Cloud
        </div>

      </div>

    </div>
  );
}

