// Home.jsx
import React from "react";
import NavbarComponent from "../Components/BasicComponents/NavbarComponent";
import CheckAuthentication from "./CheckAuthentication";
import { Outlet } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { Height } from "@mui/icons-material";

const Home = ({ user }) => {
  const navigate = useNavigate();
  

  return (
  <div style={{ height: '100vh', display: 'flex', flexDirection: 'column' }}>
    <NavbarComponent loggedUser={user} />
    <Outlet style={{ flex: 1, overflowY: 'auto' }}></Outlet>
  </div>
  );
};

export default Home;
