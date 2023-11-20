import React, { useEffect,useState } from "react";
import FormComponent from "./FormComponent"; // Assuming you've created a FormComponent
import { FormControl } from "@mui/material";
import BasicButton from "./BasicButton";
import './basic-items.css'
const BasicForm = ({ template, callback, label= "Create item"}) => {


  const [formState, setFormState] = useState({});

  const handleInputChange = (itemName, value) => {
    setFormState((prevFormState) => ({
      ...prevFormState,
      [itemName]: value,
    }));
  };
  return (
    <FormControl className="basic-form">
      {/* <h2>{label}</h2> */}
      {template.map((item, index) => (
        <FormComponent 
        
         key={index}
         props = {item} 
         form ={formState} 
         change={handleInputChange} />
      ))}
    <BasicButton text={"Submit"} onClick={()=>{callback(formState)}}/>
    </FormControl>
    
  );
};

export default BasicForm;
