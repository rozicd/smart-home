using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ILampService : ISmartDeviceActionsService, IInfluxReadable
    {
        Task Add(Lamp sensor);
        Task<Lamp> GetById(Guid lampId);
        Task TurnOn(Guid lampId);
        Task TurnOff(Guid lampId);
        Task ChangeThreshold(Guid lampId, float newThreshold);
        Task ChangeMode(Guid lampId, LampMode mode);

    }
}
