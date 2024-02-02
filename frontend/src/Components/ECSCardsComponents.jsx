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
import { getESCReadings } from "./Services/ESCService";
import ESCReadingsComponent from "./ESCReadingsComponent";

const ECSCardsComponent = ({ deviceInfo }) =>{
    const [ecsData, setECSData] = useState({airHumidity: 0, roomTemperature: 0});
    const [dates, setDates] = useState([])
    const [temperatures, setTemperatures] = useState([])
    const [humidities, setHumidities] = useState([])
    const [dataSelect, setDataSelect] = useState(1)
    const [dataHistory, setDataHistory] = useState([])
    const [toDate, setToDate] = useState(null);
    const [fromDate, setFromDate] = useState(null);
    const[escReadings, setEscReadings] = useState({})

    useEffect(()=>{
        async function connect(){
            if(ecsHubConnection.state === "Disconnected"){
                await ecsHubConnection.start();
            }
            ecsHubConnection.on(deviceInfo.connection, (airHumidity, roomTemperature) =>{
                setECSData({airHumidity, roomTemperature})
            });
        }
    
        connect();

    }, []);

    useEffect(()=>{
        const getReadings = async() =>{
            try{
                
                const response = await getESCReadings(deviceInfo.id, fromDate, toDate)
                setEscReadings(response);
            }catch(error){
                console.log(error);
            }
        }
        console.log(fromDate)
        console.log(toDate)
        getReadings();
    }, [fromDate, toDate])

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
            <Grid item xs={12} md={12} sx={{marginTop:"50px"}}>
                <ESCReadingsComponent escReadings={escReadings} setEndDate={setToDate} setStartDate={setFromDate}></ESCReadingsComponent>
            </Grid>

    </Grid>
    );
}

export default ECSCardsComponent;