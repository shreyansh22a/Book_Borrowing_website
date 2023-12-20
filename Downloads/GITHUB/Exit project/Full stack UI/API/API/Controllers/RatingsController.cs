using System;
using System.Threading.Tasks;
using Business_Layer.IServices;
using DataAccessLayer.Interfaces;
using DataAccessLayer.models;
using Microsoft.AspNetCore.Mvc;
using Shared_Layer.DTOs;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RatingsController : ControllerBase
	{
		private readonly IRatingService _ratingService;

		public RatingsController(IRatingService ratingService)
		{
			_ratingService = ratingService;
		}

		[HttpPost("AddRatings")]
		public async Task<IActionResult> AddRatings([FromBody] RatingsDTO request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid rating request.");
			}

			var rating = new Ratings
			{
				RatingID = Guid.NewGuid(),
				rating = request.Rating,
				productId = request.ProductId
			};

			await _ratingService.AddRating(rating);

			return Ok();
		}

		[HttpGet("GetRating/{productId}")]
		public async Task<IActionResult> GetRating(string productId)
		{
			var averageRating = await _ratingService.GetAverageRating(productId);

			return Ok(averageRating);
		}
	}
}
