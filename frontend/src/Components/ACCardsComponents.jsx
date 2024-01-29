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
import { turnOn, turnOff, changeMode, addScheduledMode, getACActions } from "./Services/ACService";
import InfoDialog from "./BasicComponents/InfoDialog";
import ACScheduleModeDialog from "./Dialogs/ACScheduleModeDialog";
import ACHistoryComponent from "./ACHistoryComponent";

const ACCardsComponents = ({ deviceInfo }) => {
  const [airConditionerInfo, setAirConditionerInfo] = useState(deviceInfo)
  const [selectedButton, setSelectedButton] = useState("COOLING");
  const [acData, setACData] = useState({currentTemperature: airConditionerInfo.minimumTemperature, powerState: 0});
  const [currentTemperature, setCurrentTemperature] = useState(acData.currentTemperature);
  const [toDate,setToDate] = useState(null);
  const [fromDate,setFromDate] = useState(null);
  const [acHistory, setACHistory] = useState([]);
  const [infoDialog, setInfoDialog] = useState({
    open: false,
    title: '',
    content: ''
  });

  const [autoModeDialogOpen, setAutoModeDialogOpen] = useState(false);

  const handleAutoButtonClick = () => {
    setAutoModeDialogOpen(true);
  };

  const handleAutoModeSubmit = async (autoModeSettings) => {
    try{
      const response = await addScheduledMode(airConditionerInfo.id, autoModeSettings)
      setAirConditionerInfo(prevInfo => ({
        ...prevInfo,
        ...response.data
      }));
      
    }catch(error){
      console.log(error)
    }
  };

  const handleSwitchChange = async () => {
    console.log(airConditionerInfo.id)
    if(acData.powerState === 0){
        try{
            await turnOn(airConditionerInfo.id)
        }
        catch(error){
            console.log(error)
        }
    }
    else{
        try{
            await turnOff(airConditionerInfo.id)
        }catch(error){
            console.log(error)
        }
        
    }
  };

  const handleDecrease = () => {
    if (currentTemperature > airConditionerInfo.minimumTemperature) {
      setCurrentTemperature((prevTemp) => prevTemp - 1);
    }
  };

  const handleIncrease = () => {
    if (currentTemperature < airConditionerInfo.maximumTemperature) {
      setCurrentTemperature((prevTemp) => prevTemp + 1);
    }
  };

  const handleButtonClick = (buttonName) => {
    setSelectedButton(buttonName);

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

    let changeACModeDTO = {id:airConditionerInfo.id, mode: selectedMode, currentTemperature: currentTemperature}

    try{
        await changeMode(changeACModeDTO);
        setInfoDialog({
            open: true,
            title: 'AC Mode',
            content: 'AC is running on chosed mode',
          });
    }catch(error){
        console.log(error)
    }
  }

  useEffect(() => {

    const fetchData = async () => {
      try {
        let data = await getACActions(airConditionerInfo.id,fromDate,toDate)
        setACHistory(data)
        console.log(data)
      } catch (error) {
        console.log(error)
      } 
    };

    fetchData();
  }, [toDate,fromDate]);

  useEffect(()=>{

    async function connect(){
      if(ACHubConnection.state === "Disconnected"){
        await ACHubConnection.start();
      }
      ACHubConnection.on(airConditionerInfo.connection, (payloadObject) =>{
        setACData({currentTemperature: payloadObject.currentTemperature, powerState: payloadObject.powerState});
        setCurrentTemperature(payloadObject.currentTemperature)
        setSelectedButton(payloadObject.acMode.trim());
      });
    }
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
              {airConditionerInfo.minimumTemperature}
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
              {airConditionerInfo.maximumTemperature}
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
              
            </div>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={24} md={12}>
        <Button onClick={()=>handleSubmitClick()} disabled={acData.powerState === 0}>Submit</Button>
        <Button
                style={{
                  margin: "30px",
                  border: selectedButton === "AUTOMATIC" ? "2px solid #00AEAE" : "none",
                  fontSize: "15px",
                }}
                onClick={handleAutoButtonClick}
              >
                Add Scheduled
        </Button>
      </Grid>
      <Grid item xs={12} md={12}>
        <ACHistoryComponent acHistory= {acHistory} setEndDate={setToDate} setStartDate={setFromDate}/>
      </Grid>
      <InfoDialog
        open={infoDialog.open}
        onClose={() => setInfoDialog({ ...infoDialog, open: false })}
        title={infoDialog.title}
        content={infoDialog.content}
      />
      <ACScheduleModeDialog
        open={autoModeDialogOpen}
        onClose={() => setAutoModeDialogOpen(false)}
        onSubmit={handleAutoModeSubmit}
        deviceInfo={airConditionerInfo}
      />
    </Grid>
  );
};

export default ACCardsComponents;
