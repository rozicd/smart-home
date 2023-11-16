import React from "react";
import "./basic-items.css";
import { FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from "@mui/material";
const BasicRadioButton = ({ label, choices, value, identificator, callback }) => {
    return (
        <div className="form-item">
            <FormLabel 
            id={"id-" + identificator + "-group"}>{label}</FormLabel>
            <RadioGroup
                row
                aria-labelledby={"id-" + identificator + "-group"}
                name={+identificator + "-group"}
                value={value?value:0}
                onChange={callback}
            >
                {choices.map((item, index) => (
                    <FormControlLabel key={index} value={index} control={<Radio />} label={item} />
                ))}

            </RadioGroup>
        </div>
    );
};

export default BasicRadioButton;