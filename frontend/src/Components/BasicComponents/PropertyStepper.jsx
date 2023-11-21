// PropertyStepper.js
import React, { useState, useRef } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Stepper,
  Step,
  StepLabel,
} from '@mui/material';
import PropertiesMapForm from '../Forms/PropertiesMapForm';
import PropertyDetailsForm from '../Forms/PropertyDetailsForm';
import { createProperty } from '../Services/PropertiesService';

const steps = ['Map Location', 'Property Details'];

const PropertyStepper = ({ open, onClose }) => {
  const [activeStep, setActiveStep] = useState(0);
  const [formData, setFormData] = useState({});
  const [previousFormData, setPreviousFormData] = useState({});
  const propertiesMapFormRef = useRef();
  const propertyDetailsFormRef = useRef();

  const handleNext = async () => {
    if (activeStep === 0) {
      await propertiesMapFormRef.current.handleNextButtonClick();
      const formErrors = await propertiesMapFormRef.current.getFormErrors();
      const isValid = Object.keys(formErrors).length === 0;
      if (isValid) {
        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        return;
      }
    } else if (activeStep === 1) {
      const isValid = propertyDetailsFormRef.current.validateForm();
      if (!isValid) {
        return;
      }
      else{
        await propertyDetailsFormRef.current.handleFinishButtonClick();
      }
    }
  };

  const handleFinish = async () => {
    if (activeStep === steps.length - 1) {
        const formRef = propertyDetailsFormRef.current;
      
        if (formRef) {
          const isValid = await propertyDetailsFormRef.current.validateForm();
      
          if (isValid) {
            const data = await propertyDetailsFormRef.current.handleFinishButtonClick();

            const finalFormData = {
              ...data,
              ...formData,
            };
            await createProperty(finalFormData);
            onClose(1);
            setFormData({});
            setPreviousFormData({});
            setActiveStep(0);
          }
        }
      }
      
  };

  const handleCancel = () => {
    setFormData({});
    setPreviousFormData({});
    setActiveStep(0);
    onClose();
  };

  return (
    <Dialog open={open} onClose={handleCancel} fullWidth maxWidth="md">
      <DialogTitle sx={{textAlign:'center'}}>Add New Property</DialogTitle>
      <DialogContent>
        <Stepper activeStep={activeStep} alternativeLabel>
          {steps.map((label) => (
            <Step key={label}>
              <StepLabel>{label}</StepLabel>
            </Step>
          ))}
        </Stepper>
        <div>
          {activeStep === steps.length ? (
            <div>
              <p>All steps completed</p>
            </div>
          ) : (
            <div>
              {activeStep === 0 && (
                <PropertiesMapForm
                onDataValidated={(data) => {
                  setFormData((prevData) => ({ ...prevData, ...data }));
                  setPreviousFormData({ ...data });
                }}
                ref={propertiesMapFormRef}
                previousFormData={previousFormData}
              />
              )}
              {activeStep === 1 && (
                    <PropertyDetailsForm
                    onDataValidated={(data) => {
                        setFormData((prevData) => {
                          const newData = { ...prevData, ...data };
                          return newData;
                        });
                      }}
                    previousFormData={previousFormData}
                    ref={propertyDetailsFormRef}
                />
              )}
            </div>
          )}
        </div>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleCancel}>Cancel</Button>
        <Button disabled={activeStep === 0} onClick={() => setActiveStep((prev) => prev - 1)}>
          Back
        </Button>
        <Button
          variant="contained"
          color="primary"
          onClick={activeStep === steps.length - 1 ? handleFinish : handleNext}
        >
          {activeStep === steps.length - 1 ? 'Finish' : 'Next'}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default PropertyStepper;
