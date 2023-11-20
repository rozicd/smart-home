// UserService.js
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const signIn = async (credentials) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/users/login`, credentials);
    return response.data;
  } catch (error) {
    throw error;
  }
};

const register = async (userDTO) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/users`, userDTO, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    });

    console.log('Response:', response.data);
    return response.data;
  } catch (error) {
    if (error.response && error.response.status == 400) {
      window.alert(error.response.data)
    } else if (error.request) {
      window.alert('No response received for the request.');
    } else {
      window.alert('Error Message:', error.message);
    }

    return null;
  }
};


export { signIn, register };