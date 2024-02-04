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
import BasicGraph from "./BasicComponents/BasicGraph";

const ESCReadingsComponent = ({escReadings, setEndDate, setStartDate})=>{
    const [dataSelect, setDataSelect] = useState(1)
    const [dateVisibility, setDateVisibility] = useState(false);
    const [fromDate, setFromDate] = useState("");
    const [toDate, setToDate] = useState("");

    const handleStartDateChange = (value) => {
        setFromDate(value);
        setStartDate(value);
      };
      const handleEndDateChange = (value) => {
        setToDate(value);
        setEndDate(value);
      };
    
      const handleSelectValueChange = (event) => {
        const selectedValue = event.target.value;
        let currentDate = new Date();
        setDataSelect(selectedValue)
        console.log(selectedValue);
        // Update startTime and endTime based on the selected time range
        switch (selectedValue) {
            case 1:
              setStartDate(new Date(currentDate.getTime() - 1 * 60 * 60 * 1000)); // Subtract 1 hour
              setEndDate(currentDate);
              setDateVisibility(false);
              break;
            case 2:
              setStartDate(new Date(currentDate.getTime() - 6 * 60 * 60 * 1000)); // Subtract 6 hours
              setEndDate(currentDate);
              setDateVisibility(false);
              break;
            case 3:
              setStartDate(new Date(currentDate.getTime() - 12 * 60 * 60 * 1000)); // Subtract 12 hours
              setEndDate(currentDate);
              setDateVisibility(false);
              break;
            case 4:
              setStartDate(new Date(currentDate.getTime() - 24 * 60 * 60 * 1000)); // Subtract 24 hours
              setEndDate(currentDate);
              setDateVisibility(false);
              break;
            case 5:
              setStartDate(new Date(currentDate.getTime() - 7 * 24 * 60 * 60 * 1000)); // Subtract 7 days
              setEndDate(currentDate);
              break;
            case 6:
              setDateVisibility(true);
              break;
            default:
              setStartDate(new Date(currentDate.getTime() - 1 * 60 * 60 * 1000)); // Default to 1 hour
              setEndDate(currentDate);
          }
    
    };

    return(
        <Card style={{ height: "auto", width: "85%", margin: "auto" }}>
            <CardContent
                style={{
                    display: "flex",
                    flexDirection: "column",
                    alignItems: "center",
                    justifyContent: "space-evenly",
                    height: "80%",
                  }}>
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
                <div style={{ display: "flex", justifyContent: "space-between", margin: "2vh", width: "80%", maxHeight: "200px",  }}>
                    {dateVisibility &&(
                        <TextField
                        label="From Date"
                        type="date"
                        value={fromDate}
                        onChange={(e) => handleStartDateChange(e.target.value)}
                        InputLabelProps={{ shrink: true }}
                        />
                        )
                    }
                    {dateVisibility &&(
                        <TextField
                        label="To Date"
                        type="date"
                        value={toDate}
                        onChange={(e) => handleEndDateChange(e.target.value)}
                        InputLabelProps={{ shrink: true }}
                        />
                        )
                    }
                </div>
                <BasicGraph data={escReadings} datakey="roomTemperate" ah={false}/>
                <BasicGraph data={escReadings} datakey="airHumidity" ah={false}/>

            </CardContent>

        </Card>
)
}

export default ESCReadingsComponent;