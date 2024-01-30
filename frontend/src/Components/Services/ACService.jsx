import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080';

const turnOn = async (acId) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/turnOn`, { acId: acId  }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  
  const turnOff = async (acId) => {
    console.log(acId)
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/turnOff`, { acId: acId }, { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };

  const changeMode = async (changeACModeDTO) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/airconditioner/changeMode`,  changeACModeDTO , { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };


  export { turnOn, turnOff, changeMode };