using InfluxDB.Client.Core.Flux.Domain;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface IHomeBatteryService : ISmartDeviceActionsService
    {
        Task Add(HomeBattery sensor);
        Task<HomeBattery> GetById(Guid id);
        Task<List<FluxTable>> GetInfluxDataAsync(string id,string h);

        Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate);

    }
}
