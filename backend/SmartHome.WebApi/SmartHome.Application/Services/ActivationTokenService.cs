using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class ActivationTokenService : IActivationTokenService
    {
        public IActivationTokenRepository _activationTokenRepository { get; set; }

        public ActivationTokenService(IActivationTokenRepository activationTokenRepository)
        {
            _activationTokenRepository = activationTokenRepository;
        }
        public async Task AddOne(Guid id)
        {
            await _activationTokenRepository.AddOne(id);
        }

        public async Task<bool> IsTokenValid(ActivationToken activationToken)
        {
            ActivationToken existingActivationToken = await _activationTokenRepository.GetByUserAndToken(activationToken);
            if(existingActivationToken.expires >= DateTime.Now) {
                return true;
            }
            return false;
        }
    }
}
