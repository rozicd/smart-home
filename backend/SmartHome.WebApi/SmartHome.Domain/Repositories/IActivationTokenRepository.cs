using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface IActivationTokenRepository
    {
        Task<ActivationToken> AddOne(Guid userId);
        Task DeleteOne(ActivationToken activationToken);
        Task<ActivationToken> GetByUserAndToken(ActivationToken activationToken);
        Task<List<ActivationToken>> GetByUserId(Guid id);
    }
}
