using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateCarChargerDTO :CreateSmartDeviceRequestDTO
    {
        public float ChargingPower { get; set; }
        public int ConnectorNumber { get; set; }
    }
}
