using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IInfluxClientService
    {
        Task WriteDataAsync(PointData pointData);

        Task<List<ESCData>> GetESCDataAsync(string name, string start, string stop);

        Task<List<FluxTable>> GetInfluxData(string query);

    }
}
