using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface IAirConditionerService : ISmartDeviceActionsService,IInfluxReadable
    {
        Task Add(AirConditioner sensor);
        Task<AirConditioner> GetById(Guid id);
        Task TurnOn(Guid airConditionId);
        Task TurnOff(Guid airConditionId);
        Task ChangeMode(LoggedUser user, AirConditioner airConditioner);
        Task<AirConditioner> AddScheduledMode(Guid id, ACScheduledMode scheduledMode, LoggedUser user);

    }
}
