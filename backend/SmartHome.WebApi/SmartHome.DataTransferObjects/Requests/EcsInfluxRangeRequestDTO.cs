using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class EcsInfluxRangeRequestDTO
    {
        public Guid Id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
