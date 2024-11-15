﻿using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class ActivationTokenRepository : IActivationTokenRepository
    {
        private readonly DbSet<ActivationTokenEntity> _activationTokens;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ActivationTokenRepository(DatabaseContext context, IMapper mapper)
        {
            
            _context = context;
            _activationTokens = context.Set<ActivationTokenEntity>();
            _mapper = mapper;
        }

        public async Task<ActivationToken> AddOne(Guid userId)
        {
            ActivationTokenEntity activationTokenEntity = new ActivationTokenEntity();
            activationTokenEntity.UserId = userId;
            activationTokenEntity.Token = Guid.NewGuid().ToString();
            activationTokenEntity.expires = DateTime.Now.AddMinutes(30);

            await _activationTokens.AddAsync(activationTokenEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ActivationToken>(activationTokenEntity);

        }

        public Task DeleteOne(ActivationToken activationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ActivationToken> GetByUserAndToken(ActivationToken activationToken)
        {
            ActivationTokenEntity activationTokenEntity = await _activationTokens.FirstOrDefaultAsync(token => token.UserId == activationToken.UserId && token.Token == activationToken.Token);
            if (activationTokenEntity == null)
            {
                throw new ResourceNotFoundException("Token does not exists for user: " + activationToken.UserId.ToString());
            }
            return _mapper.Map<ActivationToken>(activationTokenEntity);
        }

        public async Task<List<ActivationToken>> GetByUserId(Guid id)
        {
            List<ActivationTokenEntity> activationTokenEntities = await _activationTokens.Where(token => token.UserId == id).ToListAsync();
            List<ActivationToken> activationTokens = activationTokenEntities.Select(token => _mapper.Map<ActivationToken>(token)).ToList();
            return activationTokens;
        }
    }
}
