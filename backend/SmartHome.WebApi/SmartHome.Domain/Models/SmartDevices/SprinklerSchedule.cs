using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class SprinklerSchedule
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public virtual Sprinkler Sprinkler { get; set; }
        public Guid SprinklerId { get; set; }
    }
}
