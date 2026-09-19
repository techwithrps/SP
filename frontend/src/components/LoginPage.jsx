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
  Users, 
  Container,
  ArrowRight, 
  CheckCircle2, 
  AlertCircle,
  KeyRound,
  Building2,
  Sparkles
} from 'lucide-react';

// Hardcoded authorized corporate user accounts
export const AUTHORIZED_USERS = [
  {
    id: 'admin@spjcargo.com',
    username: 'admin',
    password: 'SPJ@Cargo2026',
    altPassword: 'admin',
    name: 'Rishabh Pratap Singh',
    role: 'Enterprise Administrator',
    badge: 'Super Admin',
    badgeColor: 'bg-purple-500/20 text-purple-300 border-purple-500/30'
  },
  {
    id: 'director@spjcargo.com',
    username: 'director',
    password: 'SPJ@Director2026',
    altPassword: 'director123',
    name: 'Executive Director',
    role: 'Board of Directors',
    badge: 'Executive',
    badgeColor: 'bg-amber-500/20 text-amber-300 border-amber-500/30'
  },
  {
    id: 'ops@spjcargo.com',
    username: 'operations',
    password: 'SPJ@Operations2026',
    altPassword: 'ops123',
    name: 'Dadri Yard Incharge',
    role: 'Head of Yard Operations',
    badge: 'Ops Lead',
    badgeColor: 'bg-emerald-500/20 text-emerald-300 border-emerald-500/30'
  }
];

