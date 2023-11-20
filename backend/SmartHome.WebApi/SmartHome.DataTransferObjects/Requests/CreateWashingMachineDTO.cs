using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateWashingMachineDTO : CreateSmartDeviceRequestDTO
    {
        public List<WashingMachineModeDTO> Modes { get; set; }
        
        public CreateWashingMachineDTO() {
            Modes = new List<WashingMachineModeDTO>();
        }
}
    }

