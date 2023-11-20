using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Entities.SmartDevices
{
    public class SolarPanelSystemEntity : SmartDeviceEntity
    {

        List<SolarPanelEntity> SolarPanels { get; set; }
    }
}
