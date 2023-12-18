import React, { useState, useEffect } from "react";
import { Dialog, Container } from "@mui/material";
import BasicForm from "./BasicForm";
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
import { Switch } from "@mui/material";
import { turnOn, turnOff, connect } from "../Services/SmartDeviceService";
import { useNavigate } from "react-router-dom";

const SmartDeviceCard = ({ device }) => {
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isChecked, setIsChecked] = useState(false);
  const navigate = useNavigate();

  const clickedDevice = () => {
    navigate("/devices/" + device.type.toLowerCase() + "/" + device.id);
  };
  useEffect(() => {
    setIsChecked(device.deviceStatus ? true : false);

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

  const handleChange = async (event) => {
    const isChecked = event.target.checked;

    console.log(`Switch is ${isChecked ? "checked" : "unchecked"}`);

    const data = new FormData();
    console.log(device.id);
    data.append("id", device.id);
    setIsChecked(isChecked ? true : false);
    if (isChecked) {
      await turnOn(data);
    }
    if (!isChecked) {
      await turnOff(data);
    }
    device.deviceStatus = !isChecked;
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Card
      className="property-card"
      style={{
        display: "flex",
        width: "450px",
        height: "160px",
        boxShadow: "0 2px 10px rgba(0, 0, 0, 0.1)",
      }}
    >
      <CardMedia
        onClick={() => {
          clickedDevice();
        }}
        component="img"
        alt="Property"
        style={{ objectFit: "contain",width: "260px", height: "160px", border: "1px solid #f1f2f3" }}
        image={imageData}
      />
      <Box style={{ display: "flex", flexDirection: "column", flex: 1 }}>
        <CardContent
          onClick={() => {
            clickedDevice();
          }}
          style={{
            display: "flex",
            flexDirection: "column",
            flex: 1,
            padding: "20px",
            backgroundColor: "#ffffff",
            color: "#000000",
            justifyContent:"center"

          }}
        >
          <Typography
            variant="h5"
            sx={{ marginBottom: "5px" }}
            style={{ flex: "40%" }}
          >
            {device.name}
          </Typography>
          <Typography style={{ flex: "40%" }}>
            <Chip
              label={getTypeText(device.deviceType)}
              style={{ padding :"0",borderRadius : "5px", color :"black", height:"20px", marginBottom:"5px"}}
            />
          </Typography>
          <Typography style={{ flex: "40%" }}>{device.type}</Typography>

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
      return "#2e7d32";
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
      return "HSM";
    case 1:
      return "OSM";
    case 2:
      return "BED";
    default:
      return "Unknown";
  }
};

export default SmartDeviceCard;
