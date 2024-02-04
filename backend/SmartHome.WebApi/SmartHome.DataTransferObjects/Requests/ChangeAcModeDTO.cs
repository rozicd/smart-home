using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeAcModeDTO
    {
        public Guid Id { get; set; }
        public ACMode mode { get; set; }
        public float currentTemperature { get; set; }
    }
}
