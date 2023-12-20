using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class RatingRepository : IRatingRepository
	{
		private readonly APIDbContext _dbContext;

		public RatingRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task AddRating(Ratings rating)
		{
			_dbContext.Rating.Add(rating);
			return _dbContext.SaveChangesAsync();
		}

		public async Task<double> GetAverageRating(string productId)
		{
			var ratings = await _dbContext.Rating.Where(r => r.productId == productId).ToListAsync();

			if (ratings.Count == 0)
			{
				return 0;
			}

			var averageRating = ratings.Average(r => r.rating);
			return averageRating;
		}
	}
}
