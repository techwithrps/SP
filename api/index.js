const express = require('express');
const cors = require('cors');
require('dotenv').config();

const apiRoutes = require('../backend/src/routes/api');

const app = express();

app.disable('x-powered-by');

// Security headers
app.use((req, res, next) => {
  res.setHeader('X-Content-Type-Options', 'nosniff');
  res.setHeader('X-Frame-Options', 'DENY');
  res.setHeader('Referrer-Policy', 'strict-origin-when-cross-origin');
  next();
});

const allowedOrigins = [
  'https://spj-mauve.vercel.app',
  'http://localhost:5173',
  'http://localhost:3000',
  'http://localhost:5001',
  'http://127.0.0.1:5173',
  'http://127.0.0.1:5001',
  process.env.FRONTEND_URL,
].filter(Boolean);

const corsOptions = {
  origin: (origin, callback) => {
    if (!origin) return callback(null, true);
    const isAllowed = allowedOrigins.some(
      allowed => allowed === origin || (allowed.endsWith('.vercel.app') && origin.endsWith('.vercel.app'))
    );
    if (isAllowed) return callback(null, true);
    return callback(new Error('CORS policy: Not allowed by Access-Control-Allow-Origin.'));
  },
  methods: ['GET', 'POST', 'PUT', 'DELETE', 'OPTIONS'],
  allowedHeaders: ['Content-Type', 'Authorization', 'x-auth-token', 'x-admin-key'],
};

app.use(cors(corsOptions));
app.use(express.json());

// API routes
app.use('/api', apiRoutes);

// Root fallback
app.get('/', (req, res) => {
  res.json({
    status: 'online',
    name: 'SPJ Cargo Intelligence & CIR API (Vercel Serverless)',
    version: '1.0.0',
  });
});

module.exports = app;
