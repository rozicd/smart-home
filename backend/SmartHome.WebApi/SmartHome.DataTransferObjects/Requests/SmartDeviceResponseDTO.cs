using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class SmartDeviceResponseDTO
    {
        public string Id {  get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl {  get; set; }
        public PowerSupplyType PowerSupply { get; set; }
        public float EnergySpending { get; set; }
        public DeviceType DeviceType { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
    }
}
