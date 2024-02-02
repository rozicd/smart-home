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
    public class WashingMachineRepository : IWashingMachineRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<WashingMachineEntity> _washingMachines;
        private readonly DbSet<WashingMachineModeEntity> _washingMachineModes;
        private readonly DatabaseContext _context;

        public WashingMachineRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _washingMachines = context.Set<WashingMachineEntity>();
            _washingMachineModes = context.Set<WashingMachineModeEntity>();
            _mapper = mapper;
        }

        public async Task Add(WashingMachine device)
        {
            WashingMachineEntity washingMachineEntity = _mapper.Map<WashingMachineEntity>(device);
            washingMachineEntity.Modes = _washingMachineModes.ToList();
            await _washingMachines.AddAsync(washingMachineEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<WashingMachine> getById(Guid id)
        {
            WashingMachineEntity washingMachineEntity = await _washingMachines.FirstOrDefaultAsync(wm => wm.Id == id);
            if(washingMachineEntity == null)
            {
                throw new ResourceNotFoundException($"Washing machine with id: {id} was not found");
            }
            return _mapper.Map<WashingMachine>(washingMachineEntity);

        }

        public async Task<List<WashingMachineMode>> GetWashingMachineModes()
        {

            var washingMachineModesEntities = await _washingMachineModes.ToListAsync();
            var washingMachineModes = washingMachineModesEntities.Select(entity => _mapper.Map<WashingMachineMode>(entity)).ToList();

            return washingMachineModes;
        }
    }

}
