using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.models
{
    public class Review
    {

        public Guid ID { get; set; }
        public string review{ get; set; }
        public string productId { get; set; }
        public string userName { get; set; }

    }
}
