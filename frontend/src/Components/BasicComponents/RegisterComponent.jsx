import React from "react";
import "./basic-items.css";
import HeaderComponent from "./HeaderComponent";
import BasicForm from "./BasicForm";
import ProfilePictureUpload from "./ProfilePictureUpload";
import { useState, useEffect } from "react";
import { register } from "../Services/UserService";
import BasicButton from "./BasicButton";



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
    const [profilePicture, setProfilePicture] = useState([]);
    const [formState, setFormState] = useState({});
  
    useEffect(() => {
        // console.log(profilePicture);
        console.log(formState);
      }, [profilePicture, formState]);
    
      const handleProfilePictureChange = (picture) => {
        setProfilePicture(picture);
      };

      const handleSubmit = async (state) =>{
        setFormState(state)
        const userDTO = {
            Name: formState['name'],
            Surname: formState['surname'],
            Email: formState['email'],
            ImageFile: profilePicture,
            Password: formState['password'],
            Status: 0,
            Role: 0
        }
        console.log(userDTO)
        const response = await register(userDTO)
        window.alert(response)

      }
    
      
  
    return (
      <div className="register">
        <HeaderComponent name="REGISTER" />
        <ProfilePictureUpload onProfilePictureChange={handleProfilePictureChange} />
        <div className="register-form"> 
          <BasicForm template={registerTemplate} callback={handleSubmit} />
        </div>
        <div className="button-container">
          <BasicButton text = {'Go back'} variant={'text'}></BasicButton>
        </div>
      </div>
    );
  };
  
  export default RegisterComponent;