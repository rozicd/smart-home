import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const GetSmartDevicesByProperty = async (pagination) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/smart-device/property/`, {
        params: pagination, 
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };