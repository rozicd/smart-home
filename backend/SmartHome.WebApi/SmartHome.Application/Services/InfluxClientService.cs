using InfluxDB.Client.Writes;
using InfluxDB.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Domain.Services;
using SmartHome.Domain.Models.SmartDevices;
using InfluxDB.Client.Core.Flux.Domain;

namespace SmartHome.Application.Services
{
    public class InfluxClientService : IInfluxClientService
    {
        private readonly InfluxDBClient _client;
        private readonly string _bucket;
        private readonly string _organization;

        public InfluxClientService(string influxDbUrl, string token, string bucket, string organization)
        {
            _client = new InfluxDBClient(influxDbUrl, token);
            _bucket = bucket;
            _organization = organization;
        }

        public async Task WriteDataAsync(PointData pointData)
        {
            var writeApi = _client.GetWriteApiAsync();

            await writeApi.WritePointAsync(pointData,this._bucket, this._organization);
        }

        public async Task<List<FluxTable>> GetCarGateInfluxDataAsync(Guid carGateId, DateTime startDate, DateTime endDate)
        {
            var query = $"from(bucket:\"{_bucket}\") |> range(start: {startDate:yyyy-MM-dd'T'HH:mm:ss.fff'Z'}, stop: {endDate:yyyy-MM-dd'T'HH:mm:ss.fff'Z'}) |> filter(fn: (r) => r[\"_measurement\"] == \"Car actions\") |> filter(fn: (r) => r[\"Id\"] == \"{carGateId}\") |> sort(columns: [\"_time\"], desc: false)  |> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var fluxTable = await _client.GetQueryApi().QueryAsync(query, _organization);

            return fluxTable;
        }
    }
}
