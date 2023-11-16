import React from "react";
import "./basic-items.css";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

const BasicSelect = ({ label, callback, selected, collection, valueParam, nameParam }) => {
    return (
        < >
            <Select
                sx={{ m: 1, minWidth: 120,maxHeight:40,marginTop:"20px" }}
                id={label + "-select"}
                className="form-item"
                value={selected ? selected : "x"}
                displayEmpty
                onChange={callback}
            >
                <MenuItem value={"x"}>{"Select " + label}</MenuItem>

                {collection.map((item, index) => (
                    <MenuItem key={item[valueParam]} value={item[valueParam]}>{item[nameParam]}</MenuItem>
                ))}

            </Select>
        </>
    );
};

export default BasicSelect;