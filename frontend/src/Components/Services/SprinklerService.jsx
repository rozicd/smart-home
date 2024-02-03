import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080/api';

const turnOnSprinkler = async (id) => {
  try {
    const response = await axios.post(
      `${API_BASE_URL}/sprinkler/${id}/turn-on`,
      {},
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const turnOffSprinkler = async (id) => {
  try {
    const response = await axios.post(
      `${API_BASE_URL}/sprinkler/${id}/turn-off`,
      {},
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const addSprinklerSchedule = async (id, schedule) => {
  try {
    const response = await axios.post(
      `${API_BASE_URL}/sprinkler/${id}/add-schedule`,
      schedule,
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const removeSprinklerSchedule = async (id, scheduleId) => {
  try {
    const response = await axios.post(
      `${API_BASE_URL}/sprinkler/${id}/remove-schedule`,
      {scheduleId},
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getSprinklerActions = async (id, startDate, endDate) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/sprinkler/${id}/history`, {
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

  
export {
  turnOnSprinkler,
  turnOffSprinkler,
  addSprinklerSchedule,
  removeSprinklerSchedule,
};
