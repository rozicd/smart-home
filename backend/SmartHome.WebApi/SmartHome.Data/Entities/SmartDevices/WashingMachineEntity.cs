using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class WashingMachineEntity :SmartDeviceEntity
    {
        public virtual List<WashingMachineModeEntity> Modes { get; set; } = new List<WashingMachineModeEntity>();
        public virtual WashingMachineModeEntity? CurrentMode { get; set; }
        public DateTime StartTime { get; set; }
        public virtual List<WMScheduledModeEntity> ScheduledModes { get; set; } = new List<WMScheduledModeEntity> { };
    }
}
