import React from "react";
import "./basic-items.css";
import { Button } from "@mui/material";

const HeaderComponent = ({ name }) => {
    return (
        <div className="header">
            <p>{name}</p>
        </div>
    );
};

export default HeaderComponent;