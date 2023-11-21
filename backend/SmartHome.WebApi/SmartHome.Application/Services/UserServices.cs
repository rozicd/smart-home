using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
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
        public Task UpdateStatus(User user)
        {
            return _userRepository.UpdateStatus(user);
        }

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetByEmailAndPassword(email, password);
        }

        public async Task GenerateSuperAdmin()
        {
            User superAdmin = await _userRepository.FindSuperAdmin();
            if(superAdmin != null)
            {
                return;
            }
            else
            {
                var newSuperAdmin = new User();
                newSuperAdmin.ProfilePictureUrl = "static/users\\97dbd7a9-5a33-4af1-a277-02910c1f84a0";
                newSuperAdmin.Name = "admin";
                newSuperAdmin.Email = "sanduzicro19@gmail.com";
                newSuperAdmin.Password = GenerateRandomPassword(12);
                newSuperAdmin.Status = Status.INACTIVE;
                newSuperAdmin.Role = Role.SUPERADMIN;
                await _userRepository.Add(newSuperAdmin);
                await _emailService.SendSuperAdminCredentials(newSuperAdmin);
            }
           
        }
        private string GenerateRandomPassword(int length)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                StringBuilder password = new StringBuilder(length);

                foreach (byte byteValue in randomBytes)
                {
                    password.Append(allowedChars[byteValue % allowedChars.Length]);
                }

                return password.ToString();
            }
        }
    }
}
