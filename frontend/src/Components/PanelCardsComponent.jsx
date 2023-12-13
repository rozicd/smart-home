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

const PanelCardsComponent = ({ deviceInfo }) => {
  const [power,setPower] = useState(0);


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

 
 

  return (
    <Container sx = {{width : "100%"}}>

    <Grid container spacing={2}>
      <Grid item  md={12}>
        <Card style={{ height: "20vh" }}>
          <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
            <Typography variant="h6">Power Per Minute</Typography>
            <Typography align="center" variant="h4">
              {power}kWh
            </Typography>
          </CardContent>
        </Card>
      </Grid>
      
    </Grid>
    </Container>
  );
};

export default PanelCardsComponent;
