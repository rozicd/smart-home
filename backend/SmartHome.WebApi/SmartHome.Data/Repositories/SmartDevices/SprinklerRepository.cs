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
    public class SprinklerRepository : ISprinklerRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _sprinklers;
        private readonly DatabaseContext _context;

        public SprinklerRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _sprinklers = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(Sprinkler device)
        {
            SprinklerEntity sprinklerEntity = _mapper.Map<SprinklerEntity>(device);
            await _sprinklers.AddAsync(sprinklerEntity);
            await _context.SaveChangesAsync();
        }

    }

}
