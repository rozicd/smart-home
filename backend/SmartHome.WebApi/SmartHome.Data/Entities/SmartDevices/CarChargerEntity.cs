using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class CarChargerEntity : SmartDeviceEntity
    {
        public float ChargingPower { get; set; }
        public int ConnectorNumber { get; set; }

    }
}
