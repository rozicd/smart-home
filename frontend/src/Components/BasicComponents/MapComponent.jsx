// MapComponent.js
import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents, useMap } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import icon from 'leaflet/dist/images/marker-icon.png';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';
import {fetchLocationBounds } from '../Services/MapService';

let DefaultIcon = L.icon({
  iconUrl: icon,
  shadowUrl: iconShadow
});

L.Marker.prototype.options.icon = DefaultIcon;

const MapInner = ({ formValue, callback, countryName, cityName }) => {
    const map = useMap();
  
    const handleMapClick = (e) => {
      const latlng = e.latlng;
      callback(latlng);
    };
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          if (countryName) {
            const countryBounds = await fetchLocationBounds(countryName);
            map.flyToBounds(countryBounds);
          }
        } catch (error) {
          console.log(error);
        }
      };
  
      fetchData();
    }, [countryName, map]);
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          if (countryName && cityName) {
            const locationName = `${cityName}`;
            const locationBounds = await fetchLocationBounds(locationName);
            map.flyTo(locationBounds); // Fly to bounds
          }
        } catch (error) {
          console.error('Error fetching location data:', error);
        }
      };
  
      fetchData();
    }, [countryName, cityName, map]); // Dependency array
  
    return (
      <>
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        />
        <Marker position={formValue} autoPan='true'>
          <Popup>Your selected location</Popup>
        </Marker>
        <LocationFinderDummy onClick={handleMapClick} />
      </>
    );
  };
  
  const LocationFinderDummy = ({ onClick }) => {
    const map = useMapEvents({
      click(e) {
        onClick(e);
      },
    });
    return null;
  };

const MapComponent = ({ formValue, callback, visibility = 'visible',countryName,cityName }) => {
  const [position, setPosition] = useState(formValue || [51.505, -0.09]);

  const handleMapClick = (e) => {
    const latlng = e.latlng;
    setPosition(latlng);
    callback(latlng);
  };

  return (
    <div className="form-item map-container" style={{ visibility }}>
      <MapContainer center={position} zoom={13} style={{ height: '400px', width: '400px' }} onClick={handleMapClick}>
        <MapInner formValue={formValue} callback={callback} countryName={countryName} cityName={cityName}/>
      </MapContainer>
    </div>
  );
};

export default MapComponent;
