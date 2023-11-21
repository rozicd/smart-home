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

const AuthenticatedHome = CheckAuthentication({ Component: Home });
const AuthenticatedProperties = CheckAuthentication({ Component: UserPropertiesPage });





const App = () => {
  return (
    <ThemeProvider theme={themeOptions}>
      <Router>
        <Routes>
          <Route path="/activate" element={<ActivateAccountPage/>}/>
          <Route path="/activate-superadmin" element={<ActivateSuperAdminPage/>}/>
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/*" element={<AuthenticatedHome />} >
            <Route path="properties" element={<AuthenticatedProperties />} />
            </Route>
        </Routes>
      </Router>
    </ThemeProvider>
  );
};

export default App;
