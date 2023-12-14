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

import { LineChart } from "@mui/x-charts";
import { ecsHubConnection } from "./Sockets/SocketService";
import { getESCData } from "./Services/SmartDeviceService";


const ECSCardsComponent = ({ deviceInfo }) =>{
    const [ecsData, setECSData] = useState({airHumidity: 0, roomTemperature: 0});
    const [dates, setDates] = useState([])
    const [temperatures, setTemperatures] = useState([])
    const [humidities, setHumidities] = useState([])
    const [dataSelect, setDataSelect] = useState(1)

    useEffect(()=>{
        async function connect(){
            if(ecsHubConnection.state === "Disconnected"){
                await ecsHubConnection.start();
            }
            ecsHubConnection.on(deviceInfo.connection, (airHumidity, roomTemperature) =>{
                setECSData({airHumidity, roomTemperature})
            });
        }
        async function getData(){
            try{
                let data = []
                data = await getESCData(deviceInfo.type, {Name:"Room", start:"-1h", end:"0h"});
                let onlyDates = []
                let temps = []
                let onlyHumidities = []
                data.forEach((element, index) => {
                    onlyDates.push(element.time)
                    temps.push(element.roomTemperature)
                    onlyHumidities.push(element.airHumidity)
                });
                setDates(onlyDates);
                setTemperatures(temps);
                setHumidities(onlyHumidities);
                console.log(data);
            }catch(error){
                console.log(error);
            }
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
                        label="Age"
                    >
                        <MenuItem value={10}>Last hour</MenuItem>
                        <MenuItem value={20}>Last 6 hours</MenuItem>
                        <MenuItem value={30}>Last 12 hours</MenuItem>
                    </Select>
                </FormControl>
                <LineChart
                    xAxis={[{ data: [1, 2, 3, 5, 8, 10] }]}
                    series={[
                        {
                        data: [2, 5.5, 2, 8.5, 1.5, 5],
                        },
                    ]}
                    width={500}
                    height={300}
                    />
                </CardContent>
                </Card>
            </Grid>

    </Grid>
    );
}

export default ECSCardsComponent;