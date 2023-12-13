import React, { useState } from 'react';
import { Box, Button, Card, CardContent, CardMedia, Container, Dialog, Grid, Typography } from '@mui/material';
import BasicForm from './BasicComponents/BasicForm';
import { connect } from './Services/SmartDeviceService';

const template = [
    { item: "BasicInput", itemValue: "connection", label: "Connection" },
  ];

const BasicDeviceInfoComponent = ({ imageData, deviceData }) => {

  const [openModal, setOpenModal] = useState(false);

    const Connect = async (connection) => {
        const data = new FormData()
        data.append("id",deviceData.id)
        data.append("address",connection.connection)
        await connect(data);
        setOpenModal(false)
        deviceData.connection = connection.connection
      };

  return (
    <Grid container item xs={12} sm={6} direction="column"  height={"100%"} display={"flex"} justifyContent={"space-evenly"} alignItems={"center"}>
      <Card item style={{ aspectRatio: "1/1" }}>
        <CardMedia
          component="img"
          alt="Device Image"
          width={"100%"}
          height={"100%"}
          image={imageData}
        />
      </Card>

      <Card item style={{ height: "30%", width: "50%" }}>
        <CardContent style={{display:"flex",flexDirection:"row"}}>
            <Box style={{display:"flex",flexDirection:"column",justifyContent:"center",alignItems:"center",flex:"1 0 60%"}} >
                <Typography variant="h5" marginBottom={"20px"}  component="div" marginLeft= {"40%"}>
                {deviceData.name}
                </Typography>
                <Typography variant="body1" width={"100%"} marginBottom={"8px"} color="text.secondary">
                Device Type: {deviceData.type}
                </Typography>
                <Typography variant="body1" width={"100%"} marginBottom={"8px"} color="text.secondary">
                Power Supply: {deviceData.powerSupply}
                </Typography>
                <Typography variant="body1" width={"100%"} marginBottom={"8px"} color="text.secondary">
                Energy Spending: {deviceData.energySpending}
                </Typography>
                <Typography variant="body1" width={"100%"} marginBottom={"8px"} color="text.secondary">
                Device Type: {deviceData.deviceType}
                </Typography>
                <Typography variant="body1" width={"100%"} marginBottom={"8px"} color="text.secondary">
                Device Status: {deviceData.deviceStatus}
                </Typography>
             </Box>
             <div style={{display:"flex",flexDirection:"column",alignItems:"flex-end",justifyContent:"space-between" ,flex:"1 0 40%"}}>
                <div
                    style={{
                    margin: "10px",
                    width: "12px",
                    height: "12px",
                    position: "relative",
                    top: "10",
                    right: "10",
                    borderRadius: "100%",
                    backgroundColor: `${deviceData.deviceStatus ? "green" : "red"}`,
                    }}
                ></div>
            </div>
            </CardContent>
        </Card>
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
    </Grid>
  );
};

export default BasicDeviceInfoComponent;