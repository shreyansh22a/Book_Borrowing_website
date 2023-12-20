using System;
using System.Collections.Generic;
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
	public class ReviewController : ControllerBase
	{
		private readonly IReviewService _reviewService;

		public ReviewController(IReviewService reviewService)
		{
			_reviewService = reviewService;
		}

		[HttpGet("GetReviews/{productId}")]
		public async Task<IActionResult> GetReviewsByProductId(string productId)
		{
			var reviews = await _reviewService.GetReviewsByProductId(productId);

			return Ok(reviews);
		}

		[HttpPost("AddReview")]
		public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid review data.");
			}

			var review = new Review
			{
				ID = Guid.NewGuid(),
				review = reviewDTO.review,
				productId = reviewDTO.ProductId,
				userName = reviewDTO.UserName
			};

			await _reviewService.AddReview(review);

			return Ok(review);
		}
	}
}
