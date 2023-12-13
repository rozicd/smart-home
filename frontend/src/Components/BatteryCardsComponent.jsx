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
import { BatteryHubConnection, panelHubConnection } from "./Sockets/LightSocketService";

const BatteryCardsComponent = ({ deviceInfo }) => {
  const [level,setLevel] = useState(0);


  useEffect(() => {
    async function connect() {
      if (BatteryHubConnection.state === "Disconnected") {
        await BatteryHubConnection.start();
      }

      BatteryHubConnection.on(deviceInfo.connection, (powerPerMinute) => {
        console.log(powerPerMinute)
        setLevel(powerPerMinute)
      });
    }
    connect();
  }, []);

 
 

  return (
    <Container sx = {{width : "100%"}}>

    <Grid container spacing={2}>
      <Grid item  lg={6}>
      <Card style={{ height: "20vh", padding : "20px" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
            <Typography variant="h6">Level</Typography>
            <Typography align="center" variant="h4">
              {level}%
            </Typography>
          </CardContent>
        </Card>
      </Grid>
      <Grid item  lg={6}>
        <Card style={{ height: "20vh", padding : "20px" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
            <Typography variant="h6">Battery Size</Typography>
            <Typography align="center" variant="h4">
              {deviceInfo.batterySize}kWh
            </Typography>
          </CardContent>
        </Card>
      </Grid>
      
    </Grid>
    </Container>
  );
};

export default BatteryCardsComponent;
