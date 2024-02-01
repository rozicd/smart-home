using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class SprinklerScheduleDTO
    {
        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Duration in minutes is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int DurationMinutes { get; set; }

    }
}
