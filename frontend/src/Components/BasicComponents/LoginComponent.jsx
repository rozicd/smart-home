import React from "react";
import "./login-component.css";
import HeaderComponent from "./HeaderComponent";
import { useState, useEffect } from "react";
import { signIn } from "../Services/UserService";
import BasicForm from "./BasicForm";
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import Button from '@mui/material/Button';


const loginTemplate = [
    
    {
        item: "BasicInput",
        label: "E-mail",
        itemValue :"email"
    
    },
    {
        item: "BasicInput",
        label: "Password",
        itemValue :"password",
        type: "password"
    }

    
]

const LoginComponent = () => {
    const [userCredentials, setUserCredentials] = useState({});
    const [dialogOpen, setDialogOpen] = useState(false);
    const [dialogTitle, setDialogTitle] = useState("");
    const [dialogContent, setDialogContent] = useState("");

    useEffect(() => {
        console.log("Updated userCredentials:", userCredentials);
    }, [userCredentials]);

    const handleCloseDialog = () => {
        setDialogOpen(false);
    };

    const handleSubmit = async (state) => {
        setUserCredentials(state);
        console.log(userCredentials);
        try {
            const response = await signIn(state);
            if (response) {
                window.location.reload();
            }
        } catch (error) {
            if (error.response && error.response.status === 500) {
                setDialogTitle("Account Not Activated");
                setDialogContent("Account not activated! Check your email.");
                setDialogOpen(true);
            } else {
                setDialogTitle("Error");
                setDialogContent(error.response?.data || "Problem occurred");
                setDialogOpen(true);
            }
        }
    };

    return (
        <div className="login-component">
            <HeaderComponent name={"LOGIN"}></HeaderComponent>
            <div className="login-form">
                <BasicForm template={loginTemplate} callback={handleSubmit} />
                <p>
                    Don't have an account? <a href="/register">Sign up Here.</a>
                </p>
            </div>
            <Dialog open={dialogOpen} onClose={handleCloseDialog}>
                <DialogTitle>{dialogTitle}</DialogTitle>
                <DialogContent>{dialogContent}</DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDialog} color="primary">
                        Close
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default LoginComponent;