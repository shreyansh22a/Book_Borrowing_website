using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
	public interface IOrderService
	{
		Task AddOrder(Order order);
		List<Order> GetOrdersByUserId(string userId);
		List<Order> GetAllOrders();
		
	}
}
