import React, { useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  FormControlLabel,
  Switch,
  Button
} from "@mui/material";
import AcUnitIcon from "@mui/icons-material/AcUnitOutlined";
import WbSunnyIcon from "@mui/icons-material/WbSunnyOutlined";
import AirOutlinedIcon from "@mui/icons-material/AirOutlined";

const ACCardsComponents = ({ deviceInfo }) => {
  const [currentTemperature, setCurrentTemperature] = useState(20);
  const [selectedButton, setSelectedButton] = useState(null);

  const handleSwitchChange = () => {
    console.log("ONOFF");
  };

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

  const handleButtonClick = (buttonName) => {
    setSelectedButton(buttonName);
    // Add logic here to perform actions based on the clicked button
    console.log(`${buttonName} button clicked`);
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%"
            }}
          >
            <Typography variant="h6">Min Temperature</Typography>
            <Typography align="center" variant="h4">
              {deviceInfo.minimumTemperature}
            </Typography>
            <Typography align="center">°C</Typography>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%"
            }}
          >
            <Typography variant="h6">Max Temperature</Typography>
            <Typography align="center" variant="h4">
              {deviceInfo.maximumTemperature}
            </Typography>
            <Typography align="center">°C</Typography>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%"
            }}
          >
            <Typography variant="h6">Power</Typography>
            <FormControlLabel
              style={{ width: "80%", height: "20%" }}
              control={
                <Switch
                  checked={deviceInfo.deviceStatus === "ONLINE"}
                  onChange={handleSwitchChange}
                  size="medium"
                />
              }
              label={deviceInfo.deviceStatus === "ONLINE" ? "ON" : "OFF"}
            />
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
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
            <Typography align="center" variant="h4">
              {currentTemperature} °C
            </Typography>
            <Typography align="center"></Typography>
            <div>
              <Button style={{ fontSize: "36px" }} onClick={handleDecrease}>
                -
              </Button>
              <Button style={{ fontSize: "36px" }} onClick={handleIncrease}>
                +
              </Button>
            </div>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={24} md={12}>
        <Card style={{ height: "25vh" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%"
            }}
          >
            <div>
              <Button
                style={{
                  margin: "30px",
                  border:
                    selectedButton === "AcUnit" ? "2px solid #00AEAE" : "none"
                }}
                onClick={() => handleButtonClick("AcUnit")}
              >
                <AcUnitIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border:
                    selectedButton === "WbSunny" ? "2px solid #00AEAE" : "none"
                }}
                onClick={() => handleButtonClick("WbSunny")}
              >
                <WbSunnyIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border:
                    selectedButton === "AirOutlined"
                      ? "2px solid #00AEAE"
                      : "none"
                }}
                onClick={() => handleButtonClick("AirOutlined")}
              >
                <AirOutlinedIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border: selectedButton === "AUTO" ? "2px solid #00AEAE" : "none",
                  fontSize: "15px"
                }}
                onClick={() => handleButtonClick("AUTO")}
              >
                AUTO
              </Button>
            </div>
          </CardContent>
        </Card>
      </Grid>
    </Grid>
  );
};

export default ACCardsComponents;
