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
    public class CarGateRepository : ICarGateRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _carGates;
        private readonly DatabaseContext _context;

        public CarGateRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _carGates = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
        }

        public async Task Add(CarGate device)
        {
            CarGateEntity carGateEntity = _mapper.Map<CarGateEntity>(device);
            await _carGates.AddAsync(carGateEntity);
            await _context.SaveChangesAsync();
        }

    }

}
