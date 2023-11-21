using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class HomeBatteryEntity : SmartDeviceEntity
    {
        public float BatterySize { get; set; }
        public float BatteryLevel { get; set; }
    }
}
