import React from "react";
import "./basic-items.css";
import { Button } from "@mui/material";

const BasicButton = ({ color, text, onClick }) => {
    return (
        <Button
            variant="contained"
            color={color}
            className="btn"
            onClick={onClick}
        >
        {text}
        </Button>
    );
};

export default BasicButton;