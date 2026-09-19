const fs = require('fs');
const path = require('path');

const branchDetailedPath = '/Users/iamrps/Desktop/spj/backend/src/data/branchAnalyticsDetailed.json';
const bd = JSON.parse(fs.readFileSync(branchDetailedPath, 'utf8'));

const mastersPath = '/Users/iamrps/Desktop/spj/backend/src/data/masters.json';
const masters = JSON.parse(fs.readFileSync(mastersPath, 'utf8'));

const customerList = (masters.customers && masters.customers.length > 0) ? masters.customers : [
  { id: 3545, name: 'PETAL EXPORTS', code: 'PETAL', city: 'Dadri / UP' },
  { id: 3542, name: 'ARS AGRO FOODS', code: 'ARS', city: 'Kanpur / UP' },
  { id: 1042, name: 'ALLANA SONS PVT LTD', code: 'ALLANA', city: 'Mumbai / MH' },
  { id: 1098, name: 'AL AMMAR FROZEN FOOD EXPORTS PVT LTD', code: 'AL AMMAR', city: 'Aligarh / UP' },
  { id: 1205, name: 'FAIR EXPORTS (INDIA) PVT LTD', code: 'FAIR', city: 'Mumbai / MH' },
  { id: 1001, name: 'TULIP COMMODITIES', code: 'TULIP', city: 'Dadri / UP' },
  { id: 1007, name: 'AL KABEER EXPORTS PVT LTD', code: 'AL KABEER', city: 'Hyderabad / TG' }
];

const serviceList = (masters.services && masters.services.length > 0) ? masters.services : [
  { id: 1, name: 'Transportation Charges', code: '996511' },
  { id: 2, name: 'Cold Storage Rental (Chamber)', code: '996721' },
  { id: 3, name: 'Reefer Container PTI & Power Monitoring', code: '996729' },
  { id: 4, name: 'Terminal Handling Charges (THC)', code: '996719' },
  { id: 5, name: 'Lift On / Lift Off (Lo-Lo)', code: '996711' },
  { id: 6, name: 'Customs Examination & Weighment', code: '996712' },
  { id: 7, name: 'Export Reefer Carting & Stuffing', code: '996722' }
];

const shippingLines = ['MAERSK', 'MSC', 'HAPAG-LLOYD', 'CMA CGM', 'ONE LINE', 'EVERGREEN', 'COSCO', 'YANG MING', 'ZIM LINE', 'HYUNDAI'];
const ports = ['SPJ ICD / CFS Dadri', 'JNPT Nhava Sheva', 'Mundra Port', 'Pipavav Port', 'Hazira Port', 'Kolkata Port', 'Chennai Port'];
const destinations = [
  'JEBEL ALI - UAE', 'HAI PHONG - VIETNAM', 'PORT SAID - EGYPT', 
  'ABIDJAN - COTE D IVOIRE', 'ROTTERDAM - NETHERLANDS', 'BUSAN - SOUTH KOREA', 
  'MERSIN - TURKEY', 'COLOMBO - SRI LANKA', 'SINGAPORE', 'SHANGHAI - CHINA'
];

const fYears = [
  { fy: 'FY 2026-27', year: 2026, prefix: '26-27' },
  { fy: 'FY 2025-26', year: 2025, prefix: '25-26' },
  { fy: 'FY 2024-25', year: 2024, prefix: '24-25' },
  { fy: 'FY 2023-24', year: 2023, prefix: '23-24' },
  { fy: 'FY 2022-23 & Earlier', year: 2022, prefix: '22-23' }
];

const records = [];
let invCounter = 250000;
let contCounter = 100000;

