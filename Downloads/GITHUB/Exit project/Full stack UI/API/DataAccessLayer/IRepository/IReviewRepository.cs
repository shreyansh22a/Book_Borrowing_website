using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
	public interface IReviewRepository
	{
		Task<IEnumerable<Review>> GetReviewsByProductId(string productId);
		Task AddReview(Review review);
	}
}
