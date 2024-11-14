using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services.SmartDevices
{
    public interface IWashingMachineService : ISmartDeviceActionsService, IInfluxReadable
    {
        Task Add(WashingMachine sensor);
        Task<List<WashingMachineMode>> GetWashingMachineModes();
        Task<WashingMachine> GetById(Guid id);
        Task TurnOn(Guid id);
        Task TurnOff(Guid id);
        Task changeMode(LoggedUser loggedUser, string mode, WashingMachine washingMachine);
        Task<WashingMachine> AddScheduledMode(Guid id, WMScheduledMode wmScheduledMode, LoggedUser loggedUser);

    }
}
