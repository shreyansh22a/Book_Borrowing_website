using System;
using System.Threading.Tasks;
using Business_Layer.Interfaces;
using DataAccessLayer.IRepository;
using Shared_Layer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Business_Layer.IServices;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		[HttpPost("addtocart")]
		public async Task<IActionResult> AddToCart([FromBody] CartDto cartDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _cartService.AddToCart(cartDto);

			return Ok();
		}

		[HttpGet("getCartItems")]
		public async Task<IActionResult> GetCartItems(string userId)
		{
			var cartItems = await _cartService.GetCartItems(userId);
			return Ok(cartItems);
		}

		[HttpDelete("deleteCartItem/{cartId}")]
		public async Task<IActionResult> DeleteCartItem(Guid cartId)
		{
			await _cartService.DeleteCartItem(cartId);
			return Ok();
		}

		[HttpPost("emptyusercart")]
		public async Task<IActionResult> EmptyUserCart(string userId)
		{
			await _cartService.EmptyUserCart(userId);
			return Ok();
		}
	}
}