export default function LoginPage({ onLoginSuccess }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [rememberMe, setRememberMe] = useState(true);
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const [selectedDemoIndex, setSelectedDemoIndex] = useState(0);

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
      // Find matching authorized user
      const found = AUTHORIZED_USERS.find(u => 
        (u.id.toLowerCase() === cleanUser || u.username.toLowerCase() === cleanUser) &&
        (u.password === cleanPass || u.altPassword === cleanPass)
      );

      if (found) {
        if (rememberMe) {
          localStorage.setItem('spj_auth_user', JSON.stringify({
            id: found.id,
            name: found.name,
            role: found.role,
            badge: found.badge,
            loginTime: new Date().toISOString()
          }));
        }
        setLoading(false);
        onLoginSuccess(found);
      } else {
        setLoading(false);
        setError('Invalid User ID or Password. Please check credentials or use 1-Click Quick Fill below.');
      }
    }, 450);
  };

  const handleQuickFill = (userObj, index) => {
    setSelectedDemoIndex(index);
    setUsername(userObj.id);
    setPassword(userObj.password);
    setError('');
  };

  return (
    <div className="min-h-screen bg-[#0d091e] text-slate-100 flex flex-col justify-between relative overflow-hidden font-sans selection:bg-[#ff6a00] selection:text-white">
      
      {/* Background Ambient Glows */}
      <div className="absolute top-[-10%] left-[-10%] w-[500px] h-[500px] bg-purple-600/15 rounded-full blur-[120px] pointer-events-none"></div>
      <div className="absolute bottom-[-10%] right-[-10%] w-[600px] h-[600px] bg-orange-600/15 rounded-full blur-[140px] pointer-events-none"></div>
      <div className="absolute top-[40%] right-[30%] w-[350px] h-[350px] bg-indigo-600/10 rounded-full blur-[100px] pointer-events-none"></div>

      {/* Top Bar Brand */}
      <header className="px-6 sm:px-12 py-6 flex items-center justify-between relative z-10">
        <div className="flex items-center gap-3">
          <img 
            src="/logo.png" 
            alt="SPJ Cargo" 
            className="h-12 w-auto object-contain bg-white/95 px-3 py-1.5 rounded-2xl shadow-lg shadow-purple-950/50" 
          />
        </div>

        <div className="flex items-center gap-3">
          <div className="hidden sm:flex items-center gap-2 px-3.5 py-1.5 rounded-full bg-white/5 border border-white/10 text-xs text-purple-200">
            <ShieldCheck className="w-4 h-4 text-emerald-400" />
            <span>256-Bit SSL Encrypted Portal</span>
          </div>
          <span className="text-xs font-mono font-bold text-emerald-400 bg-emerald-950/60 border border-emerald-700/50 px-2.5 py-1 rounded-lg">
            ● ORACLE LIVE
          </span>
        </div>
      </header>

      {/* Center Auth Card */}
      <main className="flex-1 flex items-center justify-center px-4 sm:px-6 py-6 relative z-10">
        <div className="w-full max-w-md bg-white/[0.04] backdrop-blur-xl border border-white/15 rounded-3xl p-6 sm:p-8 shadow-2xl shadow-black/80 space-y-6">
          
          {/* Card Header */}
          <div className="text-center space-y-2">
            <div className="inline-flex items-center justify-center w-14 h-14 rounded-2xl bg-gradient-to-tr from-[#2b1f55] to-[#ff6a00] p-0.5 shadow-lg shadow-orange-500/20 mb-1">
              <div className="w-full h-full bg-[#181133] rounded-2xl flex items-center justify-center">
                <Lock className="w-6 h-6 text-orange-400" />
              </div>
            </div>
            <h1 className="text-2xl font-black font-display tracking-tight text-white">
              Executive Sign In
            </h1>
            <p className="text-xs text-purple-200/80">
              SPJ Cargo & Logistics Intelligence Operations Portal
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
                  placeholder="e.g. admin@spjcargo.com"
                  className="w-full h-12 pl-4 pr-10 bg-white/5 hover:bg-white/10 focus:bg-white/10 border border-white/20 focus:border-[#ff6a00] rounded-2xl text-sm font-medium text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-[#ff6a00]/30 transition-all"
                  required
                />
              </div>
            </div>

            {/* Password Input */}
            <div className="space-y-1.5">
              <div className="flex items-center justify-between">
                <label className="text-[11px] font-bold text-slate-300 uppercase tracking-wider flex items-center gap-1.5">
                  <KeyRound className="w-3.5 h-3.5 text-purple-400" />
                  Password
                </label>
              </div>
              <div className="relative">
                <input
                  type={showPassword ? 'text' : 'password'}
                  value={password}
                  onChange={(e) => {
                    setPassword(e.target.value);
                    setError('');
                  }}
                  placeholder="Enter your secure password"
                  className="w-full h-12 pl-4 pr-11 bg-white/5 hover:bg-white/10 focus:bg-white/10 border border-white/20 focus:border-[#ff6a00] rounded-2xl text-sm font-medium text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-[#ff6a00]/30 transition-all"
                  required
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-3.5 top-1/2 -translate-y-1/2 text-slate-400 hover:text-white transition-colors"
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

              <span className="text-[11px] text-purple-300 font-semibold">
                Protected by Oracle IAM
              </span>
            </div>

            {/* Submit Button */}
            <button
              type="submit"
              disabled={loading}
              className="w-full h-12 bg-gradient-to-r from-[#ff6a00] via-[#ea580c] to-[#d946ef] hover:opacity-95 text-white font-black text-sm rounded-2xl shadow-lg shadow-orange-500/25 flex items-center justify-center gap-2 transition-all duration-200 cursor-pointer disabled:opacity-50"
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

          {/* Quick Demo Credential Autofill Chips */}
          <div className="pt-4 border-t border-white/10 space-y-2.5">
            <div className="flex items-center justify-between text-[11px] text-slate-400">
              <span className="flex items-center gap-1 font-bold text-slate-300">
                <Sparkles className="w-3.5 h-3.5 text-amber-400" />
                1-Click Quick Login Accounts:
              </span>
              <span>Tap to autofill</span>
            </div>

            <div className="grid grid-cols-3 gap-2">
              {AUTHORIZED_USERS.map((user, idx) => (
                <button
                  key={idx}
                  type="button"
                  onClick={() => handleQuickFill(user, idx)}
                  className={`p-2 rounded-xl border text-left transition-all cursor-pointer flex flex-col justify-between ${
                    username === user.id 
                      ? 'bg-white/15 border-orange-400 shadow-md shadow-orange-500/20 ring-1 ring-orange-400/50' 
                      : 'bg-white/5 border-white/10 hover:bg-white/10 hover:border-white/20'
                  }`}
                >
                  <div className="flex items-center justify-between w-full mb-1">
                    <span className={`text-[9px] px-1.5 py-0.5 rounded border font-bold ${user.badgeColor}`}>
                      {user.badge}
                    </span>
                    {username === user.id && <CheckCircle2 className="w-3 h-3 text-orange-400" />}
                  </div>
                  <div className="text-xs font-bold text-white truncate">{user.username}</div>
                  <div className="text-[10px] text-slate-400 font-mono">••••••••</div>
                </button>
              ))}
            </div>
          </div>

        </div>
      </main>

      {/* Footer System Highlights */}
      <footer className="px-6 py-4 border-t border-white/10 bg-black/30 backdrop-blur-md relative z-10">
        <div className="max-w-6xl mx-auto flex flex-col sm:flex-row items-center justify-between gap-3 text-xs text-slate-400">
          <div className="flex items-center gap-4">
            <div className="flex items-center gap-1.5 text-slate-300">
              <Globe2 className="w-4 h-4 text-purple-400" />
              <span>39 Multi-Modal Terminals</span>
            </div>
            <div className="flex items-center gap-1.5 text-slate-300">
              <Container className="w-4 h-4 text-orange-400" />
              <span>89,249 Active Units</span>
            </div>
          </div>

          <div className="text-[11px] text-slate-500">
            © {new Date().getFullYear()} SPJ Cargo & Cold Logistics ERP • Confidential & Secure
          </div>
        </div>
      </footer>

    </div>
  );
}
