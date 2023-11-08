using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Exceptions
{
    public class EmailAlreadyExistException : Exception
    {

        public EmailAlreadyExistException(string message)
            : base(message)
        {
        }
        public EmailAlreadyExistException()
            : base("Email Already Exists")
        {
        }
    }
}
