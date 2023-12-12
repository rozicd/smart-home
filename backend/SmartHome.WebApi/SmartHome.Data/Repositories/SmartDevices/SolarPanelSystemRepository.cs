using AutoMapper;
using InfluxDB.Client.Core.Exceptions;
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
        private readonly DbSet<SolarPanelSystemEntity> _solarPanelSystems;
        private readonly DatabaseContext _context;

        public SolarPanelSystemRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _solarPanelSystems = context.Set<SolarPanelSystemEntity>();
            _mapper = mapper;
        }

        public async Task Add(SolarPanelSystem device)
        {
            
            SolarPanelSystemEntity solarPanelSystemEntity = _mapper.Map<SolarPanelSystemEntity>(device);
            await _solarPanelSystems.AddAsync(solarPanelSystemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<SolarPanelSystem> GetById(Guid id)
        {
            SolarPanelSystemEntity spsEntity = await _solarPanelSystems.FirstOrDefaultAsync(sps => sps.Id == id);

            if (spsEntity == null)
            {
                throw new NotFoundException($"Solar Panel System with ID {spsEntity} not found");
            }

            SolarPanelSystem sps = _mapper.Map<SolarPanelSystem>(spsEntity);
            return sps;
        }
    }

}
