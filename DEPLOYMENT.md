# SPJ Cargo & Logistics Backend — Deployment Guide

## 📌 Architecture Overview

The SPJ Cargo & Logistics platform connects a modern React dashboard to an enterprise Oracle Database (`SPJLIVE` schema).

```
┌─────────────────────────────────┐           ┌───────────────────────────────────────┐           ┌───────────────────────────────────────┐
│     React + Vite Frontend       │  HTTPS    │     Node.js + Java Express Backend    │  Oracle   │     Oracle SPJLIVE Database Server    │
│   (Vercel: spj-mauve.vercel.app)│ ────────> │   (Railway / Render / Docker / VPS)   │   JDBC    │ (144.24.138.129:1521 / pdb1...)       │
│                                 │   CORS    │                                       │ ────────> │                                       │
│ • Real-time KPIs & Drilldowns   │           │ • Express API routes                  │ Encrypted │ • REPORT_PKG.SP_INVOICE_REPORT_NEW    │
│ • Date & Terminal/Customer Filter│          │ • OracleAnalyticsEngine (Java JDBC)   │ Native    │ • IMP_INVOICE & IMP_INVOICE_TAX       │
│ • Container & Fleet Tracking    │           │ • ojdbc11.jar with Native Encryption  │ Network   │ • ALL_PARTY_ACCOUNT                   │
└─────────────────────────────────┘           └───────────────────────────────────────┘           └───────────────────────────────────────┘
```

### Why Java JDBC is Required (The Vercel Limitation)
1. **Oracle Native Network Encryption:** The SPJLIVE database requires native network encryption (`SQLNET.ENCRYPTION_SERVER = REQUIRED`). Standard Node.js `oracledb` thin mode fails with `ORA-12660: Encryption or crypto-checksumming parameter incompatible`. Only thick mode or the official Oracle JDBC driver (`ojdbc11.jar`) can handshake with this server.
2. **Execution Time & Subprocesses:** Vercel Serverless functions have a hard 10-second timeout limit and cannot spawn long-running Java child processes (`child_process.execFile('java', ...)`). Live aggregations across 70,000+ invoices and 46,000+ container cycles can take 10–25 seconds.
3. **The Solution:** The backend runs as a persistent container/process on a Java-capable host (Railway, Render, AWS EC2, or VPS), while the frontend remains hosted on Vercel.

---

## 🔑 Required Environment Variables

Set these in your hosting provider's dashboard or in `.env`:

| Variable | Description | Example / Default |
| :--- | :--- | :--- |
| `PORT` | HTTP port the server listens on | `5001` (or assigned by platform) |
| `ORACLE_HOST` | Oracle database host IP | `144.24.138.129` |
| `ORACLE_PORT` | Oracle database TNS listener port | `1521` |
| `ORACLE_SERVICE_NAME` | Pluggable database service name | `pdb1.sub06121018360.prodvcn.oraclevcn.com` |
| `ORACLE_USER` | Schema username | `SPJLIVE` |
| `ORACLE_PASSWORD` | Schema password | `SPjlive_0112#` |
| `ORACLE_JDBC_URL` | Complete JDBC connection string | `jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com` |
| `FRONTEND_URL` | Allowed frontend origin for CORS | `https://spj-mauve.vercel.app` |

---

## 🚀 Option 1: Railway Deployment (Recommended — 1-Click Docker)

Railway automatically detects the `backend/Dockerfile` and handles Node.js + Java out of the box.

