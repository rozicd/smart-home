using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartHome.Domain.Models.SmartDevices.CarGate;

namespace SmartHome.DataTransferObjects.Requests
{
    public class ChangeModeDTO
    {
        public CarGateMode NewMode { get; set; }

    }
}
