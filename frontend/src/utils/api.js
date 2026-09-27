/**
 * Centralized Authenticated Fetch Helper
 * Injects Authorization: Bearer <token> for all protected API requests.
 */

export function getAuthToken() {
  try {
    return localStorage.getItem('spj_auth_token') || '';
  } catch {
    return '';
  }
}

const API_BASE = (typeof import.meta !== 'undefined' && import.meta.env?.VITE_API_URL) ? import.meta.env.VITE_API_URL.replace(/\/api\/?$/, '') : '';

export function authFetch(url, options = {}) {
  const token = getAuthToken();
  const headers = {
    'Content-Type': 'application/json',
    ...options.headers,
    ...(token ? { Authorization: `Bearer ${token}` } : {}),
  };
  const fullUrl = url.startsWith('http') ? url : `${API_BASE}${url}`;
  return fetch(fullUrl, { ...options, headers });
}
