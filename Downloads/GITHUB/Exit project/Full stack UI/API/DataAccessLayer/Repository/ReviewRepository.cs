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
	public class ReviewRepository : IReviewRepository
	{
		private readonly APIDbContext _dbContext;

		public ReviewRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Review>> GetReviewsByProductId(string productId)
		{
			return await _dbContext.Reviews
				.Where(r => r.productId == productId)
				.ToListAsync();
		}

		public async Task AddReview(Review review)
		{
			_dbContext.Reviews.Add(review);
			await _dbContext.SaveChangesAsync();
		}
	}
}
