using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ISmartDeviceService
    {
        Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page);
        Task Connect(Guid id, string address);
        Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page, Guid propertyId);



    }
}
