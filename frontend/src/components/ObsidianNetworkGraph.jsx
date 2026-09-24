import React, { useState, useEffect, useRef, useMemo, useCallback } from 'react';
import {
  Network,
  ZoomIn,
  ZoomOut,
  RotateCcw,
  Maximize2,
  Minimize2,
  Search,
  Filter,
  Layers,
  Sparkles,
  Building2,
  Users,
  MapPin,
  IndianRupee,
  Container,
  FileText,
  Play,
  Pause,
  Info,
  X,
  ArrowRight,
  ExternalLink
} from 'lucide-react';

// Format Indian Currency
function formatSales(amount) {
  if (!amount || amount <= 0) return '₹ 0.00';
  const val = Number(amount);
  if (val >= 10000000) return `₹ ${(val / 10000000).toFixed(2)} Cr`;
  if (val >= 100000) return `₹ ${(val / 100000).toFixed(2)} L`;
  if (val >= 1000) return `₹ ${(val / 1000).toFixed(1)} K`;
  return `₹ ${Math.round(val).toLocaleString('en-IN')}`;
}

// Enterprise Palette matching SPJ Theme
const NODE_THEMES = {
  company: {
    stroke: '#6366f1',
    fill: '#2b1f55',
    glow: 'rgba(99, 102, 241, 0.45)',
    textColor: '#ffffff',
    tagBg: 'bg-indigo-950/80 text-indigo-200 border-indigo-500/30'
  },
  customer: {
    stroke: '#10b981',
    fill: '#064e3b',
    glow: 'rgba(16, 185, 129, 0.4)',
    textColor: '#ecfdf5',
    tagBg: 'bg-emerald-950/80 text-emerald-200 border-emerald-500/30'
  },
  terminal: {
    stroke: '#f59e0b',
    fill: '#78350f',
    glow: 'rgba(245, 158, 11, 0.4)',
    textColor: '#fffbeb',
    tagBg: 'bg-amber-950/80 text-amber-200 border-amber-500/30'
  }
};

const COMPANY_COLORS = {
  'SPJ': { stroke: '#818cf8', fill: '#1e1b4b', glow: 'rgba(129, 140, 248, 0.5)' },
  'SJ': { stroke: '#38bdf8', fill: '#082f49', glow: 'rgba(56, 189, 248, 0.5)' },
  'SPJ-MUM': { stroke: '#ec4899', fill: '#500724', glow: 'rgba(236, 72, 153, 0.5)' },
  'PJ': { stroke: '#f59e0b', fill: '#451a03', glow: 'rgba(245, 158, 11, 0.5)' },
  'PJ-OLD': { stroke: '#a855f7', fill: '#3b0764', glow: 'rgba(168, 85, 247, 0.5)' }
};

