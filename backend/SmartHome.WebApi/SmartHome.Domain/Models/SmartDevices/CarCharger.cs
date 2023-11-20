using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class CarCharger : SmartDevice
    {
        public float ChargingPower { get; set; }
        public int ConnectorNumber { get; set; }
        public CarCharger()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.BED;
            Connection = "";
        }
    }
}
