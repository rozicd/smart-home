using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ISmartDeviceActionsService
    {
        Task<SmartDevice> Connect(Guid id);
        Task Disconnect(Guid id);
    }
}
