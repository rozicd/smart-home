using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateSmartDeviceRequestDTO
    {
        public string Name { get; set; }

        public float EnergySpending { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid PropertyId {  get; set; }


    }
}
