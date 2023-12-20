﻿using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
	public interface IUserRepository
	{
		Task<Register> AddUser(Register user);
		Task<IEnumerable<Register>> GetAllUsers();
		Task<bool> CheckEmailExists(string email);
		Task<Register> GetUserByEmail(string email);
	}
}