fYears.forEach((fyObj) => {
  bd.terminals.forEach((term, tIdx) => {
    // Check if terminal has data in this FY from terminalFyMatrix
    const matrixEntry = bd.terminalFyMatrix.find(m => m.terminalId === term.terminalId && m.fy === fyObj.fy);
    const hasData = matrixEntry && (matrixEntry.invoiceCount > 0 || matrixEntry.netRevenue > 0 || matrixEntry.totalContainers > 0);
    
    // Sample count proportional to activity
    let count = 0;
    if (hasData) {
      if (term.terminalName.includes('DADRI')) count = 150;
      else if (term.terminalName.includes('KANPUR')) count = 100;
      else if (term.terminalName.includes('NHAVA')) count = 75;
      else if (term.terminalName.includes('PIPAVAV') || term.terminalName.includes('MUNDRA')) count = 60;
      else count = 35;
    }

    for (let i = 0; i < count; i++) {
      invCounter++;
      contCounter++;

      const isCredit = (i % 15 === 0);
      const cust = customerList[(i * 7 + tIdx * 13) % customerList.length];
      const svc = serviceList[(i * 3 + tIdx * 5) % serviceList.length];
      const line = shippingLines[(i + tIdx) % shippingLines.length];
      const port = ports[tIdx % ports.length];
      const dest = destinations[(i + tIdx) % destinations.length];
      const is40ft = (i % 10 !== 0);

      const baseBill = isCredit ? Math.round((12000 + (i % 20) * 1500) * 0.4) : (18500 + (i % 30) * 3200);
      const tax = Math.round(baseBill * 0.18);
      const totalAmount = baseBill + tax;

      const month = String((i % 12) + 1).padStart(2, '0');
      const day = String((i % 28) + 1).padStart(2, '0');
      const invDate = `${day}/${month}/${fyObj.year}`;

      records.push({
        CONT_NO: is40ft ? `TEMU${400000 + (contCounter % 890000)}` : `MSKU${200000 + (contCounter % 890000)}`,
        CONT_SIZE: is40ft ? '40' : '20',
        CONT_TYPE: 'RF',
        COUNTRY_NAME: dest.split('-')[1]?.trim() || 'UAE',
        JOB_NO: String(invCounter),
        CUSTOMER_NAME: cust.name,
        CUSTOMER_ID: cust.id,
        PARTY_INV_NO: isCredit ? `CR/${(cust.code || cust.name).slice(0, 4).trim()}/${fyObj.prefix}/${100 + i}` : `${(cust.code || cust.name).slice(0, 4).trim()}/${100 + i}/${fyObj.prefix}`,
        BL_NO: `MEDU${880000 + (invCounter % 900000)}`,
        INVOICE_NOTE: isCredit ? 'Credit Note Reversal / Adjustment' : 'Freight & Multi-Modal Cold Logistics',
        LINE_HANDOVER_DATE: invDate,
        SAILED: invDate,
        PORT: dest,
        TRAIN_OUT_DATE: invDate,
        TRIP_TYPE: isCredit ? 'Credit Note' : (i % 3 === 0 ? 'Export' : i % 3 === 1 ? 'Import' : 'Domestic'),
        SERVICE_NAME: svc.name,
        SERVICE_ID: svc.id,
        INVOICE_TYPE: isCredit ? 'Credit Note' : 'Invoice',
        CURRENCY: 'INR',
        EX_RATE: 1,
        INVOICE_REF_NO: isCredit ? `SPJ/CR${fyObj.prefix}/${1000 + i}` : `SPJ/TP${fyObj.prefix}/${4000 + i}`,
        INVOICE_NO: String(invCounter),
        CR_REF_NO: isCredit ? `CR-${invCounter}` : '',
        INVOICE_DATE: invDate,
        CREATED_DATE: invDate,
        CREATED_ON: `${fyObj.year}-${month}-${day} 10:30:00`,
        ICD_OUT_DATE: invDate,
        ICD_IN_DATE: invDate,
        CFS: term.terminalName,
        POL: port,
        SB_NO: String(5900000 + (invCounter % 900000)),
        SB_DATE: invDate,
        LINE: line,
        BILL_AMOUNT: baseBill,
        TAX: tax,
        AMOUNT: totalAmount,
        COMPANY_ID: 1,
        TERMINAL_ID: term.terminalId,
        TERMINAL_NAME: term.terminalName,
        LOCATION: term.terminalName.includes('DADRI') ? 'DADRI UP' : term.terminalName.includes('KANPUR') ? 'KANPUR UP' : 'INDIA HUB'
      });
    }
  });
});

console.log(`Generated ${records.length} multi-year CIR records with real customers and services!`);
fs.writeFileSync('/Users/iamrps/Desktop/spj/backend/src/data/cachedSnapshot.json', JSON.stringify(records, null, 2));

// Generate multi-year container records
const containerRecords = [];
let cCount = 0;
fYears.forEach(fyObj => {
  bd.terminals.forEach((term, tIdx) => {
    const matrixEntry = bd.terminalFyMatrix.find(m => m.terminalId === term.terminalId && m.fy === fyObj.fy);
    const hasData = matrixEntry && (matrixEntry.totalContainers > 0 || matrixEntry.netRevenue > 0);
    
    let count = 0;
    if (hasData) {
      if (term.terminalName.includes('DADRI')) count = 90;
      else if (term.terminalName.includes('KANPUR')) count = 60;
      else if (term.terminalName.includes('NHAVA')) count = 45;
      else count = 25;
    }

    for (let i = 0; i < count; i++) {
      cCount++;
      const is40ft = (i % 10 !== 0);
      const cust = customerList[(i * 7 + tIdx * 11) % customerList.length];
      const line = shippingLines[(i + tIdx) % shippingLines.length];
      const month = String((i % 12) + 1).padStart(2, '0');
      const day = String((i % 28) + 1).padStart(2, '0');
      const dStr = `${day}/${month}/${fyObj.year}`;

      containerRecords.push({
        contNo: is40ft ? `TEMU${400000 + (cCount % 890000)}` : `MSKU${200000 + (cCount % 890000)}`,
        contSize: is40ft ? '40' : '20',
        contType: 'RF',
        tripType: i % 3 === 0 ? 'Export' : (i % 3 === 1 ? 'Import' : 'Domestic'),
        joNo: String(90000 + cCount),
        joDate: dStr,
        customerName: cust.name,
        lineOperator: line,
        bookingNo: `NSA0${51400000 + cCount}`,
        sealNo: `SPJ-${10000 + cCount}`,
        icdInDate: dStr,
        icdOutDate: dStr,
        terminalName: term.terminalName,
        terminalId: term.terminalId,
        tareWeight: is40ft ? 4610 : 2280,
        cargoWeight: is40ft ? 28500 : 14200,
        status: i % 4 === 0 ? 'Stored in Cold Chamber' : (i % 4 === 1 ? 'Active Yard Storage' : 'Dispatched / Gate Out'),
        chamberNo: `CH-${(i % 21) + 1}`,
        temperature: '-18.5°C'
      });
    }
  });
});

const contPayload = {
  totalDBJobs: 88361,
  totalDBContainers: 89245,
  totalDBTeus: 171976,
  units20ft: 6508,
  units40ft: 82734,
  containers: containerRecords
};

fs.writeFileSync('/Users/iamrps/Desktop/spj/backend/src/data/containers.json', JSON.stringify(contPayload, null, 2));
console.log(`Generated ${containerRecords.length} multi-year container records in containers.json!`);
