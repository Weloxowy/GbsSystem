import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Login from "./login/Login";
import Register from "./login/Register";
import MainPage from "./mainPage/MainPage";
import {  MantineProvider } from '@mantine/core';
import {theme} from "./theme.tsx";
import '@mantine/core/styles.css';

export default function App() {

  return (
    <MantineProvider theme={theme}>
      <BrowserRouter>
        <Routes>
        <Route path="/" element={<MainPage />}>
            {" "}
          </Route>
          <Route path="/login" element={<Login />}>
            {" "}
          </Route>
          <Route path="/register" element={<Register />}>
            {" "}
          </Route>
        </Routes>
      </BrowserRouter>
      </MantineProvider>
  );
}