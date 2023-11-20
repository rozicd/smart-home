import React from "react";
import "./basic-items.css";
import HeaderComponent from "./HeaderComponent";
import { useState } from "react";
import { signIn } from "../Services/UserService";
import BasicForm from "./BasicForm";
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
    const [userCredentials, setUserCredentials] = useState({})

    const handleSubmit = async (state) =>{
        setUserCredentials(state)
        const response = await signIn(userCredentials);
        window.alert(response['email'])
      }

    return (
        <div className="login-component">
            <HeaderComponent name = {"LOGIN"}></HeaderComponent>
            <div className="login-form">
                <BasicForm template={loginTemplate} callback={handleSubmit} />
            </div>
        </div>
    );
};

export default LoginComponent;