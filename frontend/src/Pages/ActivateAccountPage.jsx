import React from "react";
import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { useParams, useNavigate } from 'react-router-dom';
import { activateUser } from "../Components/Services/UserService";
import parse from 'query-string';


const ActivateAccountPage = () => {
    const location = useLocation();
    const { id, token } = parse.parse(location.search);
    const [activated, setActivated] = useState(false);
    const navigate = useNavigate();
    
    useEffect(() => {
        if(id && token){

            console.log({userId:id, token:token})
            const response = activateUser({userId:id, token:token})
            if(response){
                setActivated(true);
                setTimeout(()=>{
                    navigate('/')
                }, 2000)
            }
            
        }else{
            navigate('/')
        }
      }, []);
    if(activated){
        return (
            <div>
                <p>Your account has been successfully activated.</p>
            </div>
        );
    }
    return(
        <div>
            <p>Activating your account, please wait...</p>
        </div>
    )
};

export default ActivateAccountPage;