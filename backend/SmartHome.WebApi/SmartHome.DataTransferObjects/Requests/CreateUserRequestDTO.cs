using Microsoft.AspNetCore.Http;
using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class CreateUserRequestDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFile ImageFile { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}
