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
        Task<List<FluxTable>> GetCarGateInfluxDataAsync(Guid carGateId, DateTime startDate, DateTime endDate);
        Task WriteDataAsync(PointData pointData);
    }
}
