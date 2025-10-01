import React, { useState } from 'react';
import axios from 'axios';

const RegisterForm = () => {
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: ''
  });
  const [imageFile, setImageFile] = useState(null);
  const [message, setMessage] = useState('');

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setImageFile(file);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = new FormData();
    data.append('username', formData.username);
    data.append('email', formData.email);
    data.append('password', formData.password);
    if (imageFile) {
      data.append('image', imageFile);
    }
    try {
      // Replace the URL below with the address of your backend API when deployed
      await axios.post('https://dd-backend-webapp.azurewebsites.net/api/users/register', data, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
      setMessage('User registered successfully.');
      setFormData({ username: '', email: '', password: '' });
      setImageFile(null);
    } catch (error) {
      console.error(error);
      if (error.response && error.response.data) {
        setMessage(error.response.data);
      } else {
        setMessage('Error registering user.');
      }
    }
  };

  return (
    <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '0.5rem' }}>
      <label>
        Username
        <input
          type="text"
          name="username"
          value={formData.username}
          onChange={handleChange}
          required
        />
      </label>
      <label>
        Email
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
      </label>
      <label>
        Password
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          required
        />
      </label>
      <label>
        Profile Image
        <input type="file" name="image" accept="image/*" onChange={handleFileChange} />
      </label>
      <button type="submit">Register</button>
      {message && <p>{message}</p>}
    </form>
  );
};

export default RegisterForm;