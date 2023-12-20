using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class CartRepository : ICartRepository
	{
		private readonly APIDbContext _dbContext;

		public CartRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Guid> AddToCart(Cart cart)
		{
			_dbContext.Carts.Add(cart);
			await _dbContext.SaveChangesAsync();
			return cart.CartID;
		}

		public async Task<bool> DeleteCartItem(Guid cartId)
		{
			var cartItem = await _dbContext.Carts.FindAsync(cartId);
			if (cartItem == null)
				return false;

			_dbContext.Carts.Remove(cartItem);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> EmptyUserCart(string userId)
		{
			var cartItems = await _dbContext.Carts.Where(c => c.UserID == userId).ToListAsync();
			if (!cartItems.Any())
				return false;

			_dbContext.Carts.RemoveRange(cartItems);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Cart>> GetCartItems(string userId)
		{
			return await _dbContext.Carts.Where(c => c.UserID == userId).ToListAsync();
		}
	}
}
