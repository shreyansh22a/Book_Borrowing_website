using System.Collections.Generic;
using Business_Layer.IServices;
using Data_Access_Layer.IRepository;
using Shared_Layer.DTOs;

using Data_Access_Layer.Modals;
using Microsoft.EntityFrameworkCore;

namespace Business_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return MapToUserDtoList(users);
        }

        public UserDto GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);
            return MapToUserDto(user);
        }

        public UserDto IncrementUserTokens(string userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            user.TokensAvailable++;
            _userRepository.UpdateUser(user);

            return MapToUserDto(user);
        }

        public UserDto DecrementUserTokens(string userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null || user.TokensAvailable <= 0)
            {
                return null;
            }

            user.TokensAvailable--;
            _userRepository.UpdateUser(user);

            return MapToUserDto(user);
        }
        public User Authenticate(string username, string password)
        {
            // Implement your authentication logic using the repository
            var user = _userRepository.GetUserByUsernameAndPassword(username, password);

            // Check if user credentials are valid
            if (user == null)
            {
                return null; // Authentication failed
            }

            // If you want to include additional checks (e.g., account status, roles, etc.), you can add them here

            return user; // Authentication successful
        }


        public UserDto CreateUser(UserDto userDto)
        {
            var userEntity = MapToUserEntity(userDto);
            var createdUser = _userRepository.AddUser(userEntity);
            return MapToUserDto(createdUser);
        }

        public UserDto UpdateUser(string id, UserDto userDto)
        {
            var existingUser = _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return null; // Handle not found scenario
            }

            // Update existingUser properties with values from userDto
            existingUser.Name = userDto.Name;
            existingUser.Username = userDto.Username;
            existingUser.Password = userDto.Password;
            existingUser.TokensAvailable = userDto.TokensAvailable;
            // Add updates for other properties as needed

            var updatedUser = _userRepository.UpdateUser(existingUser);
            return MapToUserDto(updatedUser);
        }

        public UserDto DeleteUser(string id)
        {
            var deletedUser = _userRepository.DeleteUser(id);
            return MapToUserDto(deletedUser);
        }

        // Helper method for mapping from User entity to UserDto
        private UserDto MapToUserDto(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                TokensAvailable = user.TokensAvailable
                // Add other properties as needed
            };
        }

        // Helper method for mapping from User entities list to List<UserDto>
        private List<UserDto> MapToUserDtoList(IEnumerable<User> users)
        {
            var userDtoList = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = MapToUserDto(user);
                userDtoList.Add(userDto);
            }
            return userDtoList;
        }

        // Helper method for mapping from UserDto to User entity
        private User MapToUserEntity(UserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password,
                TokensAvailable = userDto.TokensAvailable
                // Add other properties as needed
            };
        }
        public bool IsUsernameExists(string username)
        {
            // Example: Check if there's any user with the provided username
            var existingUser = _userRepository.GetByUsername(username);

            return existingUser != null;
        }
    }
}
