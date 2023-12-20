import React, { useState, useEffect } from "react";
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
import { ACHubConnection } from "./Sockets/SocketService";
import { turnOn, turnOff, changeMode } from "./Services/ACService";

const ACCardsComponents = ({ deviceInfo }) => {
  const [currentTemperature, setCurrentTemperature] = useState(20);
  const [selectedButton, setSelectedButton] = useState("COOLING");
  const [acData, setACData] = useState({currentTemperature: deviceInfo.minimumTemperature, powerState: 0});

  const handleSwitchChange = async () => {
    console.log(deviceInfo.id)
    if(acData.powerState === 0){
        try{
            await turnOn(deviceInfo.id)
        }
        catch(error){
            console.log(error)
        }
    }
    else{
        try{
            await turnOff(deviceInfo.id)
        }catch(error){
            console.log(error)
        }
        
    }
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
  
  const handleSubmitClick = async () =>{
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

    let changeACModeDTO = {id:deviceInfo.id, mode: selectedMode, currentTemperature: currentTemperature}

    try{
        await changeMode(changeACModeDTO);
    }catch(error){
        console.log(error)
    }
  }

  useEffect(()=>{
    
    async function connect(){
        if(ACHubConnection.state === "Disconnected"){
            await ACHubConnection.start();
        }
        ACHubConnection.on(deviceInfo.connection, (currentTemperature, powerState) =>{
            setACData({currentTemperature: currentTemperature, powerState: powerState})
            console.log("PowerState: "+powerState)

        });
    }
    console.log(deviceInfo)
    connect();

    }, []);

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
                  checked={acData.powerState === 1}
                  onChange={handleSwitchChange}
                  size="medium"
                />
              }
              label={acData.powerState === 1 ? "ON" : "OFF"}
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
                    selectedButton === "COOLING" ? "2px solid #00AEAE" : "none"
                }}
                onClick={() => handleButtonClick("COOLING")}
              >
                <AcUnitIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border:
                    selectedButton === "HEATING" ? "2px solid #00AEAE" : "none"
                }}
                onClick={() => handleButtonClick("HEATING")}
              >
                <WbSunnyIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border:
                    selectedButton === "FAN"
                      ? "2px solid #00AEAE"
                      : "none"
                }}
                onClick={() => handleButtonClick("FAN")}
              >
                <AirOutlinedIcon sx={{ fontSize: 60 }} color="primary" />
              </Button>
              <Button
                style={{
                  margin: "30px",
                  border: selectedButton === "AUTOMATIC" ? "2px solid #00AEAE" : "none",
                  fontSize: "15px"
                }}
                onClick={() => handleButtonClick("AUTOMATIC")}
              >
                AUTO
              </Button>
            </div>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={24} md={12}>
        <Button onClick={()=>handleSubmitClick()}>Submit</Button>
      </Grid>
      
    </Grid>
  );
};

export default ACCardsComponents;
