import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import '@mantine/core/styles.css';
import MainPage from "./mainPage/MainPage";
import {  MantineProvider } from '@mantine/core';
import LoginPage from "./routes/LoginPage/LoginPage.tsx";
import Planets from "./planets/Planets.jsx";
import {theme} from "./theme.tsx";

export default function App() {

  return (
    <MantineProvider theme={theme}>
      <BrowserRouter>
        <Routes>
        <Route path="/" element={<MainPage />}>
            {" "}
          </Route>
          <Route path="/login" element={<LoginPage />}>
            {" "}
          </Route>
          <Route path="/planets" element={<Planets />}>
            {" "}
          </Route>
        </Routes>
      </BrowserRouter>
      </MantineProvider>
  );
}