using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class OrderDto
	{
		public Guid OrderID { get; set; }
		public string UserID { get; set; }
		public string ProductID { get; set; }
		public int ProductQuantity { get; set; }
		public DateTime OrderTime { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
