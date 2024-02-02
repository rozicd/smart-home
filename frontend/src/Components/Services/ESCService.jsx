import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080';

export const getESCReadings = async (id, startDate, endDate) =>{
    try{
      const response = await axios.get(`${API_BASE_URL}/environmentalconditionssensor/history/${id}`, {
        params: {
          start: startDate,
          end: endDate,
        },
        withCredentials: true,
      });
      return response.data
    }catch(error){
      throw error;
    }
  }
