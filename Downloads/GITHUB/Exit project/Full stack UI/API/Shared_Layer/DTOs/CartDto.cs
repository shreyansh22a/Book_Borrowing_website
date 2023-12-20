using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class CartDto
	{
		public Guid CartID { get; set; }
		public string UserID { get; set; }
		public string ProductID { get; set; }
		public int ProductQuantity { get; set; }
	}
}
