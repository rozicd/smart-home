using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class AirConditionerEntity : SmartDeviceEntity
    {
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
        public float CurrentTemperature { get; set; }
        public ACMode Mode { get; set; }
        public virtual List<ACScheduledModeEntity> ScheduledModes { get; set; } = new List<ACScheduledModeEntity>();
    }
}
