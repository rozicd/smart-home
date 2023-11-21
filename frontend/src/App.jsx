import React, { useState, useEffect } from "react";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
  Outlet,
} from "react-router-dom";
import { themeOptions } from "./themeOptions";
import UserPropertiesPage from "./Pages/UserPropertiesPage";
import RegisterPage from "./Pages/RegisterPage";
import LoginPage from "./Pages/LoginPage";
import NavbarComponent from "./Components/BasicComponents/NavbarComponent";
import { authenticateUser } from "./Components/Services/UserService";
import Home from "./Pages/Home";
import CheckAuthentication from "./Pages/CheckAuthentication";
import { Login } from "@mui/icons-material";
import AdminPropertiesPage from "./Pages/AdminPropertiesPage";
import SmartDevicePage from "./Pages/SmartDevicePage";

const AuthenticatedHome = CheckAuthentication({ Component: Home, Component2:Home });
const AuthenticatedProperties = CheckAuthentication({ Component: UserPropertiesPage, Component2: AdminPropertiesPage });





const App = () => {
  return (
    <ThemeProvider theme={themeOptions}>
      <Router>
        <Routes>
          
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/*" element={<AuthenticatedHome />} >
            <Route path="properties" element={<AuthenticatedProperties />} >
             

              </Route>
              <Route path="properties/:property" element={<SmartDevicePage />} />
            </Route>
        </Routes>
      </Router>
    </ThemeProvider>
  );
};

export default App;
