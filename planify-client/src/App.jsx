import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import UsersPage from './pages/UsersPage';
import TripsPage from './pages/TripsPage';
import CreateUserPage from './pages/CreateUserPage';


function App() {
  return (
    <Router>
      <Routes>
        <Route path="/users" element={<UsersPage />} />
        <Route path="/trips" element={<TripsPage />} />
      <Route path="/users/create" element={<CreateUserPage />} />
      </Routes>
    </Router>
  );
}

export default App;
