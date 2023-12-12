using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SolarPanelSystemEntity : SmartDeviceEntity
    {

        public float Size { get; set; }
        public int NumberOfPanels {  get; set; }
        public float Efficiency { get; set; }
    }
}
