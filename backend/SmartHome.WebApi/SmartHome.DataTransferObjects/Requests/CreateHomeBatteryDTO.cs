using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateHomeBatteryDTO 
    {
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }
        public float BatterySize { get; set; }
        public Guid PropertyId { get; set; }

    }
}
