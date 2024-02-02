import React, { useState, useEffect } from "react";
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
import BasicForm from "./BasicComponents/BasicForm";
import { connect } from "./Services/SmartDeviceService";
import DeviceStatusHistory from "./BasicComponents/DeviceStatusHistory";
import ShareIcon from '@mui/icons-material/Share';
import { getDevicePermission } from "../Components/Services/SmartDeviceService";
import DevicePermisionDialog from "./Dialogs/DevicePermisionDialog";

const template = [
  { item: "BasicInput", itemValue: "connection", label: "Connection" },
];

const BasicDeviceInfoComponent = ({ imageData, deviceData }) => {
  const [openModal, setOpenModal] = useState(false);
  const [permission, setPermission] = useState({});
  const [open, setOpen] = useState(false);

  const Connect = async (connection) => {
    const data = new FormData();
    data.append("id", deviceData.id);
    data.append("address", connection.connection);
    await connect(data);
    setOpenModal(false);
    deviceData.connection = connection.connection;
  };

  useEffect(() => {
    const fetchPermission = async() =>{
      const response = await getDevicePermission(deviceData.id);
      setPermission(response.data);  
    };
    fetchPermission();
  }, [deviceData.id]);

  const updateUsers = (users) =>{
    permission.sharedUsers = users;
    setPermission(permission);
  }
  const handleShare = () =>{
    setOpen(true);
  }

  const handleCloseDialog = () => {
    setOpen(false);
  };
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
      wrap="nowrap"
      alignItems={"center"}
      maxWidth={"100%"}
      paddingLeft={"50px"}
      paddingTop={"50px"}
    >
            
      <Box
          style={{
            overflow: "scroll",
            height: "85vh"
          }}
        >
          <Grid container spacing={2} sx={{display:"flex",flexDirection:"column",alignItems:"center" }}>
        <Card item style={{ width: "320px", height: "320px"}}>
          <CardMedia
            component="img"
            alt="Device Image"
            style={{ objectFit: "fill",width: "320px", height: "320px", border: "1px solid #f1f2f3" }}
            image={imageData}
          />
        </Card>
        {permission.owner && <Button onClick={handleShare}><ShareIcon></ShareIcon></Button>}

        <Card item style={{ height: "30%", width: "50%", marginTop:"50px" }}>
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
                {deviceData.name}
              </Typography>
              <Typography
                variant="body1"
                width={"100%"}
                marginBottom={"8px"}
                color="text.secondary"
              >
                Device Type: {deviceData.type}
              </Typography>
              <Typography
                variant="body1"
                width={"100%"}
                marginBottom={"8px"}
                color="text.secondary"
              >
                Power Supply: {deviceData.powerSupply}
              </Typography>
              {deviceData.energySpending != null && (
                <Typography
                  variant="body1"
                  width={"100%"}
                  marginBottom={"8px"}
                  color="text.secondary"
                >
                  Energy Spending: {deviceData.energySpending}
                </Typography>
              )}
              <Typography
                variant="body1"
                width={"100%"}
                marginBottom={"8px"}
                color="text.secondary"
              >
                Device Type: {deviceData.deviceType}
              </Typography>
              <Typography
                variant="body1"
                width={"100%"}
                marginBottom={"8px"}
                color="text.secondary"
              >
                Device Status: {deviceData.deviceStatus}
              </Typography>
            </Box>
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                alignItems: "flex-end",
                justifyContent: "space-between",
                flex: "1 0 40%",
              }}
            >
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
          <DeviceStatusHistory style={{height:'30%',marginTop: "60px",}} deviceInfo={deviceData} />
          </Grid>
        </Box>
        <DevicePermisionDialog open={open} onClose={handleCloseDialog} deviceId={deviceData.id} users={permission.sharedUsers} updateUsers={updateUsers}></DevicePermisionDialog>
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
