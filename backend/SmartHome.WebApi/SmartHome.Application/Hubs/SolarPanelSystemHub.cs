using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SmartHome.Application.Hubs
{
    public class SolarPanelSystemHub : Hub
    {
        public async Task SendChargePerMinute(string spsTopic, float charge)
        {
            await Clients.All.SendAsync(spsTopic, charge);
        }
    }
}
