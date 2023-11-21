import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const getPropertiesByUserId = async (userId, pagination) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/properties/user/${userId}`, {
      params: {PageNumber:pagination.pageNumber,PageSize:pagination.pageSize}, 
      withCredentials: true,
    });

    console.log(response.data)

    return response.data;
  } catch (error) {
    throw error;
  }
};

const getPendingProperties = async (pagination) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/properties/pending`, {
      params: { PageNumber: pagination.pageNumber, PageSize: pagination.pageSize },
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    throw error;
  }
};


const approveProperty = async (propertyId) => {
  try {
    const response = await axios.put(`${API_BASE_URL}/properties/${propertyId}/approve`,{}, {
      withCredentials: true,
    });

    console.log(propertyId)
    return response.data;
  } catch (error) {
    throw error;
  }
};



const rejectProperty = async (propertyId) => {
  try {
    const response = await axios.put(`${API_BASE_URL}/properties/${propertyId}/reject`,{}, {
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    throw error;
  }
};


const createProperty = async (formData) => {
  try {
    const data = new FormData();

    data.append('address', formData.address);
    data.append('cityId', formData.selectedCity.id);
    data.append('areaSquareMeters', formData.areaSquareMeters);
    data.append('numberOfFloors', formData.numberOfFloors);
    data.append('imageFile', formData.imageFile);
    data.append('propertyName',formData.propertyName)

    const response = await axios.post(`${API_BASE_URL}/properties`, data, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },withCredentials:'true'
    });
    console.log(response)

  } catch (error) {
    console.error('Error creating property:', error.response ? error.response.data : error.message);
  }
};
export { getPropertiesByUserId,createProperty,getPendingProperties,approveProperty,rejectProperty};
