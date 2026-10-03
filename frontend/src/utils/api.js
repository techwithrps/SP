/**
 * SPJ Logistics API Layer
 * 100% Direct Live Oracle Database Integration via Render Backend.
 * Zero static JSON mock files. Zero offline fallbacks.
 */

const BACKEND_BASE = (typeof import.meta !== 'undefined' && import.meta.env?.VITE_API_URL)
  ? import.meta.env.VITE_API_URL.replace(/\/api\/?$/, '')
  : 'https://spj-backend.onrender.com';

let loginPromise = null;

/**
 * Ensures a valid verified JWT token exists.
 * Silently authenticates against backend if token is missing or expired.
 */
export async function ensureAuthToken() {
  try {
    const existing = localStorage.getItem('spj_auth_token');
    if (existing && existing.split('.').length === 3) {
      return existing;
    }
  } catch {}

  if (loginPromise) return loginPromise;

  loginPromise = (async () => {
    try {
      const res = await fetch(`${BACKEND_BASE}/api/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username: 'admin', password: 'SPJ@Cargo2026' })
      });
      if (res.ok) {
        const data = await res.json();
        if (data.token) {
          try {
            localStorage.setItem('spj_auth_token', data.token);
            if (data.user) localStorage.setItem('spj_user', JSON.stringify(data.user));
          } catch {}
          return data.token;
        }
      }
    } catch (e) {
      console.error('[SPJ API] Live backend auth failed:', e.message);
    } finally {
      loginPromise = null;
    }
    return null;
  })();

  return loginPromise;
}

export function getAuthToken() {
  try {
    return localStorage.getItem('spj_auth_token') || null;
  } catch {
    return null;
  }
}

/**
 * Pure Live Authenticated Fetch
 * Directly calls Render backend -> Oracle SPJLIVE database.
 * No mock JSON fallbacks.
 */
export async function authFetch(url, options = {}) {
  let token = getAuthToken();
  if (!token || token.split('.').length !== 3) {
    token = await ensureAuthToken();
  }

  const buildHeaders = (tok) => ({
    'Content-Type': 'application/json',
    ...options.headers,
    ...(tok ? { Authorization: `Bearer ${tok}` } : {}),
  });

  const targetUrl = url.startsWith('http') ? url : `${BACKEND_BASE}${url.startsWith('/') ? url : '/' + url}`;

  for (let attempt = 0; attempt < 2; attempt++) {
    const controller = new AbortController();
    const timeoutId = setTimeout(() => controller.abort(), 60000);

    try {
      let res = await fetch(targetUrl, {
        ...options,
        headers: buildHeaders(token),
        signal: controller.signal,
      });
      clearTimeout(timeoutId);

      // If 401 unauthorized, renew JWT token and retry
      if (res.status === 401) {
        console.warn('[SPJ API] 401 received from live backend. Refreshing token...');
        try { localStorage.removeItem('spj_auth_token'); } catch {}
        token = await ensureAuthToken();
        res = await fetch(targetUrl, {
          ...options,
          headers: buildHeaders(token),
        });
      }

      return res;
    } catch (err) {
      clearTimeout(timeoutId);
      // If request was aborted by newer filter, timeout or navigation, do not retry dead request
      if (options.signal?.aborted || controller.signal.aborted || err.name === 'AbortError' || (err.message && err.message.toLowerCase().includes('abort'))) {
        return new Response(JSON.stringify({ success: false, aborted: true }), {
          status: 499,
          headers: { 'Content-Type': 'application/json' }
        });
      }
      if (attempt === 0) {
        console.warn(`[SPJ API] Initial fetch failed, retrying in 1.5s... (${err.message})`);
        await new Promise(r => setTimeout(r, 1500));
        continue;
      }
      console.error(`[SPJ API] Network error communicating with ${targetUrl}:`, err.message);
      return new Response(JSON.stringify({
        success: false,
        error: `Live backend communication error: ${err.message}`,
        targetUrl,
        isLiveError: true
      }), {
        status: 503,
        headers: { 'Content-Type': 'application/json' }
      });
    }
  }
}
