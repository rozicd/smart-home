import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  FormControlLabel,
  Switch,
  Button,
  FormControl,
  InputLabel,
  Select,
  MenuItem, 
  Dialog, 
  DialogActions, 
  DialogContent, 
  DialogTitle,
  TextField
} from "@mui/material";
import { WMHubConnection } from "./Sockets/SocketService";
import { turnWMOff, turnWMOn, changeWMMode, getWMActions, addWMScheduledMode } from "./Services/WashingMachineService";
import WMHistoryComponent from "./WMHistoryComponent";
import { set } from "lodash";
const WashingMachineCardsComponent = ({deviceInfo}) => {
  const [powerOn, setPowerOn] = useState(false);
  const [powerState, setPowerState] = useState(0);
  const [selectedMode, setSelectedMode] = useState("");
  const [currentMode, setCurrentMode] = useState("");
  const [modes, setModes] = useState([]); // Replace with actual modes from API
  const [toDate,setToDate] = useState(null);
  const [fromDate,setFromDate] = useState(null);
  const [WMhistoryData, setWMHistoryData] = useState([])
  const [isDialogOpen, setDialogOpen] = useState(false);
  const [scheduleDateTime, setScheduleDateTime] = useState(new Date());


  const handleSwitchChange = async() => {
    if(powerState === 0){
        try{
            await turnWMOn(deviceInfo.id)
        }
        catch(error){
            console.log(error)
        }
    }
    else{
        try{
            await turnWMOff(deviceInfo.id)
        }catch(error){
            console.log(error)
        }
        
    }
  };

  const handleAddSchedule = async () =>{
    console.log("time:", scheduleDateTime);
    console.log("mode:", selectedMode);
    try{
      const response = await addWMScheduledMode(deviceInfo.id, scheduleDateTime, selectedMode);
      console.log(response);
    }catch(error){
      console.log(error)
    }
  }

  const handleDialogOpen = () => {
    setDialogOpen(true);
  };
  
  const handleDialogClose = () => {
    setDialogOpen(false);
  };
  
  const handleDateTimeChange = (event) => {
    setScheduleDateTime(event.target.value);
  };

  const handleModeChange = (event) => {
    setSelectedMode(event.target.value);

  };

  const handleSubmit = async() => {
    console.log("Submit clicked with mode:", selectedMode);
    try{
        console.log({id:deviceInfo.id, mode:selectedMode})
        await changeWMMode({id:deviceInfo.id, mode:selectedMode})
    }catch(error){
        console.log(error)
    }
    // Add logic to submit the selected mode to the server
  };

  useEffect(()=>{
    async function connect(){
        if(WMHubConnection.state === "Disconnected"){
          await WMHubConnection.start();
        }
        WMHubConnection.on(deviceInfo.connection, (payloadObject) =>{
            console.log(payloadObject)
          setPowerState(payloadObject.powerState)
          setCurrentMode(payloadObject.mode)
        });
      };
    connect()
    
    console.log(deviceInfo)
    setModes(deviceInfo.modes)
    }, []);

    useEffect(()=>{
        const fetchHistory = async()=>{
            try{
                const data = await getWMActions(deviceInfo.id, fromDate, toDate)
                setWMHistoryData(data)
                console.log(data);
            }catch(error)
            {
                console.log(error);
            }
        }
        fetchHistory();
    }, [toDate, fromDate, currentMode])

  return (
    <Grid container spacing={2}>
      {/* Power Card */}
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
                  checked={powerState === 1}
                  onChange={handleSwitchChange}
                  size="medium"
                />
              }
              label={powerState === 1 ? "ON":"OFF"}
            />
          </CardContent>
        </Card>
      </Grid>

      {/* Mode Selection Card */}
      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent>
            <Typography variant="h6">Select Mode</Typography>
            <FormControl fullWidth sx={{marginTop:"15px"}}>
              <InputLabel id="mode-select-label" >Mode</InputLabel>
              <Select
                labelId="mode-select-label"
                id="mode-select"
                value={selectedMode}
                onChange={handleModeChange}
              >
                {modes.map((mode) => (
                  <MenuItem key={mode.id} value={mode.name}>
                    {mode.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </CardContent>
        </Card>
      </Grid>

      <Grid item xs={12} md={6}>
        <Card style={{ height: "20vh" }}>
          <CardContent>
            <Typography variant="h6">Current Mode</Typography>
            <Typography variant="body1">{currentMode}</Typography>
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
              justifyContent: "center",
              height: "100%"
            }}
          >
            <Button variant="contained" color="primary" onClick={handleSubmit} disabled={powerState === 0}>
              Submit
            </Button>
            <Button variant="text" color="primary" onClick={handleDialogOpen} disabled={selectedMode === ""}>
              Add Schedule
            </Button>
          </CardContent>
        </Card>
      </Grid>
      <WMHistoryComponent wmHistory={WMhistoryData} setStartDate={setFromDate} setEndDate={setToDate}></WMHistoryComponent>
      <Dialog open={isDialogOpen} onClose={handleDialogClose}>
      <DialogTitle>Add Schedule</DialogTitle>
      <DialogContent>
        <TextField
          id="datetime"
          label="Schedule Datetime"
          type="datetime-local"
          value={scheduleDateTime}
          onChange={handleDateTimeChange}
          fullWidth
          InputLabelProps={{
            shrink: true,
          }}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleDialogClose} color="primary">
          Cancel
        </Button>
        <Button onClick={handleAddSchedule} color="primary">
          Add Schedule
        </Button>
      </DialogActions>
    </Dialog>
    </Grid>
  );
};

export default WashingMachineCardsComponent;
