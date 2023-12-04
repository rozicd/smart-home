import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import useFetch from '../Services/useFetch';
import { Box, Card, CardContent, CardMedia, Typography, Button } from '@mui/material';
import CheckIcon from '@mui/icons-material/Check';
import CloseIcon from '@mui/icons-material/Close';
import getStaticContent from '../Services/StaticService';
import { themeOptions } from '../../themeOptions';
import './AdminPropertyCard.css'
const AdminPropertyCard = ({ property, onApprove, onReject }) => {
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
    <Card className='admin-property-card' style={{ display: 'flex', width: '42vw', margin:'20px', height: '260px', boxShadow: '0 2px 10px rgba(0, 0, 0, 0.1)' }}>
      <CardMedia component="img" alt="Property" style={{ flex: 1, objectFit: 'cover', minWidth: '250px', maxWidth: '250px' }} image={imageData} />
      <Box style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
        <CardContent style={{ display: 'flex', flexDirection: 'column', flex: 1, padding: '20px', backgroundColor: '#ffffff', color: '#000000' }}>
          <Typography variant="h5" style={{ marginBottom: '10px', flex: '40%' }}>{property.propertyName}</Typography>
          <Typography variant="body2" color="textSecondary" style={{ marginBottom: '10px' }}>Address: {property.address}</Typography>
          <Box style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', flex: '100%' }}>
            <Box style={{ display: 'flex', flexDirection: 'column'}}>
              <Typography sx={{textWrap:'nowrap'}} variant="body1" color="textSecondary">City: {property.cityName}</Typography>
              <Typography sx={{textWrap:'nowrap'}} variant="body1" color="textSecondary">Country: {property.countryName}</Typography>
            </Box>
            <Box style={{ display: 'flex', flexDirection: 'column', marginLeft:'30px'}}>
              <Typography sx={{textWrap:'nowrap'}} variant="body1" color="textSecondary">Area: {property.areaSquareMeters} sqm</Typography>
              <Typography sx={{textWrap:'nowrap'}} variant="body1" color="textSecondary">Floors: {property.numberOfFloors}</Typography>
            </Box>
            <Box style={{ display: 'flex', flexDirection: 'column', textAlign: 'right' }}>
              <Button variant="contained" color="success" onClick={() => onApprove(property.id)} sx={{ fontSize:"10px" ,margin: '10px',marginLeft:'30px' }} startIcon={<CheckIcon />}>
                Approve
              </Button>
              <Button variant="contained" color="error" onClick={() => onReject(property.id)} sx={{ fontSize:"10px" ,margin: '10px',marginLeft:'30px' }} startIcon={<CloseIcon />}>
                Reject
              </Button>
            </Box>
          </Box>
        </CardContent>
      </Box>
    </Card>
  );
};

AdminPropertyCard.propTypes = {
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
  onApprove: PropTypes.func.isRequired,
  onReject: PropTypes.func.isRequired,
};

export default AdminPropertyCard;
