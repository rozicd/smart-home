// CarGateService.jsx

import axios from 'axios';

const API_BASE_URL = 'http://localhost:8080/cargate';

export const openGate = async (carGateId) => {
  await axios.put(`${API_BASE_URL}/${carGateId}/open`,{},{withCredentials: true,});
};

export const closeGate = async (carGateId) => {
  await axios.put(`${API_BASE_URL}/${carGateId}/close`,{},{withCredentials: true,});
};

export const changeMode = async (carGateId, newMode) => {
  await axios.put(`${API_BASE_URL}/${carGateId}/changemode`, { NewMode: newMode });
};

export const addLicensePlate = async (carGateId, licensePlate) => {
  await axios.post(`${API_BASE_URL}/${carGateId}/addlicenseplate`, { LicensePlate: licensePlate });
};

export const removeLicensePlate = async (carGateId, licensePlate) => {
  await axios.delete(`${API_BASE_URL}/${carGateId}/removelicenseplate`, {
    data: { LicensePlate: licensePlate }
  });
};

export const getCarActions = async (id, startDate, endDate) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/${id}/history`, {
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
