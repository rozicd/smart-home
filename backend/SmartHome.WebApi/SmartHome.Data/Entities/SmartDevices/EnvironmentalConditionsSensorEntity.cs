using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class EnvironmentalConditionsSensorEntity : SmartDeviceEntity
    {
        public float RoomTemperature { get; set; }
        public float AirHumidity { get; set; }
    }
}
