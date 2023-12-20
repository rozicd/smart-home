using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class EcsInfluxRangeRequestDTO
    {
        public string Name { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
