using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SprinklerScheduleEntity
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public virtual SprinklerEntity Sprinkler { get; set; }
        public Guid SprinklerId { get; set; }
    }
}