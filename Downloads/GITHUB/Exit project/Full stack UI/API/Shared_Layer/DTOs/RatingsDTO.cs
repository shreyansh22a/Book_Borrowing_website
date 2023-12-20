using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class RatingsDTO
	{
		public Guid RatingID { get; set; }
		public int Rating { get; set; }
		public string ProductId { get; set; }
	}
}
