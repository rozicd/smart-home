using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateACScheduledModeRequestDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Temeprature { get; set; }
        public ACMode ACMode { get; set; }
    }
}
