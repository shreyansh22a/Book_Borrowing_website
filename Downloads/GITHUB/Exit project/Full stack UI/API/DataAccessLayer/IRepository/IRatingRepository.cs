using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
	public interface IRatingRepository
	{
		Task AddRating(Ratings rating);
		Task<double> GetAverageRating(string productId);
	}
}
