using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
	public interface ICartService
	{
		Task<Guid> AddToCart(CartDto cartDto);
		Task<bool> DeleteCartItem(Guid cartId);
		Task<bool> EmptyUserCart(string userId);
		Task<IEnumerable<CartDto>> GetCartItems(string userId);
	}
}
