import React from "react";
import "./navbar.css";
import {Link, useNavigate} from "react-router-dom"
import { Button } from "@mui/material";
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import BasicButton from "./BasicButton";
import { logout } from "../Services/UserService";

const NavbarComponent = ({loggedUser}) => {
    const navigate = useNavigate();
    const handleLogout = async ()=>{
        const response = await logout();
        navigate("/")
        window.location.reload();
    }

    return (
        <div className="navbar-component">
            <HomeOutlinedIcon  sx={{ fontSize: 50, color: "white" }}> </HomeOutlinedIcon>
            <div className="menu-container">
                {loggedUser != null && (
                    <>
                        <Link to = {'properties'}>
                            <BasicButton color={'secondary'}    text={"Properties"} variant="outlined"></BasicButton>
                        </Link>
                        <Link>
                            <BasicButton color={'secondary'}   text={"Button1"} variant="outlined"></BasicButton>
                        </Link>
                        {loggedUser.role == 2 &&
                        <Link to={'admins'}>
                            <BasicButton  color={'secondary'}   text={"Admins"} variant="outlined"></BasicButton>
                        </Link>}
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
                    <Link to={'/login'}>
                        <BasicButton color={'secondary'}  text={ "Login"} variant="contained"></BasicButton>
                    </Link>
                    <Link to={'/register'}>
                        <BasicButton color={'secondary'}  text={"Register"} variant={"outlined"}></BasicButton>
                    </Link>
                </>)}
            </div>
        </div>
    );
};

export default NavbarComponent;