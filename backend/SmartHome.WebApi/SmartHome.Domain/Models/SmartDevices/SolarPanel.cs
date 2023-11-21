using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class SolarPanel
    {
        public Guid Id { get; set; }
        public float Size { get; set; }
        public float Efficiency { get; set; }
    }
}
