using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class SolarPanelSystem : SmartDevice
    {
        public string Size { get; set; }
        public float Efficiency { get; set; }
        public int NumberOfPanels { get; set; }


        public SolarPanelSystem()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.BED;
            Connection = "";
        }
    }
}
