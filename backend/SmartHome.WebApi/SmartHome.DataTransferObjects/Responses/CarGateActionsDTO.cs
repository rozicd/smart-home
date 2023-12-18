using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class CarGateActionsDTO
    {
        public DateTime? Timestamp { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
    }
}
