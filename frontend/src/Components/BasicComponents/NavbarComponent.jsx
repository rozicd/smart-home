import React from "react";
import "./navbar.css";
import { Link, useNavigate } from "react-router-dom";
import { Button, Container } from "@mui/material";
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import BasicButton from "./BasicButton";
import { logout } from "../Services/UserService";

const NavbarComponent = ({ loggedUser }) => {
  const navigate = useNavigate();
  const handleLogout = async () => {
    const response = await logout();
    navigate("/");
    window.location.reload();
  };

  return (
    <div className="navbar-component">
      <div className="menu-container">
        {loggedUser != null && (
          <>
            <Link className="nav-link nav-btn nav-first" to={"properties"}>
              <div>Properties</div>
            </Link>
            <Link className="nav-link nav-btn" to={"properties"}>
              <div>Butoon</div>
            </Link>
            {loggedUser.role == 2 && (
              <Link className="nav-link nav-btn" to={"admins"}>
              <div>Admins</div>
            </Link>
            )}
          </>
        )}
      </div>
      <div className="menu-container">
        {loggedUser != null ? (
          <>
            <p
            className="logout nav-btn"
              onClick={handleLogout}
            >
              Logout
            </p>
          </>
        ) : (
          <>
            <Link to={"/login"}>
              <BasicButton
                color={"secondary"}
                text={"Login"}
                variant="contained"
              ></BasicButton>
            </Link>
            <Link to={"/register"}>
              <BasicButton
                color={"secondary"}
                text={"Register"}
                variant={"outlined"}
              ></BasicButton>
            </Link>
          </>
        )}
      </div>
    </div>
  );
};

export default NavbarComponent;
