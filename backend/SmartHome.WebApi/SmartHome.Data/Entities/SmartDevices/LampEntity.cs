using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class LampEntity :SmartDeviceEntity
    {
        public LampMode LampMode { get; set; }
        public float LightThreshold { get; set; }
    }
}
