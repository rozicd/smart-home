using AutoMapper;
using InfluxDB.Client.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories.SmartDevices
{
    public class HomeBatteryRepository : IHomeBatteryRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<HomeBatteryEntity> _homeBatteries;
        private readonly DatabaseContext _context;

        public HomeBatteryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _homeBatteries = context.Set<HomeBatteryEntity>();
            _mapper = mapper;
        }

        public async Task Add(HomeBattery device)
        {
            HomeBatteryEntity batteryEntity = await _homeBatteries.FirstOrDefaultAsync(sps => sps.PropertyId == device.PropertyId);
            if (batteryEntity != null)
            {
                throw new DeviceAlreadyExistsException($"Property Already Has HomeBattery!");

            }
            HomeBatteryEntity homeBatteryEntity = _mapper.Map<HomeBatteryEntity>(device);
            await _homeBatteries.AddAsync(homeBatteryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeBattery> GetById(Guid id)
        {
            HomeBatteryEntity batteryEntity = await _homeBatteries.FirstOrDefaultAsync(sps => sps.Id == id);

            if (batteryEntity == null)
            {
                throw new NotFoundException($"Solar Panel System with ID {batteryEntity} not found");
            }

            HomeBattery battery = _mapper.Map<HomeBattery>(batteryEntity);
            return battery;
        }
    }

}
