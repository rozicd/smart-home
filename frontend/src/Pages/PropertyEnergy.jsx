// DeviceInfoPage.jsx

import React, { useState, useEffect } from "react";
import { useLocation, useParams } from "react-router-dom";
import { getDevice } from "../Components/Services/SmartDeviceService";
import LoadingComponent from "../Components/BasicComponents/LoadingComponent";
import getStaticContent from "../Components/Services/StaticService";
import { Grid, Box } from "@mui/material";
import BasicDeviceInfoComponent from "../Components/BasicDeviceInfoComponent";
import LampCardsComponent from "../Components/LampCardsComponents";
import ECSCardsComponent from "../Components/ECSCardsComponents";
import ACCardsComponents from "../Components/ACCardsComponents";
import CarGateCardsComponent from "../Components/CarGateCardsComponent";
import PanelCardComponent from "../Components/PanelCardsComponent";
import BatteryCardsComponent from "../Components/BatteryCardsComponent";
import axios from "axios";
import { API_BASE_URL } from "../App";
import BasicPropertyComponent from "../Components/Services/BasicPropertyInfo";
import { GetPropertyPowerGraphData } from "../Components/Services/PropertiesService";
import PowerSpentHistory from "../Components/BasicComponents/PowerSpentHistory";
import BasicPowerGraph from "../Components/BasicComponents/BasicPowerGraph";
import { propertyHubConnection } from "../Components/Sockets/LightSocketService";

const PropertyEnergyPage = () => {
  const { property } = useParams();
  const [propertyData, setPropertyData] = useState(null);
  const [imageData, setImageData] = useState("");
  const [loading, setLoading] = useState(true);
  const location = useLocation();
  const [powerData, setPowerData] = useState([]);
  const [socketPower,setSocketPower] = useState("");

  useEffect(() => {
    async function connect() {
      if (propertyHubConnection.state === "Disconnected") {
        await propertyHubConnection.start();
      }

      propertyHubConnection.on("property/"+property, (powerPerMinute) => {
        console.log(powerPerMinute)
        setSocketPower(powerPerMinute)
      });
    }
    connect();
  }, []);

  const fetchProperty = () => {
    axios
      .get(`${API_BASE_URL}/properties/${property}`)

      .then(async (response) => {
        console.log(response);
        setLoading(false);
        setPropertyData(response.data);
        const propertyImage = await getStaticContent(response.data.imageUrl);
        setImageData(propertyImage);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  };
  useEffect(() => {
    const fetchData = async () => {

      try {
        let search = { id: property, hours: "6h" };
        let data = await GetPropertyPowerGraphData(search);

        setPowerData(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, [socketPower]);

  useEffect(() => {
    setLoading(true);
    fetchProperty();
  }, []);

  if (loading) {
    return <LoadingComponent />;
  }

  return (
    <Grid container style={{ height: "100%" }}>
      <BasicPropertyComponent
        imageData={imageData}
        propertyData={propertyData}
      />

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
            height: "85vh",
          }}
        >
          <PowerSpentHistory
            deviceInfo={{ id: property }}
            property={true}
            RealTimeGraph={<BasicPowerGraph data={powerData}></BasicPowerGraph>}
          />
        </Box>
      </Grid>
    </Grid>
  );
};

export default PropertyEnergyPage;
