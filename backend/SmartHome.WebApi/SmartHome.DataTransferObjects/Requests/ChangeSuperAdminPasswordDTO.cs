using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeSuperAdminPasswordDTO
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
    }
}
