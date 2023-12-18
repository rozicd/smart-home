import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  FormControl,
  InputLabel,
  Select,
  MenuItem
} from "@mui/material";

import { ecsHubConnection } from "./Sockets/SocketService";
import { getESCData } from "./Services/SmartDeviceService";
import BasicGraph from "./BasicComponents/BasicGraph";


const ECSCardsComponent = ({ deviceInfo }) =>{
    const [ecsData, setECSData] = useState({airHumidity: 0, roomTemperature: 0});
    const [dates, setDates] = useState([])
    const [temperatures, setTemperatures] = useState([])
    const [humidities, setHumidities] = useState([])
    const [dataSelect, setDataSelect] = useState(1)
    const [dataHistory, setDataHistory] = useState([])
    const [historyQuery, setHistoryQuery] = useState({Name:deviceInfo.name, start:"-1h", end:"0h"})


    const handleSelectValueChange = (event) => {
        const selectedValue = event.target.value;
      
        let startTime, endTime;
      
        // Update startTime and endTime based on the selected time range
        switch (selectedValue) {
          case 1:
            startTime = "-1h";
            endTime = "0h";
            break;
          case 2:
            startTime = "-6h";
            endTime = "0h";
            break;
          case 3:
            startTime = "-12h";
            endTime = "0h";
            break;
          default:
            startTime = "-1h";
            endTime = "0h";
        }
      
        // Use the callback version of setHistoryQuery
        setHistoryQuery((prevHistoryQuery) => ({
          ...prevHistoryQuery,
          Name: deviceInfo.name,
          start: startTime,
          end: endTime,
        }));
      
        // Call getData after the state is updated
        getData();
      };
      async function getData(){
        try{
            let data = []
            data = await getESCData(deviceInfo.type, historyQuery);

            let onlyDates = []
            let temps = []
            let onlyHumidities = []
            data.forEach((element, index) => {
                onlyDates.push(element.time)
                temps.push({time:element.time, roomTemperate:element.roomTemperate})
                onlyHumidities.push({time:element.time, airHumidity:element.airHumidity})
            });
            
            setDates(onlyDates);
            setTemperatures(temps);
            setHumidities(onlyHumidities);
            setDataHistory(data)
            console.log(data);
        }catch(error){
            console.log(error);
        }
    }

    useEffect(()=>{
        async function connect(){
            if(ecsHubConnection.state === "Disconnected"){
                await ecsHubConnection.start();
            }
            ecsHubConnection.on(deviceInfo.connection, (airHumidity, roomTemperature) =>{
                setECSData({airHumidity, roomTemperature})
            });
        }
        
        getData();
        connect();
    }, []);

    return(
        <Grid container spacing={2}>
            <Grid item xs={12} md={6}>
                <Card style={{ height: "20vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
                    <Typography variant="h6">Temperature</Typography>
                    <Typography align="center" variant="h4">
                    {ecsData.roomTemperature}
                    </Typography>
                    <Typography align="center">°C</Typography>
                </CardContent>
                </Card>
            </Grid>

            <Grid item xs={12} md={6}>
                <Card style={{ height: "20vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
                    <Typography variant="h6">Air humidity</Typography>
                    <Typography align="center" variant="h4">
                    {ecsData.airHumidity}
                    </Typography>
                    <Typography align="center">%</Typography>
                </CardContent>
                </Card>
            </Grid>
            <Grid item xs={24} md={12}>
                <Card style={{ height: "55vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
                <FormControl sx={{ m: 1, minWidth: 120 }} size="small">
                    <InputLabel id="demo-simple-select-label">Time</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={dataSelect}
                        onChange={handleSelectValueChange}
                        label="Age"
                    >
                        <MenuItem value={1}>Last hour</MenuItem>
                        <MenuItem value={2}>Last 6 hours</MenuItem>
                        <MenuItem value={3}>Last 12 hours</MenuItem>
                    </Select>
                </FormControl>
                <BasicGraph data={dataHistory} xKey="time" yKey="roomTemperate"/>
                </CardContent>
                </Card>
            </Grid>

    </Grid>
    );
}

export default ECSCardsComponent;