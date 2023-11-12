using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class RegisterPropertyRequestDTO
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Area square meters is required")]
        public double AreaSquareMeters { get; set; }

        [Required(ErrorMessage = "Number of floors is required")]
        public int NumberOfFloors { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string ImageUrl { get; set; }
    }
}
