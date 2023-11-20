import React from "react";
import "./navbar.css";
import { Button } from "@mui/material";
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import BasicButton from "./BasicButton";

const NavbarComponent = ({ loggedUser = {} }) => {
    return (
        <div className="navbar-component">
            <HomeOutlinedIcon  sx={{ fontSize: 50, color: "white" }}> </HomeOutlinedIcon>
            <div className="menu-container">
                <BasicButton color={'secondary'}    text={"Button1"} variant="outlined"></BasicButton>
                <BasicButton color={'secondary'}   text={"Button1"} variant="outlined"></BasicButton>
                <BasicButton  color={'secondary'}   text={"Button1"} variant="outlined"></BasicButton>
            </div>
            <div className="menu-container">
                <BasicButton color={'secondary'}  text={ "Login"} variant="contained"></BasicButton>
                <BasicButton color={'secondary'}  text={"Register"} variant={"outlined"}></BasicButton>
            </div>
        </div>
    );
};

export default NavbarComponent;