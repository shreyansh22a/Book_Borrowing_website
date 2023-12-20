using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
	public interface IOrderRepository
	{
		Task AddOrder(Order order);
		List<Order> GetOrdersByUserId(string userId);
		List<Order> GetAllOrders();
	}
}
