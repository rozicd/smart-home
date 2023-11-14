﻿using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface IPropertyRepository
    {
        Task Add(Property property);
        Task<IEnumerable<Property>> GetPropertiesByUserId(Guid userId);
        Task<IEnumerable<Property>> GetPropertiesByStatus(PropertyStatus status);
        Task<Property> GetById(Guid id);
        Task Update(Property property);
    }
}
