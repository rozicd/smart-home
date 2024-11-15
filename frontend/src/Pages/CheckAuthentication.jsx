import React, { useState, useEffect } from "react";
import { authenticateUser } from "../Components/Services/UserService";
import LoginPage from "./LoginPage";
import { Navigate, useNavigate } from "react-router-dom";
import { KeyboardReturnOutlined } from "@mui/icons-material";
import LoadingComponent from "../Components/BasicComponents/LoadingComponent";

const CheckAuthentication = ({ Component,Component2}) => {
  return  () => {
    const navigate = useNavigate();

    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
      async function fetchData() {
        try {
          const response = await authenticateUser();
          console.log("Response: " + response)
          if (!response) {
            setIsAuthenticated(false);
            console.log("nisam ulogovan")
            return;
          }
          console.log(response);
          setIsAuthenticated(true);
          setUser(response);
        } catch (error) {
          console.error("Error authenticating user:", error);
          setIsAuthenticated(false);
        }
        finally {
            setIsLoading(false)
        }
      }
      fetchData();
      console.log("effect")
    }, []);

    if(isLoading) {
        return <LoadingComponent/>
    }

    if (!isAuthenticated) {
        return <LoginPage/>;
    }
    
    if (user.role == 0){
      return <Component user={user} />;
    }
    else if (user.role == 1 || user.role == 2){
      console.log("ADMIN COMPONENT")
      return <Component2 user={user} />;
    }

  };
  
};

export default CheckAuthentication;
