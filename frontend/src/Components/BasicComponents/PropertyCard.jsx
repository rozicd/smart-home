import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import useFetch from '../Services/useFetch';
import { Box, Card, CardContent, CardMedia, Typography, lighten } from '@mui/material';
import getStaticContent from '../Services/StaticService';
import { themeOptions } from '../../themeOptions';

const PropertyCard = ({ property }) => {
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

  const statusStyle = {
    textAlign: 'center',
    padding: '5px',
    borderRadius: '5px',
    height: '100%',
    backgroundColor: getStatusColor(property.status),
    color: getStatusColor(property.status) === '#ffffff' ? '#000000' : '#ffffff',
    textTransform: 'uppercase',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
  };

  return (
    <Card style={{ display: 'flex', width: '800px', height: '260px', margin: '20px', boxShadow: '0 2px 10px rgba(0, 0, 0, 0.1)' }}>
      <CardMedia component="img" alt="Property" style={{ flex: 1, objectFit: 'cover', minWidth: '260px', maxWidth: '260px' }} image={imageData} />
      <Box style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
        <CardContent style={{ display: 'flex', flexDirection: 'column', flex: 1, padding: '20px', backgroundColor: '#ffffff', color: '#000000' }}>
          <Typography variant="h5" style={{ marginBottom: '10px', flex: '40%' }}>Address: {property.address}</Typography>
          <Box style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-evenly', alignItems: 'center', flex: '100%' }}>
            <Box style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
              <Typography variant="body1" color="textSecondary">City: {property.cityName}</Typography>
              <Typography variant="body1" color="textSecondary">Country: {property.countryName}</Typography>
            </Box>
            <Box style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
              <Typography variant="body1" color="textSecondary">Area: {property.areaSquareMeters} sqm</Typography>
              <Typography variant="body1" color="textSecondary">Floors: {property.numberOfFloors}</Typography>
            </Box>
            <Box style={{ display: 'flex', flexDirection: 'column', flex: 1, textAlign: 'right' }}>
              <Box style={statusStyle}>
                <Typography fontSize="larger" variant="body1">{getStatusText(property.status)}</Typography>
              </Box>
            </Box>
          </Box>
        </CardContent>
      </Box>
    </Card>
  );
};

PropertyCard.propTypes = {
  property: PropTypes.shape({
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

const getStatusColor = (status) => {
  switch (status) {
    case 0:
      return lighten(themeOptions.palette.primary.main, 0.6); 
    case 1:
      return themeOptions.palette.primary.main; 
    case 2:
      return themeOptions.palette.negative.main; 
    default:
      return '#ffffff'; 
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
