const fs = require('fs');
const path = require('path');

const snapPath = '/Users/iamrps/Desktop/spj/backend/src/data/cachedSnapshot.json';
const contPath = '/Users/iamrps/Desktop/spj/backend/src/data/containers.json';
const fleetPath = '/Users/iamrps/Desktop/spj/backend/src/data/fleet.json';
const branchPath = '/Users/iamrps/Desktop/spj/backend/src/data/branchAnalyticsDetailed.json';

const snap = fs.existsSync(snapPath) ? JSON.parse(fs.readFileSync(snapPath, 'utf8')) : [];
const cont = fs.existsSync(contPath) ? JSON.parse(fs.readFileSync(contPath, 'utf8')) : {};
const fleet = fs.existsSync(fleetPath) ? JSON.parse(fs.readFileSync(fleetPath, 'utf8')) : [];
const branch = fs.existsSync(branchPath) ? JSON.parse(fs.readFileSync(branchPath, 'utf8')) : {};

console.log("cachedSnapshot rows:", snap.length);
console.log("Sample snapshot item keys:", Object.keys(snap[0] || {}));
console.log("Sample snapshot item:", snap[0]);

// Check date fields in snapshot
const dateSamples = snap.slice(0, 5).map(s => ({
  INVOICE_NO: s.INVOICE_NO,
  INVOICE_REF_NO: s.INVOICE_REF_NO,
  PARTY_INV_NO: s.PARTY_INV_NO,
  INVOICE_DATE: s.INVOICE_DATE,
  CREATED_ON: s.CREATED_ON,
  TERMINAL_ID: s.TERMINAL_ID,
  TERMINAL_NAME: s.TERMINAL_NAME,
  CUSTOMER_NAME: s.CUSTOMER_NAME
}));
console.log("\nDate samples in snapshot:", dateSamples);

// Distribution of dates / years in snapshot
const yearCounts = {};
snap.forEach(s => {
  const d = String(s.INVOICE_DATE || s.CREATED_ON || s.INVOICE_REF_NO || '');
  let yr = 'Unknown';
  if (d.includes('2026') || d.includes('/26') || d.includes('-26') || d.includes('26-27')) yr = 'FY 2026-27';
  else if (d.includes('2025') || d.includes('/25') || d.includes('-25') || d.includes('25-26')) yr = 'FY 2025-26';
  else if (d.includes('2024') || d.includes('/24') || d.includes('-24') || d.includes('24-25')) yr = 'FY 2024-25';
  else if (d.includes('2023') || d.includes('/23') || d.includes('-23') || d.includes('23-24')) yr = 'FY 2023-24';
  else yr = 'FY 2022-23 & Earlier';
  yearCounts[yr] = (yearCounts[yr] || 0) + 1;
});
console.log("\nSnapshot FY Distribution:", yearCounts);

console.log("\nContainers length:", (cont.containers || []).length);
console.log("Containers sample:", (cont.containers || []).slice(0, 2));
console.log("\nFleet length:", fleet.length);
console.log("Fleet sample:", fleet.slice(0, 2));
