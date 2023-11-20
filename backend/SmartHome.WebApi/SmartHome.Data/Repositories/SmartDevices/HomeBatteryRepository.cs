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
    public class HomeBatteryRepository : IHomeBatteryRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _homeBatteries;
        private readonly DatabaseContext _context;

        public HomeBatteryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _homeBatteries = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(HomeBattery device)
        {
            HomeBatteryEntity homeBatteryEntity = _mapper.Map<HomeBatteryEntity>(device);
            await _homeBatteries.AddAsync(homeBatteryEntity);
            await _context.SaveChangesAsync();
        }

    }

}
