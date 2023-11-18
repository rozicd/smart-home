using SmartHome.Domain.Models;
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
        Task TurnOn(Guid id);
        Task TurnOff(Guid id);



    }
}
