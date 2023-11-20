using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<User> Add(User project);
        Task Update(User project);
        Task Delete(Guid id);
        Task<User> GetByEmailAndPassword(string email, string password);

 

    }
}
