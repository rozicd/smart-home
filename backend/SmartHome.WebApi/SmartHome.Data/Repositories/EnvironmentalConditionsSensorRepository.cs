using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class EnvironmentalConditionsSensorRepository : IEnvironmentalConditionsSensorRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<EnvironmentalConditionsSensorEntity> _environmentalConditionsSensors;
        private readonly DatabaseContext _context;

        public EnvironmentalConditionsSensorRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _environmentalConditionsSensors = context.Set<EnvironmentalConditionsSensorEntity>();
            _mapper = mapper;
        }

        public async Task Add(EnvironmentalConditionsSensor device)
        {
            EnvironmentalConditionsSensorEntity sensorEntity = _mapper.Map<EnvironmentalConditionsSensorEntity>(device);
            await _environmentalConditionsSensors.AddAsync(sensorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EnvironmentalConditionsSensor>> GetSmartDevicesByUserId(Guid userId)
        {
            var sensors = await _environmentalConditionsSensors
                .Where(s => s.UserId == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EnvironmentalConditionsSensor>>(sensors);
        }


        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            var sensor = await _environmentalConditionsSensors.FirstOrDefaultAsync(s => s.Id == id);
            if (sensor == null)
            {
                throw new ResourceNotFoundException($"EnvironmentalConditionsSensor with Id {id} not found.");
            }
            return _mapper.Map<EnvironmentalConditionsSensor>(sensor);
        }

        public async Task Update(EnvironmentalConditionsSensor device)
        {
            var existingSensor = await _environmentalConditionsSensors.FirstOrDefaultAsync(s => s.Id == device.Id);
            if (existingSensor == null)
            {
                throw new ResourceNotFoundException($"EnvironmentalConditionsSensor with Id {device.Id} not found.");
            }

            _mapper.Map(device, existingSensor);
            await _context.SaveChangesAsync();
        }

        public async Task Connect(Guid id)
        {
            // Implementation for Connect
        }
    }
}
