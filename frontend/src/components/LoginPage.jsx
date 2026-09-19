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
  Zap
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
  const [username, setUsername] = useState('admin');
  const [password, setPassword] = useState('admin');
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
        setError('Invalid credentials. Please use admin / admin.');
      }
    }, 300);
  };

  const handleOneClickFill = () => {
    setUsername('admin');
    setPassword('admin');
    setError('');
  };

  return (
    <div className="min-h-screen relative flex flex-col justify-between overflow-hidden font-sans selection:bg-[#ff6a00] selection:text-white bg-slate-900">
      
      {/* Background Image with Clean Cinematic Dark Overlay */}
      <div 
        className="absolute inset-0 bg-cover bg-center bg-no-repeat"
        style={{ backgroundImage: "url('/login-bg.jpg')" }}
      >
        <div className="absolute inset-0 bg-slate-950/60 backdrop-blur-[1px]"></div>
      </div>

      {/* Top Header */}
      <header className="px-6 sm:px-12 py-5 flex items-center justify-between relative z-10 animate-fade-in">
        <div className="flex items-center gap-3">
          <div className="bg-white px-4 py-2 rounded-2xl shadow-xl border border-slate-200 hover-lift flex items-center">
            <img 
              src="/logo.png" 
              alt="SPJ Cargo" 
              className="h-10 sm:h-11 w-auto object-contain cursor-pointer" 
              onError={(e) => {
                e.target.onerror = null;
                e.target.style.display = 'none';
              }}
            />
          </div>
        </div>

        <div className="flex items-center gap-3">
          <div className="hidden sm:flex items-center gap-2 px-4 py-2 rounded-2xl bg-white/95 border border-slate-200 text-xs font-bold text-slate-800 shadow-md">
            <ShieldCheck className="w-4 h-4 text-emerald-600" />
            <span>256-Bit SSL Protected</span>
          </div>
          
          <div className="flex items-center gap-1.5 px-3 py-1.5 rounded-xl bg-emerald-600 text-white text-xs font-black shadow-md">
            <span className="w-2 h-2 rounded-full bg-white animate-pulse"></span>
            ORACLE LIVE
          </div>
        </div>
      </header>

      {/* Center Auth Card: High-Contrast Solid White Luxury Card */}
      <main className="flex-1 flex items-center justify-center px-4 sm:px-6 py-6 relative z-10">
        <div className="w-full max-w-[430px] bg-white rounded-3xl p-8 sm:p-9 shadow-2xl shadow-black/60 border border-slate-100 space-y-6 animate-scale-in">
          
          {/* Card Header */}
          <div className="text-center space-y-2">
            <div className="inline-flex items-center justify-center w-16 h-16 rounded-2xl bg-orange-50 border border-orange-200 shadow-sm mb-1">
              <Lock className="w-8 h-8 text-[#ff6a00]" />
            </div>
            
            <h1 className="text-2xl sm:text-3xl font-black font-display tracking-tight text-slate-900">
              Admin Portal
            </h1>
            <p className="text-xs font-semibold text-slate-500">
              SPJ Cargo Operations & Revenue Intelligence ERP
            </p>
          </div>

          {/* Error Alert */}
          {error && (
            <div className="p-3.5 rounded-2xl bg-rose-50 border border-rose-200 flex items-start gap-2.5 text-xs text-rose-700 animate-shake">
              <AlertCircle className="w-4 h-4 text-rose-600 shrink-0 mt-0.5" />
              <span className="font-bold">{error}</span>
            </div>
          )}

          {/* Form */}
          <form onSubmit={handleLogin} className="space-y-4">
            
            {/* User ID Input */}
            <div className="space-y-1.5">
              <label className="text-[11px] font-extrabold text-slate-700 uppercase tracking-wider flex items-center gap-1.5">
                <User className="w-3.5 h-3.5 text-[#ff6a00]" />
                User ID
              </label>
              <div className="relative">
                <input
                  type="text"
                  value={username}
                  onChange={(e) => {
                    setUsername(e.target.value);
                    setError('');
                  }}
                  placeholder="admin"
                  className="w-full h-12 pl-4 pr-10 bg-slate-50 hover:bg-slate-100/70 focus:bg-white border-2 border-slate-200 focus:border-[#ff6a00] rounded-2xl text-sm font-bold text-slate-900 placeholder-slate-400 focus:outline-none focus:ring-4 focus:ring-[#ff6a00]/15 transition-all"
                  required
                />
              </div>
            </div>

            {/* Password Input */}
            <div className="space-y-1.5">
              <label className="text-[11px] font-extrabold text-slate-700 uppercase tracking-wider flex items-center gap-1.5">
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
                  placeholder="admin"
                  className="w-full h-12 pl-4 pr-11 bg-slate-50 hover:bg-slate-100/70 focus:bg-white border-2 border-slate-200 focus:border-[#ff6a00] rounded-2xl text-sm font-bold text-slate-900 placeholder-slate-400 focus:outline-none focus:ring-4 focus:ring-[#ff6a00]/15 transition-all"
                  required
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-3.5 top-1/2 -translate-y-1/2 text-slate-400 hover:text-slate-800 transition-colors cursor-pointer"
                >
                  {showPassword ? <EyeOff className="w-4 h-4" /> : <Eye className="w-4 h-4" />}
                </button>
              </div>
            </div>

            {/* Remember Me */}
            <div className="flex items-center justify-between pt-1">
              <label className="flex items-center gap-2 cursor-pointer text-xs font-bold text-slate-600 hover:text-slate-900 select-none">
                <input
                  type="checkbox"
                  checked={rememberMe}
                  onChange={(e) => setRememberMe(e.target.checked)}
                  className="w-4 h-4 rounded border-slate-300 text-[#ff6a00] focus:ring-[#ff6a00] cursor-pointer"
                />
                <span>Remember session</span>
              </label>

              <span className="text-[11px] text-purple-800 font-extrabold flex items-center gap-1 bg-purple-50 px-2.5 py-1 rounded-lg border border-purple-200">
                <ShieldCheck className="w-3.5 h-3.5 text-purple-700" />
                Admin Protected
              </span>
            </div>

            {/* Submit Button */}
            <button
              type="submit"
              disabled={loading}
              className="w-full h-12 bg-gradient-to-r from-[#2b1f55] via-[#3a2973] to-[#ff6a00] hover:opacity-95 text-white font-black text-sm rounded-2xl shadow-lg shadow-purple-950/20 flex items-center justify-center gap-2 transition-all duration-200 cursor-pointer disabled:opacity-50 hover-lift active:scale-[0.98]"
            >
              {loading ? (
                <div className="w-5 h-5 border-2 border-white/40 border-t-white rounded-full animate-spin"></div>
              ) : (
                <>
                  <span>Sign In as Admin</span>
                  <ArrowRight className="w-4 h-4" />
                </>
              )}
            </button>

          </form>

          {/* Quick 1-Click Credentials Pill */}
          <div className="pt-2 border-t border-slate-100">
            <button
              type="button"
              onClick={handleOneClickFill}
              className="w-full py-2.5 px-3.5 bg-gradient-to-r from-orange-50 to-purple-50 hover:from-orange-100 hover:to-purple-100 border border-orange-200/80 rounded-2xl text-xs font-bold text-slate-800 flex items-center justify-between transition-all cursor-pointer group shadow-2xs"
            >
              <span className="flex items-center gap-2 font-black">
                <Zap className="w-4 h-4 text-[#ff6a00] group-hover:scale-110 transition-transform" />
                <span>Quick Auto-Fill</span>
              </span>
              <span className="font-mono text-[11px] font-black text-white bg-gradient-to-r from-[#ff6a00] to-[#2b1f55] px-2.5 py-0.5 rounded-lg shadow-xs">
                admin / admin
              </span>
            </button>
          </div>

        </div>
      </main>

      {/* Footer System Highlights */}
      <footer className="px-6 py-4 bg-slate-950/80 backdrop-blur-md text-white border-t border-white/10 relative z-10 animate-fade-in">
        <div className="max-w-6xl mx-auto flex flex-col sm:flex-row items-center justify-between gap-3 text-xs">
          <div className="flex flex-wrap items-center justify-center gap-4 sm:gap-6 font-semibold text-slate-300">
            <div className="flex items-center gap-1.5">
              <Globe2 className="w-4 h-4 text-sky-400" />
              <span>39 Terminals</span>
            </div>
            <div className="flex items-center gap-1.5">
              <Container className="w-4 h-4 text-orange-400" />
              <span>89,249 Active Units</span>
            </div>
            <div className="flex items-center gap-1.5">
              <Truck className="w-4 h-4 text-emerald-400" />
              <span>Multi-Modal Fleet</span>
            </div>
          </div>

          <div className="text-[11px] text-slate-400 font-medium">
            © {new Date().getFullYear()} SPJ Group • Cargo & Yard Operations Dashboard
          </div>
        </div>
      </footer>

    </div>
  );
}
