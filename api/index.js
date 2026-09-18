const express = require('express');
const cors = require('cors');
require('dotenv').config();

const apiRoutes = require('../backend/src/routes/api');

const app = express();

app.use(cors());
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
