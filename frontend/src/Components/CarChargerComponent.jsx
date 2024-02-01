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
import { ChargerHubConnection } from "./Sockets/LightSocketService";
import BasicGraph from "./BasicComponents/BasicGraph";
import { GetPowerGraphData } from "./Services/BatteryService";
import PowerSpentHistory from "./BasicComponents/PowerSpentHistory";
import axios from "axios";
import { API_BASE_URL } from "../App";
import LoadingComponent from "./BasicComponents/LoadingComponent";
import CarChargerEventLog from "./BasicComponents/CarChargerEventLog";
const CarChargerComponent = ({ deviceInfo }) => {
  const [connectors, setConnectors] = useState(
    new Array(deviceInfo.connectorNumber).fill("")
  );

  const [isThresholdDialogOpen, setThresholdDialogOpen] = useState(false);
  const [newThreshold, setNewThreshold] = useState(100);
  const [thresholdError, setThresholdError] = useState("");
  const [toDate, setToDate] = useState("");
  const [chargerActions, setChargerActions] = useState([]);
  const [fromDate, setFromDate] = useState("");
  const [selectedPlug, setSelectedPlug] = useState("");
  const [connecting, setConnecting] = useState(
    new Array(deviceInfo.connectorNumber).fill(false)
  );

  const getCarActions = () => {
    axios.get(`${API_BASE_URL}/carcharger/${deviceInfo.id}/history`, {
      params: {
        startDate: fromDate,
        endDate: toDate,
      },
      withCredentials: true,
    }).then((response)=>
    {
      console.log(response)
      setChargerActions(response.data)
    }).catch((error) => {
      console.log(error);
    });;
  };

  const handleThresholdSave = async () => {
    const thresholdValue = parseFloat(newThreshold);
    if (isNaN(thresholdValue) || thresholdValue < 20 || thresholdValue > 100) {
      setThresholdError("Threshold must be a number between 0 and 100");
      return;
    }
    let param = {
      id: deviceInfo.id,
      plug: selectedPlug.toString(),
      treshold: thresholdValue,
    };
    axios
      .post(`${API_BASE_URL}/carcharger/treshold`, param, {
        withCredentials: true,
      })
      .then((response) => {
        setThresholdDialogOpen(false);
        setConnectors((prevArray) => {
          const newArray = [...prevArray];
          let items = connectors[selectedPlug].split("/");
          newArray[selectedPlug] = items[0] + "/" + thresholdValue;

          return newArray;
        });
      })
      .catch((error) => {
        console.log(error);
      });

    console.log(param);
  };
  const handleThresholdChange = (index) => {
    setSelectedPlug(index);
    console.log(index);
    setThresholdDialogOpen(true);
  };

  const handleThresholdDialogClose = () => {
    setThresholdDialogOpen(false);
    setThresholdError("");
  };

  async function connect(topic) {
    if (ChargerHubConnection.state === "Disconnected") {
      await ChargerHubConnection.start();
    }

    ChargerHubConnection.on(topic, (connected) => {
      console.log(connected);

      let items = connected.split(":");
      console.log(items);
      if (items[0] == "connected") {
        setConnecting((prevArray) => {
          const newArray = [...prevArray];

          newArray[items[1]] = true; // You can replace 10 with your desired value

          return newArray;
        });
      }
    });
    for (let i = 0; i < deviceInfo.connectorNumber; i++) {
      console.log(topic + "/plug/" + i);
      ChargerHubConnection.on(topic + "/" + i, (bla) => {
        setConnectors((prevArray) => {
          const newArray = [...prevArray];

          newArray[i] = bla; // You can replace 10 with your desired value
          setConnecting((prevArray) => {
            const newArray = [...prevArray];

            newArray[i] = false; // You can replace 10 with your desired value

            return newArray;
          });

          return newArray;
        });
      });
    }
  }

  useEffect(() => {
    connect(deviceInfo.connection);
  }, []);
  useEffect(() => {
    getCarActions();
  }, [toDate,fromDate,connecting,newThreshold]);

  useEffect(() => {
    console.log(connecting);
  }, [connecting]);

  useEffect(() => {
    console.log(connectors);
  }, [connectors]);

  return (
    <Container sx={{ width: "100%" }}>
      <Grid
        container
        spacing={2}
        alignItems={"center"}
        justifyContent={"center"}
      >
        {connectors.map((item, index) => {
          let items = item.split("/");
          if (!connecting[index]) {
            return (
              <Grid item sx={3}>
                <Card
                  onClick={() => handleThresholdChange(index)}
                  style={{ height: "20vh", padding: "20px" }}
                >
                  <CardContent
                    style={{
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                      justifyContent: "space-evenly",
                      height: "80%",
                      width: "250px",
                    }}
                  >
                    <Typography variant="h6">Plug {index}</Typography>
                    <Typography align="center" variant="h4">
                      {items[0]}% / {items[1]}%
                    </Typography>
                  </CardContent>
                </Card>
              </Grid>
            );
          } else {
            return (
              <Grid item sx={3}>
                <Card
                  onClick={() => handleThresholdChange(index)}
                  style={{ height: "20vh", padding: "20px" }}
                >
                  <CardContent
                    style={{
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                      justifyContent: "space-evenly",
                      height: "80%",
                      width: "250px",
                    }}
                  >
                    <Typography variant="h6">Plug {index}</Typography>
                    <LoadingComponent></LoadingComponent>
                  </CardContent>
                </Card>
              </Grid>
            );
          }
        })}
        <Grid item sx={9}>
          <CarChargerEventLog
            eventData={chargerActions}
            setEndDate={setToDate}
            setStartDate={setFromDate}
          />
        </Grid>
      </Grid>
      <Dialog
        open={isThresholdDialogOpen}
        onClose={handleThresholdDialogClose}
        fullWidth
      >
        <DialogTitle>Change Car Charge Threshold</DialogTitle>
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
    </Container>
  );
};

export default CarChargerComponent;
