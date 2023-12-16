using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHome.Domain.Models.SmartDevices.CarGate;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ICarGateService : ISmartDeviceActionsService
    {
        Task Add(CarGate sensor);
        Task<CarGate> GetById(Guid carGateId);
        Task OpenGate(Guid carGateId, string performedByUser);
        Task CloseGate(Guid carGateId, string performedByUser);
        Task ChangeMode(Guid carGateId, CarGateMode newMode);
        Task AddLicensePlate(Guid carGateId, string licensePlate);
        Task RemoveLicensePlate(Guid carGateId, string licensePlate);


    }
}
