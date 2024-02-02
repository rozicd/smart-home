using SmartHome.DataTransferObjects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class WashingMachineModesResponseDTO
    {
        public List<WashingMachineModeDTO> WashingMachineModes { get; set; } = new List<WashingMachineModeDTO>();
    }
}
