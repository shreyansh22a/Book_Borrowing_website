using DataAccessLayer.models;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Cart
    {
        public Guid CartID { get; set; }
        public string UserID { get; set; }

        public string productId { get; set; }
        public int productQuantity { get; set; }
   
        

        // Include other necessary properties
    }
}
