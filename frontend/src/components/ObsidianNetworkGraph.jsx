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
  ExternalLink,
  Navigation
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

// Light Enterprise Palette matching SPJ Dashboard Theme
const NODE_THEMES = {
  company: {
    stroke: '#4f46e5',
    fill: '#1e1b4b',
    glow: 'rgba(79, 70, 229, 0.25)',
    textColor: '#ffffff',
    labelColor: '#1e1b4b'
  },
  customer: {
    stroke: '#059669',
    fill: '#10b981',
    glow: 'rgba(16, 185, 129, 0.25)',
    textColor: '#ffffff',
    labelColor: '#065f46'
  },
  terminal: {
    stroke: '#d97706',
    fill: '#f59e0b',
    glow: 'rgba(245, 158, 11, 0.25)',
    textColor: '#ffffff',
    labelColor: '#92400e'
  }
};

const COMPANY_COLORS = {
  'SPJ': { stroke: '#4f46e5', fill: '#2b1f55', glow: 'rgba(79, 70, 229, 0.35)' },
  'SJ': { stroke: '#0284c7', fill: '#0369a1', glow: 'rgba(2, 132, 199, 0.35)' },
  'SPJ-MUM': { stroke: '#db2777', fill: '#9d174d', glow: 'rgba(219, 39, 119, 0.35)' },
  'PJ': { stroke: '#d97706', fill: '#b45309', glow: 'rgba(217, 119, 6, 0.35)' },
  'PJ-OLD': { stroke: '#7c3aed', fill: '#5b21b6', glow: 'rgba(124, 58, 237, 0.35)' }
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

  // Viewport State (Zoom & Pan) - spacious default zoom (0.52)
  const [transform, setTransform] = useState({ x: 0, y: 0, k: 0.52 });
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

  // Derive Normalized Filter Code
  const normalizedCompanyCode = useMemo(() => {
    if (!selectedCompany || selectedCompany === 'ALL' || selectedCompany === 'all') return null;
    const s = String(selectedCompany).toUpperCase().trim();
    if (s === '2' || s === 'SPJ') return 'SPJ';
    if (s === '1' || s === 'SJ') return 'SJ';
    if (s === '4' || s === 'SPJ-MUM' || s.includes('MUM')) return 'SPJ-MUM';
    if (s === '5' || s === 'PJ') return 'PJ';
    if (s === '3' || s === 'PJ-OLD') return 'PJ-OLD';
    return s;
  }, [selectedCompany]);

  const normalizedCustomer = useMemo(() => {
    if (!selectedCustomer || selectedCustomer === 'ALL' || selectedCustomer === 'all') return null;
    return String(selectedCustomer).toLowerCase().trim();
  }, [selectedCustomer]);

  const normalizedTerminal = useMemo(() => {
    if (!selectedTerminal || selectedTerminal === 'ALL' || selectedTerminal === 'all') return null;
    return String(selectedTerminal).toUpperCase().trim();
  }, [selectedTerminal]);

  // 1. Build Spacious Graph Structure: Company Hubs -> Customer Rings -> Terminal Outer Constellation
  const rawGraph = useMemo(() => {
    const nodes = [];
    const links = [];
    const nodeMap = new Map();

    // 1.1 Wide Anchor Coordinates for 5 Enterprise Companies
    const companyCoords = {
      'SPJ': { x: 0, y: -20 },
      'SJ': { x: 680, y: -300 },
      'SPJ-MUM': { x: 540, y: 520 },
      'PJ': { x: -600, y: -400 },
      'PJ-OLD': { x: -740, y: 340 }
    };

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

    companiesSource.forEach((comp) => {
      const initPos = companyCoords[comp.code] || { x: 0, y: 0 };
      const cNode = {
        id: `comp-${comp.id}`,
        rawId: comp.id,
        code: comp.code,
        label: comp.code,
        fullName: comp.name,
        type: 'company',
        sales: comp.sales,
        invs: comp.invs,
        radius: 36,
        x: initPos.x,
        y: initPos.y,
        vx: 0,
        vy: 0,
        color: COMPANY_COLORS[comp.code] || NODE_THEMES.company
      };
      nodes.push(cNode);
      nodeMap.set(cNode.id, cNode);
    });

    // 1.2 Customer seeds distributed smoothly in wide orbits around parent companies
    const customerSeedByCompany = {
      'SPJ': [
        { name: 'FAIR EXPORTS (INDIA) PVT LTD', sales: 2736623889.97, invs: 20460, terms: ['DADRI', 'JNPT', 'MUNDRA'] },
        { name: 'IFF INDIA FROZEN FOODS', sales: 2504888713.08, invs: 14761, terms: ['DADRI', 'KANPUR'] },
        { name: 'MARHABA FROZEN FOODS', sales: 1874476297.09, invs: 10098, terms: ['DADRI', 'MUNDRA'] },
        { name: 'RUSTAM FOODS PVT.LTD.', sales: 1854931176.52, invs: 8974, terms: ['KANPUR', 'DADRI'] },
        { name: 'AL AMMAR FROZEN FOOD EXPORTS', sales: 1766522371.32, invs: 9895, terms: ['DADRI', 'JNPT'] },
        { name: 'AL-NASIR EXPORTS PVT LTD', sales: 1538360294.34, invs: 11203, terms: ['DADRI', 'KANPUR'] },
        { name: 'MIRHA EXPORTS PVT. LTD.', sales: 1195561318.42, invs: 7925, terms: ['LUDHIANA', 'MUNDRA'] },
        { name: 'AL SAMEER EXPORTS PVT LTD', sales: 702739198.00, invs: 4461, terms: ['DADRI', 'MUNDRA'] },
        { name: 'TRANSWORLD TERMINALS DADRI', sales: 157071296.41, invs: 259, terms: ['DADRI'] },
        { name: 'RIZWAN ICE & COLD STORAGE', sales: 150309445.30, invs: 884, terms: ['DADRI', 'JNPT'] }
      ],
      'SJ': [
        { name: 'HMA AGRO INDUSTRIES LTD', sales: 1742178313.34, invs: 8608, terms: ['DADRI', 'AGRA', 'MUNDRA'] },
        { name: 'INTERNATIONAL AGRO FOODS', sales: 1630617882.17, invs: 8231, terms: ['DADRI', 'JNPT'] },
        { name: 'INDIA FROZEN FOODS', sales: 1261952376.61, invs: 8230, terms: ['DADRI', 'KANPUR'] },
        { name: 'MASH AGRO FOODS LTD', sales: 963898358.91, invs: 4026, terms: ['KANPUR', 'DADRI'] },
        { name: 'ALM INDUSTRIES LIMITED', sales: 352007379.62, invs: 2888, terms: ['DADRI', 'KANPUR'] },
        { name: 'PURE FOODSTUFF PRIVATE LIMITED', sales: 155677908.66, invs: 919, terms: ['DADRI', 'KANPUR'] },
        { name: 'AL-SUPER FROZEN FOODS', sales: 145788582.41, invs: 871, terms: ['DADRI', 'KANPUR'] }
      ],
      'SPJ-MUM': [
        { name: 'JH LOGISTICS PRIVATE LIMITED', sales: 1450731383.16, invs: 11286, terms: ['JNPT', 'MUMBAI', 'MUNDRA'] },
        { name: 'TOURO PRIMEIRO PRIVATE LIMITED', sales: 486794013.67, invs: 3876, terms: ['JNPT', 'MUNDRA'] },
        { name: 'SOHAM EXIM', sales: 138458824.43, invs: 1630, terms: ['JNPT', 'MUNDRA'] },
        { name: 'KESHODWALA FOODS', sales: 133737747.42, invs: 509, terms: ['MUNDRA', 'JNPT'] },
        { name: 'CMA CGM SA', sales: 117146760.17, invs: 75, terms: ['JNPT', 'MUNDRA', 'DADRI'] }
      ],
      'PJ': [
        { name: 'RAYBAN FROZEN FOODS', sales: 232503662.43, invs: 1609, terms: ['DADRI', 'PIYALA'] },
        { name: 'AL AAYAT FOOD EXPO', sales: 228694861.24, invs: 1139, terms: ['DADRI', 'TUGLAKABAD'] }
      ],
      'PJ-OLD': [
        { name: 'AL-MARZIA AGRO FOODS', sales: 226558217.21, invs: 1211, terms: ['DADRI', 'KANPUR'] },
        { name: 'ALM FOOD PRODUCTS', sales: 197219300.91, invs: 1737, terms: ['LUDHIANA', 'MUNDRA'] }
      ]
    };

    // 1.3 Terminals placed in an Expansive Outer Constellation (Radius 900px - 1100px)
    const terminalList = [
      { code: 'DADRI', name: 'ICD DADRI (CGML/CONCOR)', angle: 0.1, radius: 980, volume: '72,410 TEU' },
      { code: 'KANPUR', name: 'ICD KANPUR (PANKI/JUHI)', angle: 0.8, radius: 1040, volume: '34,210 TEU' },
      { code: 'JNPT', name: 'JNPA NHAVA SHEVA PORT', angle: 1.5, radius: 1000, volume: '28,950 TEU' },
      { code: 'MUNDRA', name: 'MUNDRA ADANI PORT', angle: 2.1, radius: 1060, volume: '24,190 TEU' },
      { code: 'LUDHIANA', name: 'ICD DHANDARI KALAN', angle: 2.8, radius: 980, volume: '11,400 TEU' },
      { code: 'TUGLAKABAD', name: 'ICD TKD DELHI', angle: 3.4, radius: 1020, volume: '9,820 TEU' },
      { code: 'PIYALA', name: 'ICD PIYALA FARIDABAD', angle: 4.1, radius: 980, volume: '8,210 TEU' },
      { code: 'JAIPUR', name: 'ICD CONCOR KANAKPURA', angle: 4.7, radius: 1020, volume: '6,450 TEU' },
      { code: 'MUMBAI', name: 'MUMBAI CFS / DRT', angle: 5.4, radius: 980, volume: '5,180 TEU' },
      { code: 'AGRA', name: 'ICD AGRA CFS', angle: 6.0, radius: 1000, volume: '4,220 TEU' }
    ];

    terminalList.forEach((term) => {
      const tNode = {
        id: `term-${term.code}`,
        code: term.code,
        label: term.code,
        fullName: term.name,
        type: 'terminal',
        volume: term.volume,
        radius: 22,
        x: Math.cos(term.angle) * term.radius,
        y: Math.sin(term.angle) * term.radius,
        vx: 0,
        vy: 0,
        color: NODE_THEMES.terminal
      };
      nodes.push(tNode);
      nodeMap.set(tNode.id, tNode);
    });

    // 1.4 Add Customers in Generous Non-overlapping Orbits
    let custCounter = 1;
    Object.entries(customerSeedByCompany).forEach(([compCode, custList]) => {
      const parentComp = nodes.find(n => n.type === 'company' && n.code === compCode) || nodes[0];
      const count = custList.length;

      custList.forEach((cust, idx) => {
        const orbitAngle = (idx / count) * Math.PI * 2 + (compCode === 'SPJ' ? 0.3 : 0);
        const orbitDist = 240 + (idx % 2) * 80; // Alternating distance prevents radial crowding

        const cx = parentComp.x + Math.cos(orbitAngle) * orbitDist;
        const cy = parentComp.y + Math.sin(orbitAngle) * orbitDist;

        const custNode = {
          id: `cust-${custCounter++}`,
          label: cust.name.length > 18 ? `${cust.name.substring(0, 16)}…` : cust.name,
          fullName: cust.name,
          type: 'customer',
          sales: cust.sales,
          invs: cust.invs,
          parentCompany: compCode,
          radius: Math.max(14, Math.min(24, 12 + (cust.sales / 250000000))),
          x: cx,
          y: cy,
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
          companyCode: compCode
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
              companyCode: compCode,
              termCode
            });
          }
        });
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

  // 2. React to Top Filter Selection & Auto-Focus
  useEffect(() => {
    const { nodes } = graphDataRef.current;
    if (normalizedCompanyCode) {
      const compNode = nodes.find(n => n.type === 'company' && n.code === normalizedCompanyCode);
      if (compNode) {
        // Auto-center on selected company with generous viewing frame
        setTransform({
          x: -compNode.x * 0.7,
          y: -compNode.y * 0.7,
          k: 0.7
        });
      }
    } else if (normalizedCustomer) {
      const custNode = nodes.find(n => n.type === 'customer' && n.fullName?.toLowerCase().includes(normalizedCustomer));
      if (custNode) {
        setTransform({
          x: -custNode.x * 0.9,
          y: -custNode.y * 0.9,
          k: 0.9
        });
        setSelectedNode(custNode);
      }
    } else if (normalizedTerminal) {
      const termNode = nodes.find(n => n.type === 'terminal' && n.code === normalizedTerminal);
      if (termNode) {
        setTransform({
          x: -termNode.x * 0.6,
          y: -termNode.y * 0.6,
          k: 0.6
        });
        setSelectedNode(termNode);
      }
    } else {
      // Reset to grand overview
      setTransform({ x: 0, y: 0, k: 0.52 });
    }
  }, [normalizedCompanyCode, normalizedCustomer, normalizedTerminal]);

  // 3. Physics Simulation Loop with Strong Anti-Collision Repulsion
  useEffect(() => {
    let active = true;

    const stepSimulation = () => {
      if (!isPlaying) {
        if (active) animFrameRef.current = requestAnimationFrame(stepSimulation);
        return;
      }

      const { nodes, links } = graphDataRef.current;
      const nodeMap = new Map(nodes.map(n => [n.id, n]));

      particleTimeRef.current += 0.014;

      // Force A: Center Gravity (very low to maintain wide breathing space)
      const kCenter = 0.0004;
      nodes.forEach(node => {
        if (node.isPinned) return;
        node.vx -= node.x * kCenter;
        node.vy -= node.y * kCenter;
      });

      // Force B: Node-Node Repulsion (Strong Anti-Clump Physics)
      for (let i = 0; i < nodes.length; i++) {
        const n1 = nodes[i];
        for (let j = i + 1; j < nodes.length; j++) {
          const n2 = nodes[j];
          const dx = n2.x - n1.x;
          const dy = n2.y - n1.y;
          const distSq = dx * dx + dy * dy + 400;
          const dist = Math.sqrt(distSq);

          // Generous repulsion to keep nodes well-spaced
          const repStrength = (n1.type === 'company' || n2.type === 'company') ? 7000 : 3500;
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

        const targetDist = link.type === 'company-customer' ? 260 : 420;
        const springK = 0.015;
        const force = (dist - targetDist) * springK;

        const fx = (dx / dist) * force;
        const fy = (dy / dist) * force;

        if (!s.isPinned) {
          s.vx += fx * 0.5;
          s.vy += fy * 0.5;
        }
        if (!t.isPinned) {
          t.vx -= fx * 0.5;
          t.vy += fy * 0.5;
        }
      });

      // Position Update with Velocity Damping
      const damping = 0.88;
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
  }, [isPlaying, transform, hoveredNode, selectedNode, showCompanies, showCustomers, showTerminals, searchQuery, normalizedCompanyCode, normalizedCustomer, normalizedTerminal]);

  // 4. Canvas Draw Function (Crisp White & Active Filter Path Highlighting)
  const drawGraph = useCallback(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    const { width, height } = canvas;
    
    // Background: Pure White
    ctx.fillStyle = '#ffffff';
    ctx.fillRect(0, 0, width, height);

    ctx.save();
    // Center origin + Apply Zoom/Pan
    ctx.translate(width / 2 + transform.x, height / 2 + transform.y);
    ctx.scale(transform.k, transform.k);

    const { nodes, links } = graphDataRef.current;
    const nodeMap = new Map(nodes.map(n => [n.id, n]));

    const isVisibleNode = (node) => {
      if (node.type === 'company' && !showCompanies) return false;
      if (node.type === 'customer' && !showCustomers) return false;
      if (node.type === 'terminal' && !showTerminals) return false;
      return true;
    };

    const activeHover = hoveredNode;
    const activeSearch = searchQuery.toLowerCase().trim();

    // 4.1 Determine Active Filter Path (Company -> Customer -> Terminal)
    const filterPathNodeIds = new Set();
    const filterPathLinkIds = new Set();
    let hasActiveFilter = false;

    if (normalizedCompanyCode) {
      hasActiveFilter = true;
      nodes.forEach(n => {
        if (n.type === 'company' && n.code === normalizedCompanyCode) {
          filterPathNodeIds.add(n.id);
        }
        if (n.type === 'customer' && n.parentCompany === normalizedCompanyCode) {
          filterPathNodeIds.add(n.id);
        }
      });
      links.forEach((l, idx) => {
        if (l.companyCode === normalizedCompanyCode) {
          filterPathLinkIds.add(idx);
          filterPathNodeIds.add(l.target);
          filterPathNodeIds.add(l.source);
        }
      });
    } else if (normalizedCustomer) {
      hasActiveFilter = true;
      const targetCust = nodes.find(n => n.type === 'customer' && n.fullName?.toLowerCase().includes(normalizedCustomer));
      if (targetCust) {
        filterPathNodeIds.add(targetCust.id);
        links.forEach((l, idx) => {
          if (l.source === targetCust.id || l.target === targetCust.id) {
            filterPathLinkIds.add(idx);
            filterPathNodeIds.add(l.target);
            filterPathNodeIds.add(l.source);
          }
        });
      }
    } else if (normalizedTerminal) {
      hasActiveFilter = true;
      const targetTerm = nodes.find(n => n.type === 'terminal' && n.code === normalizedTerminal);
      if (targetTerm) {
        filterPathNodeIds.add(targetTerm.id);
        links.forEach((l, idx) => {
          if (l.target === targetTerm.id) {
            filterPathLinkIds.add(idx);
            filterPathNodeIds.add(l.source);
            const srcCust = nodeMap.get(l.source);
            if (srcCust && srcCust.parentCompany) {
              const compNode = nodes.find(cn => cn.type === 'company' && cn.code === srcCust.parentCompany);
              if (compNode) filterPathNodeIds.add(compNode.id);
            }
          }
        });
      }
    }

    // Hover path connections
    const hoverConnectedIds = new Set();
    if (activeHover) {
      hoverConnectedIds.add(activeHover.id);
      links.forEach(l => {
        if (l.source === activeHover.id) hoverConnectedIds.add(l.target);
        if (l.target === activeHover.id) hoverConnectedIds.add(l.source);
      });
    }

    // 4.2 Draw Subtle Slate Dot Grid
    const gridSize = 50;
    const bound = 1600;
    ctx.fillStyle = '#cbd5e1';
    for (let x = -bound; x <= bound; x += gridSize) {
      for (let y = -bound; y <= bound; y += gridSize) {
        ctx.beginPath();
        ctx.arc(x, y, 1.2, 0, Math.PI * 2);
        ctx.fill();
      }
    }

    // 4.3 Draw Links (Connecting Lines with Active Path Highlights)
    links.forEach((link, lIdx) => {
      const s = nodeMap.get(link.source);
      const t = nodeMap.get(link.target);
      if (!s || !t || !isVisibleNode(s) || !isVisibleNode(t)) return;

      const isFilterActiveLink = hasActiveFilter && filterPathLinkIds.has(lIdx);
      const isHoverActiveLink = activeHover && hoverConnectedIds.has(s.id) && hoverConnectedIds.has(t.id);
      const isDimmed = (hasActiveFilter && !isFilterActiveLink) || (activeHover && !isHoverActiveLink);

      ctx.beginPath();
      ctx.moveTo(s.x, s.y);
      ctx.lineTo(t.x, t.y);

      if (isHoverActiveLink || isFilterActiveLink) {
        ctx.strokeStyle = s.type === 'company' ? '#4f46e5' : '#059669';
        ctx.lineWidth = 2.8;
      } else {
        ctx.strokeStyle = isDimmed ? 'rgba(203, 213, 225, 0.2)' : (link.type === 'company-customer' ? 'rgba(99, 102, 241, 0.28)' : 'rgba(16, 185, 129, 0.22)');
        ctx.lineWidth = isDimmed ? 0.8 : 1.4;
      }
      ctx.stroke();

      // Flowing Pulse Particles along active paths
      if (!isDimmed || isFilterActiveLink) {
        const speed = isFilterActiveLink ? 0.15 : 0.1;
        const particleOffset = (particleTimeRef.current + lIdx * speed) % 1;
        const px = s.x + (t.x - s.x) * particleOffset;
        const py = s.y + (t.y - s.y) * particleOffset;

        ctx.beginPath();
        ctx.arc(px, py, isFilterActiveLink ? 3.0 : 2.2, 0, Math.PI * 2);
        ctx.fillStyle = s.type === 'company' ? '#6366f1' : '#10b981';
        ctx.fill();
      }
    });

    // 4.4 Draw Nodes
    nodes.forEach(node => {
      if (!isVisibleNode(node)) return;

      const isFilterActiveNode = hasActiveFilter && filterPathNodeIds.has(node.id);
      const isHovered = activeHover && activeHover.id === node.id;
      const isHoverConnected = activeHover && hoverConnectedIds.has(node.id);
      const isSearchMatch = activeSearch ? (node.fullName?.toLowerCase().includes(activeSearch) || node.code?.toLowerCase().includes(activeSearch)) : false;
      const isDimmed = (hasActiveFilter && !isFilterActiveNode && !isHovered && !isSearchMatch) || (activeHover && !isHoverConnected && !isSearchMatch);

      const radius = (isHovered || isFilterActiveNode) ? node.radius * 1.2 : node.radius;

      ctx.save();
      ctx.globalAlpha = isDimmed ? 0.18 : 1.0;

      // Glow Ring
      if (isHovered || isFilterActiveNode || isSearchMatch || node.type === 'company') {
        ctx.beginPath();
        ctx.arc(node.x, node.y, radius + (isHovered ? 10 : 6), 0, Math.PI * 2);
        ctx.fillStyle = node.color.glow || 'rgba(79, 70, 229, 0.2)';
        ctx.fill();
      }

      // Main Node Shape
      ctx.beginPath();
      if (node.type === 'terminal') {
        // Diamond Shape for Terminals
        const d = radius * 1.15;
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
      ctx.lineWidth = (isHovered || isFilterActiveNode) ? 3.5 : 2;
      ctx.strokeStyle = isHovered ? '#0f172a' : (isFilterActiveNode ? '#ffffff' : node.color.stroke);
      ctx.stroke();

      // Node Inner Text (Company Codes)
      if (node.type === 'company') {
        ctx.font = 'bold 12px Inter, sans-serif';
        ctx.fillStyle = '#ffffff';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'middle';
        ctx.fillText(node.code, node.x, node.y);
      }

      // 4.5 Smart Obsidian Labels (Level of Detail LOD)
      const shouldShowLabel = 
        node.type === 'company' || 
        isHovered || 
        isFilterActiveNode ||
        isSearchMatch || 
        transform.k >= 0.6 || 
        (node.type === 'terminal' && transform.k >= 0.45);

      if (shouldShowLabel && !isDimmed) {
        ctx.font = node.type === 'company' ? 'bold 12px Inter, sans-serif' : '600 11px Inter, sans-serif';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'top';

        const labelY = node.y + radius + 5;
        const displayText = node.label || node.code;

        // Clean White Label Pill
        const metrics = ctx.measureText(displayText);
        const textWidth = metrics.width;
        const padX = 7;
        const padY = 3;

        ctx.fillStyle = 'rgba(255, 255, 255, 0.97)';
        ctx.strokeStyle = (isHovered || isFilterActiveNode) ? node.color.stroke : '#cbd5e1';
        ctx.lineWidth = (isHovered || isFilterActiveNode) ? 1.5 : 1;
        
        ctx.beginPath();
        ctx.roundRect(
          node.x - textWidth / 2 - padX,
          labelY - padY,
          textWidth + padX * 2,
          15 + padY * 2,
          6
        );
        ctx.fill();
        ctx.stroke();

        ctx.fillStyle = isHovered ? '#0f172a' : (node.type === 'terminal' ? '#92400e' : (node.type === 'company' ? '#1e1b4b' : '#065f46'));
        ctx.fillText(displayText, node.x, labelY + 1);

        // Sales badge under customer on zoom or hover
        if (node.sales && (transform.k >= 0.85 || isHovered || isFilterActiveNode)) {
          const salesText = formatSales(node.sales);
          ctx.font = 'bold 9.5px monospace';
          ctx.fillStyle = '#059669';
          ctx.fillText(salesText, node.x, labelY + 20);
        }
      }

      ctx.restore();
    });

    ctx.restore();
  }, [transform, hoveredNode, searchQuery, showCompanies, showCustomers, showTerminals, normalizedCompanyCode, normalizedCustomer, normalizedTerminal]);

  // Handle Canvas Resize
  const handleResize = useCallback(() => {
    const canvas = canvasRef.current;
    const container = containerRef.current;
    if (!canvas || !container) return;
    
    const rect = container.getBoundingClientRect();
    const dpr = window.devicePixelRatio || 1;
    
    canvas.width = rect.width * dpr;
    canvas.height = rect.height * dpr;
    canvas.style.width = `${rect.width}px`;
    canvas.style.height = `${rect.height}px`;

    const ctx = canvas.getContext('2d');
    if (ctx) ctx.scale(dpr, dpr);
    drawGraph();
  }, [drawGraph]);

  useEffect(() => {
    handleResize();
    window.addEventListener('resize', handleResize);
    document.addEventListener('fullscreenchange', handleResize);
    return () => {
      window.removeEventListener('resize', handleResize);
      document.removeEventListener('fullscreenchange', handleResize);
    };
  }, [handleResize]);

  // 5. Fullscreen Toggle (Standard HTML5 + Fallback)
  const toggleFullscreen = () => {
    const container = containerRef.current;
    if (!container) return;

    if (!document.fullscreenElement && !isFullscreen) {
      if (container.requestFullscreen) {
        container.requestFullscreen().catch(() => {});
      }
      setIsFullscreen(true);
    } else {
      if (document.exitFullscreen) {
        document.exitFullscreen().catch(() => {});
      }
      setIsFullscreen(false);
    }
    setTimeout(handleResize, 100);
  };

  // 6. Mouse / Touch Interactions
  const getNodeAtPoint = (px, py) => {
    const canvas = canvasRef.current;
    if (!canvas) return null;
    const rect = canvas.getBoundingClientRect();
    const mx = px - rect.left;
    const my = py - rect.top;

    const graphX = (mx - canvas.clientWidth / 2 - transform.x) / transform.k;
    const graphY = (my - canvas.clientHeight / 2 - transform.y) / transform.k;

    const { nodes } = graphDataRef.current;
    for (let i = nodes.length - 1; i >= 0; i--) {
      const n = nodes[i];
      const dx = graphX - n.x;
      const dy = graphY - n.y;
      if (dx * dx + dy * dy <= (n.radius + 8) * (n.radius + 8)) {
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
    const zoomFactor = e.deltaY < 0 ? 1.14 : 0.86;
    const newK = Math.max(0.25, Math.min(3.5, transform.k * zoomFactor));
    setTransform(prev => ({ ...prev, k: newK }));
  };

  const handleClick = (e) => {
    const node = getNodeAtPoint(e.clientX, e.clientY);
    if (node) {
      setSelectedNode(node);
    }
  };

  const handleResetZoom = () => {
    setTransform({ x: 0, y: 0, k: 0.52 });
  };

  const handleZoomIn = () => {
    setTransform(prev => ({ ...prev, k: Math.min(3.5, prev.k * 1.3) }));
  };

  const handleZoomOut = () => {
    setTransform(prev => ({ ...prev, k: Math.max(0.25, prev.k * 0.75) }));
  };

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
      className={`relative bg-white rounded-3xl border border-slate-200 shadow-soft overflow-hidden transition-all duration-300 ${
        isFullscreen ? 'fixed inset-0 z-[9999] rounded-none w-screen h-screen' : 'h-[650px] w-full'
      }`}
    >
      {/* Top Light Header & Toolbar */}
      <div className="absolute top-0 left-0 right-0 z-10 p-3.5 sm:p-4 bg-white/95 backdrop-blur-md flex flex-wrap items-center justify-between gap-3 border-b border-slate-100 shadow-xs">
        
        {/* Title & Active Path Indicator */}
        <div className="flex items-center gap-3">
          <div className="w-9 h-9 rounded-xl bg-gradient-to-tr from-[#2b1f55] to-[#4338ca] flex items-center justify-center shadow-md text-white">
            <Network className="w-5 h-5" />
          </div>
          <div>
            <div className="flex items-center gap-2">
              <h3 className="text-sm font-extrabold text-slate-900 tracking-wide flex items-center gap-1.5">
                Enterprise Logistics Graph
                <span className="text-[10px] font-semibold text-indigo-700 bg-indigo-50 px-2 py-0.5 rounded-full border border-indigo-200">
                  Obsidian Force Engine
                </span>
              </h3>
            </div>
            <p className="text-[11px] text-slate-500 font-medium mt-0.5 flex items-center gap-1.5">
              <span>Path:</span>
              <span className="text-indigo-700 font-bold">
                {normalizedCompanyCode ? `Company [${normalizedCompanyCode}]` : 'All Companies'}
              </span>
              <span>➔</span>
              <span className="text-emerald-700 font-bold">
                {normalizedCustomer ? `Customer [${normalizedCustomer}]` : 'Active Customers'}
              </span>
              <span>➔</span>
              <span className="text-amber-700 font-bold">
                {normalizedTerminal ? `Terminal [${normalizedTerminal}]` : 'Ports & Terminals'}
              </span>
            </p>
          </div>
        </div>

        {/* Search Node Input */}
        <div className="relative w-44 sm:w-60">
          <Search className="w-3.5 h-3.5 text-slate-400 absolute left-3 top-1/2 -translate-y-1/2" />
          <input
            type="text"
            placeholder="Search Company, Customer, Port..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="w-full pl-8 pr-7 py-1.5 bg-slate-50 border border-slate-200 rounded-xl text-xs text-slate-900 placeholder-slate-400 focus:outline-none focus:bg-white focus:border-[#2b1f55] focus:ring-1 focus:ring-[#2b1f55] font-medium transition-all"
          />
          {searchQuery && (
            <button
              onClick={() => setSearchQuery('')}
              className="absolute right-2.5 top-1/2 -translate-y-1/2 text-slate-400 hover:text-slate-600 text-xs font-bold"
            >
              ×
            </button>
          )}
        </div>

        {/* Visibility Filter Toggles */}
        <div className="flex items-center gap-1.5 bg-slate-100/80 p-1 rounded-xl border border-slate-200">
          <button
            onClick={() => setShowCompanies(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showCompanies ? 'bg-[#2b1f55] text-white shadow-xs' : 'text-slate-600 hover:text-slate-900'
            }`}
          >
            <Building2 className="w-3 h-3 text-indigo-300" />
            Companies ({networkStats.comps})
          </button>
          <button
            onClick={() => setShowCustomers(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showCustomers ? 'bg-emerald-600 text-white shadow-xs' : 'text-slate-600 hover:text-slate-900'
            }`}
          >
            <Users className="w-3 h-3 text-emerald-200" />
            Customers ({networkStats.custs})
          </button>
          <button
            onClick={() => setShowTerminals(prev => !prev)}
            className={`px-2.5 py-1 rounded-lg text-[11px] font-bold transition-all flex items-center gap-1 ${
              showTerminals ? 'bg-amber-600 text-white shadow-xs' : 'text-slate-600 hover:text-slate-900'
            }`}
          >
            <MapPin className="w-3 h-3 text-amber-200" />
            Terminals ({networkStats.terms})
          </button>
        </div>

        {/* Actions (Play/Pause, Zoom, Fullscreen) */}
        <div className="flex items-center gap-1 bg-slate-100/80 p-1 rounded-xl border border-slate-200">
          <button
            onClick={() => setIsPlaying(prev => !prev)}
            title={isPlaying ? 'Pause Physics Simulation' : 'Resume Physics'}
            className="p-1.5 text-slate-600 hover:text-slate-900 hover:bg-slate-200/80 rounded-lg transition-all"
          >
            {isPlaying ? <Pause className="w-3.5 h-3.5 text-indigo-600" /> : <Play className="w-3.5 h-3.5 text-emerald-600" />}
          </button>

          <div className="w-px h-4 bg-slate-300 mx-0.5"></div>

          <button
            onClick={handleZoomIn}
            title="Zoom In"
            className="p-1.5 text-slate-600 hover:text-slate-900 hover:bg-slate-200/80 rounded-lg transition-all"
          >
            <ZoomIn className="w-3.5 h-3.5" />
          </button>

          <button
            onClick={handleZoomOut}
            title="Zoom Out"
            className="p-1.5 text-slate-600 hover:text-slate-900 hover:bg-slate-200/80 rounded-lg transition-all"
          >
            <ZoomOut className="w-3.5 h-3.5" />
          </button>

          <button
            onClick={handleResetZoom}
            title="Reset View"
            className="p-1.5 text-slate-600 hover:text-slate-900 hover:bg-slate-200/80 rounded-lg transition-all"
          >
            <RotateCcw className="w-3.5 h-3.5" />
          </button>

          <div className="w-px h-4 bg-slate-300 mx-0.5"></div>

          <button
            onClick={toggleFullscreen}
            title={isFullscreen ? 'Exit Fullscreen' : 'Fullscreen'}
            className="p-1.5 text-slate-600 hover:text-slate-900 hover:bg-slate-200/80 rounded-lg transition-all"
          >
            {isFullscreen ? <Minimize2 className="w-3.5 h-3.5 text-indigo-600" /> : <Maximize2 className="w-3.5 h-3.5" />}
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
      <div className="absolute bottom-3 left-4 right-4 pointer-events-none flex items-center justify-between gap-3 text-[11px] font-mono font-semibold text-slate-600">
        <div className="bg-white/95 backdrop-blur-md px-3.5 py-1.5 rounded-xl border border-slate-200 pointer-events-auto flex items-center gap-3 shadow-md">
          <span className="flex items-center gap-1.5 text-[#2b1f55] font-bold">
            <Sparkles className="w-3.5 h-3.5 text-indigo-600" />
            Obsidian Zoom: {(transform.k * 100).toFixed(0)}%
          </span>
          <span className="text-slate-300">•</span>
          <span>{networkStats.totalLinks} Logistics Vectors</span>
          <span className="text-slate-300">•</span>
          <span className="text-emerald-700 font-bold">Active Flow: {formatSales(totalSales)}</span>
        </div>

        <div className="bg-white/95 backdrop-blur-md px-3.5 py-1.5 rounded-xl border border-slate-200 pointer-events-auto text-slate-500 shadow-md hidden sm:block">
          💡 Drag nodes to reposition • Top filters automatically isolate and trace the vector path
        </div>
      </div>

      {/* Node Inspector Modal / Popover */}
      {selectedNode && (
        <div className="absolute bottom-4 right-4 z-20 w-80 bg-white/98 backdrop-blur-xl rounded-2xl border border-indigo-200 p-4 shadow-2xl text-slate-900 animate-scale-in">
          <div className="flex items-start justify-between gap-2 border-b border-slate-100 pb-3">
            <div className="flex items-center gap-2">
              <span
                className="w-3.5 h-3.5 rounded-full"
                style={{ backgroundColor: selectedNode.color.stroke }}
              ></span>
              <div>
                <span className="text-[10px] font-bold uppercase tracking-wider text-slate-400 block">
                  {selectedNode.type} Node
                </span>
                <h4 className="text-xs font-black text-slate-900 truncate max-w-[200px]" title={selectedNode.fullName}>
                  {selectedNode.fullName || selectedNode.code}
                </h4>
              </div>
            </div>
            <button
              onClick={() => setSelectedNode(null)}
              className="p-1 text-slate-400 hover:text-slate-600 rounded-lg"
            >
              <X className="w-4 h-4" />
            </button>
          </div>

          <div className="grid grid-cols-2 gap-2 mt-3 text-xs">
            {selectedNode.sales && (
              <div className="bg-slate-50 p-2 rounded-xl border border-slate-200">
                <span className="text-[10px] text-slate-500 block font-medium">Sales Volume</span>
                <span className="font-mono font-bold text-emerald-700">
                  {formatSales(selectedNode.sales)}
                </span>
              </div>
            )}
            {selectedNode.invs && (
              <div className="bg-slate-50 p-2 rounded-xl border border-slate-200">
                <span className="text-[10px] text-slate-500 block font-medium">Total Invoices</span>
                <span className="font-mono font-bold text-indigo-900">
                  {Number(selectedNode.invs).toLocaleString('en-IN')}
                </span>
              </div>
            )}
            {selectedNode.volume && (
              <div className="bg-slate-50 p-2 rounded-xl border border-slate-200">
                <span className="text-[10px] text-slate-500 block font-medium">Throughput</span>
                <span className="font-mono font-bold text-amber-700">
                  {selectedNode.volume}
                </span>
              </div>
            )}
            {selectedNode.parentCompany && (
              <div className="bg-slate-50 p-2 rounded-xl border border-slate-200">
                <span className="text-[10px] text-slate-500 block font-medium">Parent Hub</span>
                <span className="font-bold text-purple-900">
                  {selectedNode.parentCompany}
                </span>
              </div>
            )}
          </div>

          <div className="mt-3 pt-2 border-t border-slate-100 flex justify-end">
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
              className="w-full flex items-center justify-center gap-1.5 py-1.5 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] hover:opacity-95 text-white text-xs font-bold rounded-xl shadow-md transition-all"
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
