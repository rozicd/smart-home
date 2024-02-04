using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class HomePowerResponseDTO
    {
        public string Energy { get; set; }
        public string Timestamp { get; set; }
        public string DeviceId {  get; set; }
        public string Target {  get; set; }
    }
}
