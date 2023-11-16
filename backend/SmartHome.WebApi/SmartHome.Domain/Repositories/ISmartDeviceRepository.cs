using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Domain.Models;

namespace SmartHome.Domain.Repositories
{
    public interface ISmartDeviceRepository<T> 
    {
        Task Add(T device);
        Task<IEnumerable<T>> GetSmartDevicesByUserId(Guid userId);
        Task<T> GetById(Guid id);
        Task Update(T device);
        Task Connect(Guid id);
    }
}
