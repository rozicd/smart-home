import React from "react";
import "./basic-items.css";
import { FormControl,TextField } from "@mui/material";

const BasicInput = ({type, label, callback, value, visibility='visible' }) => {
    return (
        < div
        className="form-item"

        >
            
            <TextField sx= {{width:"100%"}} id={label} 
            label={label} 
            onChange={callback} 
            visibility={visibility}
             type = {type} 
             value ={value?value:""}/>
        </div>
    );
};

export default BasicInput;