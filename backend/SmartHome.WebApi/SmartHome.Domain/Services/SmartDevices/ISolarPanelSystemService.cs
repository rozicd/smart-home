using InfluxDB.Client.Core.Flux.Domain;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface ISolarPanelSystemService : ISmartDeviceActionsService
    {
        Task Add(SolarPanelSystem sensor);
        Task<SolarPanelSystem> GetById(Guid id);
        Task TurnOn(Guid id,LoggedUser user);

        Task TurnOff(Guid id,LoggedUser user);
        Task<List<FluxTable>> GetSPSInfluxDataAsync(Guid id, DateTime startDate, DateTime endDate);




    }
}
