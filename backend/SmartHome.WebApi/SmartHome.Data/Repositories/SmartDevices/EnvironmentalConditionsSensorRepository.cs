using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmartHome.Data.Repositories.SmartDevices
{
    public class EnvironmentalConditionsSensorRepository : IEnvironmentalConditionsSensorRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _environmentalConditionsSensors;
        private readonly DatabaseContext _context;

        public EnvironmentalConditionsSensorRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _environmentalConditionsSensors = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(EnvironmentalConditionsSensor device)
        {
           
            EnvironmentalConditionsSensorEntity sensorEntity = _mapper.Map<EnvironmentalConditionsSensorEntity>(device);
            await _environmentalConditionsSensors.AddAsync(sensorEntity);
            await _context.SaveChangesAsync();
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




    }
}
