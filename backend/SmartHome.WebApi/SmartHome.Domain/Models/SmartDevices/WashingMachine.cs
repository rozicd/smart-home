using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class WashingMachine : SmartDevice
    {
        public List<WashingMachineMode> Modes { get; set; }
        public WashingMachineMode? CurrentMode { get; set; }
        public DateTime StartTime { get; set; }

        public WashingMachine()
        {
            Modes = new List<WashingMachineMode>();
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.HSD;
            Connection = "";
            StartTime = DateTime.Now.AddYears(1000);
        }
    }
}
