import React from "react";
import "./login-component.css";
import HeaderComponent from "./HeaderComponent";
import { useState, useEffect } from "react";
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

    useEffect(() => {

        console.log("Updated userCredentials:", userCredentials);
      }, [userCredentials]);

    const handleSubmit = async (state) =>{
        setUserCredentials(state)
        console.log(userCredentials)
        try{
            const response = await signIn(state);
        if(response){
            window.location.reload();
        }
        }catch(error){
            if(error.response.status == 500){
                console.log("usao")
                window.alert("Account not activated! Check your email.")
            }else{
                window.alert(error.response.data || "Problem occured")
            } 
        }
        
        
      }

    return (
        <div className="login-component">
            <HeaderComponent name = {"LOGIN"}></HeaderComponent>
            <div className="login-form">
                <BasicForm template={loginTemplate} callback={handleSubmit} /> 
                <p>Don't have account? <a href="/register">Sign up Here.</a></p> 
            </div>
            
        </div>
    );
};

export default LoginComponent;