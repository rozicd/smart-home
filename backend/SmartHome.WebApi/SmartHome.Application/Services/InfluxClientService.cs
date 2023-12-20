using InfluxDB.Client.Writes;
using InfluxDB.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Domain.Services;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using System.Drawing.Printing;
using SmartHome.Domain.Models.SmartDevices;

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
        public async Task<List<FluxTable>> GetInfluxData(string query)
        {
            var queryApi = _client.GetQueryApi();
            var queryResult = await queryApi.QueryAsync(query, "organization");
            return queryResult;
        }

        public async Task WriteDataAsync(PointData pointData)
        {
            var writeApi = _client.GetWriteApiAsync();

            await writeApi.WritePointAsync(pointData,this._bucket, this._organization);
        }

        public async Task<List<ESCData>> GetESCDataAsync(string name, string start, string stop)
        {
            var queryApi = _client.GetQueryApi();
            string fluxQuery = $"from(bucket: \"bucket\") |> range(start: {start}, stop: {stop}) |> filter(fn: (r) => r[\"_measurement\"] == \"{name}\") |> filter(fn: (r) => r[\"_field\"] == \"RoomTemperature\" or r[\"_field\"] == \"AirHumidity\") |> aggregateWindow(every: 10s, fn: mean, createEmpty: false) |> yield(name: \"mean\")";
            Console.WriteLine(fluxQuery);
            List<ESCData> data = new List<ESCData>();
            var timestampData = new Dictionary<string, ESCData>();
            var queryResult = await queryApi.QueryAsync(fluxQuery, _organization);
            foreach (var record in queryResult.SelectMany(table => table.Records))
            {
                string timestamp = record.GetTime().ToString();
                string fieldName = record.GetValueByKey("_field").ToString();
                var fieldValue = Convert.ToDouble(record.GetValueByKey("_value"));

                // If timestamp not present in the dictionary, add a new entry
                if (!timestampData.ContainsKey(timestamp))
                {
                    timestampData[timestamp] = new ESCData { Timestamp = timestamp };
                }

                // Add field and value to the CombinedData object for the current timestamp
                if (fieldName == "RoomTemperature")
                {
                    timestampData[timestamp].RoomTemperate = (float)fieldValue;
                }
                else if (fieldName == "AirHumidity")
                {
                    timestampData[timestamp].AirHumidity = (float)fieldValue;
                }
            }
            foreach (ESCData eSCData in timestampData.Values)
            {
                data.Add(eSCData);
            }
            return data;

        }

    }
}
