import React from "react";
import "./basic-items.css";
import { FormControl,TextField } from "@mui/material";

const BasicInput = ({type, label, callback, value, visibility='visible' }) => {
    return (
        < div
        className="form-item"

        >
        
            <TextField id={label} 
            label={label} 
            onChange={callback} 
            variant="standard"
            visibility={visibility}
             type = {type} 
             value ={value?value:""}/>
        </div>
    );
};

export default BasicInput;