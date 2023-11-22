import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

export const GetSmartDevicesByProperty = async (pagination) => {
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
  export const turnOn = async (id) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/smart-device/on`,id, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  export const turnOff = async (id) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/smart-device/off`,id, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  export const connect = async (connection) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/smart-device/connect`,connection, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };

  export const AddSmartDevice = async (device,url) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/${url}`,device, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
        
        
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };