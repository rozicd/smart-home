// DeviceInfoPage.jsx

import React, { useState, useEffect } from "react";
import { useLocation, useParams } from "react-router-dom";
import { getDevice } from "../Components/Services/SmartDeviceService";
import LoadingComponent from "../Components/BasicComponents/LoadingComponent";
import getStaticContent from "../Components/Services/StaticService";
import { Grid, Box, Button } from "@mui/material";
import BasicDeviceInfoComponent from "../Components/BasicDeviceInfoComponent";
import LampCardsComponent from "../Components/LampCardsComponents";
import ECSCardsComponent from "../Components/ECSCardsComponents";
import ACCardsComponents from "../Components/ACCardsComponents";
import CarGateCardsComponent from "../Components/CarGateCardsComponent";
import PanelCardComponent from "../Components/PanelCardsComponent";
import BatteryCardsComponent from "../Components/BatteryCardsComponent";
import CarChargerComponent from "../Components/CarChargerComponent";
import SprinklerCardsComponent from "../Components/SprinklerCardsComponent";


const DeviceInfoPage = () => {
  const { deviceType, deviceId } = useParams();
  const [deviceData, setDeviceData] = useState(null);
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const location = useLocation();

  useEffect(() => {
    const fetchDeviceData = async () => {
      console.log(deviceType, deviceId)
      try {
        const deviceInfo = await getDevice(deviceType, deviceId);
        console.log("MOJ UREDJAJ:")
        console.log(deviceInfo)
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



  console.log(deviceData)
  return (
    <Grid container style={{ height: "100%",display:'flex',flexDirection:'row'  }}>

            <BasicDeviceInfoComponent imageData={imageData} deviceData={deviceData} />

      <Grid
        container
        item
        xs={12}
        sm={6}
        paddingRight={"50px"}
        paddingTop={"50px"}
        >
        <Box
          style={{
            overflow: "scroll",
            height :"85vh"
          }}
        >
          {deviceType === "lamp" && (
            <LampCardsComponent deviceInfo={deviceData} />
          )}
          {deviceType === "cargate" && (
            <CarGateCardsComponent
              deviceData={deviceData}
            ></CarGateCardsComponent>
          )}
          {deviceType === "solarpanelsystem" && (
            <PanelCardComponent deviceInfo={deviceData} />
          )}
          {deviceType === "homebattery" && (
            <BatteryCardsComponent deviceInfo={deviceData} />
          )}
          {deviceType === "environmentalconditionssensor" && (
            <ECSCardsComponent
              deviceInfo={deviceData}
            />
          )}
          {deviceType === "airconditioner" &&(
            <ACCardsComponents
              deviceInfo={deviceData}
            />
          )

          }
          {deviceType === "carcharger" &&(
            <CarChargerComponent
              deviceInfo={deviceData}
              />
          )}
          {deviceType === "sprinkler" &&(
            <SprinklerCardsComponent
              deviceData={deviceData}
            />
          )

          }
          
          {/* Add other device type checks and load corresponding components */}
        </Box>
      </Grid>
    </Grid>
  );
};

export default DeviceInfoPage;
