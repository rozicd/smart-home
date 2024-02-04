import axios from 'axios';
const API_BASE_URL = 'http://localhost:8080/api';

const turnOn = async (lampId) => {
    try {

      const response = await axios.post(`${API_BASE_URL}/solarpanelsystem/turnOn`, { lampId }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  
  const turnOff = async (lampId) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/solarpanelsystem/turnOff`, { lampId }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  const getPanelActions = async (id, startDate, endDate) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/solarpanelsystem/${id}/history`, {
        params: {
          startDate: startDate, 
          endDate: endDate,     
        },
        withCredentials: true,
      });
  
      return response.data;
    } catch (error) {
      throw error;
    }
  };

  export { turnOn, turnOff,getPanelActions };
