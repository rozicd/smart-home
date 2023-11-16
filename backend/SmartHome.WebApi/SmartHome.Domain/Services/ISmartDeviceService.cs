using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ISmartDeviceService<T>
    {
        Task Add(T device);
        Task<IEnumerable<T>> GetSmartDevicesByUserId(Guid userId);
        Task<T> GetById(Guid id);
        Task Update(T device);
        Task Connect(Guid id);

    }
}
