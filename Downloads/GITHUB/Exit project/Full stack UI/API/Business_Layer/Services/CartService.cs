using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer.Interfaces;
using Business_Layer.IServices;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Shared_Layer.DTOs;

namespace Business_Layer.Services
{
	public class CartService : ICartService
	{
		private readonly ICartRepository _cartRepository;

		public CartService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public async Task<Guid> AddToCart(CartDto cartDto)
		{
			var cart = new Cart
			{
				CartID = Guid.NewGuid(),
				UserID = cartDto.UserID,
				productId = cartDto.ProductID,
				productQuantity = cartDto.ProductQuantity
			};

			return await _cartRepository.AddToCart(cart);
		}

		public async Task<bool> DeleteCartItem(Guid cartId)
		{
			return await _cartRepository.DeleteCartItem(cartId);
		}

		public async Task<bool> EmptyUserCart(string userId)
		{
			return await _cartRepository.EmptyUserCart(userId);
		}

		public async Task<IEnumerable<CartDto>> GetCartItems(string userId)
		{
			var cartItems = await _cartRepository.GetCartItems(userId);

			return cartItems.Select(cart => new CartDto
			{
				CartID=cart.CartID,
				UserID = cart.UserID,
				ProductID = cart.productId,
				ProductQuantity = cart.productQuantity
			});
		}
	}
}
