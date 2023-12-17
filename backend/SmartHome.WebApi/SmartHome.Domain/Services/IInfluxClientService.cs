using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
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
        Task<List<FluxTable>> GetInfluxData(string query);

    }
}
