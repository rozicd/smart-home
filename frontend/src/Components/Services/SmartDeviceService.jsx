import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080';

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

  export const getDevice = async (deviceType,deviceId) => {
    if(deviceType == null){
      deviceType = "smart-device"
    }
    try {
      const response = await axios.get(`${API_BASE_URL}/${deviceType.toLowerCase()}/${deviceId}`,{withCredentials: true}  );
      const data = await response.data;
      return data;
    } catch (error) {
      throw new Error("Error fetching device information");
    }
  };

  export const getESCData = async (deviceType, dataParams) => {
    if(deviceType == null){
      deviceType = "smart-device"
    }
    try {
      const response = await axios.get(`${API_BASE_URL}/${deviceType.toLowerCase()}/data?Name=${dataParams.Name}&start=${dataParams.start}&end=${dataParams.end}`,{withCredentials: true});
      const data = await response.data;
      return data;
    } catch (error) {
      throw new Error("Error fetching device information");
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

  export const GetStatusGraphData = async (search) => {
    try {
        console.log(search)
      const response = await axios.post(`${API_BASE_URL}/smart-device/data`, search , { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  export const GetStatusGraphDataDate = async (search) => {
    try {
        console.log(search)
      const response = await axios.post(`${API_BASE_URL}/smart-device/data/date`, search , { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };

  export const addDeviceUserPermission = async (id, email) =>{
    try{
      const response = await axios.put(`${API_BASE_URL}/smart-device/addPermission/${id}`, {Email:email}, {withCredentials:true});
      return response
    }catch(error){
      throw error;
    }
  };
  export const removeDeviceUserPermission = async (id, email) =>{
    try{
      const response = await axios.put(`${API_BASE_URL}/smart-device/removePermission/${id}`, {Email:email}, {withCredentials:true});
      return response
    }catch(error){
      throw error;
    }
  };

  export const getDevicePermission = async (id) =>{
    try{
      const response = await axios.get(`${API_BASE_URL}/smart-device/getPermissions/${id}`, {withCredentials:true})
      return response;
    }catch(error){
      throw error
    }
  }