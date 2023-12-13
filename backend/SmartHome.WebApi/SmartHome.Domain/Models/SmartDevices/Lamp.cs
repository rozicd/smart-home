using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class Lamp : SmartDevice
    {
        public LampMode LampMode { get; set; }
        public float LightThreshold { get; set; }

        public Lamp()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.ESD;
            LampMode = LampMode.AUTO;
            Connection = "";
        }
    }

    public enum LampMode { MANUAL,AUTO}
}
