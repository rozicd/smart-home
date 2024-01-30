using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface ISprinklerRepository
    {
        Task Add(Sprinkler sensor);
        Task<Sprinkler> GetByIdAsync(Guid sprinklerId);
        Task UpdateAsync(Sprinkler sprinkler);
        Task AddScheduleAsync(Guid sprinklerId, SprinklerSchedule schedule);
        Task RemoveScheduleAsync(Guid sprinklerId, Guid scheduleId);
        Task<SprinklerSchedule> GetScheduleByIdAsync(Guid scheduleId);
        Task<List<SprinklerSchedule>> GetSprinklerSchedulesAsync(Guid sprinklerId);
    }
}
