using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class Sprinkler : SmartDevice
    {
        public SprinkleMode? Mode { get; set; }
        public Guid?  ModeId { get; set; }
        public Sprinkler()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.ESD;
            Connection = "";
        }
    }
}
