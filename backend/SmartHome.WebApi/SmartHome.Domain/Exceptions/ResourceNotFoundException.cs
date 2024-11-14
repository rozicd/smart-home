using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Exceptions
{
    public class ResourceNotFoundException : Exception
    {

        public ResourceNotFoundException(string message)
            : base(message)
        {
        }
        public ResourceNotFoundException()
           : base("Resource not found!")
        {
        }
    }
}
