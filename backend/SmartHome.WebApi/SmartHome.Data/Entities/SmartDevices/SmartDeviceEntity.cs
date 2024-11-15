﻿using SmartHome.Domain.Models.SmartDevices;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SmartDeviceEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Connection { get; set; }
        public PowerSupplyType PowerSupply { get; set; }
        public float EnergySpending { get; set; }
        public DeviceType DeviceType { get; set; }
        public string ImageUrl { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public virtual UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public virtual PropertyEntity Property { get; set; }
        public Guid PropertyId {  get; set; }

        public virtual List<UserEntity> SharedUsers { get; set; } = new List<UserEntity>();
    }
}
