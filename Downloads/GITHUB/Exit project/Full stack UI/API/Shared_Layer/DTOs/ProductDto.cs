using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class ProductDto
	{
		public Guid id { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public int AvailableQuantity { get; set; }
		public string image { get; set; }
		public decimal Discount { get; set; }
		public string Specification { get; set; }
	}
}
