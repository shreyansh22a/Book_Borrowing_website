using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.DTOs
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }
        public bool IsAvailable { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
      
    }

}
