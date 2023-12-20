using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
	public interface IRatingService
	{
		Task AddRating(Ratings rating);
		Task<double> GetAverageRating(string productId);
	}
}
