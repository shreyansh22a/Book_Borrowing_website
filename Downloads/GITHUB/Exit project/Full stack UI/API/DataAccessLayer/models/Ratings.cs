using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.models
{
    public class Ratings
    {
        public Guid RatingID{ get; set; }
        public int rating { get; set; }
        public string productId { get; set; }

    }
}
