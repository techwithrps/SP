/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        spj: {
          purpleDark: '#1c133b',
          purple: '#2b1f55',
          purpleHover: '#38296d',
          purpleLight: '#ede9fe',
          navy: '#0f172a',
          orange: '#ff6a00',
          orangeHover: '#e65c00',
          orangeLight: '#fff7ed',
          cyan: '#0284c7',
          cyanLight: '#e0f2fe',
          surface: '#ffffff',
          bg: '#f8fafc',
          border: '#e2e8f0',
          borderDark: '#cbd5e1',
          textDark: '#0f172a',
          textMuted: '#64748b',
          textLight: '#94a3b8',
        }
      },
      fontFamily: {
        sans: ['Inter', 'Outfit', 'system-ui', 'sans-serif'],
        display: ['Outfit', 'Inter', 'sans-serif'],
      },
      boxShadow: {
        'soft': '0 2px 15px -3px rgba(0, 0, 0, 0.05), 0 4px 6px -2px rgba(0, 0, 0, 0.02)',
        'card': '0 4px 20px -2px rgba(43, 31, 85, 0.06)',
        'elevated': '0 10px 30px -5px rgba(43, 31, 85, 0.1)',
        'purple-glow': '0 4px 20px -2px rgba(43, 31, 85, 0.25)',
      }
    },
  },
  plugins: [],
}
