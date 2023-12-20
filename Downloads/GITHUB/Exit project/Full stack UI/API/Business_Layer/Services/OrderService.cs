using Business_Layer.IServices;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task AddOrder(Order order)
		{
			await _orderRepository.AddOrder(order);
		}

		public List<Order> GetOrdersByUserId(string userId)
		{
			return _orderRepository.GetOrdersByUserId(userId);
		}

		public List<Order> GetAllOrders()
		{
			return _orderRepository.GetAllOrders();
		}

		
	}
}
