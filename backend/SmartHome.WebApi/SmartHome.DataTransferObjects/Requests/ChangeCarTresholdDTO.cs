using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeCarTresholdDTO
    {
        public Guid Id {  get; set; }
        public float Treshold {  get; set; }
        public string Plug {  get; set; }
    }
}
