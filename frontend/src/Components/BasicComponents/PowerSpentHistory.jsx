// Import necessary Material-UI components
import React, { useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  TextField,
  Grid,
  Button,
} from "@mui/material";
import InfoDialog from "./InfoDialog";
import BasicPowerGraph from "./BasicPowerGraph";
import BasicGraph from "./BasicGraph";
import BasicSelect from "./BasicSelect";
import {
  GetPowerGraphData,
  GetPowerGraphDataDate,
} from "../Services/BatteryService";
import {
  GetPropertyPowerGraphData,
  GetPropertyPowerGraphDataDate,
} from "../Services/PropertiesService";
const searchOptions = [
  { key: "real", value: "Real Time" },
  { key: "1", value: "5m" },
  { key: "2", value: "1h" },
  { key: "3", value: "6h" },
  { key: "4", value: "12h" },
  { key: "5", value: "24h" },
  { key: "6", value: "7d" },
  { key: "7", value: "30d" },
  { key: "8", value: "Date Range" },
  { key: "9", value: "Day" },

];
const PowerSpentHistory = ({ deviceInfo, property = false, RealTimeGraph }) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [day, setDay] = useState("");

  const [sortOrder, setSortOrder] = useState("asc");
  const [selectedSearch, setSelectedSearch] = useState("real");
  const [dateVisibility, setDateVisibility] = useState(false);
  const [dayVisibility, setDayVisibility] = useState(false);

  const [powerData, setPowerData] = useState([]);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);



  const fetchData = async (hrs) => {

    try {
      let search = { id: deviceInfo.id, hours: hrs };
      let data = null;
      if (!property) data = await GetPowerGraphData(search);
      else {
        data = await GetPropertyPowerGraphData(search);
      }
      console.log(data)
      setPowerData(data);
    } catch (error) {
      console.log(error);
    }
  };


  const handleSearchChange = (value) => {
    const foundOption = searchOptions.find((option) => option.key === value);
    console.log(foundOption);
    setDateVisibility(false);
    setDayVisibility(false);

    setSelectedSearch(value);
    if (value == "real") return;

    if (value == "x") return;

    if (value == "8") setDateVisibility(true);
    if (value == "9") setDayVisibility(true);

    else {
      fetchData(foundOption.value);
    }
  };

  const handleSearchClick = async () => {
    if (toDate == "" || fromDate == "") {
      setErrorModal(true);
      setErrorMessage("Please Select Valid Dates");
      return;
    }
    let search = {
      id: deviceInfo.id,
      startDate: fromDate,
      endDate: toDate,
    };
    try {
      let data = null;
      if (!property) data = await GetPowerGraphDataDate(search);
      else {
        data = await GetPropertyPowerGraphDataDate(search);
      }

      setPowerData(data);
    } catch (error) {
      if (error.response) {
        setErrorModal(true);
        setErrorMessage(error.response.data);
      }
    }
  };
  const handleSearchClickDay = async () => {
    if (day == "") {
      setErrorModal(true);
      setErrorMessage("Please Select Valid Day");
      return;
    }
    const selectedDate = new Date(day);

    const startDate = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate());

    const endDate = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 23, 59, 59);
    

    const startOfDayFormatted = startDate.toISOString()
    const endOfDayFormatted = endDate.toISOString()

    let search = {
      id: deviceInfo.id,
      startDate: startOfDayFormatted,
      endDate: endOfDayFormatted,
    };
    try {
      let data = null;
      if (!property) data = await GetPowerGraphDataDate(search);
      else {
        data = await GetPropertyPowerGraphDataDate(search);
      }

      setPowerData(data);
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
            {selectedSearch === "real" ? (
              // Render RealTimeGraph if selectedSearch is "real"
              RealTimeGraph
            ) : property === false ? (
              <BasicGraph data={powerData}></BasicGraph>
            ) : (
              <BasicPowerGraph data={powerData} />
            )}
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
              {dayVisibility && (
                <Grid
                  container
                  item
                  xs={12}
                  spacing={3}
                  alignItems="center"
                  justifyContent="center"
                >
                  
                  <Grid item xs={8}>
                    <TextField
                      label="Day"
                      type="date"
                      value={day}
                      onChange={(e) => setDay(e.target.value)}
                      InputLabelProps={{ shrink: true }}
                    />
                  </Grid>
                  <Grid item xs={4}>
                    <Button onClick={() => handleSearchClickDay()}>Search</Button>
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

export default PowerSpentHistory;
