using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ISmartDeviceService : IInfluxReadable
    {
        Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page);
        Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page, Guid propertyId);
        Task<User> addUserPermission(Guid id, string email);
        Task<User> RemoveUserPermission(Guid id, string email);
        Task<SmartDevice> GetDeviceById(Guid id);



    }
}
