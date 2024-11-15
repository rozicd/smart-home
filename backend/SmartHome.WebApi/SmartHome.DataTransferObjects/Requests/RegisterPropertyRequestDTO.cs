﻿using Microsoft.AspNetCore.Http;
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
        [StringLength(100, ErrorMessage = "Address should not exceed 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City id is required")]
        public Guid CityId { get; set; }

        [Required(ErrorMessage = "Area square meters is required")]
        [Range(1, 1000, ErrorMessage = "Area square meters should be greater than 0")]
        public double AreaSquareMeters { get; set; }

        [Required(ErrorMessage = "PropertyName is required")]
        [StringLength(20, ErrorMessage = "Name should not exceed 20 characters")]
        public string PropertyName { get; set; }


        [Required(ErrorMessage = "Number of floors is required")]
        [Range(1, 100, ErrorMessage = "Number of floors should be greater than 0")]
        public int NumberOfFloors { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFile ImageFile { get; set; }
    }
}