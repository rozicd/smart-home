import React, { useEffect, useState } from "react";
import AddButton from "../Components/BasicComponents/AddButton";
import { useParams } from "react-router-dom";
import { AddSmartDevice, GetSmartDevicesByProperty } from "../Components/Services/SmartDeviceService";
import "./device.css";
import { Container, Dialog } from "@mui/material";
import BasicSelect from "../Components/BasicComponents/BasicSelect";
import BasicForm from "../Components/BasicComponents/BasicForm";
import SmartDeviceCard from "../Components/BasicComponents/SmartDeviceCard";

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


const SmartDevicePage = ({}) => {

  let t = 
  [
    {
      item:"ImageDrop",

    },
    {
      item:"BasicInput",
      label:"Name",
      itemValue : "name"

    }

  ]
  const [openModal, setOpenModal] = useState(false);
  const [selectedDevice, setSelectedDevice] = useState();
  const [template,setTemplate] = useState(t);
  const [url,setUrl] = useState("");
  const propertyId = useParams().property;

  const test =async (form)=>
  {
    const data = new FormData();

    data.append('name', form.name);
    data.append('imageFile', form.imageFile);
    data.append('propertyId',propertyId)
    if (selectedDevice == 1)
    {
      data.append('energySpending', form.energySpending);
    }
    if (selectedDevice == 2)
    {
      data.append('energySpending', form.energySpending);
      data.append('maximumTemperature', form.maximumTemperature);
      data.append('minimumTemperature', form.minimumTemperature);
    }
    if (selectedDevice == 4)
    {
      data.append('energySpending', form.energySpending);
      data.append('lightThreshold', form.lightThreshold);
    }
    if (selectedDevice == 6)
    {
      data.append('energySpending', form.energySpending);
    }
    if (selectedDevice == 7)
    {
      data.append('energySpending', form.energySpending);
      data.append('size', form.size);
      data.append('efficiency', form.efficiency);

    }
    if (selectedDevice == 8)
    {
      data.append('batterySize', form.batterySize);

    }
    if (selectedDevice == 9)
    {
      data.append('chargingPower', form.chargingPower);
      data.append('connectorNumber', form.connectorNumber);

    }
    for(var pair of data.entries()) {
      console.log(pair[0]+', '+pair[1]);
    }
    await AddSmartDevice(data,url)
    setOpenModal(false)

  }


let l = 
[
  {
    item:"BasicInput",
    label:"Threshold",
    type :"number",
    itemValue : "lightThreshold"
  },
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  }
]
let ecs = 
[
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  }
]
let s = 
[
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  }
]
let ac = 
[
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  },
  {
    item:"BasicInput",
    label:"Minimum Temperature",
    type :"number",
    itemValue : "minimumTemperature"

  },
  {
    item:"BasicInput",
    label:"Maximum Temperature",
    type :"number",
    itemValue : "maximumTemperature"

  }
]
let sps = 
[
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  },
  {
    item:"BasicInput",
    label:"Area",
    type :"number",
    itemValue : "size"

  },
  {
    item:"BasicInput",
    label:"Efficiency",
    type :"number",
    itemValue : "efficiency"

  }
]
let hb = 
[
  
  {
    item:"BasicInput",
    label:"Battery Size",
    type :"number",
    itemValue : "batterySize"

  },
]
let cc = 
[
  
  {
    item:"BasicInput",
    label:"Energy Spending",
    type :"number",
    itemValue : "energySpending"

  },
  {
    item:"BasicInput",
    label:"Charging Power",
    type :"number",
    itemValue : "chargingPower"

  },
  {
    item:"BasicInput",
    label:"Number of Connectors",
    type :"number",
    itemValue : "connectorNumber"

  }
]


  console.log("Param=" + propertyId);

  useEffect(() => {
    setTemplate(t)
    if (selectedDevice == 1)
    {
      setTemplate(t.concat(ecs))
      setUrl("conditions-sensor")
    }
    if (selectedDevice == 2)
    {
      setTemplate(t.concat(ac))
      setUrl("air-conditioner")

    }

    if (selectedDevice == 4)
    {
      setTemplate(t.concat(l))
      setUrl("lamp")

    }
    
    if (selectedDevice == 6)
    {
      setTemplate(t.concat(s))
      setUrl("sprinkler")

    }
    if (selectedDevice == 7)
    {
      setTemplate(t.concat(sps))
      setUrl("solar-panel-system")

    }
    if (selectedDevice == 8)
    {
      setTemplate(t.concat(hb))
      setUrl("home-battery")

    }
    if (selectedDevice == 9)
    {
      setTemplate(t.concat(cc))
      setUrl("car-charger")

    }
    
  }, [selectedDevice]);
  const [smartDevices,setSmartDevices] = useState([]);
  useEffect(() => {
    console.log("asdasdasdasd");
    const fetch = async () => {
      console.log("asdasdasdasd");

      let request = {
        propertyId: propertyId,
      };
      const smartDevicesUser = await GetSmartDevicesByProperty(request);
      console.log(smartDevicesUser)
      setSmartDevices(smartDevicesUser.items);
    };

    fetch();
    console.log("asdasdasdasd");
  }, [propertyId]);

  return (
    <div className="smart-device-container">
      <div className="device-list">
          {smartDevices.map((device) => (
            <SmartDeviceCard key={device.id} device={device}  />
          ))}
        </div>
      <AddButton
        className="add-property-button"
        onClick={() => setOpenModal(true)}
      />
      <Dialog open={openModal} onClose={() => setOpenModal(false)}>
        <Container sx={{ padding: "10px", backgroundColor:"snow", display :"flex", alignItems:"center", flexDirection:"column"}}>
          <BasicSelect
            label={"Sensor Type"}
            collection={deviceTypes}
            valueParam={"id"}
            nameParam={"name"}
            selected={selectedDevice}
            callback={(e) => setSelectedDevice(e.target.value)}
          ></BasicSelect>
          <BasicForm template={template} callback={test}></BasicForm>
        </Container>
      </Dialog>
    </div>
  );
};

export default SmartDevicePage;
