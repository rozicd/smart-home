import React, { useEffect, useState } from "react";
import BasicSelect from "./BasicSelect";
import BasicRadioButton from "./BasicRadioButtons";
import BasicInput from "./BasicInput";
import MapComponent from "./MapComponent";
import Dropzone from "react-dropzone";
import { Box } from "@mui/material";
import {Typography} from "@mui/material";
import RegistrationInput from "./RegistrationInput";
import MultipleSelect from "./MultipleSelect";

const FormComponent = ({ props, form, change }) => {
  const [imageFile, setImageFile] = useState(null);

  useEffect(() => {}, [props, form]);

  const handleImageDrop = (acceptedFiles) => {
    const file = acceptedFiles[0];
    const imageFiles = acceptedFiles.filter((file) =>
      file.type.startsWith("image/")
    );
    setImageFile(imageFiles[0]);
    change("imageFile", imageFiles[0]);
  };

  switch (props.item) {
    case "BasicSelect":
      return (
        <BasicSelect
          label={props.label}
          collection={props.collection}
          valueParam={props.valueParam}
          selected={form[props.itemValue]}
          nameParam={props.nameParam}
          callback={(e) => change(props.itemValue, e.target.value)}
        />
      );
    case "BasicInput":
      return (
        <BasicInput
          label={props.label}
          type={props.type}
          value={form[props.itemValue]}
          callback={(e) => change(props.itemValue, e.target.value)}
        />
      );
    case "BasicRadio":
      return (
        <BasicRadioButton
          label={props.label}
          value={form[props.itemValue]}
          callback={(e) => change(props.itemValue, e.target.value)}
          choices={props.choices}
          identificator={props.identificator}
        />
      );
    case "MapComponent":
      return (
        <MapComponent
          callback={(latlng) => {
            console.log(latlng);
            change(props.itemValue, latlng);
          }}
        />
      );
    case "ImageDrop":
      return (
        <Dropzone onDrop={handleImageDrop}>
          {({ getRootProps, getInputProps }) => (
            <Box
              {...getRootProps()}
              sx={{
                border: "2px dashed #cccccc",
                borderRadius: "8px",
                cursor: "pointer",
                padding: "20px",
                marginTop: "20px",
                width: "150px",
                height: "150px",
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                overflow: "hidden",
              }}
            >
              <input {...getInputProps()} />
              {imageFile ? (
                <img
                  src={URL.createObjectURL(imageFile)}
                  alt="Uploaded Image"
                  style={{ width: "100%", height: "100%", objectFit: "cover" }}
                />
              ) : (
                <Typography>Click here or drag an image to upload.</Typography>
              )}
            </Box>
          )}
        </Dropzone>
      );
    case "RegistrationInput":
      return (
        <RegistrationInput
          onRegistrationChange={(value) => change(props.itemValue, value)}
          onAddRegistration={(registrations) => change("AllowedLicensePlates", registrations)}
        />
      );
    case "MultipleSelect":
        return(
          <MultipleSelect onModeChange={(modes) => change("Modes", modes)}/>
        )
    default:
      return null;
  }
};

export default FormComponent;
