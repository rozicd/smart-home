using InfluxDB.Client.Core.Flux.Domain;
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
        Task ChangeTreshold(Guid id, string plug, float treshold,string user);
        Task<CarCharger> GetById(Guid chargerId);
        Task<List<FluxTable>> GetChargerActionsInflux(string id);
        Task<List<FluxTable>> GetChargerActionsInfluxDate(string id, DateTime startDate, DateTime endDate);


    }
}
