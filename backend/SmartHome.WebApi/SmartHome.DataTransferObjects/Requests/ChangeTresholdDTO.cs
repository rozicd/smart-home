using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeThresholdDTO
    {
        public Guid LampId { get; set; }

        [Range(1, 100, ErrorMessage = "Threshold should be a number between 0 and 100")]
        public float NewThreshold { get; set; }
    }
}
