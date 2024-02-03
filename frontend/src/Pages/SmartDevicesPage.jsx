import React, { useEffect, useState } from "react";
import AddButton from "../Components/BasicComponents/AddButton";
import { useParams } from "react-router-dom";
import {
  AddSmartDevice,
  GetSmartDevicesByProperty,
} from "../Components/Services/SmartDeviceService";
import "./device.css";
import { Container, Dialog } from "@mui/material";
import BasicSelect from "../Components/BasicComponents/BasicSelect";
import BasicForm from "../Components/BasicComponents/BasicForm";
import SmartDeviceCard from "../Components/BasicComponents/SmartDeviceCard";
import BasicPagination from "../Components/BasicComponents/BasicPagination";
import InfoDialog from "../Components/BasicComponents/InfoDialog";
import { Title } from "@mui/icons-material";
import { Grid, Box, Card, CardContent, Button } from "@mui/material";
import PowerSpentHistory from "../Components/BasicComponents/PowerSpentHistory";
import { GetPropertyPowerGraphData } from "../Components/Services/PropertiesService";
import BasicPowerGraph from "../Components/BasicComponents/BasicPowerGraph";
import { propertyHubConnection } from "../Components/Sockets/LightSocketService";
import ShareIcon from '@mui/icons-material/Share';
import PermisionDialog from "../Components/Dialogs/PermisionDialog";
import { getPropertyById } from "../Components/Services/PropertiesService";

const deviceTypes = [
  { id: 1, name: "Enviromantal condition sensor" },
  { id: 2, name: "Air Conditioner" },
  { id: 3, name: "Washing Machine" },
  { id: 4, name: "Lamp" },
  { id: 5, name: "Car Gate" },
  { id: 6, name: "Sprinkler" },
  { id: 7, name: "Solar Panel System" },
  { id: 8, name: "Home Battery" },
  { id: 9, name: "Car Charger" },
];

