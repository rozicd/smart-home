using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ICarChargerService : ISmartDeviceActionsService
    {
        Task Add(CarCharger sensor);
        Task ChangeTreshold(Guid id, string plug, float treshold);
        Task<CarCharger> GetById(Guid chargerId);

    }
}
