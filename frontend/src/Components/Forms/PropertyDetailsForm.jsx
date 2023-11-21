// PropertyDetailsForm.js
import React, { forwardRef, useState } from 'react';
import { Box, TextField, Typography } from '@mui/material';
import Dropzone, { useDropzone } from 'react-dropzone';

const PropertyDetailsForm = forwardRef(({ onDataValidated, previousFormData }, ref) => {
  useDropzone({
    accept: {
      'image/jpeg': [],
      'image/png': []
    }
  });

  const [propertyName, setPropertyName] = useState(
    previousFormData.propertyName || ''
  );
  const [areaSquareMeters, setAreaSquareMeters] = useState(
    previousFormData.areaSquareMeters || ''
  );
  const [numberOfFloors, setNumberOfFloors] = useState(
    previousFormData.numberOfFloors || ''
  );
  const [imageFile, setImageFile] = useState(previousFormData.imageFile || null);
  const [formErrors, setFormErrors] = useState({});

  const handleImageDrop = (acceptedFiles) => {
    const file = acceptedFiles[0];
    const imageFiles = acceptedFiles.filter(file => file.type.startsWith('image/'));
    setImageFile(imageFiles[0]);
  };

  const validateForm = async () => {
    const errors = {};

    if (!propertyName) {
      errors.propertyName = 'Property Name is required.';
    } else if (propertyName.length > 20) {
      errors.propertyName = 'Property Name cannot be more than 20 characters.';
    }

    if (!areaSquareMeters) {
      errors.areaSquareMeters = 'Area Square Meters is required.';
    } else if (isNaN(areaSquareMeters) || areaSquareMeters < 1 || areaSquareMeters > 1000) {
      errors.areaSquareMeters = 'Area Square Meters must be a number between 1 and 1000.';
    }
  
    if (!numberOfFloors) {
      errors.numberOfFloors = 'Number of Floors is required.';
    } else if (isNaN(numberOfFloors) || numberOfFloors < 1 || numberOfFloors > 100) {
      errors.numberOfFloors = 'Number of Floors must be a number between 1 and 100.';
    }

    if (!imageFile) {
      errors.imageFile = 'Image File is required.';
    }

    setFormErrors(errors);

    return Object.keys(errors).length === 0;
  };

  const handleFinishButtonClick = async () => {
    const isValid = validateForm();

    if (!isValid) {
      return;
    }

    return {
      propertyName,
      areaSquareMeters,
      numberOfFloors,
      imageFile,
    };
  };

  React.useImperativeHandle(ref, () => ({
    handleFinishButtonClick,
    validateForm
  }));

  return (
    <Box
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        margin: '20px',
      }}
    >
      <TextField
        id="propertyName-input"
        label="Property Name"
        type="text"
        value={propertyName}
        onChange={(e) => setPropertyName(e.target.value)}
        sx={{ minWidth: '300px', minHeight: '40px', margin: '10px' }}
      />
      {formErrors.propertyName && (
        <Typography color="error">{formErrors.propertyName}</Typography>
      )}

      <TextField
        id="areaSquareMeters-input"
        label="Area Square Meters"
        type="number"
        inputMode="numeric"
        value={areaSquareMeters}
        onChange={(e) => setAreaSquareMeters(e.target.value)}
        sx={{ minWidth: '300px', minHeight: '40px', margin: '10px' }}
      />
      {formErrors.areaSquareMeters && (
        <Typography color="error">{formErrors.areaSquareMeters}</Typography>
      )}

      <TextField
        id="numberOfFloors-input"
        label="Number of Floors"
        type="number"
        inputMode="numeric"
        value={numberOfFloors}
        onChange={(e) => setNumberOfFloors(e.target.value)}
        sx={{ minWidth: '300px', minHeight: '40px', margin: '10px' }}
      />
      {formErrors.numberOfFloors && (
        <Typography color="error">{formErrors.numberOfFloors}</Typography>
      )}

      <Dropzone onDrop={handleImageDrop}>
        {({ getRootProps, getInputProps }) => (
          <Box
            {...getRootProps()}
            sx={{
              border: '2px dashed #cccccc',
              borderRadius: '8px',
              cursor: 'pointer',
              padding: '20px',
              marginTop: '20px',
              width: '300px',
              height: '200px',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              overflow: 'hidden',
            }}
          >
            <input {...getInputProps()} />
            {imageFile ? (
              <img
                src={URL.createObjectURL(imageFile)}
                alt="Uploaded Image"
                style={{ width: '100%', height: '100%', objectFit: 'cover' }}
              />
            ) : (
              <Typography>
                Click here or drag an image to upload.
              </Typography>
            )}
          </Box>
        )}
      </Dropzone>
      {formErrors.imageFile && (
        <Typography color="error">{formErrors.imageFile}</Typography>
      )}
    </Box>
  );
});

export default PropertyDetailsForm;
