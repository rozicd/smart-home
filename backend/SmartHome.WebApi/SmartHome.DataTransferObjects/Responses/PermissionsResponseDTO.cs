using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class PermissionsResponseDTO
    {
        public bool Owner { get; set; }
        public List<UserResponseDTO> SharedUsers { get; set; } = new List<UserResponseDTO>();
    }
}
