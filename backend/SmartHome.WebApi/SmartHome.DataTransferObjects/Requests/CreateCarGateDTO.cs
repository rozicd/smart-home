using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public  class CreateCarGateDTO : CreateSmartDeviceRequestDTO
    {
        public List<string> AllowedLicensePlates { get; set; }
        public CreateCarGateDTO() 
        {
            AllowedLicensePlates = new List<string>();  
        }

    }
}
