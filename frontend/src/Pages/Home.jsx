// Home.jsx
import React from "react";
import NavbarComponent from "../Components/BasicComponents/NavbarComponent";
import CheckAuthentication from "./CheckAuthentication";
import { Outlet } from "react-router-dom";
import { useNavigate } from "react-router-dom";

const Home = ({ user }) => {
  const navigate = useNavigate();
  

  return (
    <div>
      <NavbarComponent loggedUser={user} />
      <Outlet></Outlet>
    </div>
  );
};

export default Home;
