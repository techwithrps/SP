const fs = require('fs');
const path = require('path');

const branchDetailedPath = '/Users/iamrps/Desktop/spj/backend/src/data/branchAnalyticsDetailed.json';
const bd = JSON.parse(fs.readFileSync(branchDetailedPath, 'utf8'));

// Customer database
const customerList = [
  { id: 3545, name: 'PETAL EXPORTS', gstin: '09AAACP4512A1Z4', city: 'Dadri / UP' },
  { id: 3542, name: 'ARS AGRO FOODS', gstin: '09AABCA9124K1Z2', city: 'Kanpur / UP' },
  { id: 1042, name: 'ALLANA SONS PVT LTD', gstin: '27AAACA1042L1Z8', city: 'Mumbai / MH' },
  { id: 1098, name: 'AL AMMAR FROZEN FOOD EXPORTS PVT LTD', gstin: '09AAACA1098M1Z9', city: 'Aligarh / UP' },
  { id: 1205, name: 'FAIR EXPORTS (INDIA) PVT LTD', gstin: '27AAACF1205K1Z1', city: 'Mumbai / MH' },
  { id: 1001, name: 'TULIP COMMODITIES', gstin: '09AAACT1001F1Z5', city: 'Dadri / UP' },
  { id: 1002, name: 'AGRO FOODS PVT LTD', gstin: '07AABCA1002M1Z2', city: 'Delhi NCR' },
  { id: 1003, name: 'HIMALAYA FROZEN LOGISTICS', gstin: '09AABCH1003K1Z9', city: 'Noida / UP' },
  { id: 1004, name: 'OCEANIC COLD CHAIN', gstin: '06AACCO1004L1Z1', city: 'Gurugram / HR' },
  { id: 1005, name: 'HMA AGRO INDUSTRIES LTD', gstin: '09AAACH1005P1Z3', city: 'Agra / UP' },
  { id: 1006, name: 'FRIGORIFICO ALLANA PVT LTD', gstin: '09AAACF1006N1Z7', city: 'Sahibabad / UP' },
  { id: 1007, name: 'AL KABEER EXPORTS PVT LTD', gstin: '36AAACA1007M1Z4', city: 'Hyderabad / TG' },
  { id: 1008, name: 'CONTAINER CORPORATION OF INDIA LTD', gstin: '07AAACC1008K1Z6', city: 'New Delhi' }
];

const serviceList = [
  { id: 1, name: 'Transportation Charges', code: '996511', rate: 18500 },
  { id: 2, name: 'Cold Storage Rental (Chamber)', code: '996721', rate: 45000 },
  { id: 3, name: 'Reefer Container PTI & Power Monitoring', code: '996729', rate: 12500 },
  { id: 4, name: 'Terminal Handling Charges (THC)', code: '996719', rate: 8500 },
  { id: 5, name: 'Lift On / Lift Off (Lo-Lo)', code: '996711', rate: 3500 },
  { id: 6, name: 'Customs Examination & Weighment', code: '996712', rate: 4200 },
  { id: 7, name: 'Export Reefer Carting & Stuffing', code: '996722', rate: 22000 }
];

const shippingLines = ['MAERSK', 'MSC', 'HAPAG', 'CMA CGM', 'ONE LINE', 'EVERGREEN', 'COSCO', 'YANG MING'];
const ports = ['SPJ ICD / CFS Dadri', 'JNPT Nhava Sheva', 'Mundra Port', 'Pipavav Port', 'Hazira Port', 'Kolkata Port', 'Chennai Port'];
const destinations = ['JEBEL ALI - UAE', 'HAI PHONG - VIETNAM', 'PORT SAID - EGYPT', 'ABIDJAN - COTE D IVOIRE', 'ROTTERDAM - NETHERLANDS', 'BUSAN - SOUTH KOREA', 'MERSIN - TURKEY', 'COLOMBO - SRI LANKA'];

const fYears = [
  { fy: 'FY 2026-27', year: 2026, prefix: '26-27', dateStr: '18/09/2026', icdDate: '14/08/2026' },
  { fy: 'FY 2025-26', year: 2025, prefix: '25-26', dateStr: '15/10/2025', icdDate: '10/09/2025' },
  { fy: 'FY 2024-25', year: 2024, prefix: '24-25', dateStr: '12/11/2024', icdDate: '08/10/2024' },
  { fy: 'FY 2023-24', year: 2023, prefix: '23-24', dateStr: '20/12/2023', icdDate: '15/11/2023' },
  { fy: 'FY 2022-23 & Earlier', year: 2022, prefix: '22-23', dateStr: '10/05/2022', icdDate: '01/04/2022' }
];

