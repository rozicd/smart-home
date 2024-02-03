using SmartHome.DataTransferObjects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class WashingMachineResponseDTO
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

        public List<WashingMachineModeDTO> Modes { get; set; }
        public List<WMScheduledModeResponseDTO> ScheduledModes { get; set; }
    }
}
