using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateSolarPanelSystemDTO 
    {
        public float Size { get; set; }
        public int NumberOfPanels { get; set; }
        public float Efficiency { get; set; }
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }
        public Guid PropertyId { get; set; }


    }
}
