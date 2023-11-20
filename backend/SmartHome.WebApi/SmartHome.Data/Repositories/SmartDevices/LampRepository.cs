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
    public class LampRepository : ILampRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _lamps;
        private readonly DatabaseContext _context;

        public LampRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _lamps = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(Lamp device)
        {
            LampEntity lampEntity = _mapper.Map<LampEntity>(device);
            await _lamps.AddAsync(lampEntity);
            await _context.SaveChangesAsync();
        }
    }

}
