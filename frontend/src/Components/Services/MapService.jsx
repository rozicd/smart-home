import axios from 'axios';

export const routeToLocation = async (locationName, setMapPosition) => {
  try {
    const response = await axios.get(`https://nominatim.openstreetmap.org/search?format=json&q=${locationName}`);
    if (response.data && response.data.length > 0) {
      const { lat, lon } = response.data[0];
      setMapPosition([parseFloat(lat), parseFloat(lon)]);
    }
  } catch (error) {
    console.error('Error routing to location:', error);
  }
};

const fetchLocationBounds = async (locationName) => {
  try {
    const nominatimUrl = `https://nominatim.openstreetmap.org/search?format=json&q=${locationName}`;
    const response = await fetch(nominatimUrl);
    const data = await response.json();

    if (data.length > 0 && data[0].boundingbox) {
      const [south, north, west, east] = data[0].boundingbox.map(Number);
      return [[south, west], [north, east]];
    }
  } catch (error) {
    console.error('Error fetching Nominatim data:', error);
    throw error;
  }
};

export const getAddressFromCoordinates = async (latlng) => {
    try {
      const response = await axios.get(`https://nominatim.openstreetmap.org/reverse?format=json&lat=${latlng.lat}&lon=${latlng.lng}`);
      if (response.data && response.data.display_name) {
        return response.data.display_name;
      }
    } catch (error) {
      console.error('Error fetching address from coordinates:', error);
      throw error;
    }
  };

export { fetchLocationBounds };
