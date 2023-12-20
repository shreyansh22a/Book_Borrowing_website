using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.IRepository;
using Data_Access_Layer.Modals;

using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            // Implementation to get a user by username and password from the database
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User AddUser(User user)
        {


            user.Id = Guid.NewGuid().ToString();
           


            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(string id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
