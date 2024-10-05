import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Login from "./login/Login";
import Register from "./login/Register";
import MainPage from "./mainPage/MainPage";
import {  MantineProvider } from '@mantine/core';

export default function App() {

  return (
    <MantineProvider>
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