﻿using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities
{
    public class PropertyEntity
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public virtual CityEntity City { get; set; }
        public double AreaSquareMeters { get; set; }
        public int NumberOfFloors { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public PropertyStatus Status { get; set; }
        public virtual List<UserEntity> SharedUsers { get; set; } = new List<UserEntity>();
    }

}
