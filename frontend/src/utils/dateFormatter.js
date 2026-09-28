/**
 * SPJ Date Formatting Utility
 * Standardizes all date inputs to DD/MM/YYYY Indian ERP format.
 */

export function parseToYYYYMMDD(inputStr) {
  if (!inputStr) return '';
  const s = String(inputStr).trim();
  if (/^\d{4}-\d{2}-\d{2}$/.test(s)) return s;
  
  // Matches DD/MM/YYYY or DD-MM-YYYY or D/M/YYYY
  const dmy = s.match(/^(\d{1,2})[\/\-](\d{1,2})[\/\-](\d{4})$/);
  if (dmy) {
    const d = dmy[1].padStart(2, '0');
    const m = dmy[2].padStart(2, '0');
    const y = dmy[3];
    // Check basic validity
    const numM = parseInt(m, 10);
    const numD = parseInt(d, 10);
    if (numM >= 1 && numM <= 12 && numD >= 1 && numD <= 31) {
      return `${y}-${m}-${d}`;
    }
  }
  return '';
}

export function formatToDDMMYYYY(dateStr) {
  if (!dateStr) return '';
  const s = String(dateStr).trim();
  if (s.match(/^\d{4}-\d{2}-\d{2}$/)) {
    const [y, m, d] = s.split('-');
    return `${d}/${m}/${y}`;
  }
  if (s.match(/^\d{2}\/\d{2}\/\d{4}$/)) {
    return s;
  }
  return s;
}

export function formatToReadableIndian(dateStr) {
  if (!dateStr) return '';
  const s = String(dateStr).trim();
  const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  
  if (s.match(/^\d{4}-\d{2}-\d{2}$/)) {
    const [y, m, d] = s.split('-');
    const mIdx = parseInt(m, 10) - 1;
    return `${d} ${months[mIdx] || m} ${y}`;
  }
  if (s.match(/^\d{2}\/\d{2}\/\d{4}$/)) {
    const [d, m, y] = s.split('/');
    const mIdx = parseInt(m, 10) - 1;
    return `${d} ${months[mIdx] || m} ${y}`;
  }
  return s;
}
