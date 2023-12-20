using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Shared_Layer.DTOs;

namespace DataAccess_Layer.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly APIDbContext _dbContext;

		public OrderRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddOrder(Order order)
		{
			_dbContext.Orders.Add(order);
			await _dbContext.SaveChangesAsync();
		}

		public List<Order> GetOrdersByUserId(string userId)
		{
			return _dbContext.Orders
				.Where(o => o.UserID == userId)
				.ToList();
		}

		public List<Order> GetAllOrders()
		{
			return _dbContext.Orders.ToList();
		}

	}
}
