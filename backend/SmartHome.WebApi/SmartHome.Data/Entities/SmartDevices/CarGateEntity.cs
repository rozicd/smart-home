using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHome.Domain.Models.SmartDevices.CarGate;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class CarGateEntity :SmartDeviceEntity
    {
        public CarGateMode Mode { get; set; }
        public List<string> AllowedLicensePlates { get; set; }

    }
}
