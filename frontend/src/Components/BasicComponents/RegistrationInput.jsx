import React, { useState } from "react";
import { TextField, Chip, Box, Button } from "@mui/material";

const RegistrationInput = ({ onRegistrationChange, onAddRegistration }) => {
  const [licensePlate, setLicensePlate] = useState("");
  const [licensePlates, setLicensePlates] = useState([]);

  const handleLicensePlateChange = (event) => {
    setLicensePlate(event.target.value);
  };

  const handleAddRegistration = () => {
    if (licensePlate.trim() !== "" && !licensePlates.includes(licensePlate)) {
        setLicensePlates((prevLicensePlates) => [...prevLicensePlates, licensePlate]);
      setLicensePlate("");
      onAddRegistration([...licensePlates, licensePlate]);
    }
  };

  const handleRemoveRegistration = (index) => {
    setLicensePlates((prevLicensePlates) =>
      prevLicensePlates.filter((_, i) => i !== index)
    );
    onAddRegistration(licensePlates.filter((_, i) => i !== index));
  };

  return (
    <div style={{display:"flex",flexDirection:"Column"}} className="form-item">
      <TextField
        label="License Plate"
        variant="outlined"
        value={licensePlate}
        onChange={handleLicensePlateChange}
      />
      <Button
        variant="outlined"
        size="small" 
        onClick={handleAddRegistration}
        style={{ marginTop: "20px" }} 
      >
        Add License Plate
      </Button>
      <Box mt={2}>
        {licensePlates.map((plate, index) => (
          <Chip
            key={index}
            label={plate}
            onDelete={() => handleRemoveRegistration(index)}
            style={{ margin: "4px" }}
          />
        ))}
      </Box>
    </div>
  );
};

export default RegistrationInput;
