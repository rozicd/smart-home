using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class SmartDevicePropertyDTO
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }

        public string CountryName { get; set; }
    }
}
