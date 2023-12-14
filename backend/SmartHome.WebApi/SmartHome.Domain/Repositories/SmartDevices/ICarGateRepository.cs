using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface ICarGateRepository
    {
        Task Add(CarGate sensor);
        Task<CarGate> GetById(Guid carGateId);

    }
}
