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
    public class WashingMachineRepository : IWashingMachineRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _washingMachines;
        private readonly DatabaseContext _context;

        public WashingMachineRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _washingMachines = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(WashingMachine device)
        {
            foreach (WashingMachineMode mode in device.Modes)
            {
                WashingMachineModeEntity modeEntity = _mapper.Map<WashingMachineModeEntity>(mode);
                await _context.WashingMachineModes.AddAsync(modeEntity);
            }
            WashingMachineEntity washingMachineEntity = _mapper.Map<WashingMachineEntity>(device);
            await _washingMachines.AddAsync(washingMachineEntity);
            await _context.SaveChangesAsync();
        }

    }

}
