using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SmartHome.Application.Hubs
{
    public class HomeBatteryHub : Hub
    {
        public async Task SendCurrentLevel(string batteryTopoc, float batteryLevel)
        {
            await Clients.All.SendAsync(batteryTopoc,batteryLevel);
        }
    }
}
