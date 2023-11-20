using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<UserEntity> _users;
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _users = context.Set<UserEntity>();
            _mapper = mapper;
        }

        public async Task<User> Add(User user)
        {
            UserEntity existingUser = await _users.FirstOrDefaultAsync(p => p.Email == user.Email);
            if (existingUser != null)
            {
                throw new EmailAlreadyExistException($"{user.Email} is already in use");
            }
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            string salt = "$2a$12$abcdefghijklmno1234567";
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(userEntity.Password, salt);
            await _users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<User>(userEntity);
        }

        public async Task Delete(Guid id)
        {
            UserEntity userDb = await _users.FirstOrDefaultAsync(p => p.Id == id);
            if (userDb == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            _users.Remove(userDb);
            await _context.SaveChangesAsync();
        }


        public async Task<User> GetById(Guid id)
        {
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == id);
            if (userEntity == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            string salt = "$2a$12$abcdefghijklmno1234567";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Email == email && p.Password == hashedPassword);


            if (userEntity == null)
            {
                throw new ResourceNotFoundException("Wrong Credentials");
            }
            return _mapper.Map<User>(userEntity);

        }

        public async Task Update(User user)
        {
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == user.Id);
            if (userEntity == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            string salt = "$2a$12$abcdefghijklmno1234567";
            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            userEntity.Status = user.Status;
            userEntity.Role = user.Role;
            await _context.SaveChangesAsync();
        }

 /*       public void SeedSuperAdmin()
        {
            if (!_users.Any(u => u.Email == "admin"))
            {
                string randomPassword = GenerateRandomPassword(12);

                var superAdmin = new UserEntity
                {
                    
                };

                context.Users.Add(superAdmin);
                context.SaveChanges();
            }
        }*/
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

