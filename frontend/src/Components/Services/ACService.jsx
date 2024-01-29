import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

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

  const addScheduledMode = async (id, createACSCheduledModeRequestDTO) => {
    try{
      const response = await axios.put(`${API_BASE_URL}/airconditioner/addScheduled/${id}`,  createACSCheduledModeRequestDTO , { withCredentials: true });
      return response
    }catch(error) {
      throw error;
    }
  }

  const getACActions = async (id, startDate, endDate) =>{
    try{
      const response = await axios.get(`${API_BASE_URL}/airconditioner/${id}/history`, {
        params: {
          startDate: startDate,
          endDate: endDate,
        },
        withCredentials: true,
      });
      return response.data
    }catch(error){
      throw error;
    }
  }

  export { turnOn, turnOff, changeMode, addScheduledMode, getACActions };