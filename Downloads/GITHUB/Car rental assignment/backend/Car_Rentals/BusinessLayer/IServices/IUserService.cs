using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(string id);
        Task<UserDTO> AuthenticateUserAsync(string id, string password);
        Task CreateUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(string id, UserDTO userDTO);
        Task DeleteUserAsync(string id);
        bool UserExists(string id);
    }

}