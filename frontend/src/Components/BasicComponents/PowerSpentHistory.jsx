// Import necessary Material-UI components
import React, { useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  TextField,
  TableContainer,
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  IconButton,
  InputAdornment,
  Grid,
  Container,
  Button,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";
import BasicGraph from "./BasicGraph";
import BasicSelect from "./BasicSelect";
import BasicButton from "./BasicButton";
import { GetPowerGraphData } from "../Services/BatteryService";
const searchOptions = [
  { key: "1", value: "6h" },
  { key: "2", value: "12h" },
  { key: "3", value: "24h" },
  { key: "4", value: "7d" },
  { key: "5", value: "30d" },
  { key: "6", value: "Date Range" },
];
const PowerSpentHistory = ({deviceInfo}) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [sortOrder, setSortOrder] = useState("asc");
  const [selectedSearch, setSelectedSearch] = useState();
  const [dateVisibility, setDateVisibility] = useState(false);
  const [powerData,setPowerData] = useState([])



  

    const fetchData = async (hrs) => {
      console.log("data")

      try {
        let search = { 'id': deviceInfo.id, 'hours': hrs };
        let data = await GetPowerGraphData(search)
        console.log("data")

        console.log(data)
        setPowerData(data)
        console.log("data")

      } catch (error) {
        console.log(error)
      } 
    };


  const handleSearchChange = (value) => {
    const foundOption = searchOptions.find(option => option.key === value);
    console.log(foundOption)
    setDateVisibility(false);
    setSelectedSearch(value);
    if (value == "6") setDateVisibility(true);
    else 
    {
        fetchData(foundOption.value)
    }
  };

  return (
    <Grid container spacing={2}>

      <Grid item xs={12}>
        <Card>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "center",
            }}
          >
            <Typography variant="h6">History</Typography>

            <BasicGraph data={powerData}></BasicGraph>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12}>
        <Card style={{ width: "85%", margin: "auto" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "center",
            }}
          >
            <Grid
              container
              item
              spacing={3}
              alignItems="center"
              justifyContent="center"
            >
              <Grid item xs={12}>
                <BasicSelect
                  label={"Sensor Type"}
                  collection={searchOptions}
                  valueParam={"key"}
                  nameParam={"value"}
                  selected={selectedSearch}
                  callback={(e) => handleSearchChange(e.target.value)}
                ></BasicSelect>
              </Grid>

              {/* Container for date pickers */}
              {dateVisibility && (
                <Grid
                  container
                  item
                  xs={12}
                  spacing={3}
                  alignItems="center"
                  justifyContent="center"
                >
                  <Grid item xs={4}>
                    <TextField
                      label="From Date"
                      type="date"
                      value={fromDate}
                      onChange={(e) => setFromDate(e.target.value)}
                      InputLabelProps={{ shrink: true }}
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <TextField
                      label="To Date"
                      type="date"
                      value={toDate}
                      onChange={(e) => setToDate(e.target.value)}
                      InputLabelProps={{ shrink: true }}
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <Button >Search</Button>
                  </Grid>
                </Grid>
              )}
            </Grid>
          </CardContent>
        </Card>
      </Grid>
    </Grid>
  );
};

export default PowerSpentHistory;
