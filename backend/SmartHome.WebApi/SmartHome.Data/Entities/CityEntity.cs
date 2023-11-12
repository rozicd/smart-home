using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities
{
    public class CityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public ICollection<PropertyEntity> Properties { get; set; }
    }
}
