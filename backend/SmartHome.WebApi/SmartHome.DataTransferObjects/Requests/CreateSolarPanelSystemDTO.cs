using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateSolarPanelSystemDTO :CreateSmartDeviceRequestDTO
    {
        public List<CreateSolarPanelDTO> SolarPanels { get; set; }

        public CreateSolarPanelSystemDTO()
        {
            SolarPanels = new List<CreateSolarPanelDTO>();
        }
    }
}
