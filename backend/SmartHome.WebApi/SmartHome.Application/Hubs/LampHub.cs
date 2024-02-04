using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SmartHome.Application.Hubs
{
    public class LampHub : Hub
    {
        public async Task SendLightData(string lampTopic,float lightStrength, int powerState)
        {
            await Clients.All.SendAsync(lampTopic, lightStrength, powerState);
        }
    }
}
