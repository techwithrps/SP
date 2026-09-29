import React, { useState, useEffect } from 'react';
import { X, UserPlus, Trash2, Shield, Users, Lock, CheckCircle2, AlertCircle, Key, Search } from 'lucide-react';
import { authFetch } from '../utils/api';

export default function UserManagementModal({ isOpen, onClose, masters }) {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  // Form fields
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [name, setName] = useState('');
  const [role, setRole] = useState('customer');
  const [selectedCustomerId, setSelectedCustomerId] = useState('');
  const [selectedCustomerName, setSelectedCustomerName] = useState('');
  const [customerSearch, setCustomerSearch] = useState('');

  const customersList = masters?.customers || [];

  const filteredCustomers = customersList.filter(c => 
    !customerSearch || 
    (c.name && c.name.toLowerCase().includes(customerSearch.toLowerCase())) ||
    (c.id && String(c.id).includes(customerSearch))
  );

  const fetchUsers = async () => {
    setLoading(true);
    try {
      const res = await authFetch('/api/v1/auth/users');
      const data = await res.json();
      if (data.success) {
        setUsers(data.users || []);
      }
    } catch (err) {
      console.error('Error fetching users:', err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    if (isOpen) {
      fetchUsers();
      setError('');
      setSuccess('');
    }
  }, [isOpen]);

  if (!isOpen) return null;

  const handleCreateUser = async (e) => {
    e.preventDefault();
    if (!username || !password || !name) {
      setError('Username, password, and name are required.');
      return;
    }

    setLoading(true);
    setError('');
    setSuccess('');

    try {
      const res = await authFetch('/api/v1/auth/users', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          username,
          password,
          name,
          role,
          customerId: selectedCustomerId,
          customerName: selectedCustomerName || name,
        })
      });

      const data = await res.json();
      if (data.success) {
        setSuccess(`User '${data.user.username}' created successfully!`);
        setUsername('');
        setPassword('');
        setName('');
        setSelectedCustomerId('');
        setSelectedCustomerName('');
        fetchUsers();
      } else {
        setError(data.message || 'Failed to create user');
      }
    } catch (err) {
      setError('Network error while creating user');
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteUser = async (userId) => {
    if (!window.confirm(`Are you sure you want to delete user account '${userId}'?`)) return;

    try {
      const res = await authFetch(`/api/v1/auth/users/${userId}`, {
        method: 'DELETE',
      });
      const data = await res.json();
      if (data.success) {
        setSuccess('User account removed.');
        fetchUsers();
      } else {
        setError(data.message || 'Could not delete user');
      }
    } catch (err) {
      setError('Failed to delete user');
    }
  };

  return (
    <div className="fixed inset-0 z-50 overflow-y-auto bg-slate-900/60 backdrop-blur-sm flex items-center justify-center p-3 sm:p-6 animate-fadeIn">
      <div className="bg-white rounded-3xl shadow-2xl border border-slate-200 w-full max-w-4xl overflow-hidden flex flex-col max-h-[90vh]">
        
        {/* Modal Header */}
        <div className="bg-gradient-to-r from-[#2b1f55] to-[#4338ca] text-white p-5 sm:p-6 flex items-center justify-between relative">
          <div className="flex items-center gap-3">
            <div className="w-10 h-10 rounded-2xl bg-white/10 flex items-center justify-center backdrop-blur-md">
              <Shield className="w-5 h-5 text-indigo-200" />
            </div>
            <div>
              <h2 className="text-lg sm:text-xl font-bold tracking-tight">User & Access Management</h2>
              <p className="text-xs text-indigo-200">Role-Based Access Control (RBAC) & Tenant Security</p>
            </div>
          </div>
          <button 
            onClick={onClose}
            className="w-9 h-9 rounded-full bg-white/10 hover:bg-white/20 text-white flex items-center justify-center transition-all cursor-pointer"
          >
            <X className="w-5 h-5" />
          </button>
        </div>

        {/* Modal Body */}
        <div className="p-4 sm:p-6 overflow-y-auto space-y-6 flex-1 bg-slate-50/50">

          {/* Feedback Alerts */}
          {error && (
            <div className="p-3 bg-red-50 border border-red-200 text-red-700 rounded-2xl text-xs flex items-center gap-2">
              <AlertCircle className="w-4 h-4 shrink-0" />
              <span>{error}</span>
            </div>
          )}
          {success && (
            <div className="p-3 bg-emerald-50 border border-emerald-200 text-emerald-700 rounded-2xl text-xs flex items-center gap-2">
              <CheckCircle2 className="w-4 h-4 shrink-0" />
              <span>{success}</span>
            </div>
          )}

          {/* Create New User Form */}
          <form onSubmit={handleCreateUser} className="bg-white p-4 sm:p-5 rounded-2xl border border-slate-200 shadow-sm space-y-4">
            <div className="flex items-center gap-2 text-slate-800 font-bold text-sm border-b border-slate-100 pb-2">
              <UserPlus className="w-4 h-4 text-indigo-600" />
              <span>Create New Access Login</span>
            </div>

            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-3">
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Username *</label>
                <input 
                  type="text"
                  required
                  placeholder="e.g. marhaba_hr"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  className="w-full px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Password *</label>
                <input 
                  type="password"
                  required
                  placeholder="e.g. client@123"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  className="w-full px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Account / Company Name *</label>
                <input 
                  type="text"
                  required
                  placeholder="e.g. Marhaba Frozen Foods HR"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-full px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">User Role</label>
                <select
                  value={role}
                  onChange={(e) => setRole(e.target.value)}
                  className="w-full px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 focus:bg-white transition-all outline-none"
                >
                  <option value="customer">Enterprise Customer (Tenant Isolated)</option>
                  <option value="admin">Master Administrator (Full Access)</option>
                  <option value="terminal_operator">Terminal Operator (Terminal Isolated)</option>
                </select>
              </div>

              {role === 'customer' && (
                <div className="sm:col-span-2">
                  <label className="block text-xs font-semibold text-slate-600 mb-1">Link to Oracle Customer Master</label>
                  <div className="space-y-1.5">
                    <input 
                      type="text"
                      placeholder="Search customer name or ID..."
                      value={customerSearch}
                      onChange={(e) => setCustomerSearch(e.target.value)}
                      className="w-full px-3 py-1.5 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 outline-none"
                    />
                    <select
                      value={selectedCustomerId}
                      onChange={(e) => {
                        const cid = e.target.value;
                        setSelectedCustomerId(cid);
                        const found = customersList.find(c => String(c.id) === cid);
                        if (found) setSelectedCustomerName(found.name);
                      }}
                      className="w-full px-3 py-2 bg-slate-50 border border-slate-200 rounded-xl text-xs focus:ring-2 focus:ring-indigo-500 outline-none max-h-32 overflow-y-auto"
                    >
                      <option value="">-- Select Oracle Customer Account --</option>
                      {filteredCustomers.slice(0, 50).map(c => (
                        <option key={c.id} value={c.id}>
                          {c.name} (ID: {c.id})
                        </option>
                      ))}
                    </select>
                  </div>
                </div>
              )}
            </div>

            <div className="flex justify-end pt-2">
              <button
                type="submit"
                disabled={loading}
                className="px-5 py-2.5 bg-gradient-to-r from-[#2b1f55] to-[#4338ca] hover:opacity-95 text-white rounded-xl text-xs font-bold transition-all shadow-md flex items-center gap-2 cursor-pointer disabled:opacity-50"
              >
                <UserPlus className="w-4 h-4" />
                <span>Create User Account</span>
              </button>
            </div>
          </form>

          {/* Active Users Table / Mobile Cards */}
          <div className="bg-white p-4 sm:p-5 rounded-2xl border border-slate-200 shadow-sm space-y-3">
            <div className="flex items-center justify-between border-b border-slate-100 pb-3">
              <div className="flex items-center gap-2 text-slate-800 font-bold text-sm">
                <Users className="w-4 h-4 text-indigo-600" />
                <span>Active User Accounts ({users.length})</span>
              </div>
            </div>

            <div className="overflow-x-auto">
              <table className="w-full text-left text-xs">
                <thead>
                  <tr className="bg-slate-50 text-slate-500 border-b border-slate-200">
                    <th className="p-2.5 font-semibold">User</th>
                    <th className="p-2.5 font-semibold">Role</th>
                    <th className="p-2.5 font-semibold">Tenant Scope</th>
                    <th className="p-2.5 font-semibold text-right">Actions</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-100">
                  {users.map((u) => (
                    <tr key={u.id} className="hover:bg-slate-50/80 transition-colors">
                      <td className="p-2.5">
                        <div className="font-bold text-slate-900">{u.name}</div>
                        <div className="text-[11px] text-slate-500 font-mono">@{u.username}</div>
                      </td>
                      <td className="p-2.5">
                        <span className={`px-2 py-0.5 rounded-full text-[10px] font-bold ${
                          u.role === 'admin' 
                            ? 'bg-purple-100 text-purple-700 border border-purple-200'
                            : 'bg-indigo-100 text-indigo-700 border border-indigo-200'
                        }`}>
                          {u.badge || u.role}
                        </span>
                      </td>
                      <td className="p-2.5 text-slate-600">
                        {u.tenantScope?.type === 'ALL' ? (
                          <span className="text-emerald-600 font-semibold">All Enterprise Tenants</span>
                        ) : (
                          <span>{u.tenantScope?.customerName || u.tenantScope?.customerId || 'Isolated'}</span>
                        )}
                      </td>
                      <td className="p-2.5 text-right">
                        {u.role !== 'admin' && (
                          <button
                            onClick={() => handleDeleteUser(u.id)}
                            className="p-1.5 text-slate-400 hover:text-red-600 hover:bg-red-50 rounded-lg transition-colors cursor-pointer"
                            title="Delete User"
                          >
                            <Trash2 className="w-4 h-4" />
                          </button>
                        )}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

        </div>

      </div>
    </div>
  );
}
