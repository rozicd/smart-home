import React from "react";
import "./basic-items.css";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

const BasicSelect = ({ label, callback, selected, collection, valueParam, nameParam, visibility='visible' }) => {
    return (
        <FormControl className="form-item" sx={{ m: 1, minWidth: 120,maxHeight:40,marginTop:"20px",visibility:visibility }}
        >
            <Select
                id={label + "-select"}
                key={label + "-select"}
                value={selected ? selected : "x"}
                displayEmpty
                onChange={callback}
            >   
                <MenuItem value={"x"}>{"Select " + label}</MenuItem>

                {collection.map((item, index) => (
                    <MenuItem key={index} value={item[valueParam]}>{item[nameParam]}</MenuItem>
                ))}

            </Select>
        </FormControl>
    );
};

export default BasicSelect;