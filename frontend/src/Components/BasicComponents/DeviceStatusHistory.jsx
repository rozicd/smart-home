// DeviceStatusHistory.jsx
import React, { useEffect, useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  Button,
  TextField,
} from "@mui/material";
import { GetStatusGraphData, GetStatusGraphDataDate } from "../Services/SmartDeviceService";
import InfoDialog from "./InfoDialog";
import BasicSelect from "./BasicSelect";
import { BarChartComponent, PieChartComponent } from "./DeviceCharts";

const searchOptions = [
  { key: "3", value: "6h" },
  { key: "4", value: "12h" },
  { key: "5", value: "24h" },
  { key: "6", value: "7d" },
  { key: "7", value: "30d" },
  { key: "8", value: "Date Range" },
];

const DeviceStatusHistory = ({ deviceInfo }) => {
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [selectedSearch, setSelectedSearch] = useState();
  const [dateVisibility, setDateVisibility] = useState(false);
  const [statusData, setStatusData] = useState([]);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);
  const [timeRangeHours, setTimeRangeHours] = useState(['hours',0,null]);

  const fetchData = async (hrs) => {
    try {
      let search = { id: deviceInfo.id, hours: hrs };
      let data = await GetStatusGraphData(search);
      setStatusData(data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchData("6");
    setTimeRangeHours(['hours', 6,null]);

    }, []);

  const handleSearchChange = (value) => {
    const foundOption = searchOptions.find((option) => option.key === value);
    setDateVisibility(false);
    setSelectedSearch(value);

    if (value === "x") return;

    if (value === "8") {
      setDateVisibility(true);
    } else {
      let timeRangeValue = 0;
      let timeRangeUnit = 'hours'; 
      
      if(value ==="3"){
        timeRangeValue = 6;

      }
      else if(value === "4"){
        timeRangeValue = 12;

      }
      else if(value === "5"){
        timeRangeValue = 24;

      }
      else if(value === "6"){
        timeRangeValue = 7;
        timeRangeUnit = 'days';
      }
      else if(value === "7"){
        timeRangeValue = 30;
        timeRangeUnit = 'days';
      }
        setTimeRangeHours([timeRangeUnit, timeRangeValue,null]);
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

    if (dateDifferenceInDays > 2) {
      setTimeRangeHours(['days', dateDifferenceInDays,endDate]);
    } else {
      setTimeRangeHours(['hours', dateDifferenceInDays * 24]);
    }

    let search = {
      id: deviceInfo.id,
      startDate: fromDate,
      endDate: toDate,
    };

    try {
      let data = await GetStatusGraphDataDate(search);
      setStatusData(data);
    } catch (error) {
      if (error.response) {
        setErrorModal(true);
        setErrorMessage(error.response.data);
      }
    }
  };

  return (
<Grid container spacing={2} style={{ width: "77%", marginTop: '70px', textAlign: 'center',justifyContent:'center',wrap:"nowrap"}}>
  <Typography sx={{ fontSize: '2rem', marginBottom: '20px' }}>AVAILABILITY</Typography>
      {/* Row with Pie Chart and Bar Chart */}
      <Grid container item xs={12} spacing={2} flexDirection={"column"} wrap="nowrap">
        <Grid item xs={6} style= {{marginTop: '20px'}}>
          <PieChartComponent data={statusData} timeRange={timeRangeHours}/>
        </Grid>
        <Grid item xs={6} style= {{marginTop: '20px'}}>
          <BarChartComponent data={statusData} timeRange={timeRangeHours}/>
        </Grid>
      </Grid>

      {/* Row with Select Component */}
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
                  label={"Time"}
                  collection={searchOptions}
                  valueParam={"key"}
                  nameParam={"value"}
                  selected={selectedSearch}
                  callback={(e) => handleSearchChange(e.target.value)}
                ></BasicSelect>
              </Grid>

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

      {/* Error Dialog */}
      <InfoDialog
        open={errorModal}
        onClose={() => setErrorModal(false)}
        title={"Error"}
        content={errorMessage}
      ></InfoDialog>
    </Grid>
  );
};

export default DeviceStatusHistory;
