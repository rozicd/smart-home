using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class RejectRequestDTO
    {
        [Required(ErrorMessage = "Rejection description is required")]
        [StringLength(255, ErrorMessage = "Rejection description should not exceed 255 characters")]
        public string Description { get; set; }

    }
}
