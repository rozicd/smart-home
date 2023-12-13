using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Exceptions
{
    public class DeviceAlreadyExistsException : Exception
    {

        public DeviceAlreadyExistsException(string message)
            : base(message)
        {
        }
        public DeviceAlreadyExistsException()
            : base("Email Already Exists")
        {
        }
    }
}
