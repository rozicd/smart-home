﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateLampDTO :CreateSmartDeviceRequestDTO
    {
        public float LightThreshold { get; set; }

    }
}