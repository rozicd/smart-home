using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class EnvironmentalConditionsSensor : SmartDevice
    {
        public float RoomTemperature {  get; set; }
        public float AirHumidity {  get; set; }
        public EnvironmentalConditionsSensor()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.BED;
            Connection = "";
            RoomTemperature = 0;
            AirHumidity = 0;

        }
    }
}
