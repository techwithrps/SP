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

export function authFetch(url, options = {}) {
  const token = getAuthToken();
  const headers = {
    'Content-Type': 'application/json',
    ...options.headers,
    ...(token ? { Authorization: `Bearer ${token}` } : {}),
  };
  return fetch(url, { ...options, headers });
}
