using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHome.Domain.Models.SmartDevices.CarGate;

namespace SmartHome.DataTransferObjects.Responses
{
    public class CarGateResponseDTO
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
        public CarGateMode Mode { get; set; }
        public List<string> AllowedLicensePlates { get; set; }
    }
}
