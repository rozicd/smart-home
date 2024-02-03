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
import EventLogCard from "./BasicComponents/EventLogCard";
import { panelHubConnection } from "./Sockets/LightSocketService";
import { getPanelActions, turnOff, turnOn } from "./Services/PanelService";
import LoadingComponent from "./BasicComponents/LoadingComponent";
import axios from "axios";
import { API_BASE_URL } from "../App";
const PanelCardsComponent = ({ deviceInfo }) => {
  const [power, setPower] = useState(0);
  const [panelStatus, setPanelStatus] = useState(true);
  const [panelHistory, setPanelHistory] = useState([]);
  const [toDate, setToDate] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [connecting, setConnecting] = useState(true);
  const getLastData = () => {
    axios
      .get(`${API_BASE_URL}/smart-device/lastdata/${deviceInfo.id}`, {

        withCredentials: true,
      })
      .then((response) => {
        setPower(response.data);
        setConnecting(false)
      })
      .catch((error) => {
        console.log(error);
      });
  };



  const handleSwitchChange = async () => {
    const newPowerState = panelStatus ? 0 : 1;
    setConnecting(true);
    try {
      if (newPowerState === 1) {
        await turnOn(deviceInfo.id);
        setPower(1);
      } else {
        await turnOff(deviceInfo.id);
        setPower(0);
      }
    } catch (error) {
      console.error("Error turning on/off panel:", error);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      console.log("data");

      try {
        let data = await getPanelActions(deviceInfo.id, fromDate, toDate);
        console.log(data);
        setPanelHistory(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, [toDate, fromDate]);

  useEffect(() => {
    async function connect() {
      if (panelHubConnection.state === "Disconnected") {
        await panelHubConnection.start();
      }

      panelHubConnection.on(deviceInfo.connection, (powerPerMinute) => {
        console.log(powerPerMinute);
        setPower(powerPerMinute);
        setConnecting(false);
      });
    }
    connect();
  }, []);

  useEffect(() => {
    if (power == 0) {
      setPanelStatus(false);
    } else {
      setPanelStatus(true);
    }
  }, [power]);

  return (
    <Container sx={{ width: "100%" }}>
      <Grid container spacing={2}>
        <Grid item md={6}>
          <Card style={{ height: "20vh", padding: "20px" }}>
            <CardContent
              style={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "space-evenly",
                height: "80%",
              }}
            >
              <Typography variant="h6">Power Per Minute</Typography>
              {!connecting && (
                <Typography align="center" variant="h4">
                  {power}kWh
                </Typography>
              )}
              {connecting && <LoadingComponent></LoadingComponent>}
            </CardContent>
          </Card>
        </Grid>

        <Grid item md={6}>
          <Card style={{ height: "20vh", padding: "20px" }}>
            <CardContent
              style={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "space-evenly",
                height: "80%",
              }}
            >
              <Typography variant="h6">Status</Typography>
              <FormControlLabel
                style={{ width: "80%", height: "20%" }}
                control={
                  <Switch
                    checked={panelStatus}
                    onChange={handleSwitchChange}
                    size="medium"
                    disabled={connecting}
                  />
                }
                label={panelStatus ? "ON" : "OFF"}
              />
            </CardContent>
          </Card>
        </Grid>
        <Grid item xs={12} md={12}>
          <EventLogCard
            eventData={panelHistory}
            setEndDate={setToDate}
            setStartDate={setFromDate}
          />
        </Grid>
      </Grid>
    </Container>
  );
};

export default PanelCardsComponent;
