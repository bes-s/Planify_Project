import React, { useState } from 'react';
import userApi from '../api/userApi';
import { useNavigate } from 'react-router-dom';

function CreateUserPage() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await userApi.create({
        firstName,
        lastName,
        email,
        passwordHash: password,
        createdAt: new Date().toISOString()
      });
      navigate('/users');
    } catch (error) {
      console.error('Failed to create user', error);
    }
  };

  return (
    <div>
      <h2>Create New User</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>First Name:</label>
          <input value={firstName} onChange={(e) => setFirstName(e.target.value)} required />
        </div>
        <div>
          <label>Last Name:</label>
          <input value={lastName} onChange={(e) => setLastName(e.target.value)} required />
        </div>
        <div>
          <label>Email:</label>
          <input value={email} onChange={(e) => setEmail(e.target.value)} required />
        </div>
        <div>
          <label>Password:</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
        </div>
        <button type="submit">Create</button>
      </form>
    </div>
  );
}

export default CreateUserPage;
