using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class WMActionsDTO
    {
        public string Name { get; set; }
        public string Mode { get; set; }
        public DateTime? Timestamp { get; set; } 

    }
}
