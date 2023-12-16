using AutoMapper;
using InfluxDB.Client.Core.Exceptions;
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
        private readonly DbSet<CarGateEntity> _carGates;
        private readonly DatabaseContext _context;

        public CarGateRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _carGates = context.Set<CarGateEntity>();
            _mapper = mapper;
        }

        public async Task Add(CarGate device)
        {
            CarGateEntity carGateEntity = _mapper.Map<CarGateEntity>(device);
            await _carGates.AddAsync(carGateEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<CarGate> GetById(Guid carGateId)
        {
            CarGateEntity carGateEntity = await _carGates.FirstOrDefaultAsync(carGate => carGate.Id == carGateId);

            if (carGateEntity == null)
            {
                throw new NotFoundException($"Car gate with ID {carGateId} not found");
            }

            CarGate carGate = _mapper.Map<CarGate>(carGateEntity);
            return carGate;
        }

        public async Task Update(CarGate updatedCarGate)
        {
            CarGateEntity carGateEntity = await _carGates.FirstOrDefaultAsync(carGate => carGate.Id == updatedCarGate.Id);

            if (carGateEntity == null)
            {
                throw new NotFoundException($"Car Gate with ID {updatedCarGate.Id} not found");
            }

            carGateEntity.Name = updatedCarGate.Name;
            carGateEntity.AllowedLicensePlates = updatedCarGate.AllowedLicensePlates;
            carGateEntity.Mode = updatedCarGate.Mode;
            carGateEntity.State = updatedCarGate.State;

            await _context.SaveChangesAsync();
        }

    }

}
