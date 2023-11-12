using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities
{
    public class CountryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CityEntity> Cities { get; set; }
    }
}
