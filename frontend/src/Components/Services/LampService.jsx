import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080/api';

const turnOn = async (lampId) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/lamp/turnOn`, { lampId }, { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};

const turnOff = async (lampId) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/lamp/turnOff`, { lampId }, { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};

const changeThreshold = async (lampId, newThreshold) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/lamp/changeThreshold`, { lampId, newThreshold }, { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};

const changeMode = async (lampId, newMode) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/lamp/changeMode`, { lampId, Mode:newMode }, { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};

const GetGraphData = async (search) => {
  try {
      console.log(search)
    const response = await axios.post(`${API_BASE_URL}/lamp/data`, search , { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};
const GetGraphDataDate = async (search) => {
  try {
      console.log(search)
    const response = await axios.post(`${API_BASE_URL}/lamp/data/date`, search , { withCredentials: true });
    return response.data;
  } catch (error) {
    throw error;
  }
};


export { turnOn, turnOff, changeThreshold, changeMode, GetGraphData,GetGraphDataDate };
