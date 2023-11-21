using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateAirConditionerDTO :CreateSmartDeviceRequestDTO
    {
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
    }
}
