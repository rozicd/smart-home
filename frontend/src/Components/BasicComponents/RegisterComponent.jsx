import React from "react";
import "./basic-items.css";
import HeaderComponent from "./HeaderComponent";
import BasicForm from "./BasicForm";
import { Button } from "@mui/material";
import ProfilePictureUpload from "./ProfilePictureUpload";
import { useState, useEffect } from "react";


const registerTemplate = 
[
    {
        item: "BasicInput",
        label: "Name",
        itemValue :"name"
    
        },
        {
        item: "BasicInput",
        label: "Surname",
        itemValue :"surname"
    
        },
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

const RegisterComponent = () => {
    const [profilePicture, setProfilePicture] = useState(null);
    const [formState, setFormState] = useState(null);
  
    useEffect(() => {
        // console.log(profilePicture);
        console.log(formState);
      }, [profilePicture, formState]);
    
      const handleProfilePictureChange = (picture) => {
        setProfilePicture(picture);
      };

      const handleSubmit = (state) =>{
        setFormState(state)
        const userDTO = {
            profilePicture: profilePicture,
            name: formState['name'],
            surname: formState['surname'],
            email: formState['email'],
            passoword: formState['passoword']
        }
        console.log(userDTO)
      }
    
      
  
    return (
      <div className="register">
        <HeaderComponent name="REGISTER" />
        <ProfilePictureUpload onProfilePictureChange={handleProfilePictureChange} />
        <div className="register-form"> 
          <BasicForm template={registerTemplate} callback={handleSubmit} />
        </div>
      </div>
    );
  };
  
  export default RegisterComponent;