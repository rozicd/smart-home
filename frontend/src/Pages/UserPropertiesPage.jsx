// UserPropertiesPage.js
import React, { useEffect, useState } from 'react';
import { getPropertiesByUserId } from '../Components/Services/PropertiesService';
import PropertyCard from '../Components/BasicComponents/PropertyCard';
import AddButton from '../Components/BasicComponents/AddButton';
import './UserPropertiesPage.css';
import PropertyStepper from '../Components/BasicComponents/PropertyStepper';

const UserPropertiesPage = ({ userId }) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [stepperOpen, setStepperOpen] = useState(false);

  useEffect(() => {
    const fetchProperties = async () => {
      try {
        const userProperties = await getPropertiesByUserId(userId);
        setProperties(userProperties);
      } catch (error) {
        setError(error.message || 'Error fetching properties');
      } finally {
        setLoading(false);
      }
    };

    fetchProperties();
  }, [userId]);

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
