using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateSolarPanelSystemDTO :CreateSmartDeviceRequestDTO
    {
        public float Size { get; set; }
        public float Efficiency { get; set; }

    }
}
