using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class ReviewDTO
	{
		public string review { get; set; }

		public string ProductId { get; set; }

		public string UserName { get; set; }
	}
}
