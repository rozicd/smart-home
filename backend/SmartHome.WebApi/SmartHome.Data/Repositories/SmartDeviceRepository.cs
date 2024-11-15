﻿using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using SmartHome.Data.Entities;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class SmartDeviceRepository : ISmartDeviceRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<SmartDeviceEntity> _smartDevices;
        private readonly DbSet<PropertyEntity> _properties;
        private readonly DbSet<UserEntity> _users;
        private readonly DatabaseContext _context;
        public SmartDeviceRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _smartDevices = context.Set<SmartDeviceEntity>();
            _mapper = mapper;
            _properties = context.Set<PropertyEntity>();
            _users = context.Set<UserEntity>();
        }
       

        public async Task Connect(Guid id, string address)
        {
            var sensor = await _smartDevices.FirstOrDefaultAsync(s => s.Id == id);
            if (sensor == null)
            {
                throw new ResourceNotFoundException($"EnvironmentalConditionsSensor with Id {id} not found.");
            }
            sensor.Connection = address;
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page)
        {
            IQueryable<SmartDeviceEntity> query = _smartDevices;


            var queryWithCountForDevices = new
            {
                TotalCount = _smartDevices.Count(),
                Devices = query
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                    .ToList()
            };

            PaginationReturnObject<SmartDevice> result = new PaginationReturnObject<SmartDevice>(
                _mapper.Map<IEnumerable<SmartDevice>>(queryWithCountForDevices.Devices),
                page.PageNumber,
                page.PageSize,
                queryWithCountForDevices.TotalCount
            );


            return result;
        }

        public async Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page,Guid propertyId)
        {
            IQueryable<SmartDeviceEntity> query = _smartDevices;

            query = query.Where(device => device.PropertyId == propertyId);

            var queryWithCountForDevices = new
            {

                TotalCount = query.Count(),
                Devices = query
                .OrderByDescending(device => device) 
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                    .ToList()
            };

            PaginationReturnObject<SmartDevice> result = new PaginationReturnObject<SmartDevice>(
                _mapper.Map<IEnumerable<SmartDevice>>(queryWithCountForDevices.Devices),
                page.PageNumber,
                page.PageSize,
                queryWithCountForDevices.TotalCount
            );


            return result;
        }

        public async Task<List<SmartDevice>> GetAllFromPropertyNoPage(Guid propertyId)
        {
           List<SmartDeviceEntity> devices = await _smartDevices
            .Where(device => device.PropertyId == propertyId)
            .ToListAsync();

            return _mapper.Map<List<SmartDevice>>(devices);
        }

        public async Task<SmartDevice> TurnOn(Guid id)
        {
            var existingDevice = await _smartDevices.FirstOrDefaultAsync(s => s.Id == id);
            if (existingDevice == null)
            {
                throw new ResourceNotFoundException($"SmartDevice with Id {id} not found.");
            }
            existingDevice.DeviceStatus = DeviceStatus.ONLINE;
            await _context.SaveChangesAsync();
            return (_mapper.Map<SmartDevice>(existingDevice));
        }

        public async Task<SmartDevice> TurnOff(Guid id)
        {
            SmartDeviceEntity existingDevice = null;
            try
            {
                existingDevice = await _smartDevices.FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (existingDevice == null)
            {
                throw new ResourceNotFoundException($"SmartDevice with Id {id} not found.");
            }
            if (existingDevice.DeviceStatus == DeviceStatus.OFFLINE)
            {

                return null;
            }
            existingDevice.DeviceStatus = DeviceStatus.OFFLINE;
            await _context.SaveChangesAsync();
            return (_mapper.Map<SmartDevice>(existingDevice));
        }

        public async Task<string> GetDeviceType(Guid deviceId)
        {
            var smartDevice = await _context.SmartDevices.FindAsync(deviceId);

            Console.WriteLine(smartDevice.Type);
            if (smartDevice != null)
            {
                return smartDevice.Type;
            }

            return null; 
        }

        public async Task<User> addUserPermission(Guid id, string email)
        {
            var smartDevice = await _smartDevices.FirstOrDefaultAsync(s=> s.Id == id);
            var userEntity = await _users.FirstOrDefaultAsync(s=> s.Email == email);
            if(userEntity == null)
            {
                throw new ResourceNotFoundException($"User with email: {email} was not found");
            }
            if(!smartDevice.SharedUsers.Contains(userEntity))
            {
                var property = await _properties.FirstOrDefaultAsync(p => p.Id == smartDevice.PropertyId);
                smartDevice.SharedUsers.Add(userEntity);
                if (!property.SharedUsers.Contains(userEntity)){
                    property.SharedUsers.Add(userEntity); 
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> removeUserPermission(Guid id, string email)
        {
            var smartDevice = await _smartDevices.FirstOrDefaultAsync(s => s.Id == id);
            var userEntity = await _users.FirstOrDefaultAsync(s => s.Email == email);
            if (userEntity == null)
            {
                throw new ResourceNotFoundException($"User with email: {email} was not found");
            }
            smartDevice.SharedUsers.Remove(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<User>(userEntity);
        }

        public async Task<SmartDevice> getById(Guid id)
        {
            var smartDeviceEntity = await  _smartDevices.FirstOrDefaultAsync(s => s.Id == id);
            if (smartDeviceEntity == null) 
            {
                throw new ResourceNotFoundException($"Smart device with Id: {id} was not found");
            }
            SmartDevice smart = _mapper.Map<SmartDevice>(smartDeviceEntity);
            return smart;
        }
    }
}
