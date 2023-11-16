using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IActivationTokenService
    {
        Task AddOne(Guid id);
    }
}