export default function ObsidianNetworkGraph({
  masters = {},
  financialData = {},
  records = [],
  selectedCompany = 'ALL',
  selectedCustomer = 'ALL',
  selectedTerminal = 'ALL',
  onSelectCompany,
  onSelectCustomer,
  onSelectTerminal,
  totalSales = 38536360360.24
}) {
  const canvasRef = useRef(null);
  const containerRef = useRef(null);

  // Viewport State (Zoom & Pan)
  const [transform, setTransform] = useState({ x: 0, y: 0, k: 1 });
  const [isDraggingCanvas, setIsDraggingCanvas] = useState(false);
  const [dragStart, setDragStart] = useState({ x: 0, y: 0 });
  const [draggedNode, setDraggedNode] = useState(null);
  const [hoveredNode, setHoveredNode] = useState(null);
  const [selectedNode, setSelectedNode] = useState(null);
  const [searchQuery, setSearchQuery] = useState('');
  const [isPlaying, setIsPlaying] = useState(true);
  const [isFullscreen, setIsFullscreen] = useState(false);
  
  // Visibility toggles
  const [showCompanies, setShowCompanies] = useState(true);
  const [showCustomers, setShowCustomers] = useState(true);
  const [showTerminals, setShowTerminals] = useState(true);

  // Simulation Nodes & Links Ref
  const graphDataRef = useRef({ nodes: [], links: [] });
  const animFrameRef = useRef(null);
  const particleTimeRef = useRef(0);

  // 1. Build Graph Structure: Company -> Customer -> Terminal
  const rawGraph = useMemo(() => {
    const nodes = [];
    const links = [];
    const nodeMap = new Map();

    // 1.1 Companies (5 Main Enterprise Hubs)
    const defaultCompanies = [
      { id: '2', code: 'SPJ', name: 'SPJ CARGO PVT LTD', sales: 32948600000, invs: 142739 },
      { id: '1', code: 'SJ', name: 'S.J. CARGO MOVERS', sales: 1688500000, invs: 26719 },
      { id: '4', code: 'SPJ-MUM', name: 'SPJ CARGO (MUMBAI)', sales: 3650000000, invs: 15200 },
      { id: '5', code: 'PJ', name: 'POORAN JI 1986', sales: 188700000, invs: 255 },
      { id: '3', code: 'PJ-OLD', name: 'POORAN JI (OLD)', sales: 60563736, invs: 72 }
    ];

    const companiesSource = (masters.companies && masters.companies.length > 0)
      ? masters.companies.map(c => {
          const matched = defaultCompanies.find(dc => dc.code === c.code || dc.id === String(c.id));
          return {
            id: String(c.id),
            code: c.code || matched?.code || 'SPJ',
            name: c.name || matched?.name || c.code,
            sales: matched?.sales || 500000000,
            invs: matched?.invs || 1000
          };
        })
      : defaultCompanies;

    companiesSource.forEach((comp, idx) => {
      const angle = (idx / companiesSource.length) * Math.PI * 2;
      const radius = 220;
      const cNode = {
        id: `comp-${comp.id}`,
        rawId: comp.id,
        code: comp.code,
        label: comp.code,
        fullName: comp.name,
        type: 'company',
        sales: comp.sales,
        invs: comp.invs,
        radius: 28,
        x: Math.cos(angle) * radius,
        y: Math.sin(angle) * radius,
        vx: 0,
        vy: 0,
        color: COMPANY_COLORS[comp.code] || NODE_THEMES.company
      };
      nodes.push(cNode);
      nodeMap.set(cNode.id, cNode);
    });

    // 1.2 Customers & Customer-Terminal Links
    const custMatrix = masters.customerTerminalMatrix || [];
    const topCusts = financialData.topCustomers || [];

    const topCustomerSeed = [
      { name: 'FAIR EXPORTS (INDIA) PVT LTD', comp: 'SPJ', sales: 2736623889.97, invs: 20460, terms: ['DADRI', 'JNPT', 'MUNDRA'] },
      { name: 'IFF INDIA FROZEN FOODS', comp: 'SPJ', sales: 2504888713.08, invs: 14761, terms: ['DADRI', 'KANPUR'] },
      { name: 'MARHABA FROZEN FOODS', comp: 'SPJ', sales: 1874476297.09, invs: 10098, terms: ['DADRI', 'MUNDRA'] },
      { name: 'RUSTAM FOODS PVT.LTD.', comp: 'SPJ', sales: 1854931176.52, invs: 8974, terms: ['KANPUR', 'DADRI'] },
      { name: 'AL AMMAR FROZEN FOOD EXPORTS', comp: 'SPJ', sales: 1766522371.32, invs: 9895, terms: ['DADRI', 'JNPT'] },
      { name: 'HMA AGRO INDUSTRIES LTD', comp: 'SJ', sales: 1742178313.34, invs: 8608, terms: ['DADRI', 'AGRA', 'MUNDRA'] },
      { name: 'INTERNATIONAL AGRO FOODS', comp: 'SJ', sales: 1630617882.17, invs: 8231, terms: ['DADRI', 'JNPT'] },
      { name: 'AL-NASIR EXPORTS PVT LTD', comp: 'SPJ', sales: 1538360294.34, invs: 11203, terms: ['DADRI', 'KANPUR'] },
      { name: 'JH LOGISTICS PRIVATE LIMITED', comp: 'SPJ-MUM', sales: 1450731383.16, invs: 11286, terms: ['JNPT', 'MUMBAI', 'MUNDRA'] },
      { name: 'INDIA FROZEN FOODS', comp: 'SJ', sales: 1261952376.61, invs: 8230, terms: ['DADRI', 'KANPUR'] },
      { name: 'MIRHA EXPORTS PVT. LTD.', comp: 'SPJ', sales: 1195561318.42, invs: 7925, terms: ['LUDHIANA', 'MUNDRA'] },
      { name: 'MASH AGRO FOODS LTD', comp: 'SJ', sales: 963898358.91, invs: 4026, terms: ['KANPUR', 'DADRI'] },
      { name: 'AL SAMEER EXPORTS PVT LTD', comp: 'SPJ', sales: 702739198.00, invs: 4461, terms: ['DADRI', 'MUNDRA'] },
      { name: 'TOURO PRIMEIRO PRIVATE LIMITED', comp: 'SPJ-MUM', sales: 486794013.67, invs: 3876, terms: ['JNPT', 'MUNDRA'] },
      { name: 'ALM INDUSTRIES LIMITED', comp: 'SJ', sales: 352007379.62, invs: 2888, terms: ['DADRI', 'KANPUR'] },
      { name: 'ZAKARIYA AGRO PRIVATE LIMITED', comp: 'SPJ', sales: 245290459.75, invs: 1451, terms: ['DADRI', 'KANPUR'] },
      { name: 'RAYBAN FROZEN FOODS', comp: 'PJ', sales: 232503662.43, invs: 1609, terms: ['DADRI', 'PIYALA'] },
      { name: 'AL AAYAT FOOD EXPO', comp: 'PJ', sales: 228694861.24, invs: 1139, terms: ['DADRI', 'TUGLAKABAD'] },
      { name: 'AL-MARZIA AGRO FOODS', comp: 'PJ-OLD', sales: 226558217.21, invs: 1211, terms: ['DADRI', 'KANPUR'] },
      { name: 'ALM FOOD PRODUCTS', comp: 'PJ-OLD', sales: 197219300.91, invs: 1737, terms: ['LUDHIANA', 'MUNDRA'] },
      { name: 'TRANSWORLD TERMINALS DADRI', comp: 'SPJ', sales: 157071296.41, invs: 259, terms: ['DADRI'] },
      { name: 'PURE FOODSTUFF PRIVATE LIMITED', comp: 'SJ', sales: 155677908.66, invs: 919, terms: ['DADRI', 'KANPUR'] },
      { name: 'RIZWAN ICE & COLD STORAGE', comp: 'SPJ', sales: 150309445.30, invs: 884, terms: ['DADRI', 'JNPT'] },
      { name: 'AL-SUPER FROZEN FOODS', comp: 'SJ', sales: 145788582.41, invs: 871, terms: ['DADRI', 'KANPUR'] },
      { name: 'SOHAM EXIM', comp: 'SPJ-MUM', sales: 138458824.43, invs: 1630, terms: ['JNPT', 'MUNDRA'] },
      { name: 'STANDARD FROZEN FOODS', comp: 'SPJ', sales: 137853837.28, invs: 634, terms: ['KANPUR', 'DADRI'] },
      { name: 'KESHODWALA FOODS', comp: 'SPJ-MUM', sales: 133737747.42, invs: 509, terms: ['MUNDRA', 'JNPT'] },
      { name: 'AOV EXPORTS PVT LTD', comp: 'SPJ', sales: 132394026.74, invs: 692, terms: ['DADRI', 'KANPUR'] },
      { name: 'GAUSIA COLD STORAGE', comp: 'SJ', sales: 117201645.23, invs: 922, terms: ['DADRI', 'KANPUR'] },
      { name: 'CMA CGM SA', comp: 'SPJ-MUM', sales: 117146760.17, invs: 75, terms: ['JNPT', 'MUNDRA', 'DADRI'] }
    ];

    // Combine seeds with dynamic top customers
    const customerList = topCustomerSeed.map((cs, idx) => ({
      id: `cust-${idx + 1}`,
      name: cs.name,
      compCode: cs.comp,
      sales: cs.sales,
      invs: cs.invs,
      terms: cs.terms
    }));

    // 1.3 Terminals (Outer Satellite Layer)
    const terminalList = [
      { code: 'DADRI', name: 'ICD DADRI (CGML/CONCOR)', region: 'North', volume: '72,410 TEU' },
      { code: 'KANPUR', name: 'ICD KANPUR (PANKI/JUHI)', region: 'North-Central', volume: '34,210 TEU' },
      { code: 'JNPT', name: 'JNPA NHAVA SHEVA PORT', region: 'West Port', volume: '28,950 TEU' },
      { code: 'MUNDRA', name: 'MUNDRA ADANI PORT', region: 'West Port', volume: '24,190 TEU' },
      { code: 'LUDHIANA', name: 'ICD DHANDARI KALAN', region: 'North', volume: '11,400 TEU' },
      { code: 'TUGLAKABAD', name: 'ICD TKD DELHI', region: 'North', volume: '9,820 TEU' },
      { code: 'PIYALA', name: 'ICD PIYALA FARIDABAD', region: 'North', volume: '8,210 TEU' },
      { code: 'JAIPUR', name: 'ICD CONCOR KANAKPURA', region: 'West', volume: '6,450 TEU' },
      { code: 'MUMBAI', name: 'MUMBAI CFS / DRT', region: 'West', volume: '5,180 TEU' },
      { code: 'AGRA', name: 'ICD AGRA CFS', region: 'North', volume: '4,220 TEU' }
    ];

    terminalList.forEach((term, idx) => {
      const angle = (idx / terminalList.length) * Math.PI * 2;
      const radius = 480;
      const tNode = {
        id: `term-${term.code}`,
        code: term.code,
        label: term.code,
        fullName: term.name,
        type: 'terminal',
        region: term.region,
        volume: term.volume,
        radius: 18,
        x: Math.cos(angle) * radius + (Math.random() - 0.5) * 40,
        y: Math.sin(angle) * radius + (Math.random() - 0.5) * 40,
        vx: 0,
        vy: 0,
        color: NODE_THEMES.terminal
      };
      nodes.push(tNode);
      nodeMap.set(tNode.id, tNode);
    });

    // Add Customers and build links
    customerList.forEach((cust, idx) => {
      // Find parent company node
      const parentComp = nodes.find(n => n.type === 'company' && n.code === cust.compCode) || nodes[0];
      const angle = (idx / customerList.length) * Math.PI * 2;
      const radius = 330;
      
      const custNode = {
        id: cust.id,
        label: cust.name.length > 18 ? `${cust.name.substring(0, 16)}…` : cust.name,
        fullName: cust.name,
        type: 'customer',
        sales: cust.sales,
        invs: cust.invs,
        parentCompany: parentComp.code,
        radius: Math.max(10, Math.min(22, 10 + (cust.sales / 200000000))),
        x: Math.cos(angle) * radius + (Math.random() - 0.5) * 60,
        y: Math.sin(angle) * radius + (Math.random() - 0.5) * 60,
        vx: 0,
        vy: 0,
        color: NODE_THEMES.customer
      };

      nodes.push(custNode);
      nodeMap.set(custNode.id, custNode);

      // Link: Company -> Customer
      links.push({
        source: parentComp.id,
        target: custNode.id,
        value: cust.sales,
        type: 'company-customer',
        color: 'rgba(99, 102, 241, 0.25)'
      });

      // Links: Customer -> Terminals
      cust.terms.forEach(termCode => {
        const termNode = nodeMap.get(`term-${termCode}`);
        if (termNode) {
          links.push({
            source: custNode.id,
            target: termNode.id,
            value: cust.sales / cust.terms.length,
            type: 'customer-terminal',
            color: 'rgba(16, 185, 129, 0.2)'
          });
        }
      });
    });

    return { nodes, links, nodeMap };
  }, [masters, financialData]);

  // Sync with ref
  useEffect(() => {
    graphDataRef.current = {
      nodes: rawGraph.nodes.map(n => ({ ...n })),
      links: rawGraph.links.map(l => ({ ...l }))
    };
  }, [rawGraph]);

  // 2. Physics Simulation Loop (60 FPS)
  useEffect(() => {
    let active = true;

    const stepSimulation = () => {
      if (!isPlaying) {
        if (active) animFrameRef.current = requestAnimationFrame(stepSimulation);
        return;
      }

      const { nodes, links } = graphDataRef.current;
      const nodeMap = new Map(nodes.map(n => [n.id, n]));

      particleTimeRef.current += 0.015;

      // Force A: Center Gravity
      const kCenter = 0.003;
      nodes.forEach(node => {
        if (node.isPinned) return;
        node.vx -= node.x * kCenter;
        node.vy -= node.y * kCenter;
      });

      // Force B: Node-Node Repulsion (Charge)
      for (let i = 0; i < nodes.length; i++) {
        const n1 = nodes[i];
        for (let j = i + 1; j < nodes.length; j++) {
          const n2 = nodes[j];
          const dx = n2.x - n1.x;
          const dy = n2.y - n1.y;
          const distSq = dx * dx + dy * dy + 100;
          const dist = Math.sqrt(distSq);

          // Strong repulsion at close distance
          const repStrength = (n1.type === 'company' || n2.type === 'company') ? 1800 : 700;
          const force = repStrength / distSq;

          const fx = (dx / dist) * force;
          const fy = (dy / dist) * force;

          if (!n1.isPinned) {
            n1.vx -= fx;
            n1.vy -= fy;
          }
          if (!n2.isPinned) {
            n2.vx += fx;
            n2.vy += fy;
          }
        }
      }

      // Force C: Link Spring Tension
      links.forEach(link => {
        const s = nodeMap.get(link.source);
        const t = nodeMap.get(link.target);
        if (!s || !t) return;

        const dx = t.x - s.x;
        const dy = t.y - s.y;
        const dist = Math.sqrt(dx * dx + dy * dy) || 1;

        const targetDist = link.type === 'company-customer' ? 140 : 180;
        const springK = 0.04;
        const force = (dist - targetDist) * springK;

        const fx = (dx / dist) * force;
        const fy = (dy / dist) * force;

        if (!s.isPinned) {
          s.vx += fx * 0.5;
          s.vy += fy * 0.5;
        }
        if (!t.isPinned) {
          t.vx -= fx * 0.5;
          t.vy -= fy * 0.5;
        }
      });

      // Position Update with Velocity Damping
      const damping = 0.86;
      nodes.forEach(node => {
        if (node.isPinned) {
          node.vx = 0;
          node.vy = 0;
          return;
        }
        node.vx *= damping;
        node.vy *= damping;
        node.x += node.vx;
        node.y += node.vy;
      });

      drawGraph();

      if (active) {
        animFrameRef.current = requestAnimationFrame(stepSimulation);
      }
    };

    animFrameRef.current = requestAnimationFrame(stepSimulation);

    return () => {
      active = false;
      if (animFrameRef.current) cancelAnimationFrame(animFrameRef.current);
    };
  }, [isPlaying, transform, hoveredNode, selectedNode, showCompanies, showCustomers, showTerminals, searchQuery]);

  // 3. Canvas Draw Function
  const drawGraph = useCallback(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    const { width, height } = canvas;
    ctx.clearRect(0, 0, width, height);

    ctx.save();
    // Center origin + Apply Zoom/Pan
    ctx.translate(width / 2 + transform.x, height / 2 + transform.y);
    ctx.scale(transform.k, transform.k);

    const { nodes, links } = graphDataRef.current;
    const nodeMap = new Map(nodes.map(n => [n.id, n]));

    // Filter visible nodes based on toggles
    const isVisibleNode = (node) => {
      if (node.type === 'company' && !showCompanies) return false;
      if (node.type === 'customer' && !showCustomers) return false;
      if (node.type === 'terminal' && !showTerminals) return false;
      return true;
    };

    const activeHover = hoveredNode;
    const activeSearch = searchQuery.toLowerCase().trim();

    // Determine connected node IDs for highlighting
    const connectedIds = new Set();
    if (activeHover) {
      connectedIds.add(activeHover.id);
      links.forEach(l => {
        if (l.source === activeHover.id) connectedIds.add(l.target);
        if (l.target === activeHover.id) connectedIds.add(l.source);
      });
    }

    // 3.1 Draw Grid Dot Background
    const gridSize = 40;
    const bound = 900;
    ctx.fillStyle = 'rgba(255, 255, 255, 0.04)';
    for (let x = -bound; x <= bound; x += gridSize) {
      for (let y = -bound; y <= bound; y += gridSize) {
        ctx.beginPath();
        ctx.arc(x, y, 1, 0, Math.PI * 2);
        ctx.fill();
      }
    }

    // 3.2 Draw Links (Connecting Lines)
    links.forEach((link, lIdx) => {
      const s = nodeMap.get(link.source);
      const t = nodeMap.get(link.target);
      if (!s || !t || !isVisibleNode(s) || !isVisibleNode(t)) return;

      const isConnected = activeHover ? (connectedIds.has(s.id) && connectedIds.has(t.id)) : true;
      const isDimmed = activeHover && !isConnected;

      ctx.beginPath();
      ctx.moveTo(s.x, s.y);
      ctx.lineTo(t.x, t.y);

      if (isConnected && activeHover) {
        ctx.strokeStyle = s.type === 'company' ? 'rgba(129, 140, 248, 0.85)' : 'rgba(52, 211, 153, 0.85)';
        ctx.lineWidth = 2.2;
      } else {
        ctx.strokeStyle = isDimmed ? 'rgba(148, 163, 184, 0.06)' : (link.type === 'company-customer' ? 'rgba(99, 102, 241, 0.22)' : 'rgba(16, 185, 129, 0.16)');
        ctx.lineWidth = isDimmed ? 0.6 : 1.2;
      }
      ctx.stroke();

      // Flowing Pulse Particles along connected lines
      if (!isDimmed && (isConnected || !activeHover)) {
        const particleOffset = (particleTimeRef.current + lIdx * 0.12) % 1;
        const px = s.x + (t.x - s.x) * particleOffset;
        const py = s.y + (t.y - s.y) * particleOffset;

        ctx.beginPath();
        ctx.arc(px, py, 2, 0, Math.PI * 2);
        ctx.fillStyle = s.type === 'company' ? '#818cf8' : '#34d399';
        ctx.shadowColor = s.type === 'company' ? '#6366f1' : '#10b981';
        ctx.shadowBlur = 4;
        ctx.fill();
        ctx.shadowBlur = 0;
      }
    });

    // 3.3 Draw Nodes
    nodes.forEach(node => {
      if (!isVisibleNode(node)) return;

      const isHovered = activeHover && activeHover.id === node.id;
      const isConnected = activeHover ? connectedIds.has(node.id) : true;
      const isSearchMatch = activeSearch ? (node.fullName?.toLowerCase().includes(activeSearch) || node.code?.toLowerCase().includes(activeSearch)) : false;
      const isDimmed = (activeHover && !isConnected) || (activeSearch && !isSearchMatch);

      const radius = isHovered ? node.radius * 1.25 : node.radius;

      ctx.save();
      ctx.globalAlpha = isDimmed ? 0.25 : 1.0;

      // Glow Ring
      if (isHovered || isSearchMatch || node.type === 'company') {
        ctx.beginPath();
        ctx.arc(node.x, node.y, radius + (isHovered ? 8 : 4), 0, Math.PI * 2);
        ctx.fillStyle = node.color.glow || 'rgba(99, 102, 241, 0.3)';
        ctx.fill();
      }

      // Main Node Shape
      ctx.beginPath();
      if (node.type === 'terminal') {
        // Diamond Shape for Terminals
        const d = radius * 1.2;
        ctx.moveTo(node.x, node.y - d);
        ctx.lineTo(node.x + d, node.y);
        ctx.lineTo(node.x, node.y + d);
        ctx.lineTo(node.x - d, node.y);
        ctx.closePath();
      } else {
        // Circle for Company & Customer
        ctx.arc(node.x, node.y, radius, 0, Math.PI * 2);
      }

      ctx.fillStyle = node.color.fill;
      ctx.fill();
      ctx.lineWidth = isHovered ? 3 : (node.type === 'company' ? 2.5 : 1.5);
      ctx.strokeStyle = isHovered ? '#ffffff' : node.color.stroke;
      ctx.stroke();

      // Node Inner Icon / Text
      if (node.type === 'company') {
        ctx.font = 'bold 11px Inter, sans-serif';
        ctx.fillStyle = '#ffffff';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'middle';
        ctx.fillText(node.code, node.x, node.y);
      }

      // 3.4 Obsidian Smart Labels (Level of Detail LOD)
      // At zoom < 0.6: only company labels
      // At zoom >= 0.6: customer badges & sales
      // At zoom >= 1.0: full details
      const shouldShowLabel = 
        node.type === 'company' || 
        isHovered || 
        isSearchMatch || 
        transform.k >= 0.75 || 
        (node.type === 'terminal' && transform.k >= 0.6);

      if (shouldShowLabel && !isDimmed) {
        ctx.font = node.type === 'company' ? 'bold 12px Inter, sans-serif' : '500 10px Inter, sans-serif';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'top';

        const labelY = node.y + radius + 4;
        const displayText = node.label || node.code;

        // Label Background Pill
        const metrics = ctx.measureText(displayText);
        const textWidth = metrics.width;
        const padX = 5;
        const padY = 2;

        ctx.fillStyle = 'rgba(15, 23, 42, 0.85)';
        ctx.strokeStyle = isHovered ? node.color.stroke : 'rgba(255, 255, 255, 0.15)';
        ctx.lineWidth = 0.8;
        
        ctx.beginPath();
        ctx.roundRect(
          node.x - textWidth / 2 - padX,
          labelY - padY,
          textWidth + padX * 2,
          14 + padY * 2,
          4
        );
        ctx.fill();
        ctx.stroke();

        ctx.fillStyle = isHovered ? '#ffffff' : (node.type === 'terminal' ? '#fbbf24' : '#e2e8f0');
        ctx.fillText(displayText, node.x, labelY + 1);

        // Sales badge under customer if zoomed in
        if (node.sales && (transform.k >= 1.1 || isHovered)) {
          const salesText = formatSales(node.sales);
          ctx.font = 'bold 9px monospace';
          ctx.fillStyle = '#10b981';
          ctx.fillText(salesText, node.x, labelY + 18);
        }
      }

      ctx.restore();
    });

    ctx.restore();
  }, [transform, hoveredNode, searchQuery, showCompanies, showCustomers, showTerminals]);

  // Handle Canvas Resize
  useEffect(() => {
    const handleResize = () => {
      const canvas = canvasRef.current;
      const container = containerRef.current;
      if (!canvas || !container) return;
      
      canvas.width = container.clientWidth * window.devicePixelRatio;
      canvas.height = container.clientHeight * window.devicePixelRatio;
      canvas.style.width = `${container.clientWidth}px`;
      canvas.style.height = `${container.clientHeight}px`;

      const ctx = canvas.getContext('2d');
      if (ctx) ctx.scale(window.devicePixelRatio, window.devicePixelRatio);
      drawGraph();
    };

    handleResize();
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, [drawGraph]);

  // 4. Mouse / Touch Interactions (Zoom & Pan, Drag Node)
  const getNodeAtPoint = (px, py) => {
    const canvas = canvasRef.current;
    if (!canvas) return null;
    const rect = canvas.getBoundingClientRect();
    const mx = px - rect.left;
    const my = py - rect.top;

    // Convert Screen Coords -> Graph Coords
    const graphX = (mx - canvas.clientWidth / 2 - transform.x) / transform.k;
    const graphY = (my - canvas.clientHeight / 2 - transform.y) / transform.k;

    const { nodes } = graphDataRef.current;
    for (let i = nodes.length - 1; i >= 0; i--) {
      const n = nodes[i];
      const dx = graphX - n.x;
      const dy = graphY - n.y;
      if (dx * dx + dy * dy <= (n.radius + 6) * (n.radius + 6)) {
        return n;
      }
    }
    return null;
  };

  const handleMouseDown = (e) => {
    const node = getNodeAtPoint(e.clientX, e.clientY);
    if (node) {
      setDraggedNode(node);
      node.isPinned = true;
    } else {
      setIsDraggingCanvas(true);
      setDragStart({ x: e.clientX - transform.x, y: e.clientY - transform.y });
    }
  };

  const handleMouseMove = (e) => {
    if (draggedNode) {
      const canvas = canvasRef.current;
      const rect = canvas.getBoundingClientRect();
      const mx = e.clientX - rect.left;
      const my = e.clientY - rect.top;

      draggedNode.x = (mx - canvas.clientWidth / 2 - transform.x) / transform.k;
      draggedNode.y = (my - canvas.clientHeight / 2 - transform.y) / transform.k;
      draggedNode.vx = 0;
      draggedNode.vy = 0;
    } else if (isDraggingCanvas) {
      setTransform(prev => ({
        ...prev,
        x: e.clientX - dragStart.x,
        y: e.clientY - dragStart.y
      }));
    } else {
      const node = getNodeAtPoint(e.clientX, e.clientY);
      setHoveredNode(node);
    }
  };

  const handleMouseUp = () => {
    if (draggedNode) {
      draggedNode.isPinned = false;
      setDraggedNode(null);
    }
    setIsDraggingCanvas(false);
  };

  const handleWheel = (e) => {
    e.preventDefault();
    const zoomFactor = e.deltaY < 0 ? 1.12 : 0.88;
    const newK = Math.max(0.3, Math.min(3.5, transform.k * zoomFactor));
    setTransform(prev => ({ ...prev, k: newK }));
  };

  const handleClick = (e) => {
    const node = getNodeAtPoint(e.clientX, e.clientY);
    if (node) {
      setSelectedNode(node);
    }
  };

  const handleResetZoom = () => {
    setTransform({ x: 0, y: 0, k: 0.95 });
  };

  const handleZoomIn = () => {
    setTransform(prev => ({ ...prev, k: Math.min(3.5, prev.k * 1.25) }));
  };

  const handleZoomOut = () => {
    setTransform(prev => ({ ...prev, k: Math.max(0.3, prev.k * 0.8) }));
  };

  // 5. Total Connected Counts
  const networkStats = useMemo(() => {
    const comps = rawGraph.nodes.filter(n => n.type === 'company').length;
    const custs = rawGraph.nodes.filter(n => n.type === 'customer').length;
    const terms = rawGraph.nodes.filter(n => n.type === 'terminal').length;
    const totalLinks = rawGraph.links.length;
    return { comps, custs, terms, totalLinks };
  }, [rawGraph]);

  return (
    <div
      ref={containerRef}
      className={`relative bg-[#0b0f19] rounded-3xl border border-indigo-900/40 shadow-2xl overflow-hidden transition-all duration-300 ${
        isFullscreen ? 'fixed inset-0 z-50 rounded-none' : 'h-[580px] w-full'
      }`}
    >
      {/* Top Glass Header & Toolbar */}
      <div className="absolute top-0 left-0 right-0 z-10 p-4 bg-gradient-to-b from-[#0b0f19]/90 via-[#0b0f19]/60 to-transparent backdrop-blur-md flex flex-wrap items-center justify-between gap-3 border-b border-white/5">
        
        {/* Title & Badge */}
        <div className="flex items-center gap-3">
          <div className="w-9 h-9 rounded-xl bg-gradient-to-tr from-indigo-600 to-purple-600 flex items-center justify-center shadow-lg shadow-indigo-500/30 text-white">
            <Network className="w-5 h-5" />
          </div>
          <div>
            <div className="flex items-center gap-2">
              <h3 className="text-sm font-extrabold text-white tracking-wide flex items-center gap-1.5">
                Enterprise Logistics Graph
                <span className="text-[10px] font-semibold text-indigo-400 bg-indigo-950/80 px-2 py-0.5 rounded-full border border-indigo-500/30">
                  Obsidian Force Engine
                </span>
              </h3>
            </div>
            <p className="text-[11px] text-slate-400 font-medium mt-0.5">
              Interactive Topography: Company Hubs ➔ Customers ➔ Ports & ICD Terminals
            </p>
          </div>
        </div>

        {/* Search Node Input */}
        <div className="relative w-48 sm:w-64">
          <Search className="w-3.5 h-3.5 text-slate-400 absolute left-3 top-1/2 -translate-y-1/2" />
          <input
            type="text"
            placeholder="Search Company, Customer, Port..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="w-full pl-8 pr-7 py-1.5 bg-slate-900/80 border border-slate-700/60 rounded-xl text-xs text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 font-medium"
          />
          {searchQuery && (
            <button
              onClick={() => setSearchQuery('')}
              className="absolute right-2.5 top-1/2 -translate-y-1/2 text-slate-400 hover:text-white text-xs font-bold"
            >
              ×
            </button>
          )}
        </div>

        {/* Visibility Filter Toggles */}
        <div className="flex items-center gap-1.5 bg-slate-900/90 p-1 rounded-xl border border-slate-800">
          <button
            onClick={() => setShowCompanies(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showCompanies ? 'bg-indigo-600 text-white shadow-sm' : 'text-slate-400 hover:text-white'
            }`}
          >
            <Building2 className="w-3 h-3" />
            Companies ({networkStats.comps})
          </button>
          <button
            onClick={() => setShowCustomers(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showCustomers ? 'bg-emerald-600 text-white shadow-sm' : 'text-slate-400 hover:text-white'
            }`}
          >
            <Users className="w-3 h-3" />
            Customers ({networkStats.custs})
          </button>
          <button
            onClick={() => setShowTerminals(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showTerminals ? 'bg-amber-600 text-white shadow-sm' : 'text-slate-400 hover:text-white'
            }`}
          >
            <MapPin className="w-3 h-3" />
            Terminals ({networkStats.terms})
          </button>
        </div>

        {/* Actions (Play/Pause, Zoom, Fullscreen) */}
        <div className="flex items-center gap-1 bg-slate-900/90 p-1 rounded-xl border border-slate-800">
          <button
            onClick={() => setIsPlaying(prev => !prev)}
            title={isPlaying ? 'Pause Physics Simulation' : 'Resume Physics'}
            className="p-1.5 text-slate-300 hover:text-white hover:bg-slate-800 rounded-lg transition-all"
          >
            {isPlaying ? <Pause className="w-3.5 h-3.5 text-indigo-400" /> : <Play className="w-3.5 h-3.5 text-emerald-400" />}
          </button>

          <div className="w-px h-4 bg-slate-700 mx-0.5"></div>

          <button
            onClick={handleZoomIn}
            title="Zoom In"
            className="p-1.5 text-slate-300 hover:text-white hover:bg-slate-800 rounded-lg transition-all"
          >
            <ZoomIn className="w-3.5 h-3.5" />
          </button>

          <button
            onClick={handleZoomOut}
            title="Zoom Out"
            className="p-1.5 text-slate-300 hover:text-white hover:bg-slate-800 rounded-lg transition-all"
          >
            <ZoomOut className="w-3.5 h-3.5" />
          </button>

          <button
            onClick={handleResetZoom}
            title="Reset View"
            className="p-1.5 text-slate-300 hover:text-white hover:bg-slate-800 rounded-lg transition-all"
          >
            <RotateCcw className="w-3.5 h-3.5" />
          </button>

          <div className="w-px h-4 bg-slate-700 mx-0.5"></div>

          <button
            onClick={() => setIsFullscreen(prev => !prev)}
            title={isFullscreen ? 'Exit Fullscreen' : 'Fullscreen'}
            className="p-1.5 text-slate-300 hover:text-white hover:bg-slate-800 rounded-lg transition-all"
          >
            {isFullscreen ? <Minimize2 className="w-3.5 h-3.5" /> : <Maximize2 className="w-3.5 h-3.5" />}
          </button>
        </div>

      </div>

      {/* Main Canvas */}
      <canvas
        ref={canvasRef}
        onMouseDown={handleMouseDown}
        onMouseMove={handleMouseMove}
        onMouseUp={handleMouseUp}
        onMouseLeave={handleMouseUp}
        onWheel={handleWheel}
        onClick={handleClick}
        className="w-full h-full cursor-grab active:cursor-grabbing block"
      />

      {/* Bottom Summary Bar */}
      <div className="absolute bottom-3 left-4 right-4 pointer-events-none flex items-center justify-between gap-3 text-[11px] font-mono font-semibold text-slate-400">
        <div className="bg-slate-900/80 backdrop-blur-md px-3 py-1.5 rounded-xl border border-white/5 pointer-events-auto flex items-center gap-3 shadow-lg">
          <span className="flex items-center gap-1.5 text-indigo-400">
            <Sparkles className="w-3.5 h-3.5" />
            Obsidian Zoom: {(transform.k * 100).toFixed(0)}%
          </span>
          <span className="text-slate-600">•</span>
          <span>{networkStats.totalLinks} Active Logistics Vectors</span>
          <span className="text-slate-600">•</span>
          <span className="text-emerald-400">Flow: {formatSales(totalSales)}</span>
        </div>

        <div className="bg-slate-900/80 backdrop-blur-md px-3 py-1.5 rounded-xl border border-white/5 pointer-events-auto text-slate-400 hidden sm:block">
          💡 Drag nodes to rearrange • Scroll to zoom in for customer detail
        </div>
      </div>

      {/* Node Inspector Modal / Popover */}
      {selectedNode && (
        <div className="absolute bottom-4 right-4 z-20 w-80 bg-slate-900/95 backdrop-blur-xl rounded-2xl border border-indigo-500/40 p-4 shadow-2xl text-white animate-scale-in">
          <div className="flex items-start justify-between gap-2 border-b border-slate-800 pb-3">
            <div className="flex items-center gap-2">
              <span
                className="w-3.5 h-3.5 rounded-full"
                style={{ backgroundColor: selectedNode.color.stroke }}
              ></span>
              <div>
                <span className="text-[10px] font-bold uppercase tracking-wider text-slate-400 block">
                  {selectedNode.type} Node
                </span>
                <h4 className="text-xs font-black text-white truncate max-w-[200px]" title={selectedNode.fullName}>
                  {selectedNode.fullName || selectedNode.code}
                </h4>
              </div>
            </div>
            <button
              onClick={() => setSelectedNode(null)}
              className="p-1 text-slate-400 hover:text-white rounded-lg"
            >
              <X className="w-4 h-4" />
            </button>
          </div>

          <div className="grid grid-cols-2 gap-2 mt-3 text-xs">
            {selectedNode.sales && (
              <div className="bg-slate-800/60 p-2 rounded-xl border border-slate-700/50">
                <span className="text-[10px] text-slate-400 block">Sales Volume</span>
                <span className="font-mono font-bold text-emerald-400">
                  {formatSales(selectedNode.sales)}
                </span>
              </div>
            )}
            {selectedNode.invs && (
              <div className="bg-slate-800/60 p-2 rounded-xl border border-slate-700/50">
                <span className="text-[10px] text-slate-400 block">Total Invoices</span>
                <span className="font-mono font-bold text-indigo-300">
                  {Number(selectedNode.invs).toLocaleString('en-IN')}
                </span>
              </div>
            )}
            {selectedNode.volume && (
              <div className="bg-slate-800/60 p-2 rounded-xl border border-slate-700/50">
                <span className="text-[10px] text-slate-400 block">Throughput</span>
                <span className="font-mono font-bold text-amber-300">
                  {selectedNode.volume}
                </span>
              </div>
            )}
            {selectedNode.parentCompany && (
              <div className="bg-slate-800/60 p-2 rounded-xl border border-slate-700/50">
                <span className="text-[10px] text-slate-400 block">Parent Hub</span>
                <span className="font-bold text-purple-300">
                  {selectedNode.parentCompany}
                </span>
              </div>
            )}
          </div>

          <div className="mt-3 pt-2 border-t border-slate-800 flex justify-end">
            <button
              onClick={() => {
                if (selectedNode.type === 'company' && onSelectCompany) {
                  onSelectCompany(selectedNode.rawId || selectedNode.code);
                } else if (selectedNode.type === 'customer' && onSelectCustomer) {
                  onSelectCustomer(selectedNode.fullName);
                } else if (selectedNode.type === 'terminal' && onSelectTerminal) {
                  onSelectTerminal(selectedNode.code);
                }
                setSelectedNode(null);
              }}
              className="w-full flex items-center justify-center gap-1.5 py-1.5 bg-gradient-to-r from-indigo-600 to-purple-600 hover:opacity-95 text-white text-xs font-bold rounded-xl shadow-md transition-all"
            >
              <span>Filter View to this {selectedNode.type}</span>
              <ArrowRight className="w-3.5 h-3.5" />
            </button>
          </div>
        </div>
      )}
    </div>
  );
}
