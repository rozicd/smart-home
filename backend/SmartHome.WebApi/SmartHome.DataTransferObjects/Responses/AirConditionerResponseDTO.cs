using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class AirConditionerResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
        public string PowerSupply { get; set; }
        public float EnergySpending { get; set; }
        public string DeviceType { get; set; }
        public string DeviceStatus { get; set; }
        public string Connection { get; set; }
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
        public float CurrentTemperature { get; set; }
        public ACMode ACMode { get; set; }
        public List<ACScheduledModeResponseDTO> ScheduledModes { get; set; }
    }
}
