using System.Collections.Generic;
using Data_Access_Layer.Modals;
using Shared_Layer.DTOs;

namespace Business_Layer.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        User Authenticate(string username, string password);
        UserDto GetUserById(string id);
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(string id, UserDto userDto);
        UserDto DeleteUser(string id);

        bool IsUsernameExists(string username);

        UserDto IncrementUserTokens(string userId);

        UserDto DecrementUserTokens(string userId);

    }
}
