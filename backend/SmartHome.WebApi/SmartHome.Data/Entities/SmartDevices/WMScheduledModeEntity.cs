using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class WMScheduledModeEntity
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Mode { get; set; }

        public Guid WashingMachineId { get; set; }
        public virtual WashingMachineEntity WashingMachine { get; set; }
    }
}
