import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  TextField
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
    const [dateVisibility, setDateVisibility] = useState(false);
    const [fromDate, setFromDate] = useState("");
    const [toDate, setToDate] = useState("");


    const handleSelectValueChange = (event) => {
        const selectedValue = event.target.value;
        console.log(selectedValue);
        let startTime, endTime;
        setDataSelect(selectedValue)
      
        // Update startTime and endTime based on the selected time range
        switch (selectedValue) {
          case 1:
            startTime = "-1h";
            endTime = "0h";
            setDateVisibility(false)
            break;
          case 2:
            startTime = "-6h";
            endTime = "0h";
            setDateVisibility(false)
            break;
          case 3:
            startTime = "-12h";
            endTime = "0h";
            setDateVisibility(false)
            break;
          case 4:
            startTime = "-24h";
            endTime = "0h";
            setDateVisibility(false)
            break;
          case 5:
            startTime = "-7d";
            endTime = "0h";
            break;
           case 6:
            setDateVisibility(true)
          default:
            startTime = "-1h";
            endTime = "0h";
        }
        
        
        // Use the callback version of setHistoryQuery
        // setHistoryQuery((prevHistoryQuery) => ({
        //   ...prevHistoryQuery,
        //   Name: deviceInfo.name,
        //   start: startTime,
        //   end: endTime,
        // }));
        // Call getData after the state is updated
        getData(startTime, endTime);
      };
      async function getData(start="-1h", end="0h"){
        let historyQuery = {Name:deviceInfo.name, start:start, end:end}
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
            setDataHistory(data);
            console.log(dataHistory)
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
        <Grid container spacing={2} >
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
            <Grid item xs={24} md={12} sx={{marginTop:"50px"}}>
                <Card style={{ height: "100vh"}}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"100%" }}>
                <FormControl sx={{ m: 1, minWidth: 120 }} size="small">
                    <div>
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
                            <MenuItem value={4}>Last 24 hours</MenuItem>
                            <MenuItem value={5}>Last 7 days</MenuItem>
                            <MenuItem value={6}>Data Range</MenuItem>
                        </Select>
                        {dateVisibility &&(
                            <TextField
                            label="From Date"
                            type="date"
                            value={fromDate}
                            onChange={(e) => setFromDate(e.target.value)}
                            InputLabelProps={{ shrink: true }}
                            />
                            )
                        }
                        {dateVisibility &&(
                            <TextField
                            sx={{height:"35px"}}
                            label="To Date"
                            type="date"
                            value={toDate}
                            onChange={(e) => {setToDate(e.target.value);
                                                if(fromDate !== "" && toDate!==""){
                                                    getData(fromDate, toDate)
                                                }}}
                            InputLabelProps={{ shrink: true }}
                            />
                            )
                        }
                    </div>
                </FormControl>
                <BasicGraph data={temperatures} datakey="roomTemperate" ah={false}/>
                <BasicGraph data={humidities} datakey="airHumidity" ah={false}/>
                </CardContent>
                </Card>
            </Grid>

    </Grid>
    );
}

export default ECSCardsComponent;