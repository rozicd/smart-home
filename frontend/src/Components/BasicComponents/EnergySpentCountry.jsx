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

  const [selectedSearchParam, setSelectedSearchParam] = useState("1");
  const [countryVisible, setCountryVisible] = useState(false);
  const [cityVisible, setCityVisible] = useState(false);

  const [countries, setCountries] = useState([]);
  const [cities, setCities] = useState([]);
  const [selectedCountry, setSelectedCountry] = useState("x");
  const [selectedCity, setSelectedCity] = useState("x");

  const handleCountryChange = (value) => {
    setSelectedCountry(value);
  };
  const handleCityChange = (value) => {
    setSelectedCity(value);
  };
  const handleSearchParamChange = (value) => {
    setCountryVisible(false);
    setCityVisible(false);

    if (value == "1") setCityVisible(true);
    if (value == "2") setCountryVisible(true);

    setSelectedSearchParam(value);
  };

  const handleSearchChange = (value) => {
    const foundOption = searchOptions.find((option) => option.key === value);

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
  const fetchEnergy = (search) => {
    axios
      .post(`${API_BASE_URL}/properties/country/energy`, search, {
        withCredentials: true,
      })
      .then((response) => {
        setSpent(response.data.spent);
        setGenerated(response.data.generated);
        console.log(response.data);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  };
  useEffect(() => {
    fetchProperty();
  }, []);
  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <BasicSelect
          label={"Param"}
          collection={searchParam}
          valueParam={"key"}
          nameParam={"value"}
          selected={selectedSearchParam}
          callback={(e) => handleSearchParamChange(e.target.value)}
        ></BasicSelect>
      </Grid>

      <Grid item xs={12}>
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
      {(selectedCity != "x" || selectedCountry!= "x")&&(countryVisible || cityVisible) && (
        <Grid item xs={12}>
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
    </Grid>
  );
};
export default EnergySpentCountry;
