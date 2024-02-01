using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;

namespace SmartHome.Domain.Repositories
{
    public interface ISmartDeviceRepository 
    {
        Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page);
        Task Connect(Guid id,string address);
        Task<SmartDevice> TurnOn(Guid id);
        Task<SmartDevice> TurnOff(Guid id);
        Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page, Guid propertyId);
        Task<string> GetDeviceType(Guid deviceId);
        Task<User> addUserPermission(Guid id, string email);
        Task<User> removeUserPermission(Guid id, string email);
        Task<SmartDevice> getById(Guid id);
    }
}
