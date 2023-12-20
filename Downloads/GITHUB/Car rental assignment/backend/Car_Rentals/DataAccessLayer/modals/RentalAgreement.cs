using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.modals
{
    public class RentalAgreement
    {
        public Guid Id { get; set; }
       
        public string CarId { get; set; }
        public string UserId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsAccepted { get; set; }
        public string RequestToReturn { get; set; }
        
        // Add other properties as needed
    }

}
