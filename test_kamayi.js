const { getPool } = require('./backend/src/config/db');

async function testKamayi() {
  const pool = await getPool();

  const qYears = `
    SELECT 
      YEAR(mi.INVOICE_DATE) as [Year],
      MONTH(mi.INVOICE_DATE) as [Month],
      DATENAME(month, mi.INVOICE_DATE) as [MonthName],
      COUNT(DISTINCT mi.INVOICE_NO) as TotalInvoices,
      SUM(ISNULL(mii.BILL_AMOUNT, 0)) as BaseRevenue,
      SUM(ISNULL(mii.BILL_AMOUNT, 0) * 0.18) as TaxAmount,
      SUM(ISNULL(mii.BILL_AMOUNT, 0) * 1.18) as GrossRevenue
    FROM MANUAL_INVOICE mi
    LEFT JOIN MANUAL_INVOICE_ITEMS mii ON mii.INVOICE_NO = mi.INVOICE_NO AND mii.TERMINAL_ID = mi.TERMINAL_ID
    WHERE ISNULL(mi.CANCLE_FLAGE, 0) = 0
    GROUP BY YEAR(mi.INVOICE_DATE), MONTH(mi.INVOICE_DATE), DATENAME(month, mi.INVOICE_DATE)
    ORDER BY [Year] DESC, [Month] DESC
  `;
  const years = await pool.request().query(qYears);
  console.log("=== Years / Months ===");
  console.log(years.recordset);

  const qTerm = `
    SELECT 
      ISNULL(tm.TERMINAL_NAME, 'SPJ Cold Storage & ICD Dadri') as TerminalName,
      ISNULL(tm.ADDRESS, 'Dadri, Greater Noida (UP)') as Location,
      COUNT(DISTINCT mi.INVOICE_NO) as Invoices,
      COUNT(DISTINCT mii.CONT_NO) as ContainersHandled,
      SUM(ISNULL(mii.BILL_AMOUNT, 0)) as BaseRevenue,
      SUM(ISNULL(mii.BILL_AMOUNT, 0) * 0.18) as GST,
      SUM(ISNULL(mii.BILL_AMOUNT, 0) * 1.18) as GrossRevenue
    FROM MANUAL_INVOICE mi
    LEFT JOIN MANUAL_INVOICE_ITEMS mii ON mii.INVOICE_NO = mi.INVOICE_NO AND mii.TERMINAL_ID = mi.TERMINAL_ID
    LEFT JOIN TERMINAL_MASTER tm ON tm.TERMINAL_ID = mi.TERMINAL_ID
    WHERE ISNULL(mi.CANCLE_FLAGE, 0) = 0
    GROUP BY tm.TERMINAL_NAME, tm.ADDRESS
  `;
  const terminals = await pool.request().query(qTerm);
  console.log("=== Terminals / Locations ===");
  console.log(terminals.recordset);

  const qCont = `
    SELECT TOP 20
      ISNULL(NULLIF(mii.CONT_NO, ''), CONCAT('CONT-', CAST(mii.LINE_ITEM AS VARCHAR(20)))) as ContainerNo,
      ISNULL(cm.CUSTOMER_NAME, 'SPJ Account Client') as CustomerName,
      ISNULL(mii.CONT_SIZE, '40') as Size,
      ISNULL(mii.CONT_TYPE, 'REEFER') as [Type],
      COUNT(DISTINCT mi.INVOICE_NO) as Trips,
      SUM(ISNULL(mii.BILL_AMOUNT, 0)) as BaseRevenue,
      SUM(ISNULL(mii.BILL_AMOUNT, 0) * 1.18) as TotalEarnings
    FROM MANUAL_INVOICE_ITEMS mii
    JOIN MANUAL_INVOICE mi ON mi.INVOICE_NO = mii.INVOICE_NO AND mi.TERMINAL_ID = mii.TERMINAL_ID AND ISNULL(mi.CANCLE_FLAGE, 0) = 0
    LEFT JOIN CUSTOMER_MASTER cm ON cm.CUSTOMER_ID = mi.BILL_TO
    GROUP BY mii.CONT_NO, mii.LINE_ITEM, cm.CUSTOMER_NAME, mii.CONT_SIZE, mii.CONT_TYPE
    ORDER BY TotalEarnings DESC
  `;
  const conts = await pool.request().query(qCont);
  console.log("=== Top Container Earnings ===");
  console.log(conts.recordset);

  process.exit(0);
}

testKamayi();
