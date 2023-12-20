using DataAccessLayer.Models;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
	public interface ICartRepository
	{
		Task<Guid> AddToCart(Cart cart);
		Task<bool> DeleteCartItem(Guid cartId);
		Task<bool> EmptyUserCart(string userId);
		Task<IEnumerable<Cart>> GetCartItems(string userId);
	}
}
