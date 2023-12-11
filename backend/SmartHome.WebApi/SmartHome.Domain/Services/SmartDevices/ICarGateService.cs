using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ICarGateService : ISmartDeviceActionsService
    {
        Task Add(CarGate sensor);

    }
}
