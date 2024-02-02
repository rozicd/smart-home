using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class ESCData
    {
        public DateTime?  Timestamp { get; set; }
        public float RoomTemperate { get; set; }
        public float AirHumidity { get; set; }
    }
}
