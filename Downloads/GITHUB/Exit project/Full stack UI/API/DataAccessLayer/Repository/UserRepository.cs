using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly APIDbContext _dbContext;

		public UserRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Register> AddUser(Register user)
		{
			_dbContext.Registers.Add(user);
			await _dbContext.SaveChangesAsync();
			return user;
		}

		public async Task<IEnumerable<Register>> GetAllUsers()
		{
			return await _dbContext.Registers.ToListAsync();
		}

		public async Task<bool> CheckEmailExists(string email)
		{
			return await _dbContext.Registers.AnyAsync(u => u.email == email);
		}

		public async Task<Register> GetUserByEmail(string email)
		{
			return await _dbContext.Registers.FirstOrDefaultAsync(u => u.email == email);
		}
	}
}
