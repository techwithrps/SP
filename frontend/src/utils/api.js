/**
 * SPJ Logistics API Layer
 * 100% Direct Live Oracle Database Integration via Render Backend.
 * Zero static JSON mock files. Zero offline fallbacks.
 */

export const BACKEND_BASE = (typeof import.meta !== 'undefined' && import.meta.env?.VITE_API_URL)
  ? import.meta.env.VITE_API_URL.replace(/\/api\/?$/, '')
  : 'https://spj-backend.onrender.com';

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
 * Requires user to be authenticated. Never embeds plain-text master credentials.
 */
export async function authFetch(url, options = {}) {
  const token = getAuthToken();

  const buildHeaders = (tok) => ({
    'Content-Type': 'application/json',
    ...options.headers,
    ...(tok ? { Authorization: `Bearer ${tok}` } : {}),
  });

  const targetUrl = url.startsWith('http') ? url : `${BACKEND_BASE}${url.startsWith('/') ? url : '/' + url}`;

  for (let attempt = 0; attempt < 3; attempt++) {
    const controller = new AbortController();
    const timeoutId = setTimeout(() => controller.abort(), 60000);

    try {
      const res = await fetch(targetUrl, {
        ...options,
        headers: buildHeaders(token),
        signal: options.signal || controller.signal,
      });
      clearTimeout(timeoutId);

      // If 401 unauthorized, session has expired or is invalid
      if (res.status === 401) {
        try {
          localStorage.removeItem('spj_auth_token');
          localStorage.removeItem('spj_auth_user');
        } catch {}
        return res;
      }

      return res;
    } catch (err) {
      clearTimeout(timeoutId);
      // If request was aborted by newer filter, timeout or navigation, do not retry dead request
      if (options.signal?.aborted || controller.signal?.aborted || err.name === 'AbortError' || (err.message && err.message.toLowerCase().includes('abort'))) {
        return new Response(JSON.stringify({ success: false, aborted: true }), {
          status: 499,
          headers: { 'Content-Type': 'application/json' }
        });
      }
      if (attempt < 2) {
        await new Promise(r => setTimeout(r, 150 * (attempt + 1)));
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
