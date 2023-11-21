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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Add(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }


        public Task<User> GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }


        public Task Update(User user)
        {
            return _userRepository.Update(user);
        }

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetByEmailAndPassword(email, password);
        }

    }
}
