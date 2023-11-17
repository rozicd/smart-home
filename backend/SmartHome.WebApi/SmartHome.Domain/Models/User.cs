using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
        
    }
    public enum Status
    {
        INACTIVE,
        ACTIVE
    }

    public enum Role
    {
        USER,
        ADMIN,
        SUPERADMIN
    }
}
