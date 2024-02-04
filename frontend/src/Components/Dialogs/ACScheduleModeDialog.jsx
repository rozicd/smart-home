import React, { useState } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  Grid,
  Card,
  CardContent,
  Typography
} from "@mui/material";
import AcUnitIcon from "@mui/icons-material/AcUnitOutlined";
import WbSunnyIcon from "@mui/icons-material/WbSunnyOutlined";
import AirOutlinedIcon from "@mui/icons-material/AirOutlined";

const ACScheduleModeDialog = ({ open, onClose, onSubmit, deviceInfo }) => {
  const [startTime, setStartTime] = useState("00:00");
  const [endTime, setEndTime] = useState("00:00");
  const [selectedButton, setSelectedButton] = useState("COOLING");
  const [currentTemperature, setCurrentTemperature] = useState(20);


  const handleDecrease = () => {
    if (currentTemperature > deviceInfo.minimumTemperature) {
      setCurrentTemperature((prevTemp) => prevTemp - 1);
    }
  };

  const handleIncrease = () => {
    if (currentTemperature < deviceInfo.maximumTemperature) {
      setCurrentTemperature((prevTemp) => prevTemp + 1);
    }
  };



  const handleIconClick = (icon) => {
    // You can add logic to handle icon clicks here
    setSelectedButton(icon);
  };

  const handleCancel = () => {
    onClose();
  };

  const handleDialogSubmit = () => {
    const currentDate = new Date();

    // Extract the hours and minutes from the selected start and end times
    const [startHours, startMinutes] = startTime.split(":");
    const [endHours, endMinutes] = endTime.split(":");

    // Set the hours and minutes for the start and end times
    const startDate = new Date(
        currentDate.getFullYear(),
        currentDate.getMonth(),
        currentDate.getDate(),
        startHours,
        startMinutes
    );

    const endDate = new Date(
        currentDate.getFullYear(),
        currentDate.getMonth(),
        currentDate.getDate(),
        endHours,
        endMinutes
    );

    startDate.setHours(startDate.getHours() + 1);
    endDate.setHours(endDate.getHours() + 1);
    let selectedMode = 0;
    if(selectedButton === "COOLING"){
        selectedMode = 0;
    }
    else if(selectedButton === "HEATING"){
        selectedMode = 1;
    }
    else if(selectedButton === "AUTOMATIC"){
        selectedMode = 2;
    }
    else if(selectedButton === "FAN"){
        selectedMode = 3;
    }
    onSubmit({
      start: startDate.toISOString().replace('Z', ''),
      end: endDate.toISOString().replace('Z', ''),
      temeprature: currentTemperature,
      acMode: selectedMode
      // Add logic to get the selected icon
    });
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Auto Mode Settings</DialogTitle>
      <DialogContent>
        <Grid container spacing={2} sx={{marginTop:"10px"}}>
          <Grid item xs={6} >
            <TextField
                
              label="Start Time"
              type="time"
              value={startTime}
              onChange={(e) => setStartTime(e.target.value)}
              InputLabelProps={{
                shrink: true,
              }}
              inputProps={{
                step: 300, // 5 minutes
              }}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              label="End Time"
              type="time"
              value={endTime}
              onChange={(e) => setEndTime(e.target.value)}
              InputLabelProps={{
                shrink: true,
              }}
              inputProps={{
                step: 300, // 5 minutes
              }}
            />
          </Grid>
        </Grid>
        <Grid item xs={12} >
        <Card style={{ height: "15vh" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%"
            }}
          >
            <Typography variant="h6">Current Temp</Typography>
            <Typography align="center" variant="h5" fontWeight="bold">
              {currentTemperature} °C
            </Typography>
            <Typography align="center"></Typography>
            <div>
              <Button style={{ fontSize: "24px" }} onClick={handleDecrease}>
                -
              </Button>
              <Button style={{ fontSize: "24px" }} onClick={handleIncrease}>
                +
              </Button>
            </div>
          </CardContent>
        </Card>
      </Grid>
        <Grid container spacing={2} justifyContent="center" alignItems="center">
          <Button 
          style={{
            margin: "30px",
            border:
              selectedButton === "COOLING" ? "2px solid #00AEAE" : "none"
          }}
          onClick={() => handleIconClick("COOLING")}>
            <AcUnitIcon />
          </Button>
          <Button 
          style={{
            margin: "30px",
            border:
              selectedButton === "HEATING" ? "2px solid #00AEAE" : "none"
          }}
          onClick={() => handleIconClick("HEATING")}>
            <WbSunnyIcon />
          </Button>
          <Button 
          style={{
            margin: "30px",
            border:
              selectedButton === "FAN" ? "2px solid #00AEAE" : "none"
          }}
          onClick={() => handleIconClick("FAN")}>
            <AirOutlinedIcon />
          </Button>
        </Grid>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleCancel}>Cancel</Button>
        <Button onClick={handleDialogSubmit}>Submit</Button>
      </DialogActions>
    </Dialog>
  );
};

export default ACScheduleModeDialog;
