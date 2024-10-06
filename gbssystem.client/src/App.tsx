import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import '@mantine/core/styles.css';
import MainPage from "./mainPage/MainPage";
import {  MantineProvider } from '@mantine/core';
import LoginPage from "./routes/LoginPage/LoginPage.tsx";
import Planets from "./planets/Planets.jsx";
import {theme} from "./theme.tsx";
import NavBarMenu from "./NavBarMenu/NavBarMenu.tsx";
import Quiz from "./quiz/Quiz.tsx";

export default function App() {

  return (
    <MantineProvider theme={theme} forceColorScheme={"dark"}>
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
          <Route path="/navBarMenu" element={<NavBarMenu />}>
                {" "}
            </Route>
<Route path="/quiz" element={<Quiz />}>
                {" "}
            </Route>
        </Routes>
      </BrowserRouter>
      </MantineProvider>
  );
}