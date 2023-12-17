using AutoMapper;
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
    public class AirConditionerRepository : IAirConditionerRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _airConditioners;
        private readonly DatabaseContext _context;

        public AirConditionerRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _airConditioners = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(AirConditioner device)
        {
            AirConditionerEntity airConditionerEntity = _mapper.Map<AirConditionerEntity>(device);
            await _airConditioners.AddAsync(airConditionerEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<AirConditioner> GetById(Guid id)
        {
            var airConditioner = await _airConditioners.FirstOrDefaultAsync(ac => ac.Id == id);
            if (airConditioner == null)
            {
                throw new ResourceNotFoundException($"AC with Id {id} not found.");
            }
            return _mapper.Map<AirConditioner>(airConditioner);

        }
    }

}
