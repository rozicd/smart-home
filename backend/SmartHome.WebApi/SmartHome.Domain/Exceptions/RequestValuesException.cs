using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Exceptions
{
    public class RequestValuesException : Exception
    {

        public RequestValuesException(string message)
            : base(message)
        {
        }
        public RequestValuesException()
           : base("There was an issue with the values in your request!")
        {
        }
    }
}
