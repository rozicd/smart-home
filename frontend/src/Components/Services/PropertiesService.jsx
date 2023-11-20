import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const getPropertiesByUserId = async (userId) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/properties/user/${userId}`,{withCredentials:true});
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

    const response = await axios.post(`${API_BASE_URL}/properties`, data, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },withCredentials:'true'
    });

  } catch (error) {
    console.error('Error creating property:', error.response ? error.response.data : error.message);
  }
};
export { getPropertiesByUserId,createProperty };
