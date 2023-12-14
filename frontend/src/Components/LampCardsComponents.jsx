// LampCardsComponent.jsx
import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Switch,
  FormControlLabel,
  Select,
  MenuItem,
  Grid,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
} from "@mui/material";
import { hubConnection } from "../Components/Sockets/LightSocketService";
import { changeMode, turnOn, turnOff, changeThreshold } from "../Components/Services/LampService"; 

const LampCardsComponent = ({ deviceInfo }) => {
  const [lightData, setLightData] = useState({ lightStrength: 0, powerState: 0 });
  const [lampMode, setLampMode] = useState(deviceInfo.lampMode);
  const [lightThreshold, setLightThreshold] = useState(deviceInfo.lightThreshold);
  const [isThresholdDialogOpen, setThresholdDialogOpen] = useState(false);
  const [newThreshold, setNewThreshold] = useState("");
  const [thresholdError, setThresholdError] = useState("");

  useEffect(() => {
    async function connect() {
      if (hubConnection.state === "Disconnected") {
        await hubConnection.start();
      }

      hubConnection.on(deviceInfo.connection, (lightStrength, powerState) => {
        console.log(lightStrength,powerState)
        setLightData({ lightStrength, powerState });
      });
    }
    connect();
  }, []);

  const handleLampModeChange = async (event) => {
    const newLampMode = event.target.value;
    console.log(newLampMode);
    setLampMode(newLampMode);

    try {
      await changeMode(deviceInfo.id, newLampMode);
    } catch (error) {
      console.error("Error changing lamp mode:", error);
    }
  };

  const handleSwitchChange = async () => {
    if (lampMode === 0) {
      const newPowerState = lightData.powerState === 1 ? 0 : 1;
      setLightData((prevLightData) => ({ ...prevLightData, powerState: newPowerState }));

      try {
        if (newPowerState === 1) {
          await turnOn(deviceInfo.id);
        } else {
          await turnOff(deviceInfo.id);
        }
      } catch (error) {
        console.error("Error turning on/off lamp:", error);
      }
    }
  };

  const handleThresholdChange = () => {
    setThresholdDialogOpen(true);
  };

  const handleThresholdDialogClose = () => {
    setThresholdDialogOpen(false);
    setThresholdError("");
  };

  const handleThresholdSave = async () => {
    const thresholdValue = parseFloat(newThreshold);
    if (isNaN(thresholdValue) || thresholdValue < 0 || thresholdValue > 100) {
      setThresholdError("Threshold must be a number between 0 and 100");
      return;
    }

    try {
      await changeThreshold(deviceInfo.id, thresholdValue);
      setLightThreshold(thresholdValue);
      setThresholdDialogOpen(false);
      setThresholdError("");
    } catch (error) {
      console.error("Error changing lamp threshold:", error);
    }
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
            <Typography variant="h6">Light Strength</Typography>
            <Typography align="center" variant="h4">
              {lightData.lightStrength}
            </Typography>
            <Typography align="center">Lux</Typography>
          </CardContent>
        </Card>
      </Grid>

      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
            <Typography variant="h6">Power State</Typography>
            <Typography align="center" variant="h4">
              {lightData.powerState === 1 ? "ON" : "OFF"}
            </Typography>
            <Typography align="center">{lightData.powerState === 1 ? "Running" : "Stopped"}</Typography>
          </CardContent>
        </Card>
      </Grid>

      <Grid container item xs={12} md={6}>
        <Card style={{ height: "20vh" ,width:"55%"}}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
            <Typography variant="h6">Lamp Mode</Typography>
            <Select value={lampMode} onChange={handleLampModeChange} style={{ width: "80%", height:"20%" }}>
              <MenuItem value={1}>Auto</MenuItem>
              <MenuItem value={0}>Manual</MenuItem>
            </Select>
          </CardContent>
        </Card>

        <Card style={{ height: "20vh",width:"40%",marginLeft:"5%"}}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
            <Typography variant="h6">Lamp Power</Typography>
            <FormControlLabel
              style={{ width: "80%", height:"20%" }}
              control={<Switch checked={lightData.powerState === 1} onChange={handleSwitchChange} size="medium" />}
              label={lightData.powerState === 1 ? "ON" : "OFF"}
              disabled={lampMode === 1} // Disable the switch if mode is "Auto"
            />
          </CardContent>
        </Card>
      </Grid>

      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"}}>
            <Typography variant="h6">Light Threshold</Typography>
            <Typography align="center" variant="h4">
              {lightThreshold}
            </Typography>
            <Button variant="outlined" size="large" onClick={handleThresholdChange}>
              Change Threshold
            </Button>
          </CardContent>
        </Card>
      </Grid>

      <Dialog open={isThresholdDialogOpen} onClose={handleThresholdDialogClose} fullWidth>
        <DialogTitle>Change Light Threshold</DialogTitle>
        <DialogContent>
          <TextField
            label="New Threshold"
            type="number"
            value={newThreshold}
            onChange={(e) => setNewThreshold(e.target.value)}
            error={!!thresholdError}
            helperText={thresholdError}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleThresholdDialogClose}>Cancel</Button>
          <Button onClick={handleThresholdSave}>Save</Button>
        </DialogActions>
      </Dialog>
    </Grid>
  );
};

export default LampCardsComponent;
