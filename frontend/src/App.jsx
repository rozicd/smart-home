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
import ActivateAccountPage from "./Pages/ActivateAccountPage";
import ActivateSuperAdminPage from "./Pages/ActivateSuperAdminPage";
import { authenticateUser } from "./Components/Services/UserService";
import Home from "./Pages/Home";
import CheckAuthentication from "./Pages/CheckAuthentication";
import { Login } from "@mui/icons-material";
import AdminPropertiesPage from "./Pages/AdminPropertiesPage";
import SmartDevicesPage from "./Pages/SmartDevicesPage";
import AdminCreationPage from "./Pages/AdminCreationPage";
import CheckForSuperAdmin from "./Pages/CheckForSuperAdmin";
import DeviceInfoPage from "./Pages/DeviceInfoPage";
import AdminEnergyPage from "./Pages/AdminEnergyPage";
import CheckForAmin from "./Pages/CheckForAdmin";
export const API_BASE_URL = "http://localhost:8080";
import PropertyEnergyPage from "./Pages/PropertyEnergy";

const AuthenticatedHome = CheckAuthentication({
  Component: Home,
  Component2: Home,
});
const AuthenticatedProperties = CheckAuthentication({
  Component: UserPropertiesPage,
  Component2: AdminPropertiesPage,
});
const AuthenticatedAdmins = CheckForSuperAdmin({
  Component: AdminCreationPage,
});
const AuthenticatedEnergy = CheckForAmin({
  Component: AdminEnergyPage,
});

const App = () => {
  return (
    <ThemeProvider theme={themeOptions}>
      <Router>
        <Routes>
          <Route path="/activate" element={<ActivateAccountPage />} />
          <Route
            path="/activate-superadmin"
            element={<ActivateSuperAdminPage />}
          />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/*" element={<AuthenticatedHome />}>
            <Route path="properties" element={<AuthenticatedProperties />} />

            <Route path="properties/:property" element={<SmartDevicesPage />} />
            <Route path="devices/:deviceType/:deviceId" element={<DeviceInfoPage/>} />
            <Route path="admins" element={<AuthenticatedAdmins />} />
            <Route path="energy" element={<AuthenticatedEnergy />} />
            <Route path="energy/:property" element={<PropertyEnergyPage />} />


          </Route>
        </Routes>
      </Router>
    </ThemeProvider>
  );
};

export default App;
