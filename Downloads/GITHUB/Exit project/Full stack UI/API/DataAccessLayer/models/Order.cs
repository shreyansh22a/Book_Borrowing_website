using DataAccessLayer.models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
	public class Order
	{
		/// <summary>
		public Guid OrderID { get; set; }
		/// </summary>
		public string UserID { get; set; }
		public string productID { get; set; }

		public int productQuantity { get; set; }

		public long TotalMoneyPaid { get; set; }
		public DateTime OrderTime { get; set; }
		public DateTime OrderDate { get; set; }
		// Include other necessary properties
	}
}
