import React, { useEffect, useState } from 'react';
import { getPropertiesByUserId } from '../Components/Services/PropertiesService';
import PropertyCard from '../Components/BasicComponents/PropertyCard';
import AddButton from '../Components/BasicComponents/AddButton';
import BasicPagination from '../Components/BasicComponents/BasicPagination'; // Import your Pagination component
import './UserPropertiesPage.css';
import PropertyStepper from '../Components/BasicComponents/PropertyStepper';

const UserPropertiesPage = ({ user }) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 4 });
  const [totalItems, setTotalItems] = useState(0);
  const [stepperOpen, setStepperOpen] = useState(false);

  const ClickedProperty=(id) =>
  {
    console.log(id)
  }
  
  const fetchProperties = async () => {
    try {
      setLoading(true);
      const userProperties = await getPropertiesByUserId(user.userId, pagination);
      console.log(pagination)
      console.log(userProperties)
      setProperties(userProperties.items);
      setTotalItems(userProperties.totalItems);
      setLoading(false);
    } catch (error) {
      setError(error.message || 'Error fetching properties');
      setLoading(false);
    }
  };

  useEffect(() => {

    fetchProperties();
  }, [user.userId, pagination.pageNumber, pagination.pageSize]);

  const handlePageChange = (newPage) => {
    setPagination({
      ...pagination,
      pageNumber: newPage,
    });
  };

  const handleAddProperty = () => {
    setStepperOpen(true);
  };

  const handleCloseStepper = (creation) => {
    if (creation == 1 && totalItems != pagination.pageSize){
      fetchProperties()
    }
    setStepperOpen(false);
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <div className="user-properties-container">
      <BasicPagination 
        currentPage={pagination.pageNumber}
        pageSize={pagination.pageSize}
        totalItems={totalItems}
        onPageChange={handlePageChange}
      />
      <div className="property-list-container">
        <div className="property-list">
          {properties.map((property) => (
            <PropertyCard key={property.id} property={property} callback={ClickedProperty} />
          ))}
        </div>
      </div>
      <AddButton className="add-property-button" onClick={handleAddProperty} />
      <PropertyStepper open={stepperOpen} onClose={handleCloseStepper}/>
    </div>
  );
};

export default UserPropertiesPage;
