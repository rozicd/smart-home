import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  TextField,
  Grid,
  Button,
} from "@mui/material";
import BasicSelect from "./BasicSelect";
import { API_BASE_URL } from "../../App";
import axios from "axios";
import BasicPieChart from "./BasicPieChart";
import InfoDialog from "./InfoDialog";

const searchOptions = [
  { key: "1", value: "6h" },
  { key: "2", value: "12h" },
  { key: "3", value: "24h" },
  { key: "4", value: "7d" },
  { key: "5", value: "30d" },
  { key: "6", value: "Date Range" },
];
const searchParam = [
  { key: "1", value: "City" },
  { key: "2", value: "Country" },
];

const EnergySpentCountry = ({}) => {
  const [selectedSearch, setSelectedSearch] = useState("1");
  const [spent, setSpent] = useState(0);
  const [generated, setGenerated] = useState(0);
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [dateVisibility, setDateVisibility] = useState(false);

  const [selectedSearchParam, setSelectedSearchParam] = useState("1");
  const [countryVisible, setCountryVisible] = useState(false);
  const [cityVisible, setCityVisible] = useState(true);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);

  const [countries, setCountries] = useState([]);
  const [cities, setCities] = useState([]);
  const [selectedCountry, setSelectedCountry] = useState("x");
  const [selectedCity, setSelectedCity] = useState("x");
  const [data, setData] = useState([]);
  const handleSearchClick = async () => {
    if (toDate == "" || fromDate == "") {
      setErrorModal(true);
      setErrorMessage("Please Select Valid Dates");
      return;
    }

    let n = "";
    let t = "";
    if (selectedSearchParam == "1") {
      n = selectedCity;
      t = "City";
    }
    if (selectedSearchParam == "2") {
      n = selectedCountry;
      t = "Country";
    }
    if (t == "") return;
    let search = {
      name: n,
      tag: t,
      start: fromDate,
      end: toDate,
    };
    console.log(search);
    fetchEnergy(search, true);
  };
  const handleCountryChange = (value) => {
    setSpent(0);
    setGenerated(0);
    setData([]);

    setSelectedCountry(value);
  };
  const handleCityChange = (value) => {
    setSpent(0);
    setGenerated(0);
    setData([]);
    setSelectedCity(value);
  };
  const handleSearchParamChange = (value) => {
    setSpent(0);
    setGenerated(0);
    setData([]);
    

    setCountryVisible(false);
    setCityVisible(false);

    if (value == "1") setCityVisible(true);
    if (value == "2") setCountryVisible(true);

    setSelectedSearchParam(value);
  };

  const handleSearchChange = (value) => {
    const foundOption = searchOptions.find((option) => option.key === value);
    setDateVisibility(false);
    if (value == "6") {
      setDateVisibility(true);
      return;
    }

    let n = "";
    let t = "";
    if (selectedSearchParam == "1") {
      n = selectedCity;
      t = "City";
    }
    if (selectedSearchParam == "2") {
      n = selectedCountry;
      t = "Country";
    }
    if (t == "") return;
    let search = {
      name: n,
      tag: t,
      search: foundOption.value,
    };
    console.log(search);

    fetchEnergy(search);
    setSelectedSearch(value);
  };

  const fetchProperty = () => {
    axios
      .get(`${API_BASE_URL}/properties/country`)
      .then((response) => {
        console.log(response.data);
        setCities(response.data.cities);
        setCountries(response.data.countries);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  };
  const fetchEnergy = (search, date = false) => {
    let url = `${API_BASE_URL}/properties/country/energy`;
    if (date == true) {
      url = `${API_BASE_URL}/properties/country/energy/date`;
    }
    axios
      .post(url, search, {
        withCredentials: true,
      })
      .then((response) => {
        setSpent(response.data.spent);
        setGenerated(response.data.generated);
        const edata = [
          { name: "Spent", value: response.data.spent },
          { name: "Generated", value: response.data.generated },
        ];
        setData(edata);
        console.log(response.data);
      })
      .catch((error) => {
        console.error("Error:", error);
        setErrorModal(true);
        setErrorMessage(error.response.data);
      });
  };
  useEffect(() => {
    fetchProperty();
  }, []);
  return (
    <Card>
      <CardContent style={{}}>
        <Grid
          container
          spacing={2}
          direction={"column"}
          justifyContent={"center"}
          alignItems={"center"}
        >
          <Grid item xs={6}>
            <BasicSelect
              label={"Param"}
              collection={searchParam}
              valueParam={"key"}
              nameParam={"value"}
              selected={selectedSearchParam}
              callback={(e) => handleSearchParamChange(e.target.value)}
            ></BasicSelect>
          </Grid>

          <Grid item xs={6}>
            {countryVisible && (
              <BasicSelect
                label={"Country"}
                collection={countries}
                valueParam={"name"}
                nameParam={"name"}
                selected={selectedCountry}
                callback={(e) => handleCountryChange(e.target.value)}
              ></BasicSelect>
            )}
            {cityVisible && (
              <BasicSelect
                label={"City"}
                collection={cities}
                valueParam={"name"}
                nameParam={"name"}
                selected={selectedCity}
                callback={(e) => handleCityChange(e.target.value)}
              ></BasicSelect>
            )}
          </Grid>
          {(selectedCity != "x" || selectedCountry != "x") &&
            (countryVisible || cityVisible) && (
              <Grid item xs={6}>
                <BasicSelect
                  label={"Search"}
                  collection={searchOptions}
                  valueParam={"key"}
                  nameParam={"value"}
                  selected={selectedSearch}
                  callback={(e) => handleSearchChange(e.target.value)}
                ></BasicSelect>
              </Grid>
            )}
          {dateVisibility && (
            <Grid
              container
              item
              xs={6}
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
          <Grid item xs={6} justifyContent={"center"} alignContent={"center"}>
            <BasicPieChart data={data}></BasicPieChart>
          </Grid>
        </Grid>
        <InfoDialog
          open={errorModal}
          onClose={() => setErrorModal(false)}
          title={"Error"}
          content={errorMessage}
        ></InfoDialog>
      </CardContent>
    </Card>
  );
};
export default EnergySpentCountry;
