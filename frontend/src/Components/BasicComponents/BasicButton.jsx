import React from "react";
import "./basic-items.css";
import { Button } from "@mui/material";

const BasicButton = ({ color, text, onClick, variant="contained" }) => {
    return (
        <Button
        
            variant={variant}
            color={color}
            className="btn form-item"
            onClick={onClick}
        >
        {text}
        </Button>
    );
};

export default BasicButton;