using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Property = SmartHome.Domain.Models.Property;
using User = SmartHome.Domain.Models.User;

namespace SmartHome.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMqttClientService _mqttClientService;
        private readonly IInfluxClientService _influxClientService;
        private readonly IHubContext<PropertyHub> _hubContext;



        public PropertyService(IPropertyRepository propertyRepository, IMqttClientService mqttClientService, IInfluxClientService influxClientService, IHubContext<PropertyHub> hubContext)
        {
            _propertyRepository = propertyRepository;
            _mqttClientService = mqttClientService;
            _influxClientService = influxClientService;
            _hubContext = hubContext;
        }

        public async Task AddProperty(Property property)
        {
         
            await _propertyRepository.Add(property);
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByUserId(Guid userId, Pagination pagination)
        {
   
            
            var res = await _propertyRepository.GetPropertiesByUserId(userId, pagination);
             
            return res;
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByStatus(PropertyStatus status, Pagination pagination)
        {
            return await _propertyRepository.GetPropertiesByStatus(status,pagination);
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            return await _propertyRepository.GetById(id);
        }


        public async Task UpdateProperty(Property property)
        {
            await _propertyRepository.Update(property);
        }

        public async Task ListenOnCharge(Property property)
        {
            string topic = "property/" + property.Id + "/house_power";
            var client = await _mqttClientService.SubscribeAsync(topic);

            client.ApplicationMessageReceivedAsync += async e =>
            {

                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == topic)
                {
                    string messageContent = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] parts = messageContent.Split(',');
                    if (float.TryParse(parts[0], out float power))
                    {
                        await SendPowerInfluxDataAsync(property.Id.ToString(), power, parts[2], parts[1]);
                        await _hubContext.Clients.All.SendAsync("property/" + property.Id, power);




                    }


                }
            };
        }

        private async Task SendPowerInfluxDataAsync(string id, float power,string deviceId,string target)
        {
            var point = PointData
                          .Measurement("Home Energy")
                          .Tag("id", id)
                          .Field("power", power)
                          .Tag("device", deviceId)
                          .Tag("target", target)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }


        public async Task<List<FluxTable>> GetPropertyPowerInfluxData(string id, string h)
        {
            string ag = "5s";
            string fn = "last";
            if (h == "1h")
            {
                ag = "5m";
                fn = "mean";

            }
            if (h == "6h")
            {
                ag = "30m";
                fn = "mean";

            }
            if (h == "12h" || h == "24h")
            {
                ag = "1h";
                fn = "mean";

            }
            if (h == "7d" || h == "30d")
            {
                ag = "1d";
                fn = "mean";

            }
            string query = $@"
            from(bucket: ""bucket"")
              |> range(start: -{h}) 
              |> filter(fn: (r) => r[""_measurement""] == ""Home Energy"")
              |> filter(fn: (r) => r[""_field""] == ""power"")
              |> filter(fn: (r) => r[""id""] == ""{id}"")
              |> group(columns: [""_measurement"", ""_field"",""target""])

              |> aggregateWindow(every: {ag}, fn: {fn}, createEmpty: false)";

               

            var result = await _influxClientService.GetInfluxData(query);


            return result;
        }

        public async Task<List<FluxTable>> GetPropertyPowerInfluxDataDate(string id, DateTime startDate, DateTime endDate)
        {

            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            int daysApart = Math.Abs((endDate - startDate).Days);

            string ag = "1h";

            if (daysApart > 3) 
            {
                ag = "6h";
            }
            if (daysApart > 7)
            {
                ag = "1d";
            }

            string query = $@"
            from(bucket: ""bucket"")
              |> range(start: {start},stop:{end} ) 
              |> filter(fn: (r) => r[""_measurement""] == ""Home Energy"")
              |> filter(fn: (r) => r[""_field""] == ""power"")
              |> filter(fn: (r) => r[""id""] == ""{id}"")
              |> group(columns: [""_measurement"", ""_field"",""target""])

              |> aggregateWindow(every: {ag}, fn: mean, createEmpty: false)";

            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

        public async Task<PaginationReturnObject<Property>> GetAllProperties(Pagination pagination)
        {
            return await _propertyRepository.GetAllProperties(pagination);

        }

        public async  Task<CountriesAndCities> GetCountries()
        {
            return await _propertyRepository.GetCountries();
         }
        public async Task<CountryEnergyHistory> GetCountryEnergyData(string country, string h,string tag,DateTime? startDate, DateTime? endDate)
        {   
            string range = $@"|> range(start: -{h})";

            if (startDate.HasValue && endDate.HasValue)
            {
                string start = startDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string end = endDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                range = $@"|> range(start: {start},stop:{end})";
            }
            List<Property> properties;
            if (tag == "Country")
            {
                properties = await _propertyRepository.GetPropertiesByCountry(country);
            }
            else 
            {
                properties = await _propertyRepository.GetPropertiesByCity(country);
            }
            float spent = 0;
            float generated = 0;
            foreach(Property property in properties) 
            {
                string query = $@"
                from(bucket: ""bucket"")"
                + range+
                $@"  
                  |> filter(fn: (r) => r[""_measurement""] == ""Home Energy"")
                  |> filter(fn: (r) => r[""_field""] == ""power"")
                  |> filter(fn: (r) => r[""id""] == ""{property.Id}"")
                  |> group(columns: [""_measurement"", ""_field"",""target""])
                  |> aggregateWindow(every: 1s, fn: last, createEmpty: false)";

                var result = await _influxClientService.GetInfluxData(query);
                foreach (var fluxTable in result)
                {
                    foreach (var fluxRecord in fluxTable.Records)
                    {
                        float energy = float.Parse(fluxRecord.GetValueByKey("_value").ToString());

                        if (energy > 0)
                        {
                            generated += energy;
                        }
                        else
                        {
                            spent += energy*-1;
                        }
                    }
                }

            }
            CountryEnergyHistory ceh = new CountryEnergyHistory();
            ceh.Name = country;
            ceh.Spent = spent;
            ceh.Generated = generated;
            return ceh;
        }

        public async Task AddUserPermision(Guid propertyId, User user)
        {
       
            await _propertyRepository.AddUserPermision(propertyId, user);
        }

        public async Task RemoveUserPermision(Guid propertyId, User user)
        {
        
            await _propertyRepository.RemoveUserPermision(propertyId, user);
        }
    }
}
