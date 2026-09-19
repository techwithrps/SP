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
  Sparkles,
  Zap
} from 'lucide-react';

// Single Master Administrator Account
export const MASTER_USER = {
  id: 'admin@spjcargo.com',
  username: 'admin',
  password: 'SPJ@Cargo2026',
  altPassword: 'admin',
  name: 'Rishabh Pratap Singh',
  role: 'Enterprise Administrator',
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
      const isMatch = (
        (cleanUser === MASTER_USER.id.toLowerCase() || cleanUser === MASTER_USER.username.toLowerCase()) &&
        (cleanPass === MASTER_USER.password || cleanPass === MASTER_USER.altPassword)
      );

      if (isMatch) {
        if (rememberMe) {
          localStorage.setItem('spj_auth_user', JSON.stringify({
            id: MASTER_USER.id,
            name: MASTER_USER.name,
            role: MASTER_USER.role,
            badge: MASTER_USER.badge,
            loginTime: new Date().toISOString()
          }));
        }
        setLoading(false);
        onLoginSuccess(MASTER_USER);
      } else {
        setLoading(false);
        setError('Invalid credentials. Use admin@spjcargo.com / SPJ@Cargo2026 or tap Quick Login below.');
      }
    }, 400);
  };

  const handleOneClickFill = () => {
    setUsername(MASTER_USER.id);
    setPassword(MASTER_USER.password);
    setError('');
  };

  return (
    <div className="min-h-screen bg-[#0b0819] text-slate-100 flex flex-col justify-between relative overflow-hidden font-sans selection:bg-[#ff6a00] selection:text-white">
      
      {/* Background Animated Ambient Glowing Orbs */}
      <div className="absolute top-[-15%] left-[-10%] w-[600px] h-[600px] bg-purple-600/20 rounded-full blur-[140px] pointer-events-none animate-float"></div>
      <div className="absolute bottom-[-15%] right-[-10%] w-[650px] h-[650px] bg-orange-600/20 rounded-full blur-[150px] pointer-events-none animate-float-rev"></div>
      <div className="absolute top-[35%] right-[25%] w-[400px] h-[400px] bg-indigo-600/15 rounded-full blur-[120px] pointer-events-none animate-glow"></div>

      {/* Top Bar Brand Header */}
      <header className="px-6 sm:px-12 py-6 flex items-center justify-between relative z-10 animate-fade-in">
        <div className="flex items-center gap-3">
          <img 
            src="/logo.png" 
            alt="SPJ Cargo" 
            className="h-12 w-auto object-contain bg-white/95 px-3 py-1.5 rounded-2xl shadow-xl shadow-purple-950/60 hover-lift cursor-pointer" 
          />
        </div>

        <div className="flex items-center gap-3">
          <div className="hidden sm:flex items-center gap-2 px-3.5 py-1.5 rounded-full bg-white/5 border border-white/10 text-xs text-purple-200">
            <ShieldCheck className="w-4 h-4 text-emerald-400" />
            <span>256-Bit SSL Encrypted Portal</span>
          </div>
          <span className="text-xs font-mono font-bold text-emerald-400 bg-emerald-950/60 border border-emerald-700/50 px-2.5 py-1 rounded-lg flex items-center gap-1.5">
            <span className="w-2 h-2 rounded-full bg-emerald-400 animate-pulse"></span>
            ORACLE LIVE
          </span>
        </div>
      </header>

      {/* Center Auth Card */}
      <main className="flex-1 flex items-center justify-center px-4 sm:px-6 py-6 relative z-10">
        <div className="w-full max-w-md bg-white/[0.04] backdrop-blur-2xl border border-white/15 rounded-3xl p-6 sm:p-8 shadow-2xl shadow-black/80 space-y-6 animate-scale-in">
          
          {/* Card Header with Glowing Icon */}
          <div className="text-center space-y-2">
            <div className="inline-flex items-center justify-center w-16 h-16 rounded-2xl bg-gradient-to-tr from-[#2b1f55] via-[#ea580c] to-[#ff6a00] p-0.5 shadow-xl shadow-orange-500/25 mb-1 animate-glow">
              <div className="w-full h-full bg-[#150f2c] rounded-2xl flex items-center justify-center">
                <Lock className="w-7 h-7 text-orange-400 animate-float" />
              </div>
            </div>
            <h1 className="text-2xl sm:text-3xl font-black font-display tracking-tight text-white">
              Enterprise Sign In
            </h1>
            <p className="text-xs text-purple-200/80">
              SPJ Cargo & Cold Logistics Operations ERP Portal
            </p>
          </div>

          {/* Error Alert */}
          {error && (
            <div className="p-3.5 rounded-2xl bg-rose-500/15 border border-rose-500/30 flex items-start gap-2.5 text-xs text-rose-200 animate-shake">
              <AlertCircle className="w-4 h-4 text-rose-400 shrink-0 mt-0.5" />
              <span>{error}</span>
            </div>
          )}

          {/* Form */}
          <form onSubmit={handleLogin} className="space-y-4">
            
            {/* User ID / Email Input */}
            <div className="space-y-1.5">
              <label className="text-[11px] font-bold text-slate-300 uppercase tracking-wider flex items-center gap-1.5">
                <User className="w-3.5 h-3.5 text-orange-400" />
                User ID / Corporate Email
              </label>
              <div className="relative">
                <input
                  type="text"
                  value={username}
                  onChange={(e) => {
                    setUsername(e.target.value);
                    setError('');
                  }}
                  placeholder="admin@spjcargo.com"
                  className="w-full h-12 pl-4 pr-10 bg-white/5 hover:bg-white/10 focus:bg-white/10 border border-white/20 focus:border-[#ff6a00] rounded-2xl text-sm font-medium text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-[#ff6a00]/30 transition-all"
                  required
                />
              </div>
            </div>

            {/* Password Input */}
            <div className="space-y-1.5">
              <label className="text-[11px] font-bold text-slate-300 uppercase tracking-wider flex items-center gap-1.5">
                <KeyRound className="w-3.5 h-3.5 text-purple-400" />
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
                  placeholder="SPJ@Cargo2026"
                  className="w-full h-12 pl-4 pr-11 bg-white/5 hover:bg-white/10 focus:bg-white/10 border border-white/20 focus:border-[#ff6a00] rounded-2xl text-sm font-medium text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-[#ff6a00]/30 transition-all"
                  required
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-3.5 top-1/2 -translate-y-1/2 text-slate-400 hover:text-white transition-colors cursor-pointer"
                >
                  {showPassword ? <EyeOff className="w-4 h-4" /> : <Eye className="w-4 h-4" />}
                </button>
              </div>
            </div>

            {/* Remember Me */}
            <div className="flex items-center justify-between pt-1">
              <label className="flex items-center gap-2 cursor-pointer text-xs text-slate-300 hover:text-white select-none">
                <input
                  type="checkbox"
                  checked={rememberMe}
                  onChange={(e) => setRememberMe(e.target.checked)}
                  className="w-4 h-4 rounded border-white/30 bg-white/5 text-[#ff6a00] focus:ring-[#ff6a00] cursor-pointer"
                />
                <span>Remember this workstation</span>
              </label>

              <span className="text-[11px] text-purple-300 font-semibold flex items-center gap-1">
                <ShieldCheck className="w-3 h-3 text-emerald-400" />
                Protected
              </span>
            </div>

            {/* Submit Button */}
            <button
              type="submit"
              disabled={loading}
              className="w-full h-12 bg-gradient-to-r from-[#ff6a00] via-[#ea580c] to-[#d946ef] hover:opacity-95 text-white font-black text-sm rounded-2xl shadow-xl shadow-orange-500/25 flex items-center justify-center gap-2 transition-all duration-200 cursor-pointer disabled:opacity-50 hover-lift"
            >
              {loading ? (
                <div className="w-5 h-5 border-2 border-white/30 border-t-white rounded-full animate-spin"></div>
              ) : (
                <>
                  <span>Access Operations Dashboard</span>
                  <ArrowRight className="w-4 h-4" />
                </>
              )}
            </button>

          </form>

          {/* Single 1-Click Master Autofill & Login Button */}
          <div className="pt-3 border-t border-white/10 space-y-2">
            <button
              type="button"
              onClick={handleOneClickFill}
              className="w-full py-2.5 px-4 bg-white/5 hover:bg-white/10 border border-white/15 hover:border-orange-400/50 rounded-2xl text-xs font-bold text-slate-200 flex items-center justify-between transition-all cursor-pointer group"
            >
              <span className="flex items-center gap-2">
                <Zap className="w-4 h-4 text-amber-400 group-hover:scale-110 transition-transform" />
                <span>Auto-Fill Master Credentials</span>
              </span>
              <span className="font-mono text-[11px] text-orange-400 bg-orange-950/50 px-2 py-0.5 rounded border border-orange-500/30">
                admin / SPJ@Cargo2026
              </span>
            </button>
          </div>

        </div>
      </main>

      {/* Footer System Highlights */}
      <footer className="px-6 py-4 border-t border-white/10 bg-black/30 backdrop-blur-md relative z-10 animate-fade-in">
        <div className="max-w-6xl mx-auto flex flex-col sm:flex-row items-center justify-between gap-3 text-xs text-slate-400">
          <div className="flex items-center gap-4">
            <div className="flex items-center gap-1.5 text-slate-300">
              <Globe2 className="w-4 h-4 text-purple-400" />
              <span>39 Multi-Modal Terminals</span>
            </div>
            <div className="flex items-center gap-1.5 text-slate-300">
              <Container className="w-4 h-4 text-orange-400" />
              <span>89,249 Active Yard Units</span>
            </div>
          </div>

          <div className="text-[11px] text-slate-500">
            © {new Date().getFullYear()} SPJ Cargo & Logistics • Enterprise Revenue Intelligence
          </div>
        </div>
      </footer>

    </div>
  );
}
