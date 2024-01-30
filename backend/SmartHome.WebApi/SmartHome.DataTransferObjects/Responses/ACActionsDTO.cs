using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class ACActionsDTO
    {
        public DateTime? Timestamp { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; }
        public string Temperature { get; set; }
    }
}
