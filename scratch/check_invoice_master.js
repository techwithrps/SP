const sql = require('mssql');
require('dotenv').config({ path: '/Users/iamrps/Desktop/spj/backend/.env' });

const config = {
  user: process.env.DB_USER || 'sa',
  password: process.env.DB_PASSWORD,
  server: process.env.DB_SERVER || '103.197.76.251',
  port: parseInt(process.env.DB_PORT || '1433'),
  database: process.env.DB_DATABASE || 'SPJ',
  options: {
    encrypt: false,
    trustServerCertificate: true,
    requestTimeout: 60000,
    connectTimeout: 60000
  }
};

async function run() {
  const pool = await sql.connect(config);

  const invTables = await pool.request().query(`
    SELECT TABLE_NAME 
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME LIKE '%INV%' OR TABLE_NAME LIKE '%BILL%' OR TABLE_NAME LIKE '%CIR%' OR TABLE_NAME LIKE '%SALE%'
  `);
  console.log("Tables matching INV / BILL / CIR in SPJ:", invTables.recordset);

  for (const t of invTables.recordset) {
    try {
      const cnt = await pool.request().query(`SELECT COUNT(*) as c FROM [${t.TABLE_NAME}]`);
      console.log(`Table [${t.TABLE_NAME}]: ${cnt.recordset[0].c} rows`);
    } catch(e) {}
  }

  await pool.close();
}

run().catch(console.error);
