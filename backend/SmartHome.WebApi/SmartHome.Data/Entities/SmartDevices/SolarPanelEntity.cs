using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SolarPanelEntity
    {
        public Guid Id { get; set; }
        public float Size { get; set; }
        public float Efficiency { get; set; }
    }
}
