using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class CarGate : SmartDevice
    {
        public CarGateMode Mode { get; set; }
        public string LicensePlate { get; set; }
        public bool isCarClose { get; set; }
        public List<string> AllowedLicensePlates {  get; set; }
        public CarGate()
        {
            PowerSupply = PowerSupplyType.HOME;
            DeviceStatus = DeviceStatus.OFFLINE;
            DeviceType = DeviceType.ESD;
            Connection = "";
            LicensePlate = "";
            isCarClose = false;
            AllowedLicensePlates = new List<string>();
        }
        public enum CarGateMode { PUBLIC, PRIVATE }
    }
}
