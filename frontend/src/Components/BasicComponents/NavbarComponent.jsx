import React from "react";
import "./navbar.css";
import {Link} from "react-router-dom"
import { Button } from "@mui/material";
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import BasicButton from "./BasicButton";
import { logout } from "../Services/UserService";

const NavbarComponent = ({loggedUser}) => {

    const handleLogout = async ()=>{
        const response = await logout();
        window.location.reload();
    }

    return (
        <div className="navbar-component">
            <HomeOutlinedIcon  sx={{ fontSize: 50, color: "white" }}> </HomeOutlinedIcon>
            <div className="menu-container">
                {loggedUser != null && (
                    <>
                        <Link>
                            <BasicButton color={'secondary'}    text={"Button1"} variant="outlined"></BasicButton>
                        </Link>
                        <Link>
                            <BasicButton color={'secondary'}   text={"Button1"} variant="outlined"></BasicButton>
                        </Link>
                        <Link>
                            <BasicButton  color={'secondary'}   text={"Button1"} variant="outlined"></BasicButton>
                        </Link>
                    </>)}
            </div>
            <div className="menu-container">
                {loggedUser != null ? 
                (
                    <>
                        <p>{loggedUser['name']}</p>
                        <BasicButton color={'secondary'}  text={"Logout"} onClick={handleLogout} variant={"outlined"}></BasicButton>
                    </>
                ) :
                (
                    <>
                    <Link to={'login'}>
                        <BasicButton color={'secondary'}  text={ "Login"} variant="contained"></BasicButton>
                    </Link>
                    <Link to={'register'}>
                        <BasicButton color={'secondary'}  text={"Register"} variant={"outlined"}></BasicButton>
                    </Link>
                </>)}
            </div>
        </div>
    );
};

export default NavbarComponent;