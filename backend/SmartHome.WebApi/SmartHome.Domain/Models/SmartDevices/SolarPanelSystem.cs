using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class SolarPanelSystem : SmartDevice
    {
        public List<SolarPanel> SolarPanels { get; set; }
        public SolarPanelSystem()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.BED;
            Connection = "";
            SolarPanels = new List<SolarPanel>();
        }
    }
}
