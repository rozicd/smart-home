using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ISprinklerService : ISmartDeviceActionsService,IInfluxReadable
    {
        Task Add(Sprinkler sensor);
        Task TurnOn(Guid sprinklerId, string performedByUser);
        Task TurnOff(Guid sprinklerId, string performedByUser);
        Task<SprinklerSchedule> AddSchedule(Guid sprinklerId, SprinklerSchedule schedule);
        Task RemoveSchedule(Guid sprinklerId, Guid scheduleId);
        Task<Sprinkler> GetById(Guid sprinklerId);
        Task<List<SprinklerSchedule>> GetSprinklerSchedules(Guid sprinklerId);

    }
}
