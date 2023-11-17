using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ActivationTokenRequestDTO
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
