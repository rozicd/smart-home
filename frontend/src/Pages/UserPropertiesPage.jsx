import React, { useEffect, useState } from 'react';
import { getPropertiesByUserId } from '../Components/Services/PropertiesService';
import PropertyCard from '../Components/BasicComponents/PropertyCard';
import AddButton from '../Components/BasicComponents/AddButton';
import BasicPagination from '../Components/BasicComponents/BasicPagination';
import InfoDialog from '../Components/BasicComponents/InfoDialog';
import PropertyStepper from '../Components/BasicComponents/PropertyStepper';
import { useNavigate } from 'react-router-dom';
import './UserPropertiesPage.css';
import LoadingComponent from '../Components/BasicComponents/LoadingComponent';

const UserPropertiesPage = ({ user }) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 4 });
  const [totalItems, setTotalItems] = useState(0);
  const [stepperOpen, setStepperOpen] = useState(false);
  const navigate = useNavigate()

  const ClickedProperty=(id) =>
  {
    navigate(id)
  }
  const NotAccepted=(id) =>
  {
    console.log(id+" Not Accepted")
  }
  
  const [infoDialog, setInfoDialog] = useState({
    open: false,
    title: '',
    content: ''
  });



  const fetchProperties = async () => {
    try {
      setLoading(true);
      const userProperties = await getPropertiesByUserId(user.userId, pagination);
      console.log(pagination);
      console.log(userProperties);
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
    if (creation === 1 && totalItems !== pagination.pageSize) {
      fetchProperties();
      
      setInfoDialog({
        open: true,
        title: 'Property Created',
        content: 'The property has been successfully created.',
      });
    }
    setStepperOpen(false);
  };

  if (loading) {
    return <LoadingComponent/>
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
            <PropertyCard key={property.id} property={property} callback={property.status == 1?ClickedProperty:NotAccepted} />
          ))}
        </div>
      </div>
      <AddButton className="add-property-button" onClick={handleAddProperty} />
      <PropertyStepper open={stepperOpen} onClose={handleCloseStepper} />
      <InfoDialog
        open={infoDialog.open}
        onClose={() => setInfoDialog({ ...infoDialog, open: false })}
        title={infoDialog.title}
        content={infoDialog.content}
      />
    </div>
  );
};

export default UserPropertiesPage;
