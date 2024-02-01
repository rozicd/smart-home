// CityService.js
import axios from 'axios';
const API_BASE_URL = 'http://localhost:8080';

const getAllCities = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/cities`);
    return response.data;
  } catch (error) {
    throw new Error('Error fetching cities');
  }
}

const getUniqueCountries = (cities) => {
  const uniqueCountries = Array.from(new Set(cities.map(city => city.countryName)));
  return uniqueCountries.map(countryName => ({
    id: cities.find(city => city.countryName === countryName).countryId,
    name: countryName
  }));
}

const getCitiesByCountry = (cities, countryId) => {
  return cities.filter(city => city.countryId === countryId);
};

export  {getAllCities,getUniqueCountries,getCitiesByCountry};
