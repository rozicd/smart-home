﻿using InfluxDB.Client.Writes;
using InfluxDB.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Domain.Services;
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
    }
}
