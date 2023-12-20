using Business_Layer.IServices;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
	public class ReviewService : IReviewService
	{
		private readonly IReviewRepository _reviewRepository;

		public ReviewService(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<IEnumerable<Review>> GetReviewsByProductId(string productId)
		{
			return await _reviewRepository.GetReviewsByProductId(productId);
		}

		public async Task AddReview(Review review)
		{
			await _reviewRepository.AddReview(review);
		}
	}
}
