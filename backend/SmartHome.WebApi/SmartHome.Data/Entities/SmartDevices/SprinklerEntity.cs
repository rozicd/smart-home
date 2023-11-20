using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SprinklerEntity : SmartDeviceEntity
    {
        public virtual SprinkleModeEntity? Mode { get; set; }
        public Guid? ModeId { get; set; }
    }
}
