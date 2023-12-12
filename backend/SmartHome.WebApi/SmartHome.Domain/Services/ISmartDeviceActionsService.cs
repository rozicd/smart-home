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
        Task<SmartDevice> TurnOn(Guid id);
        Task TurnOff(Guid id);
    }
}
