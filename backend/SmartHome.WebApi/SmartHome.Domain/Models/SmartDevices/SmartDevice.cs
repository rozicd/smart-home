using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models.SmartDevices
{
    public class SmartDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Connection { get; set; }
        public PowerSupplyType PowerSupply { get; set; }
        public float EnergySpending { get; set; }
        public DeviceType DeviceType { get; set; }
        public string ImageUrl { get; set; }

        public DeviceStatus DeviceStatus { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Property Property { get; set; }
        public Guid PropertyId { get; set; }
    }

    public enum PowerSupplyType { AUTONOMOUSLY, HOME }
    public enum DeviceType { HSD, ESD, BED }
    public enum DeviceStatus { OFFLINE, ONLINE }
}
