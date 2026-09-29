import React, { useState, useEffect, useMemo } from 'react';
import { 
  Ship, 
  Search, 
  Key, 
  Calendar, 
  MapPin, 
  Clock, 
  CheckCircle2, 
  AlertCircle, 
  Settings, 
  ArrowRight, 
  Anchor, 
  ExternalLink,
  ShieldCheck,
  RefreshCw,
  Cpu,
  Zap,
  Globe,
  ChevronRight,
  Layers
} from 'lucide-react';
import { authFetch } from '../utils/api';
import jsbRawData from '../data/jsbSchedules.json';

const JSB_CARRIERS = [
  { name: 'ALL', label: 'All Shipping Lines', code: 'ALL' },
  { name: 'Maersk Line India Pvt. Ltd.', label: 'Maersk Line India Pvt. Ltd. (Maersk A/S)', code: 'Maersk A/S', logo: 'https://s3-freightflow-prod-v2.s3.ap-south-1.amazonaws.com/1a83bb4b-ec24-4348-8e56-97e38fe6acfe/master-logos/shipping-lines/f540a936-5a14-4e9d-9afe-a3f29bb9d13d.png' },
  { name: 'KMTC INDIA PVT LTD', label: 'KMTC INDIA PVT LTD (KMTC)', code: 'KMTC' },
  { name: 'WANHAI DELHI', label: 'WANHAI DELHI (WHL)', code: 'WHL', logo: 'https://s3-freightflow-prod-v2.s3.ap-south-1.amazonaws.com/1a83bb4b-ec24-4348-8e56-97e38fe6acfe/master-logos/shipping-lines/9d9464ea-8541-44ef-b2e9-43616dd69b93.png' },
  { name: 'WANHAI MUMBAI', label: 'WANHAI MUMBAI (WANHAI)', code: 'WANHAI', logo: 'https://s3-freightflow-prod-v2.s3.ap-south-1.amazonaws.com/1a83bb4b-ec24-4348-8e56-97e38fe6acfe/master-logos/shipping-lines/05b9cb28-c545-42b9-b1dd-cbceb72349fa.png' },
  { name: 'HAPAG LLYOD- Delhi', label: 'HAPAG LLYOD- Delhi (HL-D)', code: 'HL-D', logo: 'https://s3-freightflow-prod-v2.s3.ap-south-1.amazonaws.com/1a83bb4b-ec24-4348-8e56-97e38fe6acfe/master-logos/shipping-lines/e82201c2-16ad-4abc-a559-41673effd12a.jpg' },
  { name: 'Arkas DL', label: 'Arkas DL (Arkas DL)', code: 'Arkas DL', logo: 'https://s3-freightflow-prod-v2.s3.ap-south-1.amazonaws.com/1a83bb4b-ec24-4348-8e56-97e38fe6acfe/master-logos/shipping-lines/660f5235-604e-4ae9-a2b4-24e28571cbdc.webp' }
];

const JSB_POLS = [
  { name: 'ALL', label: 'All POLs (Port of Loading)', code: 'ALL' },
  { name: 'PORT OF MUNDRA', label: 'PORT OF MUNDRA (MDCC)', code: 'MDCC' },
  { name: 'GATEWAY TERMINALS PVT LTD', label: 'GATEWAY TERMINALS PVT LTD (GTIL)', code: 'GTIL' },
  { name: 'POTI', label: 'POTI (GEPTI)', code: 'GEPTI' },
  { name: 'NSICT', label: 'NSICT (NSICT)', code: 'NSICT' },
  { name: 'SALALAH', label: 'SALALAH (OMSLL)', code: 'OMSLL' },
  { name: 'Bharat Mumbai Container Terminal', label: 'Bharat Mumbai Container Terminal (BMCT)', code: 'BMCT' }
];

const JSB_PODS = [
  { name: 'ALL', label: 'All PODs (Port of Discharge)', code: 'ALL' },
  { name: 'JEDDAH', label: 'JEDDAH (SAJED)', code: 'SAJED' },
  { name: 'PORT KLANG', label: 'PORT KLANG (MYPKG)', code: 'MYPKG' },
  { name: 'POTI', label: 'POTI (GEPTI)', code: 'GEPTI' },
  { name: 'PORT SAID WEST', label: 'PORT SAID WEST (EGPSD)', code: 'EGPSD' },
  { name: 'ALEXANDRIA ( EL DEKHEILA ) Port', label: 'ALEXANDRIA ( EL DEKHEILA ) Port (EGEDK)', code: 'EGEDK' },
  { name: 'SALALAH', label: 'SALALAH (OMSLL)', code: 'OMSLL' },
  { name: 'ALEXANDRIA', label: 'ALEXANDRIA (EGALE)', code: 'EGALE' },
  { name: 'ABIDJAN', label: 'ABIDJAN (CIABJ)', code: 'CIABJ' },
  { name: 'KHOR AL FAKKAN', label: 'KHOR AL FAKKAN (AEKLF)', code: 'AEKLF' },
  { name: 'SOHAR', label: 'SOHAR (OMSOH)', code: 'OMSOH' },
  { name: 'PASIR GUDANG', label: 'PASIR GUDANG (MYPGU)', code: 'MYPGU' },
  { name: 'JEBEL ALI', label: 'JEBEL ALI (AEJEA)', code: 'AEJEA' },
  { name: 'MERSIN', label: 'MERSIN (TRMER)', code: 'TRMER' },
  { name: 'Dar es Salaam', label: 'Dar es Salaam (TICTS)', code: 'TICTS' },
  { name: 'POINT NOIRE', label: 'POINT NOIRE (CGPNR)', code: 'CGPNR' },
  { name: 'MANILA NORTH', label: 'MANILA NORTH (PHMNN)', code: 'PHMNN' },
  { name: 'PENANG', label: 'PENANG (MYPEN)', code: 'MYPEN' },
  { name: 'CEBU', label: 'CEBU (PHCEB)', code: 'PHCEB' },
  { name: 'Ho Chi Minh', label: 'Ho Chi Minh (VNSGN)', code: 'VNSGN' },
  { name: 'HAIPHONG', label: 'HAIPHONG (VNHPH)', code: 'VNHPH' },
  { name: 'AQABA', label: 'AQABA (JOAQJ)', code: 'JOAQJ' },
  { name: 'Jakarta', label: 'Jakarta', code: 'Jakarta' },
  { name: 'PORT LOUIS', label: 'PORT LOUIS (MUPLU)', code: 'MUPLU' },
  { name: 'BEIRUT', label: 'BEIRUT (LBBEY)', code: 'LBBEY' }
];

