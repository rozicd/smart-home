using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class DeviceDataResponseDTO
    {
        public string Percentage { get; set; }
        public string Duration { get; set; }
        public string Units { get; set; }
        public string Timestamp { get; set; }
    }
}
