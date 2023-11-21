import React, { useEffect, useState } from 'react';
import { getPropertiesByUserId } from '../Components/Services/PropertiesService';
import PropertyCard from '../Components/BasicComponents/PropertyCard';
import AddButton from '../Components/BasicComponents/AddButton';
import BasicPagination from '../Components/BasicComponents/BasicPagination'; // Import your Pagination component
import './UserPropertiesPage.css';
import PropertyStepper from '../Components/BasicComponents/PropertyStepper';

const UserPropertiesPage = ({ userId }) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 5 });
  const [totalItems, setTotalItems] = useState(0);
  const [stepperOpen, setStepperOpen] = useState(false);

  useEffect(() => {
    const fetchProperties = async () => {
      try {
        setLoading(true);
        const userProperties = await getPropertiesByUserId(userId, pagination);
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

    fetchProperties();
  }, [userId, pagination.pageNumber, pagination.pageSize]);

  const handlePageChange = (newPage) => {
    setPagination({
      ...pagination,
      pageNumber: newPage,
    });
  };

  const handleAddProperty = () => {
    setStepperOpen(true);
  };

  const handleCloseStepper = () => {
    setStepperOpen(false);
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <div className="user-properties-container">
      <h2 className="page-title">Your Properties</h2>
      <BasicPagination
        currentPage={pagination.pageNumber}
        pageSize={pagination.pageSize}
        totalItems={totalItems}
        onPageChange={handlePageChange}
      />
      <div className="property-list">
        {properties.map((property) => (
          <PropertyCard key={property.id} property={property} />
        ))}
      </div>
      <AddButton className="add-property-button" onClick={handleAddProperty} />
      <PropertyStepper open={stepperOpen} onClose={handleCloseStepper} />
    </div>
  );
};

export default UserPropertiesPage;
