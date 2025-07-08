import React, { useEffect, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import userApi from '../api/userApi';

function UsersPage() {
  const [users, setUsers] = useState([]);
  const location = useLocation(); // Track the route

  const fetchUsers = async () => {
    try {
      const res = await userApi.getAll();
      setUsers(res.data);
    } catch (err) {
      console.error('Failed to fetch users', err);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, [location]); // Re-fetch on route change

  return (
    <div>
      <h2>All Users</h2>
      <Link to="/users/create">
        <button style={{ marginBottom: '1rem' }}>Create New User</button>
      </Link>
      <ul>
        {users.map((user) => (
          <li key={user.userId}>
            {user.firstName} {user.lastName}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default UsersPage;
