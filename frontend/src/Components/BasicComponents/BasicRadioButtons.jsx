import React from "react";
import "./basic-items.css";
import { FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from "@mui/material";
const BasicRadioButton = ({ label, choices, value, identificator, callback }) => {
    return (
        <FormControl>
            <FormLabel id={"id-" + identificator + "-group"}>{label}</FormLabel>
            <RadioGroup
                row
                aria-labelledby={"id-" + identificator + "-group"}
                name={+identificator + "-group"}
                value={value}
                onChange={callback}
            >
                {choices.map((item, index) => (
                    <FormControlLabel value={index} control={<Radio />} label={item} />
                ))}

            </RadioGroup>
        </FormControl>
    );
};

export default BasicRadioButton;