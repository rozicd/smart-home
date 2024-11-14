using InfluxDB.Client.Core.Flux.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IInfluxReadable
    {
        Task<List<FluxTable>> GetInfluxDataAsync(string id, string h);
        Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate);
    }
}
