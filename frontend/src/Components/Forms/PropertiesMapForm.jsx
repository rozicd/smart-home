import React, { useEffect, useState } from "react";
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  TextField,
  Box,
  Typography,
} from "@mui/material";
import MapComponent from "../BasicComponents/MapComponent";
import {
  getCitiesByCountry,
  getAllCities,
  getUniqueCountries,
} from "../Services/CitiesService";
import { routeToLocation, getAddressFromCoordinates } from "../Services/MapService";

const PropertiesMapForm = React.forwardRef(  ({ onDataValidated, previousFormData }, ref) => {
    
    const [cities, setCities] = useState([]);
    const [countries, setCountries] = useState([]);
    const [selectedCountry, setSelectedCountry] = useState(
      previousFormData.selectedCountry || ""
    );
    const [selectedCity, setSelectedCity] = useState(
      previousFormData.selectedCity || ""
    );
    const [isCitiesVisible, setIsCitiesVisible] = useState(false);
    const [mapPosition, setMapPosition] = useState(
        previousFormData.mapPosition || [51.505, -0.09]
      );
    const [address, setAddress] = useState(previousFormData.address || "");
    const [formErrors, setFormErrors] = useState({});

  const handleNextButtonClick = async() => {
    const errors = {};
    if (!selectedCountry) {
      errors.selectedCountry = "Please select a country.";
    }
    if (!selectedCity && isCitiesVisible) {
      errors.selectedCity = "Please select a city.";
    }
    if (!address && isCitiesVisible) {
        errors.address = "Please click on the map to get the address.";
      } else if (address.length > 100) {
        errors.address = "Address must be no more than 100 characters.";
      }

    const firstErrorKey = Object.keys(errors)[0];
    setFormErrors(firstErrorKey ? { [firstErrorKey]: errors[firstErrorKey] } : {});

    if (Object.keys(errors).length > 0) {
      return;
    }

    setFormErrors({});

    onDataValidated({
      selectedCountry,
      selectedCity,
      mapPosition,
      address,
    });
  };

  const getFormErrors = () => {
    return formErrors;
  };

  React.useImperativeHandle(ref, () => ({
    handleNextButtonClick,
    getFormErrors
  }));


  useEffect(() => {
    const fetchData = async () => {
      try {
        const citiesData = await getAllCities();
        setCities(citiesData);

        const uniqueCountries = getUniqueCountries(citiesData);
        setCountries(uniqueCountries);
      } catch (error) {
        console.error("Error fetching cities:", error);
      }
    };

    fetchData();
  }, []);


  useEffect(() => {
    const fetchData = async () => {
      try {
        const citiesData = await getAllCities();
        setCities(citiesData);
  
        const uniqueCountries = getUniqueCountries(citiesData);
        setCountries(uniqueCountries);
  
        if (previousFormData.selectedCountry) {
          const selectedCountry = uniqueCountries.find(
            (country) => country.id === previousFormData.selectedCountry.id
          );
          setSelectedCountry(selectedCountry);
          setIsCitiesVisible(true);
        }
  
        if (previousFormData.selectedCity) {
          const selectedCity = getCitiesByCountry(citiesData, previousFormData.selectedCountry.id).find(
            (city) => city.id === previousFormData.selectedCity.id
          );
          setSelectedCity(selectedCity);
        }
      } catch (error) {
        console.error("Error fetching cities:", error);
      }
    };
  
    fetchData();
  }, [previousFormData]);

  const handleCountryChange = async (event) => {
    const selectedCountry = event.target.value;
    if (!selectedCountry) {
      setIsCitiesVisible(false);
      setSelectedCity("");
      setSelectedCountry(selectedCountry);
      return;
    }
    setSelectedCountry(selectedCountry);
    setIsCitiesVisible(true);
    setSelectedCity(""); 

    await routeToLocation(selectedCountry.name, setMapPosition);
  };

  const handleCityChange = async (event) => {
    const selectedCity = event.target.value;
    setSelectedCity(selectedCity);
    await routeToLocation(
      `${selectedCity.name}, ${selectedCountry.name}`,
      setMapPosition
    );
  };

  const handleMapClick = async (latlng) => {
    setMapPosition(latlng);
    const address = await getAddressFromCoordinates(latlng);
    setAddress(address);
  };

  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        margin: "20px",
      }}
    >
      <FormControl>
        <InputLabel id="country-label">Country</InputLabel>
        <Select
          labelId="country-label"
          id="country-select"
          value={selectedCountry}
          onChange={handleCountryChange}
          sx={{ minWidth: "300px", minHeight: "40px", margin: "10px" }}
        >
          <MenuItem value="">
            <em>Select Country</em>
          </MenuItem>
          {countries.map((country) => (
            <MenuItem key={country.id} value={country}>
              {country.name}
            </MenuItem>
          ))}
        </Select>
        {formErrors.selectedCountry && (
          <Typography color="error">{formErrors.selectedCountry}</Typography>
        )}
      </FormControl>

      <FormControl
        style={{
          visibility: isCitiesVisible ? "visible" : "hidden",
          marginTop: "10px",
        }}
      >
        <InputLabel id="city-label">City</InputLabel>
        <Select
          labelId="city-label"
          id="city-select"
          value={selectedCity}
          onChange={handleCityChange}
          sx={{ minWidth: "300px", minHeight: "40px", margin: "10px" }}
        >
          <MenuItem value="">
            <em>Select City</em>
          </MenuItem>
          {getCitiesByCountry(cities, selectedCountry.id).map((city) => (
            <MenuItem key={city.id} value={city}>
              {city.name}
            </MenuItem>
          ))}
        </Select>
        {formErrors.selectedCity && (
          <Typography color="error">{formErrors.selectedCity}</Typography>
        )}
      </FormControl>

      <TextField
        id="address-input"
        label="Address"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
        style={{
          visibility: isCitiesVisible ? "visible" : "hidden",
          minWidth: "300px",
          minHeight: "40px",
          margin: "10px",
        }}
      />

      <MapComponent
        callback={handleMapClick}
        visibility={isCitiesVisible ? "visible" : "hidden"}
        formValue={mapPosition}
        countryName={selectedCountry.name}
      />

      <Box marginTop="10px">
        {formErrors.address && (
          <Typography color="error">{formErrors.address}</Typography>
        )}
      </Box>
    </Box>
  );
});

export default PropertiesMapForm;
