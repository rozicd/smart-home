using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeWMModeRequestDTO
    {
        public Guid Id { get; set; }
        public string Mode { get; set; }
    }
}
