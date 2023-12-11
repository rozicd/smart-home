import React, { useState, useEffect } from "react";
import { useLocation, useParams } from "react-router-dom";
import { getDevice } from "../Components/Services/SmartDeviceService";
import LoadingComponent from "../Components/BasicComponents/LoadingComponent";
import getStaticContent from "../Components/Services/StaticService";
import { Card, CardMedia, CardContent, Typography, Grid } from "@mui/material";
import BasicDeviceInfoComponent from "../Components/BasicDeviceInfoComponent";

const template = [
    { item: "BasicInput", itemValue: "connection", label: "Connection" },
  ];

  
const DeviceInfoPage = () => {
  const { deviceType, deviceId } = useParams();
  const [deviceData, setDeviceData] = useState(null);
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const location = useLocation();

  useEffect(() => {
    const fetchDeviceData = async () => {
      try {
        const deviceInfo = await getDevice(deviceType, deviceId);
        setDeviceData(deviceInfo);
        const propertyImage = await getStaticContent(deviceInfo.imageUrl);
        setImageData(propertyImage);
      } catch (error) {
        console.error("Error fetching device information:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchDeviceData();
  }, [deviceType, deviceId]);

  if (loading) {
    return <LoadingComponent />;
  }

  return (
    <Grid container style={{ height: "100%" }}>
    <BasicDeviceInfoComponent imageData={imageData} deviceData={deviceData} />

    <Grid item xs={12} sm={6}></Grid>
  </Grid>
  );
};

export default DeviceInfoPage;
