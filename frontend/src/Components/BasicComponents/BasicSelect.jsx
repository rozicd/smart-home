import React from "react";
import "./basic-items.css";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

const BasicSelect = ({ label, callback, selected, collection, valueParam, nameParam }) => {
    return (
        <FormControl >
            <InputLabel id={label + "-id"}>{label}</InputLabel>
            <Select
                labelId={label + "-id"}
                id={label + "-select"}
                value={selected}
                label={label}
                onChange={callback}
            >
                {collection.map((item, index) => (
                    <MenuItem  value={item[valueParam]}>{item[nameParam]}</MenuItem>
                ))}
                
            </Select>
        </FormControl>
    );
};

export default BasicSelect;