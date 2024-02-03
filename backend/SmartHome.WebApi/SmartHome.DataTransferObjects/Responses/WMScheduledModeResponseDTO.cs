using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class WMScheduledModeResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Mode { get; set; }
    }
}