// Generate comprehensive multi-year snapshot
const records = [];
let invCounter = 240000;
let contCounter = 100000;

fYears.forEach(fyObj => {
  bd.terminals.forEach((term, tIdx) => {
    // Determine sample record density based on terminal activity
    const hasData = term.totalContainers > 0 || term.netRevenue > 0;
    const count = hasData ? (term.terminalName.includes('DADRI') ? 120 : term.terminalName.includes('KANPUR') ? 80 : term.terminalName.includes('NHAVA') ? 60 : 30) : 0;

    for (let i = 0; i < count; i++) {
      invCounter++;
      contCounter++;

      const isCredit = i % 18 === 0;
      const cust = customerList[(i + tIdx) % customerList.length];
      const svc = serviceList[(i * 3 + tIdx) % serviceList.length];
      const line = shippingLines[(i + tIdx) % shippingLines.length];
      const port = ports[tIdx % ports.length];
      const dest = destinations[(i + tIdx) % destinations.length];
      const is40ft = i % 10 !== 0; // 90% 40ft

      const baseBill = isCredit ? Math.round(svc.rate * 0.4) : (svc.rate + (i % 5) * 2500);
      const tax = Math.round(baseBill * 0.18);
      const totalAmount = baseBill + tax;

      // Random day in that financial year
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
        PARTY_INV_NO: isCredit ? `CR/${cust.name.slice(0, 3)}/${fyObj.prefix}/${100 + i}` : `${cust.name.slice(0, 3)}/${100 + i}/${fyObj.prefix}`,
        BL_NO: `MEDU${880000 + (invCounter % 900000)}`,
        INVOICE_NOTE: isCredit ? 'Credit Note Reversal / Adjustment' : 'Freight & Multi-Modal Cold Logistics',
        LINE_HANDOVER_DATE: invDate,
        SAILED: invDate,
        PORT: dest,
        TRAIN_OUT_DATE: invDate,
        TRIP_TYPE: isCredit ? 'Credit Note' : (i % 3 === 0 ? 'Export' : i % 3 === 1 ? 'Import' : 'Domestic'),
        SERVICE_NAME: svc.name,
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
        LOCATION: term.terminalName.includes('DADRI') ? 'DADRI UP' : term.terminalName.includes('KANPUR') ? 'KANPUR UP' : 'INDIA HUB',
        CUSTOMER_ID: cust.id,
        SERVICE_ID: svc.id
      });
    }
  });
});

console.log(`Generated ${records.length} comprehensive multi-year snapshot records!`);
fs.writeFileSync('/Users/iamrps/Desktop/spj/backend/src/data/cachedSnapshot.json', JSON.stringify(records, null, 2));

// Generate multi-year container records
const containerRecords = [];
let cCount = 0;
fYears.forEach(fyObj => {
  bd.terminals.forEach((term, tIdx) => {
    const hasData = term.totalContainers > 0 || term.netRevenue > 0;
    const count = hasData ? (term.terminalName.includes('DADRI') ? 80 : term.terminalName.includes('KANPUR') ? 50 : 25) : 0;

    for (let i = 0; i < count; i++) {
      cCount++;
      const is40ft = i % 10 !== 0;
      const cust = customerList[(i + tIdx) % customerList.length];
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
        totalWeight: is40ft ? 33110 : 16480,
        status: i % 3 === 0 ? 'Stored in Cold Chamber' : (i % 3 === 1 ? 'Dispatched / Outward' : 'Gate In / Tally Active')
      });
    }
  });
});

console.log(`Generated ${containerRecords.length} container records!`);
const contFile = {
  totalDBJobs: 88361,
  totalDBContainers: 89245,
  totalDBTeus: 171976,
  units20ft: 6508,
  units40ft: 82734,
  containers: containerRecords
};
fs.writeFileSync('/Users/iamrps/Desktop/spj/backend/src/data/containers.json', JSON.stringify(contFile, null, 2));

console.log("Data files successfully written!");
