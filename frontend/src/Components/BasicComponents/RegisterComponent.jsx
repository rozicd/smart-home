import React from "react";
import "./register-component.css";
import HeaderComponent from "./HeaderComponent";
import {Link} from 'react-router-dom'
import BasicForm from "./BasicForm";
import ProfilePictureUpload from "./ProfilePictureUpload";
import { useState, useEffect } from "react";
import { register } from "../Services/UserService";
import BasicButton from "./BasicButton";
import { useNavigate } from "react-router-dom";
import InfoDialog from "./InfoDialog";


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

const RegisterComponent = ({headerName = "REGISTER"}) => {
    const navigate = useNavigate();
    const [profilePicture, setProfilePicture] = useState({});
    const [dialogOpen, setDialogOpen] = useState(false);
    const [dialogTitle, setDialogTitle] = useState("");
    const [dialogContent, setDialogContent] = useState("");

    const [formState, setFormState] = useState({});

      const handleCloseDialog = () => {
        setDialogOpen(false);
        navigate("/")
      };

      const handleProfilePictureChange = (picture) => {
        setProfilePicture(picture);
      };

      const handleSubmit = async (state) =>{
        console.log(state)
        const userDTO = {
            Name: state['name'],
            Surname: state['surname'],
            Email: state['email'],
            ImageFile: profilePicture,
            Password: state['password'],
            Status: 0,
            Role: 0
        }
        console.log(userDTO)
        try{
          const response = await register(userDTO)
          if(response){
            setDialogContent("Registration is successful!")
            setDialogOpen(true)
          }
        }catch(error){
          console.log(error)
          setDialogContent("Registration is successful!")
          setDialogOpen(true)
        }
        
      }
    
      
  
    return (
      <div className="register">
        <HeaderComponent name={headerName} />
        <ProfilePictureUpload onProfilePictureChange={handleProfilePictureChange} />
        <div className="register-form"> 
          <BasicForm template={registerTemplate} callback={handleSubmit} />
        </div>
        <div className="button-container">
          <Link to={'/'}>
            <BasicButton text = {'Go back'} variant={'text'}></BasicButton>
          </Link>
        </div>
        <InfoDialog open={dialogOpen} onClose={handleCloseDialog} content={dialogContent}></InfoDialog>
      </div>
    );
  };
  
  export default RegisterComponent;