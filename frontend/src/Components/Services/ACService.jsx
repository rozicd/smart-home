import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const turnOn = async (lampId) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/turnOn`, { lampId }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  
  const turnOff = async (lampId) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/turnOff`, { lampId }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };

  const changeMode = async (changeACModeDTO) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/changeMode`, { changeACModeDTO }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };


  export { turnOn, turnOff, changeMode };