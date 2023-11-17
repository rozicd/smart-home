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


export { signIn };
