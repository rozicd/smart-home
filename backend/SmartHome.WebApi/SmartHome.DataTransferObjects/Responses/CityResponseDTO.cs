using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class CityResponseDTO
    {
        public string Name { get; set; }
        public CountryResponseDTO Country { get; set; }
    }

}
