using SmartHome.Domain.Models;

namespace SmartHome.Data.Entities
{
    public class SmartDeviceEntity
    {
        public Guid Id { get; set; }
        public string Connection { get; set; }
        public PowerSupplyType PowerSupply { get; set; }
        public float EnergySpending { get; set; }
        public DeviceType DeviceType { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
    }
}
