import React, { useState, useEffect } from 'react';
import { getPendingProperties, approveProperty, rejectProperty } from '../Components/Services/PropertiesService';
import AdminPropertyCard from '../Components/BasicComponents/AdminPropertyCard';
import BasicPagination from '../Components/BasicComponents/BasicPagination';
import DescriptionDialog from '../Components/BasicComponents/DescriptionDialog';
import InfoDialog from '../Components/BasicComponents/InfoDialog'; // Import the InfoDialog
import './AdminPropertiesPage.css';
import LoadingComponent from '../Components/BasicComponents/LoadingComponent';

const AdminPropertiesPage = (user) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 4 });
  const [totalItems, setTotalItems] = useState(0);
  const [rejectDialogOpen, setRejectDialogOpen] = useState(false);
  const [selectedPropertyId, setSelectedPropertyId] = useState(null);
  const [infoDialog, setInfoDialog] = useState({
    open: false,
    title: '',
    content: ''
  });

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
  }, [user.userId, pagination.pageNumber, pagination.pageSize]);

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

      setInfoDialog({
        open: true,
        title: 'Property Approved',
        content: 'Property has been successfully approved.',
        onConfirm: () => setInfoDialog({ ...infoDialog, open: false }),
      });
    } catch (error) {
      setError(error.message || 'Error accepting property');
    }
  };

  const handleRejectClick = (propertyId) => {
    setRejectDialogOpen(true);
    setSelectedPropertyId(propertyId);
  };

  const handleReject = async (description) => {
    try {
      setRejectDialogOpen(false);

      await rejectProperty(selectedPropertyId, description);

      setSelectedPropertyId(null);

      await fetchProperties();

      setInfoDialog({
        open: true,
        title: 'Property Rejected',
        content: `Property has been successfully rejected.`,
        onConfirm: () => setInfoDialog({ ...infoDialog, open: false }),
      });
    } catch (error) {
      setError(error.message || 'Error declining property');
    }
  };

  const handleRejectDialogClose = () => {
    setRejectDialogOpen(false);
    setSelectedPropertyId(null);
  };

  if (loading) {
    return <LoadingComponent/>
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
            <AdminPropertyCard
              key={property.id}
              property={property}
              onApprove={handleApprove}
              onReject={() => handleRejectClick(property.id)}
            />
          ))}
        </div>
      </div>
      <DescriptionDialog
        open={rejectDialogOpen}
        onClose={handleRejectDialogClose}
        onOk={handleReject}
      />
      <InfoDialog
        open={infoDialog.open}
        onClose={() => setInfoDialog({ ...infoDialog, open: false })}
        title={infoDialog.title}
        content={infoDialog.content}
      />
    </div>
  );
};

export default AdminPropertiesPage;
