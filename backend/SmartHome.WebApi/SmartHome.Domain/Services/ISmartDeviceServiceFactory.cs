using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ISmartDeviceServiceFactory
    {
        Task<ISmartDeviceActionsService> GetServiceAsync(Guid deviceId);
    }
}
