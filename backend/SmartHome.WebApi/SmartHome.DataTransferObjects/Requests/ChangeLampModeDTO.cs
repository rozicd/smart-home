using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeLampModeDTO
    {
        public Guid LampId { get; set; }
        public LampMode Mode { get; set; }
    }
}
