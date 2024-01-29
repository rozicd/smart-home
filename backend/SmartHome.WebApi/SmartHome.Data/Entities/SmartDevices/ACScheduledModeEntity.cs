using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class ACScheduledModeEntity
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Temeprature { get; set; }
        public ACMode ACMode { get; set; }

        public Guid AirConditionerId { get; set; }
        public virtual AirConditionerEntity airConditionerEntity { get; set; }
    }
}
