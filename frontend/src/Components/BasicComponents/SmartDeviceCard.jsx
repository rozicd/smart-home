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

const template = [
  { item: "BasicInput", itemValue: "connection", label: "Connection" },
];

const SmartDeviceCard = ({ device }) => {
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isChecked, setIsChecked] = useState(false);
  const [openModal, setOpenModal] = useState(false);

  const Connect = async (connection) => {
    const data = new FormData()
    data.append("id",device.id)
    data.append("address",connection.connection)
    await connect(data);
    setOpenModal(false)
    device.connection = connection.connection
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
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Card
      className="property-card"
      style={{
        display: "flex",
        margin: "20px",
        width: "450px",
        height: "160px",
        boxShadow: "0 2px 10px rgba(0, 0, 0, 0.1)",
      }}
    >
      <CardMedia
        onClick={() => {
          setOpenModal(true);
        }}
        component="img"
        alt="Property"
        style={{ flex: 1, objectFit: "cover", maxWidth: "260px" }}
        image={imageData}
      />
      <Box style={{ display: "flex", flexDirection: "column", flex: 1 }}>
        <CardContent
          onClick={() => {
            setOpenModal(true);
          }}
          style={{
            display: "flex",
            flexDirection: "column",
            flex: 1,
            padding: "20px",
            backgroundColor: "#ffffff",
            color: "#000000",
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
            {getTypeText(device.deviceType)}
          </Typography>
          <Typography style={{ flex: "40%" }}>{device.connection}</Typography>

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
      <Switch
        checked={isChecked}
        onChange={handleChange}
        sx={{
          position: "apsolute",
          top: "10",
          left: "10",
        }}
      />

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
      <Dialog open={openModal} onClose={() => setOpenModal(false)}>
        <Container
          sx={{
            padding: "10px",
            backgroundColor: "snow",
            display: "flex",
            alignItems: "center",
            flexDirection: "column",
          }}
        >
          <BasicForm template={template} callback={Connect}></BasicForm>
        </Container>
      </Dialog>
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