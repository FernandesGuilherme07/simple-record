import React from 'react';
import ReactDOM from 'react-dom/client';
import './styles/index.css';
import { AppRoutes } from './router';
import { ToastContainer } from 'react-toastify';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <ToastContainer />
    <AppRoutes />
  </React.StrictMode>
);
