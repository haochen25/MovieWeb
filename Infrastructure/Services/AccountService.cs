using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService

    {
        public readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> RegisterUser(RegisterModel registerModel)
        {
            var existingUser = await _userRepository.GetUserByEmail(registerModel.Email);
            if (existingUser == null)
            {
                // User with the same email already exists
                return null;
            }
            var salt = getRandomSalt();
            var hashedPassword = getHashedPassword(registerModel.Password, salt);
            var newUser = new User
            {
                Email = registerModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                DateOfBirth = registerModel.DateOfBirth
            };
            await _userRepository.Add(newUser);
            return newUser;
        }

        public async Task<UserInfoModel> ValidateUser(LoginModel loginModel)
        {
            var existingUser = await _userRepository.GetUserByEmail(loginModel.Email);
            if (existingUser == null) 
            {
                return null;
            }
            var hashedPassword = getHashedPassword(loginModel.Password, existingUser.Salt);
            if (hashedPassword.Equals(existingUser.HashedPassword))
            {
               var userInfo = new UserInfoModel
               {
                   Id = existingUser.Id,
                   Email = existingUser.Email,
                   FirstName = existingUser.FirstName,
                   LastName = existingUser.LastName,
                   DateOfBirth = existingUser.DateOfBirth ?? DateTime.MinValue
               };
                return userInfo;
            }
            else
            {
                throw new Exception("invalid password, please try again");
            }
        }
        private string getRandomSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128/8);
            return Convert.ToBase64String(salt);
        }
        private string getHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
