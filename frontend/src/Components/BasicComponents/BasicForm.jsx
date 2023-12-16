import React, { useEffect,useState } from "react";
import FormComponent from "./FormComponent"; // Assuming you've created a FormComponent
import { FormControl,Form} from "@mui/material";
import BasicButton from "./BasicButton";
import './basic-items.css'
import { maxWidth, minWidth } from "@mui/system";
const BasicForm = ({ template, callback, label= "Create item"}) => {


  const [formState, setFormState] = useState({});

  const handleInputChange = (itemName, value) => {
    console.log(itemName)
    setFormState((prevFormState) => ({
      ...prevFormState,
      [itemName]: value,
    }));
  };
  return (
    <div className="basic-form">
      {/* <h2>{label}</h2> */}
      {template.map((item, index) => (
        <FormComponent 
         
         key={index}
         props = {item} 
         form ={formState} 
         change={handleInputChange} />
      ))}
    <BasicButton text={"Submit"} onClick={()=>{callback(formState)}}/>
    </div>
    
  );
};

export default BasicForm;
