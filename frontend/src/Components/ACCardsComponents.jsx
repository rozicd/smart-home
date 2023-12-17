import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  FormControlLabel,
  Switch,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button
} from "@mui/material";
import AcUnitIcon from '@mui/icons-material/AcUnitOutlined';
import WbSunnyIcon from '@mui/icons-material/WbSunnyOutlined';
import AirOutlinedIcon from '@mui/icons-material/AirOutlined';

const ACCardsComponents = ({ deviceInfo }) =>{
    const handleSwitchChange = () =>{
        console.log("Kurac")
    }
    return(
        <Grid container spacing={2}>
            <Grid item xs={12} md={6}>
                <Card style={{ height: "20vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
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
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
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
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
                    <Typography variant="h6">Max Temperature</Typography>
                    <FormControlLabel
                        style={{ width: "80%", height:"20%" }}
                        control={<Switch checked={deviceInfo.deviceStatus === "ONLINE"} onChange={handleSwitchChange} size="medium" />}
                        label={deviceInfo.deviceStatus === "ONLINE" ? "ON" : "OFF"}                        
                    />
                </CardContent>
                </Card>
            </Grid>
            <Grid item xs={12} md={6}>
                <Card style={{ height: "20vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%" }}>
                    <Typography variant="h6">Current Temp</Typography>
                    <Typography align="center" variant="h4">
                    {deviceInfo.maximumTemperature} °C
                    </Typography>
                    <Typography align="center"></Typography>
                    <div>
                        <Button style={{fontSize: "36px"}}>-</Button>
                        <Button style={{fontSize: "36px"}}>+</Button> 
                    </div>
                </CardContent>
                </Card>
            </Grid>
            <Grid item xs={24} md={12}>
                <Card style={{ height: "25vh" }}>
                <CardContent style={{ display: "flex", flexDirection: "column", alignItems: "center", justifyContent: "space-evenly",height:"80%"  }}>
                <div>
                        <Button style={{margin:"30px"}}><AcUnitIcon sx={{ fontSize: 60 }} color="primary"></AcUnitIcon></Button>
                        <Button style={{margin:"30px"}}><WbSunnyIcon sx={{ fontSize: 60 }} color="primary"/></Button>
                        <Button style={{margin:"30px"}}><AirOutlinedIcon sx={{ fontSize: 60 }} color="primary"/></Button>
                        <Button style={{margin: "30px", fontSize: "15px"}}>AUTO</Button>   
                </div>
                </CardContent>
                </Card>
            </Grid>
        </Grid>
    );

}

export default ACCardsComponents;