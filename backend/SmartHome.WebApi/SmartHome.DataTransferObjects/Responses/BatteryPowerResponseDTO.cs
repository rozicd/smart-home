﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class BatteryPowerResponseDTO
    {
        public string Energy {  get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
