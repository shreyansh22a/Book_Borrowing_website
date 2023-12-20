using System.Collections.Generic;
using Data_Access_Layer.Modals;

namespace Data_Access_Layer.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string id);
        User GetUserByUsernameAndPassword(string username, string password);

        User GetByUsername(string username);
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(string id);
    }
}
