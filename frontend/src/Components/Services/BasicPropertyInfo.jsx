import React, { useState } from "react";
import {
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  Container,
  Dialog,
  Grid,
  Typography,
} from "@mui/material";

const template = [
  { item: "BasicInput", itemValue: "connection", label: "Connection" },
];

const BasicPropertyComponent = ({ imageData, propertyData }) => {
  

  return (
    <Grid
      container
      item
      xs={12}
      sm={6}
      direction="column"
      height={"100%"}
      display={"flex"}
      justifyContent={"space-evenly"}
      alignItems={"center"}
    >
      <Card item style={{ aspectRatio: "1/1" }}>
        <CardMedia
          component="img"
          alt="Device Image"
          style={{ objectFit: "contain",width: "320px", height: "320px", border: "1px solid #f1f2f3" }}
          image={imageData}
        />
      </Card>

      <Card item style={{ height: "30%", width: "50%" }}>
        <CardContent style={{ display: "flex", flexDirection: "row" }}>
          <Box
            style={{
              display: "flex",
              flexDirection: "column",
              justifyContent: "center",
              alignItems: "center",
              flex: "1 0 60%",
            }}
          >
            <Typography
              variant="h5"
              marginBottom={"20px"}
              component="div"
              marginLeft={"40%"}
            >
              {propertyData.name}
            </Typography>
            <Typography
              variant="body1"
              width={"100%"}
              marginBottom={"8px"}
              color="text.secondary"
            >
              Country: {propertyData.countryName}
            </Typography>
            <Typography
              variant="body1"
              width={"100%"}
              marginBottom={"8px"}
              color="text.secondary"
            >
              City: {propertyData.cityName}
            </Typography>
            
            <Typography
              variant="body1"
              width={"100%"}
              marginBottom={"8px"}
              color="text.secondary"
            >
              Address: {propertyData.address}
            </Typography>
            <Typography
              variant="body1"
              width={"100%"}
              marginBottom={"8px"}
              color="text.secondary"
            >
              Floors: {propertyData.numberOfFloors}
            </Typography>
          </Box>
          
        </CardContent>
      </Card>
      
    </Grid>
  );
};

export default BasicPropertyComponent;
