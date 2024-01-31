import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import useFetch from '../Services/useFetch';
import { Box, Card, CardContent, CardMedia, Typography, Chip, Button } from '@mui/material';
import getStaticContent from '../Services/StaticService';
import { themeOptions } from '../../themeOptions';
import "./propertyCard.css"
import PermisionDialog from '../Dialogs/PermisionDialog';

const PropertyCard = ({ property, callback }) => {
  const [imageData, setImageData] = useState('');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchImage = async () => {
      try {
        const propertyImage = await getStaticContent(property.imageUrl);
        setImageData(propertyImage);
      } catch (error) {
        setError(error.message || 'Error fetching image');
      } finally {
        setLoading(false);
      }
    };

    fetchImage();
  }, [property]);

  if (loading) {
    return <p>Loading...</p>;
  }


  return (
    <Card className="property-card" onClick={() => callback(property.id)} style={{ display: 'flex',margin:'20px', width: '40vw', height: '260px', boxShadow: '0 2px 10px rgba(0, 0, 0, 0.1)' }}>
      <CardMedia component="img" alt="Property" style={{ flex: 1, objectFit: 'cover', maxWidth: '260px' }} image={imageData} />
      <Box style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
        <CardContent style={{ display: 'flex', flexDirection: 'column', flex: 1, padding: '20px', backgroundColor: '#ffffff', color: '#000000' }}>
          <Typography variant="h5" style={{ flex: '40%' }}>{property.propertyName}</Typography>
          <Chip label={getStatusText(property.status)} style={{  marginBottom: '10px',width: '100px', height: '50px' }} color={getStatusChipColor(property.status)} />
          <Typography variant="body2" color="textSecondary" style={{marginTop: '10px', }}>Address: {property.address}</Typography>
          <Box style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', flex: '100%' }}>
            <Box style={{ display: 'flex', flexDirection: 'column'}}>
              <Typography variant="body1" color="textSecondary">City: {property.cityName}</Typography>
              <Typography variant="body1" color="textSecondary">Country: {property.countryName}</Typography>
            </Box>
            <Box style={{ display: 'flex', flexDirection: 'column'}}>
              <Typography variant="body1" color="textSecondary">Area: {property.areaSquareMeters} sqm</Typography>
              <Typography variant="body1" color="textSecondary">Floors: {property.numberOfFloors}</Typography>
            </Box>
          </Box>
          
        </CardContent>
      </Box>
    </Card>
  );
};

PropertyCard.propTypes = {
  property: PropTypes.shape({
    propertyName: PropTypes.string,
    address: PropTypes.string,
    cityName: PropTypes.string,
    countryName: PropTypes.string,
    areaSquareMeters: PropTypes.number,
    numberOfFloors: PropTypes.number,
    imageUrl: PropTypes.string,
    isActive: PropTypes.bool,
    status: PropTypes.number,
  }).isRequired,
};

export default PropertyCard;

const getStatusChipColor = (status) => {
  switch (status) {
    case 0:
      return 'default';
    case 1:
      return 'success';
    case 2:
      return 'error';
    default:
      return 'default';
  }
};

const getStatusText = (status) => {
  switch (status) {
    case 0:
      return 'Pending';
    case 1:
      return 'Accepted';
    case 2:
      return 'Rejected';
    default:
      return 'Unknown';
  }
};