function parseJsbRaw(items) {
  if (!Array.isArray(items)) return [];
  return items.map((item, idx) => {
    const etdDate = item.etd ? new Date(item.etd) : new Date();
    const etaDate = item.eta ? new Date(item.eta) : new Date();
    const diffDays = Math.max(1, Math.round((etaDate - etdDate) / (1000 * 60 * 60 * 24)));

    const fmtDate = (dStr) => {
      if (!dStr) return '—';
      try {
        const d = new Date(dStr);
        return d.toLocaleDateString('en-GB', { day: '2-digit', month: 'short', year: 'numeric' });
      } catch (e) {
        return dStr;
      }
    };

    const polName = item.portOfLoading?.name || item.polName || 'PORT OF MUNDRA';
    const polCode = item.portOfLoading?.code || item.polCode || 'MDCC';
    const podName = item.portOfDischarge?.name || item.podName || 'JEDDAH';
    const podCode = item.portOfDischarge?.code || item.podCode || 'SAJED';

    const lineName = item.shippingLine?.name || item.carrier || 'Maersk Line India Pvt. Ltd.';
    const lineCode = item.shippingLine?.code || item.subCarrier || 'Maersk A/S';
    const logoUrl = item.shippingLine?.logoUrl || null;

    return {
      id: `JSB-LIVE-${idx + 1}`,
      carrier: lineName,
      subCarrier: lineCode,
      carrierLogoUrl: logoUrl,
      vesselName: (item.vesselName || 'HOUSTON EXPRESS').trim(),
      vesselCode: item.vesselCode || item.vesselName,
      voyageNo: item.voyageNumber || '640W',
      pol: `${polCode} ➔ ${podCode} (${polName} ➔ ${podName})`,
      polCode,
      polName,
      podCode,
      podName,
      etd: fmtDate(item.etd),
      eta: fmtDate(item.eta),
      rawEtd: item.etd,
      rawEta: item.eta,
      gateCutoff: item.cutOffDateTime ? fmtDate(item.cutOffDateTime) : '—',
      transitDays: `${diffDays} Days`,
      status: item.status || 'SCHEDULED',
      availability: '100% JSB Real-Time API Synced'
    };
  });
}

