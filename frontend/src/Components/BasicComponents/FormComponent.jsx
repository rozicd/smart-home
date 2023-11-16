import {React,useEffect} from "react";
import BasicSelect from "./BasicSelect"; // Import other form components as needed
import BasicRadioButton from "./BasicRadioButtons";
import BasicInput from "./BasicInput";

const FormComponent = ({ props ,form,change}) => {
    useEffect(() => {
      }, [props,form]);

    switch (props.item) {
        
        case "BasicSelect":
            return <BasicSelect
                label={props.label}
                collection={props.collection}
                valueParam={props.valueParam}
                selected = {form[props.itemValue]}
                nameParam={props.nameParam} 
                callback = {(e)=>change(props.itemValue,e.target.value)}   
                />;
        case "BasicInput":
            return <BasicInput 
            label={props.label}
            type = {props.type}
            value = {form[props.itemValue]}
            callback = {(e)=>change(props.itemValue,e.target.value)}   



            />;
        case "BasicRadio":
            return <BasicRadioButton 
            label={props.label}
            value = {form[props.itemValue]}
            callback = {(e)=>change(props.itemValue,e.target.value)}   
            choices={props.choices}
            identificator={props.identificator}

             />;
        default:
            return null;
    }
};

export default FormComponent;
