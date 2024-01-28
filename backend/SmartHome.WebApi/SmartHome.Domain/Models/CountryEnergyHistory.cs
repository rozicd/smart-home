using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models
{
    public class CountryEnergyHistory
    {
        public string Name { get; set; }
        public float Spent {  get; set; }
        public float Generated { get; set; }
    }
}
