using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class HomeBattery : SmartDevice
    {
        public float BatterySize { get; set; }
        public float BatteryLevel { get; set; }
        public HomeBattery()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.BED;
            Connection = "";
            BatteryLevel = 0;
            EnergySpending = 0;


        }
    }
}
