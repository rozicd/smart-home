import React, { useEffect, useState } from "react";

import { useParams } from "react-router-dom";
import { GetSmartDevicesByProperty } from "../Components/Services/SmartDeviceService";

const SmartDevicePage = ({}) => {
  const propertyId = useParams().property;
  console.log("Param=" + propertyId);

  useEffect(() => {
    console.log("asdasdasdasd");
    const fetch = async () => {
      console.log("asdasdasdasd");

      let request = {
        propertyId: propertyId,
      };
      const userProperties = await GetSmartDevicesByProperty(request);
      console.log(userProperties);
    };

    fetch();
    console.log("asdasdasdasd");
  }, [propertyId]);

  return <p>asdasdasd</p>;
};

export default SmartDevicePage;
