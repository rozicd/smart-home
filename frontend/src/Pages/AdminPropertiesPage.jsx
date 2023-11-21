import React, { useState, useEffect } from 'react';
import { getPendingProperties, acceptProperty, declineProperty, approveProperty, rejectProperty } from '../Components/Services/PropertiesService';
import AdminPropertyCard from '../Components/BasicComponents/AdminPropertyCard';
import BasicPagination from '../Components/BasicComponents/BasicPagination'; // Import your Pagination component
import './AdminPropertiesPage.css';

const AdminPropertiesPage = (user) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 4 });
  const [totalItems, setTotalItems] = useState(0);

  const fetchProperties = async () => {
    try {
      setLoading(true);
      const pendingProperties = await getPendingProperties(pagination);
      setProperties(pendingProperties.items);
      setTotalItems(pendingProperties.totalItems);
      setLoading(false);
    } catch (error) {
      setError(error.message || 'Error fetching properties');
      setLoading(false);
    }
  };

  useEffect(() => {

    fetchProperties();
  }, [user.userId,pagination.pageNumber, pagination.pageSize]);

  const handlePageChange = (newPage) => {
    setPagination({
      ...pagination,
      pageNumber: newPage,
    });
  };

  const handleApprove = async (propertyId) => {
    try {
      await approveProperty(propertyId);
      await fetchProperties();
    } catch (error) {
      setError(error.message || 'Error accepting property');
    }
  };

  const handleReject = async (propertyId) => {
    try {
      await rejectProperty(propertyId);
      await fetchProperties();
    } catch (error) {
      setError(error.message || 'Error declining property');
    }
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <div className="admin-properties-container">
      <BasicPagination 
        currentPage={pagination.pageNumber}
        pageSize={pagination.pageSize}
        totalItems={totalItems}
        onPageChange={handlePageChange}
      />
      <div className="admin-property-list-container">
        <div className="admin-property-list">
          {properties.map((property) => (
            <AdminPropertyCard key={property.id} property={property} onApprove={handleApprove} onReject={handleReject}/>
          ))}
        </div>
      </div>
    </div>
  );
}
export default AdminPropertiesPage;
