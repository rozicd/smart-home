import axios from "axios";

const API_BASE_URL = "http://localhost:8080";

const getPropertiesByUserId = async (userId, pagination) => {
  try {
    const response = await axios.get(
      `${API_BASE_URL}/properties/user`,
      {
        params: {
          PageNumber: pagination.pageNumber,
          PageSize: pagination.pageSize,
        },
        withCredentials: true,
      }
    );

    console.log(response.data);

    return response.data;
  } catch (error) {
    throw error;
  }
};

const getProperties = async (pagination) => {
  axios
    .get(`${API_BASE_URL}/properties`)
    .then((response) => {
      console.log(response.data)
      return response.data
    })
    .catch((error) => {
      console.error("Error:", error);
    });
};

const getPendingProperties = async (pagination) => {
  try {
    const response = await axios.get(`${API_BASE_URL}/properties/pending`, {
      params: {
        PageNumber: pagination.pageNumber,
        PageSize: pagination.pageSize,
      },
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    throw error;
  }
};

const approveProperty = async (propertyId) => {
  try {
    const response = await axios.put(
      `${API_BASE_URL}/properties/${propertyId}/approve`,
      {},
      {
        withCredentials: true,
      }
    );

    console.log(propertyId);
    return response.data;
  } catch (error) {
    throw error;
  }
};

const rejectProperty = async (propertyId, description) => {
  try {
    const response = await axios.put(
      `${API_BASE_URL}/properties/${propertyId}/reject`,
      { description },
      {
        withCredentials: true,
      }
    );

    return response.data;
  } catch (error) {
    throw error;
  }
};

const createProperty = async (formData) => {
  try {
    const data = new FormData();

    data.append("address", formData.address);
    data.append("cityId", formData.selectedCity.id);
    data.append("areaSquareMeters", formData.areaSquareMeters);
    data.append("numberOfFloors", formData.numberOfFloors);
    data.append("imageFile", formData.imageFile);
    data.append("propertyName", formData.propertyName);

    const response = await axios.post(`${API_BASE_URL}/properties`, data, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
      withCredentials: "true",
    });
    console.log(response);
  } catch (error) {
    console.error(
      "Error creating property:",
      error.response ? error.response.data : error.message
    );
  }
};

const GetPropertyPowerGraphData = async (search) => {
  try {
    console.log(search);
    const response = await axios.post(
      `${API_BASE_URL}/properties/power`,
      search,
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const GetPropertyPowerGraphDataDate = async (search) => {
  try {
    console.log(search);
    const response = await axios.post(
      `${API_BASE_URL}/properties/power/date`,
      search,
      { withCredentials: true }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const getPropertyById = async (id) =>{
  try{
    const response = await axios.get(`${API_BASE_URL}/properties/${id}`, {
      withCredentials:true
    });
    return response.data;
  }catch(error){
    throw error
  }
}

const addUserPermission = async (id, email) =>{
  try{
    const response = await axios.put(`${API_BASE_URL}/properties/addPermision/${id}`, {Email:email},{
      withCredentials:true
    });
    console.log(response);
    return response
  }catch(error)
  {
    throw error
  }
}
const removeUserPermission = async (id, userId) =>{
  try{
    const response = await axios.put(`${API_BASE_URL}/properties/removePermision/${id}`, {Id:userId},{
      data:{userId:userId},
      withCredentials:true
    });
    return response
  }catch(error)
  {
    throw error
  }
}


export {
  GetPropertyPowerGraphDataDate,
  getPropertiesByUserId,
  createProperty,
  getPendingProperties,
  approveProperty,
  rejectProperty,
  GetPropertyPowerGraphData,
  getProperties,
  getPropertyById,
  addUserPermission,
  removeUserPermission
};
