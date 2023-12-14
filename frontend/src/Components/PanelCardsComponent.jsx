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
  Container,
  Grid,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
} from "@mui/material";
import { panelHubConnection } from "./Sockets/LightSocketService";
import { turnOff,turnOn } from "./Services/PanelService";

const PanelCardsComponent = ({ deviceInfo }) => {
  const [power,setPower] = useState(0);
  const [panelStatus,setPanelStatus] = useState(true);

  const handleSwitchChange = async () => {
      const newPowerState = panelStatus? 0 : 1;
      try {
        if (newPowerState === 1) {
          await turnOn(deviceInfo.id);

        } else {
          await turnOff(deviceInfo.id);
          setPower(0)
        }
      } catch (error) {
        console.error("Error turning on/off panel:", error);
      }
    
  };



  useEffect(() => {
    async function connect() {
      if (panelHubConnection.state === "Disconnected") {
        await panelHubConnection.start();
      }

      panelHubConnection.on(deviceInfo.connection, (powerPerMinute) => {
        console.log(powerPerMinute)
        setPower(powerPerMinute)
      });
    }
    connect();
  }, []);

  useEffect(() => {
    if (power == 0)
    {
      setPanelStatus(false)
    }
    else 
    {
      setPanelStatus(true)
    }
    
  }, [power]);

 
 

  return (
    <Container sx = {{width : "100%"}}>

    <Grid container spacing={2}>
      <Grid item  md={6}>
      <Card style={{ height: "20vh", padding : "20px" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
            <Typography variant="h6">Power Per Minute</Typography>
            <Typography align="center" variant="h4">
              {power}kWh
            </Typography>
          </CardContent>
        </Card>
      </Grid>

      <Grid item  md={6}>
      <Card style={{ height: "20vh", padding : "20px" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
            <Typography variant="h6">Status</Typography>
            <FormControlLabel
              style={{ width: "80%", height:"20%" }}
              control={<Switch checked={panelStatus} onChange={handleSwitchChange} size="medium"/>}
              label={panelStatus ? "ON" : "OFF"}

            />
          </CardContent>
        </Card>
        </Grid>

      
    </Grid>
    </Container>
  );
};

export default PanelCardsComponent;
