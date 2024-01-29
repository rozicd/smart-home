import React, { useState, useEffect } from "react";
import { authenticateUser } from "../Components/Services/UserService";
import LoginPage from "./LoginPage";
import Home from "./Home";
import { Navigate, useNavigate } from "react-router-dom";
import { KeyboardReturnOutlined } from "@mui/icons-material";

const CheckForAmin = ({ Component,Component2 }) => {
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
        return <p>Loading</p>
    }

    console.log("pre ifa")
    if (!isAuthenticated) {
        console.log("u ifu")
        return <LoginPage/>;
    }
    else if(user.role != 1){
        return <>Forbidden</>;
    }
    
    console.log("komponenta")
    return <Component user={user} />;

  };
  
};

export default CheckForAmin;
