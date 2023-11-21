// UserService.js
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5090';

const signIn = async (credentials) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/users/login`, credentials, {withCredentials: true});
    return response.data;
  } catch (error) {
    if (error.response) {
      console.log(error.response.data)
      window.alert(error.response.data)
    } else if (error.request) {
      window.alert('No response received for the request.');
    } else {
      window.alert('Error Message:', error.message);
    }
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
    if (error.response) {
      window.alert(error.response.data)
    } else if (error.request) {
      window.alert('No response received for the request.');
    } else {
      window.alert('Error Message:', error.message);
    }

    return null;
  }
};

const logout = async () =>{
  try{
    const response = await axios.post(`${API_BASE_URL}/users/logout`, {},{withCredentials: true});
    console.log(response.data);
  }catch(error){
    console.log(error)
  }
}

const authenticateUser = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/users/authenticate`, {withCredentials: true});

    if (response.status === 200) {
      console.log('Authentication successful:', response.data);
      return response.data; 
    } else {
      console.error('Unexpected status code:', response.status);
    }
  } catch (error) {
    if (error.response) {
      console.log(error.response)
      // window.alert(error.response)
    } else if (error.request) {
      window.alert('No response received for the request.');
    } else {
      window.alert('Error Message:', error.message);
    }
  }
};

export { signIn, register, authenticateUser, logout };
