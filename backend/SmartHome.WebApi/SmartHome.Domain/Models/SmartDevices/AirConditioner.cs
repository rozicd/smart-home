using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class AirConditioner : SmartDevice
    {
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
        public float CurrentTemperature { get; set; }
        public ACMode Mode { get; set; }

        public List<ACScheduledMode> ScheduledModes { get; set; }
        public AirConditioner()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.HSD;
            Connection = "";
            CurrentTemperature = 0;
            ScheduledModes = new List<ACScheduledMode>();
        }
    }
    public enum ACMode { COOLING, HEATING, AUTOMATIC, FAN }

}