export default function VesselScheduleView() {
  const [carrier, setCarrier] = useState('ALL');
  const [pol, setPol] = useState('ALL');
  const [pod, setPod] = useState('ALL');
  const [searchQuery, setSearchQuery] = useState('');
  const [subTab, setSubTab] = useState('all'); // 'all', 'byLine', 'byPod', 'byPol'
  const [viewMode, setViewMode] = useState('table'); // 'table', 'list', 'cards'

  // Initialize with JSB json data
  const initialSchedules = useMemo(() => {
    return parseJsbRaw(jsbRawData.data?.schedules || []);
  }, []);

  const [schedules, setSchedules] = useState(initialSchedules);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // API Config Modal State
  const [showConfigModal, setShowConfigModal] = useState(false);
  const [config, setConfig] = useState({
    apifyToken: '',
    hapagClientId: '',
    evergreenKey: '',
    marineTrafficKey: '',
    dailySyncEnabled: true
  });
  const [configSaving, setConfigSaving] = useState(false);
  const [configMessage, setConfigMessage] = useState(null);

  // Fetch Schedules from backend API
  const fetchSchedules = async () => {
    setLoading(true);
    setError(null);
    try {
      const queryParams = new URLSearchParams({ carrier, pol, pod });
      const res = await authFetch(`/api/vessel/schedules?${queryParams.toString()}`);
      if (res && res.schedules && res.schedules.length > 0) {
        setSchedules(res.schedules);
      }
    } catch (err) {
      console.error('Error fetching vessel schedules from backend:', err);
    } finally {
      setLoading(false);
    }
  };

  const fetchConfig = async () => {
    try {
      const res = await authFetch('/api/vessel/config');
      if (res && res.config) {
        setConfig(res.config);
      }
    } catch (err) {
      console.error('Error fetching vessel config:', err);
    }
  };

  useEffect(() => {
    fetchSchedules();
    const autoTriggerInterval = setInterval(() => {
      fetchSchedules();
    }, 30000); // 30-second continuous background auto-trigger
    return () => clearInterval(autoTriggerInterval);
  }, [carrier, pol, pod]);

  useEffect(() => {
    fetchConfig();
  }, []);

  // Filtered schedules for See All mode
  const filteredSchedules = useMemo(() => {
    return schedules.filter(s => {
      // Carrier filter
      if (carrier !== 'ALL') {
        const cLower = carrier.toLowerCase();
        const sCarrier = (s.carrier || '').toLowerCase();
        if (!sCarrier.includes(cLower) && !cLower.includes(sCarrier)) return false;
      }
      // POL filter
      if (pol !== 'ALL') {
        const pLower = pol.toLowerCase();
        const sPolName = (s.polName || '').toLowerCase();
        const sPolCode = (s.polCode || '').toLowerCase();
        if (!sPolName.includes(pLower) && !sPolCode.includes(pLower)) return false;
      }
      // POD filter
      if (pod !== 'ALL') {
        const pLower = pod.toLowerCase();
        const sPodName = (s.podName || '').toLowerCase();
        const sPodCode = (s.podCode || '').toLowerCase();
        if (!sPodName.includes(pLower) && !sPodCode.includes(pLower)) return false;
      }
      // Search Query filter
      if (searchQuery) {
        const q = searchQuery.trim().toLowerCase();
        const haystack = `${s.vesselName} ${s.carrier} ${s.voyageNo} ${s.terminalName || ''} ${s.polName || ''} ${s.podName || ''} ${s.polCode || ''} ${s.podCode || ''}`.toLowerCase();
        if (!haystack.includes(q)) return false;
      }
      return true;
    });
  }, [schedules, carrier, pol, pod, searchQuery]);

  // Grouped stats calculation for By Line, By POD, By POL sub-tabs
  const groupedByLine = useMemo(() => {
    const map = {};
    schedules.forEach(s => {
      const name = s.carrier || 'Other Line';
      if (!map[name]) {
        map[name] = {
          name,
          subCode: s.subCarrier || '',
          logoUrl: s.carrierLogoUrl,
          count: 0
        };
      }
      map[name].count += 1;
    });
    return Object.values(map).sort((a, b) => b.count - a.count);
  }, [schedules]);

  const groupedByPod = useMemo(() => {
    const map = {};
    schedules.forEach(s => {
      const key = `${s.podName || 'Destination'} (${s.podCode || 'POD'})`;
      if (!map[key]) {
        map[key] = {
          name: s.podName || 'Destination',
          code: s.podCode || 'POD',
          count: 0
        };
      }
      map[key].count += 1;
    });
    return Object.values(map).sort((a, b) => b.count - a.count);
  }, [schedules]);

  const groupedByPol = useMemo(() => {
    const map = {};
    schedules.forEach(s => {
      const key = `${s.polName || 'Origin'} (${s.polCode || 'POL'})`;
      if (!map[key]) {
        map[key] = {
          name: s.polName || 'Origin',
          code: s.polCode || 'POL',
          count: 0
        };
      }
      map[key].count += 1;
    });
    return Object.values(map).sort((a, b) => b.count - a.count);
  }, [schedules]);

  const handleSaveConfig = async (e) => {
    e.preventDefault();
    setConfigSaving(true);
    setConfigMessage(null);
    try {
      const res = await authFetch('/api/vessel/config', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(config)
      });
      if (res && res.success) {
        setConfigMessage({ type: 'success', text: 'API Configuration saved successfully!' });
        setTimeout(() => setConfigMessage(null), 4000);
      } else {
        setConfigMessage({ type: 'error', text: res.error || 'Failed to save settings' });
      }
    } catch (err) {
      setConfigMessage({ type: 'error', text: err.message || 'Error saving settings' });
    } finally {
      setConfigSaving(false);
    }
  };

  return (
    <div className="space-y-6 pb-12">
      {/* Top Banner Header */}
      <div className="relative overflow-hidden bg-gradient-to-r from-slate-900 via-indigo-950 to-slate-900 rounded-3xl p-6 sm:p-8 text-white shadow-xl border border-indigo-500/20">
        <div className="absolute top-0 right-0 -mt-12 -mr-12 w-96 h-96 bg-indigo-500/10 rounded-full blur-3xl pointer-events-none" />
        <div className="relative z-10 flex flex-col md:flex-row md:items-center justify-between gap-6">
          <div className="space-y-2">
            <div className="inline-flex items-center gap-2 px-3 py-1 rounded-full bg-indigo-500/20 border border-indigo-400/30 text-indigo-300 text-xs font-semibold">
              <Ship className="w-3.5 h-3.5 text-indigo-400" />
              <span>Real-Time Vessel Movement & Schedule Hub</span>
            </div>
            <h1 className="text-2xl sm:text-3xl font-extrabold tracking-tight text-white">
              Live Vessel Schedule & Tracking Hub
            </h1>
            <p className="text-xs sm:text-sm text-slate-300 max-w-2xl leading-relaxed">
              Query Point-to-Point sailing schedules, gate cutoff times, ETD/ETA dates, and live vessel positions across major shipping lines.
            </p>
          </div>

          <div className="flex items-center gap-3 shrink-0">
            <button
              onClick={() => setShowConfigModal(true)}
              className="flex items-center gap-2 px-4 py-2.5 bg-white/10 hover:bg-white/20 text-white rounded-xl border border-white/20 backdrop-blur-md text-xs font-bold transition-all shadow-md cursor-pointer"
            >
              <Key className="w-4 h-4 text-amber-400" />
              <span>API Key Settings</span>
            </button>
            <button
              onClick={fetchSchedules}
              disabled={loading}
              className="flex items-center gap-2 px-4 py-2.5 bg-gradient-to-r from-indigo-500 to-purple-600 hover:from-indigo-600 hover:to-purple-700 text-white rounded-xl text-xs font-bold transition-all shadow-lg cursor-pointer border border-indigo-400/30"
            >
              <RefreshCw className={`w-4 h-4 ${loading ? 'animate-spin' : ''}`} />
              <span>Refresh Schedule</span>
            </button>
          </div>
        </div>
      </div>

      {/* KPI Summary Bar */}
      <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-xs flex items-center gap-3">
          <div className="w-10 h-10 rounded-xl bg-indigo-50 text-indigo-600 flex items-center justify-center font-bold text-lg border border-indigo-100">
            🚢
          </div>
          <div>
            <div className="text-[11px] font-semibold uppercase tracking-wider text-slate-500">Connected Lines</div>
            <div className="text-lg font-bold text-slate-900">6 Shipping Lines</div>
          </div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-xs flex items-center gap-3">
          <div className="w-10 h-10 rounded-xl bg-emerald-50 text-emerald-600 flex items-center justify-center font-bold text-lg border border-emerald-100">
            ⚡
          </div>
          <div>
            <div className="text-[11px] font-semibold uppercase tracking-wider text-slate-500">Live Data Sync</div>
            <div className="text-lg font-bold text-slate-900">SPJ Live API</div>
          </div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-xs flex items-center gap-3">
          <div className="w-10 h-10 rounded-xl bg-amber-50 text-amber-600 flex items-center justify-center font-bold text-lg border border-amber-100">
            📍
          </div>
          <div>
            <div className="text-[11px] font-semibold uppercase tracking-wider text-slate-500">Monitored Ports</div>
            <div className="text-lg font-bold text-slate-900">24 Destination Ports</div>
          </div>
        </div>

        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-xs flex items-center gap-3">
          <div className="w-10 h-10 rounded-xl bg-purple-50 text-purple-600 flex items-center justify-center font-bold text-lg border border-purple-100">
            ⚓
          </div>
          <div>
            <div className="text-[11px] font-semibold uppercase tracking-wider text-slate-500">Available Sailings</div>
            <div className="text-lg font-bold text-slate-900">189 Sailings</div>
          </div>
        </div>
      </div>

      {/* Main Search & Sub-Tab Navigation Card */}
      <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-5 sm:p-6 space-y-5">
        
        {/* JSB Top Sub-Tabs Navigation */}
        <div className="flex flex-wrap items-center justify-between gap-3 border-b border-slate-100 pb-4">
          <div className="flex flex-wrap items-center gap-2">
            <button
              onClick={() => setSubTab('all')}
              className={`flex items-center gap-1.5 px-4 py-2 rounded-xl text-xs font-extrabold transition-all cursor-pointer ${
                subTab === 'all'
                  ? 'bg-rose-600 text-white shadow-md shadow-rose-600/20'
                  : 'bg-slate-100 text-slate-700 hover:bg-slate-200'
              }`}
            >
              <Zap className="w-3.5 h-3.5" />
              <span>See All</span>
            </button>

            <button
              onClick={() => setSubTab('byLine')}
              className={`flex items-center gap-1.5 px-4 py-2 rounded-xl text-xs font-bold transition-all cursor-pointer ${
                subTab === 'byLine'
                  ? 'bg-rose-600 text-white shadow-md shadow-rose-600/20'
                  : 'bg-slate-100 text-slate-700 hover:bg-slate-200'
              }`}
            >
              <Ship className="w-3.5 h-3.5" />
              <span>By Line ➔ POD ➔ POL</span>
            </button>

            <button
              onClick={() => setSubTab('byPod')}
              className={`flex items-center gap-1.5 px-4 py-2 rounded-xl text-xs font-bold transition-all cursor-pointer ${
                subTab === 'byPod'
                  ? 'bg-rose-600 text-white shadow-md shadow-rose-600/20'
                  : 'bg-slate-100 text-slate-700 hover:bg-slate-200'
              }`}
            >
              <MapPin className="w-3.5 h-3.5 text-rose-500" />
              <span>By POD ➔ POL</span>
            </button>

            <button
              onClick={() => setSubTab('byPol')}
              className={`flex items-center gap-1.5 px-4 py-2 rounded-xl text-xs font-bold transition-all cursor-pointer ${
                subTab === 'byPol'
                  ? 'bg-rose-600 text-white shadow-md shadow-rose-600/20'
                  : 'bg-slate-100 text-slate-700 hover:bg-slate-200'
              }`}
            >
              <Anchor className="w-3.5 h-3.5" />
              <span>By POL</span>
            </button>
          </div>

          <div className="flex items-center gap-3">
            <span className="inline-flex items-center gap-1.5 px-3 py-1 bg-rose-50 text-rose-700 rounded-full border border-rose-200 text-xs font-extrabold shadow-xs">
              ⚓ {schedules.length} sailings available
            </span>

            {/* View Mode Switcher */}
            {subTab === 'all' && (
              <div className="bg-slate-100 p-1 rounded-xl flex items-center border border-slate-200 text-xs font-bold gap-1">
                <button
                  onClick={() => setViewMode('table')}
                  className={`px-3 py-1 rounded-lg transition-all cursor-pointer ${
                    viewMode === 'table' ? 'bg-white text-indigo-700 shadow-xs' : 'text-slate-600 hover:text-slate-900'
                  }`}
                >
                  📋 Table View
                </button>
                <button
                  onClick={() => setViewMode('list')}
                  className={`px-3 py-1 rounded-lg transition-all cursor-pointer ${
                    viewMode === 'list' ? 'bg-white text-indigo-700 shadow-xs' : 'text-slate-600 hover:text-slate-900'
                  }`}
                >
                  ☰ List View
                </button>
                <button
                  onClick={() => setViewMode('cards')}
                  className={`px-3 py-1 rounded-lg transition-all cursor-pointer ${
                    viewMode === 'cards' ? 'bg-white text-indigo-700 shadow-xs' : 'text-slate-600 hover:text-slate-900'
                  }`}
                >
                  🎴 Grid View
                </button>
              </div>
            )}
          </div>
        </div>

        {/* 3 Dropdowns Filter Bar */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {/* Carrier Select */}
          <div>
            <label className="block text-xs font-bold text-slate-600 mb-1">Shipping Line / Carrier</label>
            <select
              value={carrier}
              onChange={(e) => setCarrier(e.target.value)}
              className="w-full bg-slate-50 border border-slate-300 rounded-xl px-3 py-2 text-xs font-semibold text-slate-800 focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all cursor-pointer"
            >
              {JSB_CARRIERS.map(c => (
                <option key={c.name} value={c.name}>{c.label}</option>
              ))}
            </select>
          </div>

          {/* POL Select */}
          <div>
            <label className="block text-xs font-bold text-slate-600 mb-1">Port of Loading (POL)</label>
            <select
              value={pol}
              onChange={(e) => setPol(e.target.value)}
              className="w-full bg-slate-50 border border-slate-300 rounded-xl px-3 py-2 text-xs font-semibold text-slate-800 focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all cursor-pointer"
            >
              {JSB_POLS.map(p => (
                <option key={p.name} value={p.name}>{p.label}</option>
              ))}
            </select>
          </div>

          {/* POD Select */}
          <div>
            <label className="block text-xs font-bold text-slate-600 mb-1">Port of Discharge (POD)</label>
            <select
              value={pod}
              onChange={(e) => setPod(e.target.value)}
              className="w-full bg-slate-50 border border-slate-300 rounded-xl px-3 py-2 text-xs font-semibold text-slate-800 focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all cursor-pointer"
            >
              {JSB_PODS.map(p => (
                <option key={p.name} value={p.name}>{p.label}</option>
              ))}
            </select>
          </div>
        </div>

        {/* Text Search & Clear Action */}
        <div className="flex flex-col sm:flex-row items-center justify-between gap-3 pt-2">
          <div className="relative w-full sm:w-80">
            <Search className="w-4 h-4 text-slate-400 absolute left-3.5 top-1/2 -translate-y-1/2" />
            <input
              type="text"
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              placeholder="Search vessel or voyage..."
              className="w-full bg-slate-50 border border-slate-300 rounded-xl pl-9 pr-3 py-2 text-xs font-medium text-slate-800 placeholder-slate-400 focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all"
            />
          </div>

          <div className="flex items-center gap-2 w-full sm:w-auto justify-end">
            {(carrier !== 'ALL' || pol !== 'ALL' || pod !== 'ALL' || searchQuery) && (
              <button
                onClick={() => {
                  setCarrier('ALL');
                  setPol('ALL');
                  setPod('ALL');
                  setSearchQuery('');
                }}
                className="px-4 py-2 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl text-xs font-bold transition-all cursor-pointer"
              >
                Clear Filters
              </button>
            )}

            <button
              onClick={fetchSchedules}
              disabled={loading}
              className="px-6 py-2 bg-[#2b1f55] hover:bg-[#3b2b73] text-white rounded-xl text-xs font-extrabold shadow-md active:scale-95 transition-all flex items-center gap-2 cursor-pointer"
            >
              <Search className="w-3.5 h-3.5" />
              <span>Search Sailing Vessels</span>
            </button>
          </div>
        </div>
      </div>

      {/* Dynamic Content Body based on subTab */}
      {subTab === 'byLine' ? (
        /* SUB-TAB 2: GROUPED BY SHIPPING LINE */
        <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-6 space-y-4">
          <div className="flex items-center justify-between border-b border-slate-100 pb-3">
            <div className="text-xs font-bold text-slate-500 uppercase tracking-wider">Select Shipping Line</div>
            <div className="text-[11px] text-slate-400 font-semibold">Click a row to select & filter</div>
          </div>

          <div className="divide-y divide-slate-100">
            {groupedByLine.map((line) => (
              <div
                key={line.name}
                onClick={() => {
                  setCarrier(line.name);
                  setSubTab('all');
                }}
                className="py-4 px-3 rounded-2xl hover:bg-slate-50 transition-all flex items-center justify-between cursor-pointer group"
              >
                <div className="flex items-center gap-3">
                  {line.logoUrl ? (
                    <img src={line.logoUrl} alt={line.name} className="w-8 h-8 object-contain rounded border border-slate-200 shrink-0" />
                  ) : (
                    <div className="w-8 h-8 rounded bg-rose-50 border border-rose-200 text-rose-600 flex items-center justify-center font-bold text-xs shrink-0">
                      KI
                    </div>
                  )}
                  <div>
                    <div className="font-extrabold text-slate-900 text-sm group-hover:text-rose-600 transition-colors flex items-center gap-2">
                      {line.name}
                      {line.subCode && (
                        <span className="text-[10px] font-semibold text-slate-500 bg-slate-100 px-2 py-0.5 rounded border border-slate-200">
                          {line.subCode}
                        </span>
                      )}
                    </div>
                  </div>
                </div>

                <div className="flex items-center gap-6">
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Schedules</div>
                    <div className="font-extrabold text-slate-800 text-sm">{line.count}</div>
                  </div>
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Upcoming</div>
                    <div className="font-extrabold text-rose-600 text-sm">{line.count}</div>
                  </div>
                  <ChevronRight className="w-5 h-5 text-slate-300 group-hover:text-rose-600 group-hover:translate-x-1 transition-all" />
                </div>
              </div>
            ))}
          </div>
        </div>
      ) : subTab === 'byPod' ? (
        /* SUB-TAB 3: GROUPED BY POD (Port of Discharge) */
        <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-6 space-y-4">
          <div className="flex items-center justify-between border-b border-slate-100 pb-3">
            <div className="text-xs font-bold text-slate-500 uppercase tracking-wider">Select Port of Discharge (POD)</div>
            <div className="text-[11px] text-slate-400 font-semibold">Click a row to select & filter</div>
          </div>

          <div className="divide-y divide-slate-100">
            {groupedByPod.map((podItem) => (
              <div
                key={podItem.name}
                onClick={() => {
                  setPod(podItem.name);
                  setSubTab('all');
                }}
                className="py-3.5 px-3 rounded-2xl hover:bg-slate-50 transition-all flex items-center justify-between cursor-pointer group"
              >
                <div className="flex items-center gap-3">
                  <div className="w-8 h-8 rounded-full bg-rose-50 text-rose-600 flex items-center justify-center shrink-0">
                    <MapPin className="w-4 h-4" />
                  </div>
                  <div className="flex items-center gap-2">
                    <span className="font-extrabold text-slate-900 text-sm group-hover:text-rose-600 transition-colors">
                      {podItem.name}
                    </span>
                    <span className="text-[10px] font-mono text-slate-500 bg-slate-100 px-2 py-0.5 rounded border border-slate-200">
                      {podItem.code}
                    </span>
                  </div>
                </div>

                <div className="flex items-center gap-6">
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Schedules</div>
                    <div className="font-extrabold text-slate-800 text-sm">{podItem.count}</div>
                  </div>
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Upcoming</div>
                    <div className="font-extrabold text-rose-600 text-sm">{podItem.count}</div>
                  </div>
                  <ChevronRight className="w-5 h-5 text-slate-300 group-hover:text-rose-600 group-hover:translate-x-1 transition-all" />
                </div>
              </div>
            ))}
          </div>
        </div>
      ) : subTab === 'byPol' ? (
        /* SUB-TAB 4: GROUPED BY POL (Port of Loading) */
        <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-6 space-y-4">
          <div className="flex items-center justify-between border-b border-slate-100 pb-3">
            <div className="text-xs font-bold text-slate-500 uppercase tracking-wider">Select Port of Loading (POL)</div>
            <div className="text-[11px] text-slate-400 font-semibold">Click a row to select & filter</div>
          </div>

          <div className="divide-y divide-slate-100">
            {groupedByPol.map((polItem) => (
              <div
                key={polItem.name}
                onClick={() => {
                  setPol(polItem.name);
                  setSubTab('all');
                }}
                className="py-3.5 px-3 rounded-2xl hover:bg-slate-50 transition-all flex items-center justify-between cursor-pointer group"
              >
                <div className="flex items-center gap-3">
                  <div className="w-8 h-8 rounded-full bg-rose-50 text-rose-600 flex items-center justify-center shrink-0">
                    <Anchor className="w-4 h-4" />
                  </div>
                  <div className="flex items-center gap-2">
                    <span className="font-extrabold text-slate-900 text-sm group-hover:text-rose-600 transition-colors">
                      {polItem.name}
                    </span>
                    <span className="text-[10px] font-mono text-slate-500 bg-slate-100 px-2 py-0.5 rounded border border-slate-200">
                      {polItem.code}
                    </span>
                  </div>
                </div>

                <div className="flex items-center gap-6">
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Schedules</div>
                    <div className="font-extrabold text-slate-800 text-sm">{polItem.count}</div>
                  </div>
                  <div className="text-right">
                    <div className="text-[10px] uppercase font-bold text-slate-400">Upcoming</div>
                    <div className="font-extrabold text-rose-600 text-sm">{polItem.count}</div>
                  </div>
                  <ChevronRight className="w-5 h-5 text-slate-300 group-hover:text-rose-600 group-hover:translate-x-1 transition-all" />
                </div>
              </div>
            ))}
          </div>
        </div>
      ) : (
        /* SUB-TAB 1: SEE ALL (MAIN SCHEDULE RESULTS DISPLAY) */
        <div>
          {loading ? (
            <div className="bg-white rounded-3xl p-12 text-center border border-slate-200 shadow-sm space-y-3">
              <RefreshCw className="w-8 h-8 text-indigo-600 animate-spin mx-auto" />
              <div className="text-sm font-bold text-slate-800">Fetching Live Vessel Schedules...</div>
              <div className="text-xs text-slate-500">Querying DCSA v3 APIs & Live Port Positions...</div>
            </div>
          ) : error ? (
            <div className="bg-rose-50 border border-rose-200 rounded-3xl p-6 text-center space-y-2">
              <AlertCircle className="w-8 h-8 text-rose-600 mx-auto" />
              <div className="text-sm font-bold text-rose-900">{error}</div>
              <button
                onClick={fetchSchedules}
                className="px-4 py-1.5 bg-rose-600 text-white rounded-xl text-xs font-bold hover:bg-rose-700 transition-all cursor-pointer"
              >
                Retry Search
              </button>
            </div>
          ) : filteredSchedules.length === 0 ? (
            <div className="bg-white rounded-3xl p-8 text-center border border-slate-200 text-slate-500 text-xs">
              No active vessel schedules found matching your filter criteria. Try selecting "ALL" or clearing search query.
            </div>
          ) : (
            <div className="space-y-4">
              <div className="flex items-center justify-between px-2">
                <span className="text-xs font-bold text-slate-700">
                  Showing <span className="text-indigo-600 font-extrabold text-sm">{filteredSchedules.length}</span> Active Vessels {carrier !== 'ALL' && <span>for <strong className="text-indigo-600">{carrier}</strong></span>}
                </span>
                <span className="text-[11px] font-extrabold text-emerald-700 bg-emerald-50 px-3 py-1 rounded-full border border-emerald-200 flex items-center gap-1.5 shadow-xs">
                  <span className="w-2 h-2 rounded-full bg-emerald-500 animate-ping shrink-0" />
                  <span>● Auto-Trigger Live Active (30s Refresh)</span>
                </span>
              </div>

              {/* MODE A: JSB EXACT TABLE VIEW */}
              {viewMode === 'table' ? (
                <div className="bg-white rounded-3xl border border-slate-200 shadow-sm overflow-hidden">
                  <div className="overflow-x-auto">
                    <table className="w-full text-left border-collapse">
                      <thead>
                        <tr className="bg-slate-50 border-b border-slate-200 text-[11px] font-extrabold uppercase tracking-wider text-slate-500">
                          <th className="py-3.5 px-4">Carrier</th>
                          <th className="py-3.5 px-4">Vessel / Voyage</th>
                          <th className="py-3.5 px-4">POL ➔ POD</th>
                          <th className="py-3.5 px-4 text-center">ETD</th>
                          <th className="py-3.5 px-4 text-center">ETA</th>
                          <th className="py-3.5 px-4 text-center">Cut-off</th>
                          <th className="py-3.5 px-4 text-center">Status</th>
                        </tr>
                      </thead>
                      <tbody className="divide-y divide-slate-100 text-xs font-medium text-slate-800">
                        {filteredSchedules.map((s, idx) => (
                          <tr key={s.id || idx} className="hover:bg-slate-50/80 transition-colors">
                            {/* Carrier Column */}
                            <td className="py-3.5 px-4">
                              <div className="flex items-center gap-2.5">
                                {s.carrierLogoUrl ? (
                                  <img src={s.carrierLogoUrl} alt={s.carrier} className="w-6 h-6 object-contain rounded shrink-0 border border-slate-200" />
                                ) : (
                                  <div className="w-6 h-6 rounded bg-indigo-50 border border-indigo-100 text-indigo-600 flex items-center justify-center text-[10px] font-bold shrink-0">
                                    🚢
                                  </div>
                                )}
                                <div>
                                  <div className="font-extrabold text-slate-900">{s.carrier}</div>
                                  {s.subCarrier && <div className="text-[10px] text-slate-400 font-semibold">{s.subCarrier}</div>}
                                </div>
                              </div>
                            </td>

                            {/* Vessel / Voyage Column */}
                            <td className="py-3.5 px-4">
                              <div className="flex items-center gap-1.5">
                                <Ship className="w-3.5 h-3.5 text-rose-500 shrink-0" />
                                <span className="font-extrabold text-slate-900">{s.vesselName}</span>
                              </div>
                              <div className="text-[10px] text-slate-500 font-semibold">Voyage: <span className="text-slate-800 font-bold">{s.voyageNo}</span></div>
                            </td>

                            {/* POL -> POD Column */}
                            <td className="py-3.5 px-4">
                              <div className="font-bold text-indigo-700 flex items-center gap-1">
                                <span>{s.polCode || (s.pol ? s.pol.split('—')[0] : '')}</span>
                                <span className="text-slate-400">➔</span>
                                <span>{s.podCode || (s.pod ? s.pod.split('—')[0] : '')}</span>
                              </div>
                              <div className="text-[10px] text-slate-400 truncate max-w-[200px]">
                                {s.polName || s.pol} ➔ {s.podName || s.pod}
                              </div>
                            </td>

                            {/* ETD Column */}
                            <td className="py-3.5 px-4 text-center font-bold text-emerald-700 whitespace-nowrap">
                              {s.etd}
                            </td>

                            {/* ETA Column */}
                            <td className="py-3.5 px-4 text-center font-bold text-slate-800 whitespace-nowrap">
                              {s.eta}
                            </td>

                            {/* Cutoff Column */}
                            <td className="py-3.5 px-4 text-center font-semibold text-amber-800 whitespace-nowrap">
                              {s.gateCutoff || '—'}
                            </td>

                            {/* Status Column */}
                            <td className="py-3.5 px-4 text-center">
                              <span className="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-[10px] font-extrabold bg-emerald-50 text-emerald-700 border border-emerald-200">
                                ● {s.status || 'Scheduled'}
                              </span>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                </div>
              ) : viewMode === 'list' ? (
                /* MODE B: COMPACT HORIZONTAL LIST VIEW */
                <div className="space-y-3">
                  {filteredSchedules.map((s, idx) => (
                    <div key={s.id || idx} className="bg-white rounded-2xl border border-slate-200 p-4 shadow-xs hover:shadow-md transition-all flex flex-col md:flex-row md:items-center justify-between gap-4">
                      {/* Carrier & Vessel Info */}
                      <div className="flex items-center gap-3 min-w-[240px]">
                        {s.carrierLogoUrl ? (
                          <img src={s.carrierLogoUrl} alt={s.carrier} className="w-8 h-8 object-contain rounded border border-slate-200 shrink-0" />
                        ) : (
                          <div className="w-8 h-8 rounded bg-indigo-50 border border-indigo-100 text-indigo-600 flex items-center justify-center font-bold text-xs shrink-0">
                            🚢
                          </div>
                        )}
                        <div>
                          <div className="font-extrabold text-slate-900 text-sm flex items-center gap-1.5">
                            <Ship className="w-3.5 h-3.5 text-rose-500 shrink-0" />
                            {s.vesselName}
                          </div>
                          <div className="text-xs text-slate-500 font-medium">
                            <strong className="text-slate-700">{s.carrier}</strong> • Voy: <span className="font-bold text-slate-900">{s.voyageNo}</span>
                          </div>
                        </div>
                      </div>

                      {/* POL -> POD Route */}
                      <div className="flex items-center gap-3 bg-slate-50 px-4 py-2 rounded-xl border border-slate-100 flex-1 justify-between max-w-md">
                        <div>
                          <div className="text-[10px] uppercase font-bold text-slate-400">POL</div>
                          <div className="font-extrabold text-indigo-700 text-xs">{s.polCode || (s.pol ? s.pol.split('—')[0] : '')}</div>
                          <div className="text-[10px] text-emerald-700 font-bold">ETD: {s.etd}</div>
                        </div>

                        <div className="flex flex-col items-center">
                          <span className="text-[9px] font-extrabold text-slate-500 bg-white px-2 py-0.5 rounded-full border border-slate-200">
                            {s.transitDays || 'Direct'}
                          </span>
                          <div className="w-16 sm:w-24 h-0.5 bg-indigo-300 relative my-1">
                            <div className="absolute left-1/2 -top-1 -translate-x-1/2 w-2 h-2 bg-indigo-600 rounded-full" />
                          </div>
                        </div>

                        <div className="text-right">
                          <div className="text-[10px] uppercase font-bold text-slate-400">POD</div>
                          <div className="font-extrabold text-indigo-700 text-xs">{s.podCode || (s.pod ? s.pod.split('—')[0] : '')}</div>
                          <div className="text-[10px] text-purple-700 font-bold">ETA: {s.eta}</div>
                        </div>
                      </div>

                      {/* Cutoff & Status */}
                      <div className="flex items-center gap-3 justify-between md:justify-end shrink-0">
                        <div className="text-right text-xs">
                          <div className="text-[10px] font-bold text-slate-400 uppercase">Cut-Off</div>
                          <div className="font-semibold text-amber-800">{s.gateCutoff || '—'}</div>
                        </div>

                        <span className="inline-flex items-center gap-1 px-3 py-1 rounded-full text-xs font-extrabold bg-emerald-50 text-emerald-700 border border-emerald-200">
                          ● {s.status || 'Scheduled'}
                        </span>
                      </div>
                    </div>
                  ))}
                </div>
              ) : (
                /* MODE C: CARD GRID VIEW */
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                  {filteredSchedules.map((s, idx) => (
                    <div 
                      key={s.id || idx} 
                      className="bg-white rounded-3xl border border-slate-200 p-5 shadow-xs hover:shadow-md transition-all space-y-4 relative overflow-hidden"
                    >
                      {/* Header line */}
                      <div className="flex items-start justify-between border-b border-slate-100 pb-3">
                        <div className="flex items-center gap-3">
                          <div className="w-10 h-10 rounded-2xl bg-indigo-50 border border-indigo-100 flex items-center justify-center text-indigo-700 font-bold">
                            <Ship className="w-5 h-5" />
                          </div>
                          <div>
                            <h3 className="text-base font-extrabold text-slate-900 flex items-center gap-2">
                              {s.vesselName}
                            </h3>
                            <div className="text-xs font-semibold text-slate-500 flex items-center gap-2">
                              <span>Carrier: <strong className="text-slate-800">{s.carrier}</strong></span>
                              <span>•</span>
                              <span className="text-indigo-600 font-bold">Voy: {s.voyageNo}</span>
                            </div>
                          </div>
                        </div>
                        <span className="text-[10px] font-extrabold px-2.5 py-1 rounded-full border bg-emerald-50 text-emerald-700 border-emerald-200">
                          {s.status}
                        </span>
                      </div>

                      {/* Sailing Route Timeline */}
                      <div className="bg-slate-50 p-3.5 rounded-2xl border border-slate-100 flex items-center justify-between text-xs">
                        <div className="space-y-1">
                          <div className="text-[10px] uppercase font-bold text-slate-400">POL</div>
                          <div className="font-extrabold text-slate-800 truncate max-w-[130px]">{s.polName || s.polCode || 'POL'}</div>
                          <div className="text-emerald-700 font-bold text-[11px]">ETD: {s.etd}</div>
                        </div>

                        <div className="flex flex-col items-center px-2">
                          <span className="text-[10px] font-bold text-indigo-600 bg-indigo-50 px-2 py-0.5 rounded-full border border-indigo-100">
                            ⏱️ {s.transitDays}
                          </span>
                          <div className="w-24 sm:w-32 h-0.5 bg-indigo-300 relative my-1">
                            <div className="absolute left-1/2 -top-1.5 -translate-x-1/2 w-3 h-3 bg-indigo-600 rounded-full border-2 border-white shadow-xs" />
                          </div>
                          <span className="text-[9px] font-semibold text-slate-400">Ocean Transit</span>
                        </div>

                        <div className="space-y-1 text-right">
                          <div className="text-[10px] uppercase font-bold text-slate-400">POD</div>
                          <div className="font-extrabold text-slate-800 truncate max-w-[130px]">{s.podName || s.podCode || 'POD'}</div>
                          <div className="text-purple-700 font-bold text-[11px]">ETA: {s.eta}</div>
                        </div>
                      </div>

                      {/* Cutoff Details Grid */}
                      <div className="grid grid-cols-2 sm:grid-cols-4 gap-2 text-xs">
                        <div className="bg-emerald-50/60 border border-emerald-200/70 p-2 rounded-xl">
                          <div className="text-[9px] font-bold text-emerald-800 uppercase">Gate Open</div>
                          <div className="font-extrabold text-emerald-950 mt-0.5 text-[11px]">{s.gateOpenDate || 'Open'}</div>
                        </div>
                        <div className="bg-amber-50/60 border border-amber-200/70 p-2 rounded-xl">
                          <div className="text-[9px] font-bold text-amber-800 uppercase">Gate Cutoff</div>
                          <div className="font-extrabold text-amber-950 mt-0.5 text-[11px]">{s.gateCutoff}</div>
                        </div>
                        <div className="bg-blue-50/60 border border-blue-200/70 p-2 rounded-xl">
                          <div className="text-[9px] font-bold text-blue-800 uppercase">Doc Cutoff</div>
                          <div className="font-extrabold text-blue-950 mt-0.5 text-[11px]">{s.docCutoff || '—'}</div>
                        </div>
                        <div className="bg-purple-50/60 border border-purple-200/70 p-2 rounded-xl">
                          <div className="text-[9px] font-bold text-purple-800 uppercase">S/Bill Cutoff</div>
                          <div className="font-extrabold text-purple-950 mt-0.5 text-[11px]">{s.sbCutoff || '—'}</div>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              )}
            </div>
          )}
        </div>
      )}

      {/* API Key Configuration Modal */}
      {showConfigModal && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-slate-950/70 backdrop-blur-xs">
          <div className="bg-white rounded-3xl max-w-xl w-full p-6 sm:p-8 shadow-2xl border border-slate-200 space-y-5 relative max-h-[90vh] overflow-y-auto">
            <div className="flex items-center justify-between border-b border-slate-100 pb-4">
              <div className="flex items-center gap-3">
                <div className="w-10 h-10 rounded-2xl bg-amber-50 text-amber-600 border border-amber-200 flex items-center justify-center font-bold">
                  <Key className="w-5 h-5" />
                </div>
                <div>
                  <h3 className="text-base font-extrabold text-slate-900">Vessel API & Scraper Integration</h3>
                  <p className="text-xs text-slate-500">Configure Apify Token & Hapag-Lloyd DCSA Credentials</p>
                </div>
              </div>
              <button
                onClick={() => setShowConfigModal(false)}
                className="text-slate-400 hover:text-slate-600 text-lg font-bold p-1 cursor-pointer"
              >
                ✕
              </button>
            </div>

            {configMessage && (
              <div className={`p-3.5 rounded-2xl text-xs font-bold ${
                configMessage.type === 'success' ? 'bg-emerald-50 text-emerald-800 border border-emerald-200' : 'bg-rose-50 text-rose-800 border border-rose-200'
              }`}>
                {configMessage.text}
              </div>
            )}

            <form onSubmit={handleSaveConfig} className="space-y-4 text-xs">
              <div>
                <label className="block font-bold text-slate-700 mb-1">Apify Web Scraper API Token</label>
                <input
                  type="password"
                  value={config.apifyToken || ''}
                  onChange={(e) => setConfig({ ...config, apifyToken: e.target.value })}
                  placeholder="apify_api_..."
                  className="w-full bg-slate-50 border border-slate-300 rounded-xl px-3 py-2 font-mono text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white"
                />
              </div>

              <div>
                <label className="block font-bold text-slate-700 mb-1">AISstream Live Vessel GPS API Key</label>
                <input
                  type="password"
                  value={config.aisStreamKey || ''}
                  onChange={(e) => setConfig({ ...config, aisStreamKey: e.target.value })}
                  placeholder="aisstream_key_..."
                  className="w-full bg-slate-50 border border-slate-300 rounded-xl px-3 py-2 font-mono text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white"
                />
              </div>

              <div className="pt-2 flex justify-end gap-3">
                <button
                  type="button"
                  onClick={() => setShowConfigModal(false)}
                  className="px-4 py-2 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-xl font-bold cursor-pointer"
                >
                  Cancel
                </button>
                <button
                  type="submit"
                  disabled={configSaving}
                  className="px-5 py-2 bg-indigo-600 hover:bg-indigo-700 text-white rounded-xl font-extrabold cursor-pointer flex items-center gap-2"
                >
                  {configSaving ? <RefreshCw className="w-3.5 h-3.5 animate-spin" /> : <ShieldCheck className="w-3.5 h-3.5" />}
                  <span>Save Configuration</span>
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}
