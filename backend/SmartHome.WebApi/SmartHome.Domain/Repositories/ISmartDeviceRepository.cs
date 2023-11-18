using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Domain.Models;

namespace SmartHome.Domain.Repositories
{
    public interface ISmartDeviceRepository 
    {
        Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page);
        Task Connect(Guid id,string address);
        Task<SmartDevice> TurnOn(Guid id);
        Task<SmartDevice> TurnOff(Guid id);
        Task ForceTurnOff(Guid id);

    }
}
