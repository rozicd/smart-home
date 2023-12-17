import axios from 'axios';
const API_BASE_URL = 'http://localhost:5090';

const GetPowerGraphData = async (search) => {
    try {
        console.log(search)
      const response = await axios.post(`${API_BASE_URL}/homebattery/power`, search , { withCredentials: true });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  

  export { GetPowerGraphData };
