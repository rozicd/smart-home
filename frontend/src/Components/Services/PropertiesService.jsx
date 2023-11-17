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


export { getPropertiesByUserId };
