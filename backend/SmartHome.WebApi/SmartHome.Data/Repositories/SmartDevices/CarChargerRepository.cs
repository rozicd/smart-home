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
    public class CarChargerRepository : ICarChargerRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<CarChargerEntity> _carChargers;
        private readonly DatabaseContext _context;

        public CarChargerRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _carChargers = context.Set<CarChargerEntity>();
            _mapper = mapper;
        }

        public async Task Add(CarCharger device)
        {
            CarChargerEntity carChargerEntity = _mapper.Map<CarChargerEntity>(device);
            await _carChargers.AddAsync(carChargerEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<CarCharger> GetById(Guid id)
        {
            CarChargerEntity chargerEntity = await _carChargers.FirstOrDefaultAsync(sps => sps.Id == id);

            if (chargerEntity == null)
            { 
                throw new NotFoundException($"Solar Panel System with ID {chargerEntity.Id} not found");
            }

            CarCharger charger = _mapper.Map<CarCharger>(chargerEntity);
            return charger;
        }
    }

}