const SmartDevicesPage = ({}) => {
  let t = [
    {
      item: "ImageDrop",
    },
    {
      item: "BasicInput",
      label: "Name",
      itemValue: "name",
    },
  ];
  const [openModal, setOpenModal] = useState(false);
  const [errorModal, setErrorModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(false);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [addedModal, setAddedModal] = useState(false);
  const [addedMessage, setAddedMessage] = useState(false);
  const [property, setProperty] = useState({});
  const [selectedDevice, setSelectedDevice] = useState();
  const [template, setTemplate] = useState(t);
  const [url, setUrl] = useState("");
  const propertyId = useParams().property;
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 6 });
  const [totalItems, setTotalItems] = useState(0);
  const [added, setAdded] = useState(false);
  const [powerData, setPowerData] = useState([]);
  const [socketPower,setSocketPower] = useState("");
  useEffect(() => {
    async function connect() {
      if (propertyHubConnection.state === "Disconnected") {
        await propertyHubConnection.start();
      }

      propertyHubConnection.on("property/"+propertyId, (powerPerMinute) => {
        console.log(powerPerMinute)
        setSocketPower(powerPerMinute)
      });
    }
    connect();
  }, []);

  useEffect(() => {
    const fetchData = async () => {
      console.log("data");

      try {
        let search = { id: propertyId, hours: "6h" };
        console.log("SEARCH!!", search);
        let data = await GetPropertyPowerGraphData(search);
        console.log("data");

        console.log(data);
        setPowerData(data);
        console.log("data");
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, [socketPower]);

  useEffect(() => {
    const fetchData = async () => {
      let response = await getPropertyById(propertyId)
      setProperty(response);
      console.log(response)
      try {
        
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, [dialogOpen]);

  const handlePageChange = (newPage) => {
    setPagination({
      ...pagination,
      pageNumber: newPage,
    });
  };

  const test = async (form) => {
    const data = new FormData();

    data.append("name", form.name);
    data.append("imageFile", form.imageFile);
    data.append("propertyId", propertyId);
    if (selectedDevice == 1) {
      data.append("energySpending", form.energySpending);
    }
    if (selectedDevice == 2) {
      data.append("energySpending", form.energySpending);
      data.append("maximumTemperature", form.maximumTemperature);
      data.append("minimumTemperature", form.minimumTemperature);
    }
    if(selectedDevice == 3){
      data.append("energySpending", form.energySpending);
      data.append("modes", form.Modes);
    }

    if (selectedDevice == 4) {
      data.append("energySpending", form.energySpending);
      data.append("lightThreshold", form.lightThreshold);
    }
    if (selectedDevice == 5) {
      data.append("energySpending", form.energySpending);
      if (form.AllowedLicensePlates){
        for (var i = 0; i < form.AllowedLicensePlates.length; i++) {
          data.append("allowedLicensePlates", form.AllowedLicensePlates[i]);
        }
      }
      else{

      }
    }
    if (selectedDevice == 6) {
      data.append("energySpending", form.energySpending);
    }
    if (selectedDevice == 7) {
      data.append("energySpending", form.energySpending);
      data.append("size", form.size);
      data.append("efficiency", form.efficiency);
      data.append("numberOfPanels", form.numberOfPanels);
    }
    if (selectedDevice == 8) {
      data.append("batterySize", form.batterySize);
    }
    if (selectedDevice == 9) {
      data.append("energySpending", 0);
      data.append("chargingPower", form.chargingPower);
      data.append("connectorNumber", form.connectorNumber);
    }
    for (var pair of data.entries()) {
      console.log(pair[0] + ", " + pair[1]);
    }
    try {
      const response = await AddSmartDevice(data, url);
      setAdded(!added);
      setAddedMessage("Device Added!");
      setAddedModal(true);
    } catch (error) {
      if (error.response) {
        setErrorMessage(error.response.data);
        setErrorModal(true);
      }
    }
    setOpenModal(false);
  };

  let wm = [
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
    {
      item:"MultipleSelect"
    }
  ]

  let l = [
    {
      item: "BasicInput",
      label: "Threshold",
      type: "number",
      itemValue: "lightThreshold",
    },
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
  ];
  let ecs = [
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
  ];

  let cg = [
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
    {
      item: "RegistrationInput",
      itemValue: "AllowedLicensePlates",
    },
  ];
  let s = [
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
  ];
  let ac = [
    {
      item: "BasicInput",
      label: "Energy Spending",
      type: "number",
      itemValue: "energySpending",
    },
    {
      item: "BasicInput",
      label: "Minimum Temperature",
      type: "number",
      itemValue: "minimumTemperature",
    },
    {
      item: "BasicInput",
      label: "Maximum Temperature",
      type: "number",
      itemValue: "maximumTemperature",
    },
  ];
  let sps = [
    {
      item: "BasicInput",
      label: "Area",
      type: "number",
      itemValue: "size",
    },
    {
      item: "BasicInput",
      label: "Number of panels",
      type: "number",
      itemValue: "numberOfPanels",
    },
    {
      item: "BasicInput",
      label: "Efficiency",
      type: "number",
      itemValue: "efficiency",
    },
  ];
  let hb = [
    {
      item: "BasicInput",
      label: "Battery Size",
      type: "number",
      itemValue: "batterySize",
    },
  ];
  let cc = [
    {
      item: "BasicInput",
      label: "Charging Power",
      type: "number",
      itemValue: "chargingPower",
    },
    {
      item: "BasicInput",
      label: "Number of Connectors",
      type: "number",
      itemValue: "connectorNumber",
    },
  ];

  console.log("Param=" + propertyId);

  useEffect(() => {
    setTemplate(t)
    if (selectedDevice == 1)
    {
      setTemplate(t.concat(ecs))
      setUrl("environmentalconditionssensor")
    }
    if (selectedDevice == 2) {
      setTemplate(t.concat(ac));
      setUrl("airconditioner");
    }

    if (selectedDevice ===3){
      setTemplate(t.concat(wm));
      setUrl("washingmachine")
    }

    if (selectedDevice == 4) {
      setTemplate(t.concat(l));
      setUrl("lamp");
    }

    if (selectedDevice == 5) {
      setTemplate(t.concat(cg));
      setUrl("cargate");
    }

    if (selectedDevice == 6) {
      setTemplate(t.concat(s));
      setUrl("sprinkler");
    }
    if (selectedDevice == 7) {
      setTemplate(t.concat(sps));
      setUrl("solarpanelsystem");
    }
    if (selectedDevice == 8) {
      setTemplate(t.concat(hb));
      setUrl("homebattery");
    }
    if (selectedDevice == 9) {
      setTemplate(t.concat(cc));
      setUrl("carcharger");
    }
  }, [selectedDevice]);
  const [smartDevices, setSmartDevices] = useState([]);
  useEffect(() => {
    console.log("asdasdasdasd");
    const fetch = async () => {
      console.log("asdasdasdasd");

      let request = {
        propertyId: propertyId,
        "page.pageSize": pagination.pageSize,
        "page.pageNumber": pagination.pageNumber,
      };
      const smartDevicesUser = await GetSmartDevicesByProperty(request);
      console.log(smartDevicesUser);
      setSmartDevices(smartDevicesUser.items);
      setTotalItems(smartDevicesUser.totalItems);
      console.log(smartDevicesUser.totalItems);
    };

    fetch();
    console.log("asdasdasdasd");
  }, [propertyId, pagination.pageNumber, pagination.pageSize, added]);

  const handleShareClick = (event) => {
    console.log('Share icon clicked');
    setDialogOpen(true)
  };


  const handleCloseDialog = () => {
    setDialogOpen(false);
  };

  const updatePermissions = (sharedUsers) =>{
    property.sharedUsers = sharedUsers
    setProperty(property);
  }

  
  return (
    <div className="smart-device-container">
      <BasicPagination
        currentPage={pagination.pageNumber}
        pageSize={pagination.pageSize}
        totalItems={totalItems}
        onPageChange={handlePageChange}
      />
      <Grid style={{ marginTop: "30px" }} container spacing={3}>
        <Grid item container lg={7} md={12} spacing={2}>
          {smartDevices.map((device) => (
            <Grid item md={6} alignItems={"center"} justifyContent={"center"}>
              <Box display="flex" justifyContent="center" alignItems="center">
                <SmartDeviceCard key={device.id} device={device} />
              </Box>
            </Grid>
          ))}
        </Grid>
        <Grid item container lg={5} md={12} alignContent={'center'} justifyContent={'center'}>
          <Grid item lg={12} md={12}>
            <Box display="flex" justifyContent="center" alignItems="center">
              <PowerSpentHistory
                deviceInfo={{ id: propertyId }}
                property={true}
                RealTimeGraph={
                  <BasicPowerGraph data={powerData}></BasicPowerGraph>
                }
              />
            </Box>
          </Grid>
        </Grid>
      </Grid>
      <AddButton
        className="add-property-button"
        onClick={() => setOpenModal(true)}
      />
      {property.owner && <Button  style={{ position: 'fixed', bottom: 16, right: 40, fontSize:"xx-large"}} onClick={handleShareClick}><ShareIcon></ShareIcon></Button>}
      <PermisionDialog open={dialogOpen} onClose={handleCloseDialog} property = {property} updatePermissions = {updatePermissions} />
      <Dialog
        open={openModal}
        onClose={() => setOpenModal(false)}
        style={{ width: "100%", minWidth: "100%" }}
        fullWidth={true}
        minWidth="100%"
      >
        <Container
          sx={{
            padding: "10px",
            backgroundColor: "snow",
            display: "flex",
            alignItems: "center",
            flexDirection: "column",
          }}
          style={{ minWidth: "70%", padding: "10%", alignItems: "center" }}
        >
          <BasicSelect
            style={{ width: "5vw" }}
            label={"Sensor Type"}
            collection={deviceTypes}
            valueParam={"id"}
            nameParam={"name"}
            selected={selectedDevice}
            callback={(e) => setSelectedDevice(e.target.value)}
          ></BasicSelect>
          <BasicForm
            style={{ width: "70%" }}
            template={template}
            callback={test}
          ></BasicForm>
        </Container>
      </Dialog>
      <InfoDialog
        open={errorModal}
        onClose={() => setErrorModal(false)}
        title={"Error"}
        content={errorMessage}
      ></InfoDialog>
      <InfoDialog
        open={addedModal}
        onClose={() => setAddedModal(false)}
        title={"Success"}
        content={addedMessage}
      ></InfoDialog>
    </div>
  );
};

export default SmartDevicesPage;
