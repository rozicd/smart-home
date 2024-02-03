using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class WMScheduledMode
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Mode { get; set; }
    }
}