1. Go to [railway.app](https://railway.app) and sign in with GitHub.
2. Click **New Project** → **Deploy from GitHub repo**.
3. Select `techwithrps/spjjbackend` (or your backend repository).
4. If deploying from a monorepo, set **Root Directory** to `backend`.
5. Go to **Settings** → **Build & Deploy**:
   - Railway will automatically detect `Dockerfile`.
6. Go to **Variables** and add the environment variables listed above (`ORACLE_HOST`, `ORACLE_USER`, `ORACLE_PASSWORD`, etc.).
7. Go to **Settings** → **Networking** → Click **Generate Domain** (e.g. `https://spj-backend-production.up.railway.app`).
8. Verify deployment by opening:
   ```bash
   curl https://your-railway-domain.up.railway.app/
   # Expected JSON: {"name":"SPJ Cargo Intelligence & CIR API","status":"operational","version":"1.0.0"}
   ```

---

## 🚀 Option 2: Render Deployment

1. Go to [dashboard.render.com](https://dashboard.render.com).
2. Click **New +** → **Web Service**.
3. Connect your repository (`techwithrps/spjjbackend`).
4. Configure the service:
   - **Environment:** `Docker` (Render reads `Dockerfile` automatically).
   - **Root Directory:** `.` (or `backend` if deploying from monorepo).
   - **Plan:** `Standard` or `Starter` (at least 1GB RAM recommended for Java heap).
5. In **Environment Variables**, paste the required Oracle credentials from the table above.
6. Click **Create Web Service**.
7. Once deployed, note down your Render service URL (e.g. `https://spj-backend.onrender.com`).

---

## 🚀 Option 3: AWS EC2 / DigitalOcean / Linux VPS (Ubuntu/Debian)

### 1. Install Node.js 20 & OpenJDK 17/21
```bash
# Update system
sudo apt-get update && sudo apt-get upgrade -y

# Install OpenJDK 17
sudo apt-get install -y openjdk-17-jdk-headless git

# Install Node.js 20
curl -fsSL https://deb.nodesource.com/setup_20.x | sudo -E bash -
sudo apt-get install -y nodejs

# Install PM2 process manager
sudo npm install -g pm2
```

### 2. Clone & Build
```bash
git clone https://github.com/techwithrps/spjjbackend.git /var/www/spj-backend
cd /var/www/spj-backend

# Install dependencies
npm install

# Compile Java analytics engine (ojdbc11.jar)
npm run build
```

### 3. Configure Environment
```bash
cat << 'EOF' > .env
PORT=5001
ORACLE_HOST=144.24.138.129
ORACLE_PORT=1521
ORACLE_SERVICE_NAME=pdb1.sub06121018360.prodvcn.oraclevcn.com
ORACLE_USER=SPJLIVE
ORACLE_PASSWORD=SPjlive_0112#
ORACLE_JDBC_URL=jdbc:oracle:thin:@//144.24.138.129:1521/pdb1.sub06121018360.prodvcn.oraclevcn.com
FRONTEND_URL=https://spj-mauve.vercel.app
EOF
```

### 4. Start with PM2
```bash
pm2 start src/server.js --name "spj-backend"
pm2 save
pm2 startup
```

---

## 🚀 Option 4: Local or Server Docker Container

Run directly with Docker anywhere:
```bash
# Build the image
docker build -t spj-backend ./backend

# Run the container
docker run -d \
  -p 5001:5001 \
  --name spj-backend \
  --env-file ./backend/.env \
  --restart unless-stopped \
  spj-backend
```

---

## 🔗 Connecting the Frontend (Vercel) to Deployed Backend

Once your backend is live (e.g., `https://spj-backend-production.up.railway.app` or `https://spj-backend.onrender.com`):

1. Go to your **Vercel Dashboard** → Select the **spj-mauve** project.
2. Go to **Settings** → **Environment Variables**.
3. Add / Update:
   - `VITE_API_URL` = `https://your-backend-domain.com/api`
4. Redeploy the latest commit on Vercel so the frontend picks up the new backend URL.

---

## 🧪 Verification & Health Check Endpoints

| Endpoint | Method | Expected Output |
| :--- | :--- | :--- |
| `/` | `GET` | `{"name":"SPJ Cargo Intelligence & CIR API","status":"operational"}` |
| `/api/masters/terminals` | `GET` | List of 22 active SPJ branch terminals from Oracle |
| `/api/masters/companies` | `GET` | List of 5 group companies |
| `/api/analytics/financial` | `GET` | Live real-time stored procedure KPI calculation |
| `/api/containers` | `GET` | Live container movements from `ALL_PARTY_ACCOUNT` |
