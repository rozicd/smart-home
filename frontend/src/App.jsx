import React, { useState, useEffect } from "react";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { BrowserRouter as Router, Routes, Route, Navigate, Outlet } from "react-router-dom";
import { themeOptions } from "./themeOptions";
import UserPropertiesPage from "./Pages/UserPropertiesPage";
import RegisterPage from "./Pages/RegisterPage";
import LoginPage from "./Pages/LoginPage";
import NavbarComponent from "./Components/BasicComponents/NavbarComponent";
import { authenticateUser } from "./Components/Services/UserService";

function App() {
  const [user, setUser] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    async function fetchData() {
      const response = await authenticateUser();
      if(response == null){
        setIsAuthenticated(false)
        return
      }
      console.log(response)
      setIsAuthenticated(true)
      setUser(response);
      
    }
    fetchData();

    return () => console.log("asdasd");
  }, []);


  return (
    <ThemeProvider theme={themeOptions}>
      <Router>
        <NavbarComponent loggedUser={user} />
        <Routes>
          <Route
            path="/login"
            element={
              isAuthenticated ? <Navigate to="/properties" /> : <LoginPage />
            }
          />
          <Route
            path="/"
            element={
              isAuthenticated ? (
                <Navigate to="/properties" />
              ) : (
                <Navigate to="/login" />
              )
            }
          />
          <Route path="login" element={<LoginPage />}/>
          <Route path="register" element={<RegisterPage />} />
          {user != null && <Route path="properties" element={<UserPropertiesPage userId={user['userId']} />} />}
        </Routes>
      </Router>
      <Outlet/>
    </ThemeProvider>
  );
}

export default App;
