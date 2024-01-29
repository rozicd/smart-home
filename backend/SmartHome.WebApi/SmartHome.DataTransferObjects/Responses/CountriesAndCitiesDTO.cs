using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class CountriesAndCitiesDTO
    {
        public List<CountryResponseDTO> Countries {  get; set; }
        public List<CityResponseDTO> Cities { get; set; }

    }
}
