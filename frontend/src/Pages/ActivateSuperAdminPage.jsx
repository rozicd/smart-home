import React from "react";
import parse from 'query-string';
import HeaderComponent from "../Components/BasicComponents/HeaderComponent";
import { useState, useEffect } from "react";
import { useLocation } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import BasicForm from "../Components/BasicComponents/BasicForm";
import "./activate-superadmin.css";
import { activateSuperAdmin } from "../Components/Services/UserService";

const formTemplate = [
    
        {
            item: "BasicInput",
            label: "Old Password",
            itemValue :"oldPassword",
            type: "password"
        
        },
        {
            item: "BasicInput",
            label: "Password",
            itemValue :"password",
            type: "password"
        }
    
    
]


const ActivateSuperAdminPage = () => {
    const [formState, setFormState] = useState({});
    const location = useLocation();
    const navigate = useNavigate();
    const {id} = parse.parse(location.search);

    useEffect(() => {
        
        if(!id){
            navigate('/')
        } else{
            console.log(id)
        }
      }, []);


    const handleSubmit = async (state) => {

        setFormState(state)
        let changeSuperAdminPasswordDTO = {
            Id: id,
            OldPassword: state['oldPassword'],
            Password: state['password']
        }
        console.log(changeSuperAdminPasswordDTO)
        const response = await activateSuperAdmin(changeSuperAdminPasswordDTO);
        if(response){
            window.alert("Super admin activated");
            navigate('/');
        }

        
    }

    return (
        <div className="superadmin-activation">
        <HeaderComponent name = {"Super admin activation"}></HeaderComponent>
        <div className="superadmin-activation-form">
            <BasicForm template={formTemplate} callback={handleSubmit} /> 
        </div>
        
    </div>
    );
}

export default ActivateSuperAdminPage