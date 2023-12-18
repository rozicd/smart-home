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
import { GetPropertyPowerGraphData, GetPropertyPowerGraphDataDate } from "../Services/PropertiesService";
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
const PowerSpentHistory = ({ deviceInfo, property = false }) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [sortOrder, setSortOrder] = useState("asc");
  const [selectedSearch, setSelectedSearch] = useState();
  const [dateVisibility, setDateVisibility] = useState(false);
  const [powerData, setPowerData] = useState([]);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);

  const fetchData = async (hrs) => {
    console.log("data");

    try {
      let search = { id: deviceInfo.id, hours: hrs };
      let data = null;
      if (!property) data = await GetPowerGraphData(search);
      else {
        data = await GetPropertyPowerGraphData(search);
      }

      setPowerData(data);
    } catch (error) {
      console.log(error);
    }
  };

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
    if (toDate == "" || fromDate == "") {
      setErrorModal(true);
      setErrorMessage("Please Select Valis Dates");
      return;
    }
    let search = {
      id: deviceInfo.id,
      startDate: fromDate,
      endDate: toDate,
    };
    try {
      let data = null ;
      if (!property)data = await GetPowerGraphDataDate(search);
      else {data= await GetPropertyPowerGraphDataDate(search)}

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

            {property === false ? (
              <BasicGraph data={powerData} />
            ) : (
              <BasicPowerGraph data={powerData} />
            )}
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

export default PowerSpentHistory;
