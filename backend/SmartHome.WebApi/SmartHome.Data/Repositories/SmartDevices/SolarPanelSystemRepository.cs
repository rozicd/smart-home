using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories.SmartDevices
{
    public class SolarPanelSystemRepository : ISolarPanelSystemRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _solarPanelSystems;
        private readonly DatabaseContext _context;

        public SolarPanelSystemRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _solarPanelSystems = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(SolarPanelSystem device)
        {
            foreach(SolarPanel solarPanel in device.SolarPanels) {
                SolarPanelEntity solarPanelEntity = _mapper.Map<SolarPanelEntity>(solarPanel);
                await _context.SolarPanels.AddAsync(solarPanelEntity);
            }
            SolarPanelSystemEntity solarPanelSystemEntity = _mapper.Map<SolarPanelSystemEntity>(device);
            await _solarPanelSystems.AddAsync(solarPanelSystemEntity);
            await _context.SaveChangesAsync();
        }

    }

}
