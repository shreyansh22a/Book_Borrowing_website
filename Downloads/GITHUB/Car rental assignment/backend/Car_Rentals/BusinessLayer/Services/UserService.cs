using BusinessLayer.IServices;
using DataAccessLayer.IRepository;
using DataAccessLayer.modals;
using Microsoft.Extensions.Configuration;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            // Map User to UserDTO
            var userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin
            };

            return userDTO;
        }

        public async Task<UserDTO> AuthenticateUserAsync(string id, string password)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(id, password);
            if (user == null)
            {
                return null;
            }

            // Map User to UserDTO
            var userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin
            };

            return userDTO;
        }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            // Map UserDTO to User and create user
            var user = new User
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                IsAdmin = userDTO.IsAdmin,
                Password=userDTO.Password
                // You may need to add logic for hashing the password here
            };

            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(string id, UserDTO userDTO)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            // Map UserDTO properties to the existing User entity
            existingUser.FirstName = userDTO.FirstName;
            existingUser.LastName = userDTO.LastName;
            existingUser.IsAdmin = userDTO.IsAdmin;

            await _userRepository.UpdateUserAsync(existingUser);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public bool UserExists(string id)
        {
            return _userRepository.UserExists(id);
        }
    }

}