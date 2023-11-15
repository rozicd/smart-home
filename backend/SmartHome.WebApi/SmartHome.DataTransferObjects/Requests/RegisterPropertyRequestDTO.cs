﻿using System;
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
        [StringLength(255, ErrorMessage = "Address should not exceed 255 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(50, ErrorMessage = "City name should not exceed 50 characters")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [StringLength(50, ErrorMessage = "Country name should not exceed 50 characters")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Area square meters is required")]
        [Range(1, 1000, ErrorMessage = "Area square meters should be greater than 0")]
        public double AreaSquareMeters { get; set; }

        [Required(ErrorMessage = "Number of floors is required")]
        [Range(1, 100, ErrorMessage = "Number of floors should be greater than 0")]
        public int NumberOfFloors { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string ImageUrl { get; set; }
    }
}