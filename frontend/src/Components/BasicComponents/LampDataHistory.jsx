// Import necessary Material-UI components
import React, { useEffect, useState } from "react";
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
import InfoDialog from "./InfoDialog";

import BasicGraph from "./BasicGraph";
import BasicSelect from "./BasicSelect";
import {
    GetGraphData,
  GetGraphDataDate,
  GetPowerGraphData,
  GetPowerGraphDataDate,
} from "../Services/LampService";
import LampGraph from "./LampGraph";
const searchOptions = [
  { key: "1", value: "5m" },
  { key: "2", value: "1h" },
  { key: "3", value: "6h" },
  { key: "4", value: "12h" },
  { key: "5", value: "24h" },
  { key: "6", value: "7d" },
  { key: "7", value: "30d" },
  { key: "8", value: "Date Range" },
];
const LampDataHistory = ({ deviceInfo }) => {
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [selectedSearch, setSelectedSearch] = useState();
  const [dateVisibility, setDateVisibility] = useState(false);
  const [lampData, setLampData] = useState([]);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);

  const fetchData = async (hrs) => {
    console.log("data");

    try {
      let search = { id: deviceInfo.id, hours: hrs };
      let data = await GetGraphData(search);
      const numericData = data.map(entry => ({
        ...entry,
        powerStatus: parseFloat(entry.powerStatus),
      }));
      console.log(numericData)
      setLampData(numericData);
    } catch (error) {
      console.log(error);
    }
  };

  
  useEffect(() => {
    fetchData("6");
  }, []);


  const handleSearchChange = (value) => {
    
    const foundOption = searchOptions.find((option) => option.key === value);
    console.log(foundOption);
    setDateVisibility(false);
    setSelectedSearch(value);
    if (value == "x") return;

    if (value == "8") setDateVisibility(true);
    else {
      fetchData(foundOption.value);
    }
  };

  const handleSearchClick = async () => {
    if (toDate === "" || fromDate === "") {
      setErrorModal(true);
      setErrorMessage("Please Select Valid Dates");
      return;
    }
  
    const startDate = new Date(fromDate);
    const endDate = new Date(toDate);
  
    const dateDifferenceInDays = (endDate - startDate) / (24 * 60 * 60 * 1000);
  
    const maxAllowedDifferenceInDays = 30;
  
    if (dateDifferenceInDays > maxAllowedDifferenceInDays) {
      setErrorModal(true);
      setErrorMessage("Date range cannot exceed 30 days");
      return;
    }
  
    let search = {
      id: deviceInfo.id,
      startDate: fromDate,
      endDate: toDate,
    };
  
    try {
      let data = await GetGraphDataDate(search);
      setLampData(data);
    } catch (error) {
      if (error.response) {
        setErrorModal(true);
        setErrorMessage(error.response.data);
      }
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

            <LampGraph data={lampData}></LampGraph>
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
                    <Button onClick={() => handleSearchClick()}>Search</Button>
                  </Grid>
                </Grid>
              )}
            </Grid>
          </CardContent>
        </Card>
      </Grid>
      <InfoDialog
        open={errorModal}
        onClose={() => setErrorModal(false)}
        title={"Error"}
        content={errorMessage}
      ></InfoDialog>
    </Grid>
  );
};

export default LampDataHistory;
