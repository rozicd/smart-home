using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories.SmartDevices
{

    public class SprinklerRepository : ISprinklerRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SprinklerEntity> _sprinklers;
        private readonly DbSet<SprinklerScheduleEntity> _sprinklerSchedules;
        private readonly DatabaseContext _context;

        public SprinklerRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _sprinklers = context.Set<SprinklerEntity>();
            _sprinklerSchedules = context.Set<SprinklerScheduleEntity>();
            _mapper = mapper;
        }

        public async Task Add(Sprinkler device)
        {
            SprinklerEntity sprinklerEntity = _mapper.Map<SprinklerEntity>(device);
            await _sprinklers.AddAsync(sprinklerEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<Sprinkler> GetByIdAsync(Guid sprinklerId)
        {
            SprinklerEntity sprinklerEntity = await _sprinklers.FirstOrDefaultAsync(s => s.Id == sprinklerId);

            if (sprinklerEntity == null)
            {
                throw new ResourceNotFoundException($"Sprinkler with ID {sprinklerId} not found");
            }

            return _mapper.Map<Sprinkler>(sprinklerEntity);
        }

        public async Task UpdateAsync(Sprinkler sprinkler)
        {
            var local = _context.Set<SprinklerEntity>()
                        .Local
                        .FirstOrDefault(entry => entry.Id.Equals(sprinkler.Id));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(_mapper.Map<SprinklerEntity>(sprinkler)).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task AddScheduleAsync(Guid sprinklerId, SprinklerSchedule schedule)
        {
            var sprinkler = await _sprinklers.FindAsync(sprinklerId);
            schedule.SprinklerId = sprinklerId;

            if (sprinkler != null)
            {
                _sprinklerSchedules.Add(_mapper.Map<SprinklerScheduleEntity>(schedule));
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ResourceNotFoundException($"Sprinkler with ID {sprinklerId} not found");
            }
        }

        public async Task RemoveScheduleAsync(Guid sprinklerId, Guid scheduleId)
        {
            var scheduleToRemove = await _sprinklerSchedules.FindAsync(scheduleId);

            if (scheduleToRemove == null)
            {
                throw new ResourceNotFoundException($"Schedule with ID {scheduleId} not found");
            }
               
            _sprinklerSchedules.Remove(scheduleToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<SprinklerSchedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            SprinklerScheduleEntity scheduleEntity = await _sprinklerSchedules.FindAsync(scheduleId);

            if (scheduleEntity == null)
            {
                throw new ResourceNotFoundException($"Sprinkler schedule with ID {scheduleId} not found");
            }

            return _mapper.Map<SprinklerSchedule>(scheduleEntity);
        }

        public async Task<List<SprinklerSchedule>> GetSprinklerSchedulesAsync(Guid sprinklerId)
        {
            IQueryable<SprinklerScheduleEntity> query = _sprinklerSchedules;
            query = query.Where(device => device.SprinklerId == sprinklerId);

            return _mapper.Map<List<SprinklerSchedule>>(query.ToList());
        }
    }
}
