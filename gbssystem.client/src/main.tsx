import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import LoginPage from "./routes/LoginPage/LoginPage.tsx";
    {
        path: "/login",
        element: <LoginPage />,
        errorElement: <ErrorPage />,
    },



ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
)