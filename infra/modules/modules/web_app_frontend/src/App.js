import React from 'react';
import RegisterForm from './components/RegisterForm';

function App() {
  return (
    <div style={{ maxWidth: '600px', margin: '0 auto', padding: '1rem' }}>
      <h1>User Registration</h1>
      <RegisterForm />
    </div>
  );
}

export default App;