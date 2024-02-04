import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080/api';

export const getWashingMachineModes = async() =>{
    try{
        const response = await axios.get(`${API_BASE_URL}/washingmachine/modes`, {withCredentials:true});
        return  response.data;
    }
    catch(error){
        throw error
    }
}
export const turnWMOn = async(id) =>{
    try{
        await axios.get(`${API_BASE_URL}/washingmachine/turnOn/${id}`, {withCredentials: true})
    }catch(error){
        throw error
    }
}

export const turnWMOff = async(id) =>{
    try{
        await axios.get(`${API_BASE_URL}/washingmachine/turnOff/${id}`, {withCredentials: true})
    }catch(error){
        throw error
    }
}

export const changeWMMode = async(changeMode) =>{
    try{
        await axios.post(`${API_BASE_URL}/washingmachine/changeMode`, changeMode, {withCredentials:true})
    }catch(error){
        throw error
    }
}

export const getWMActions = async (id, startDate, endDate) =>{
    try{
      const response = await axios.get(`${API_BASE_URL}/washingmachine/history/${id}`, {
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

export const addWMScheduledMode = async (id, dateTime, mode) =>{
    try{
        const response = await axios.put(`${API_BASE_URL}/washingmachine/addScheduled/${id}`, {DateTime:dateTime, Mode:mode}, {withCredentials:true})
        return response.data
    }catch(error)
    {
        throw error
    }
}
