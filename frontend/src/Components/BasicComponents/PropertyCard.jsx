import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import useFetch from '../Services/useFetch';
import { Box, Card, CardContent, CardMedia, Typography } from '@mui/material';
import getStaticContent from '../Services/StaticService';

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
    color: '#ffffff',
    textTransform: 'uppercase',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
  };

  return (
    <Card style={{ display: 'flex', flexDirection: 'row', alignItems:'stretch', width: '800px', height: '260px', margin: '20px', boxShadow: '0 2px 10px rgba(0, 0, 0, 0.1)' }}>
      <CardMedia component="img"  alt="Property"  style={{ flex: 1, objectFit: 'cover', minWidth: '260px', maxWidth: '260px' }} image={imageData} />
      <Box style={{ display: 'flex', flexDirection: 'column', width: "100%" }}>
        <Typography variant="h5" style={{ marginBottom: '10px', marginLeft: '20px', marginTop: '10px' }}>Address: {property.address}</Typography>
        <CardContent style={{ flex: 1, marginBottom: '40px', alignItems: 'center', display: 'flex', flexDirection: 'row', padding: '20px', backgroundColor: '#ffffff', color: '#692a4f' }}>
          <Box display='flex' height='50%' flexDirection='column' justifyContent='space-evenly' style={{ flex: 1 }}>
            <Typography variant="body1" color="textSecondary">City: {property.cityName}</Typography>
            <Typography variant="body1" color="textSecondary">Country: {property.countryName}</Typography>
          </Box>
          <Box display='flex' height='50%' flexDirection='column' justifyContent='space-evenly' style={{ flex: 1 }}>
            <Typography variant="body1" color="textSecondary">Area: {property.areaSquareMeters} sqm</Typography>
            <Typography variant="body1" color="textSecondary">Floors: {property.numberOfFloors}</Typography>
          </Box>
          <Box display='flex'  height='50%'flexDirection='column' justifyContent='space-evenly' style={{ flex: 1, textAlign: 'right', width: "100%" }}>
            <Box style={statusStyle}>
              <Typography fontSize="larger" variant="body1">{getStatusText(property.status)}</Typography>
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
      return '#ffd700'; // Pending
    case 1:
      return '#00ff00'; // Accepted
    case 2:
      return '#ff0000'; // Rejected
    default:
      return '#ffffff'; // Default to white
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
