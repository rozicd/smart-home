import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import useFetch from "../Services/useFetch";
import {
  Box,
  Card,
  CardContent,
  CardMedia,
  Typography,
  Chip,
} from "@mui/material";
import getStaticContent from "../Services/StaticService";
import { themeOptions } from "../../themeOptions";
import "./propertyCard.css";
const SmartDeviceCard = ({ device }) => {
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchImage = async () => {
      try {
        const propertyImage = await getStaticContent(device.imageUrl);
        setImageData(propertyImage);
      } catch (error) {
        setError(error.message || "Error fetching image");
      } finally {
        setLoading(false);
      }
    };

    fetchImage();
  }, [device]);

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Card
      className="property-card"
      onClick={() => callback(device.id)}
      style={{
        display: "flex",
        margin: "20px",
        width: "32vw",
        height: "160px",
        boxShadow: "0 2px 10px rgba(0, 0, 0, 0.1)",
      }}
    >
      <CardMedia
        component="img"
        alt="Property"
        style={{ flex: 1, objectFit: "cover", maxWidth: "260px" }}
        image={imageData}
      />
      <Box style={{ display: "flex", flexDirection: "column", flex: 1 }}>
        <CardContent
          style={{
            display: "flex",
            flexDirection: "column",
            flex: 1,
            padding: "20px",
            backgroundColor: "#ffffff",
            color: "#000000",
          }}
        >
          <Typography variant="h5" style={{ flex: "40%" }}>
            {device.name}
          </Typography>
          <Chip
            label={getTypeText(device.deviceType)}
            style={{ marginBottom: "10px", width: "100px", height: "50px" }}
            color={getTypeChipColor(device.deviceType)}
          />

          <Box
            style={{
              display: "flex",
              flexDirection: "row",
              justifyContent: "space-between",
              alignItems: "center",
              flex: "100%",
            }}
          >
            <Box style={{ display: "flex", flexDirection: "column" }}></Box>
            <Box style={{ display: "flex", flexDirection: "column" }}></Box>
          </Box>
        </CardContent>
      </Box>
      <div
        style={{
          margin: "10px",
          width: "12px",
          height: "12px",
          position: "apsolute",
          top: "10",
          left: "10",
          borderRadius: "100%",
          backgroundColor: `${device.deviceStatus ? "green" : "red"}`,
        }}
      ></div>
    </Card>
  );
};

const getTypeChipColor = (status) => {
  switch (status) {
    case 0:
      return "default";
    case 1:
      return "success";
    case 2:
      return "error";
    default:
      return "default";
  }
};

const getTypeText = (status) => {
  switch (status) {
    case 0:
      return "House smart device";
    case 1:
      return "Outdorr smart device";
    case 2:
      return "Big energy device";
    default:
      return "Unknown";
  }
};

export default SmartDeviceCard;
