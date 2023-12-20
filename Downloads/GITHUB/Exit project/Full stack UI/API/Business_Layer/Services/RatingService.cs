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
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository _ratingRepository;

		public RatingService(IRatingRepository ratingRepository)
		{
			_ratingRepository = ratingRepository;
		}

		public Task AddRating(Ratings rating)
		{
			return _ratingRepository.AddRating(rating);
		}

		public Task<double> GetAverageRating(string productId)
		{
			return _ratingRepository.GetAverageRating(productId);
		}
	}
}
