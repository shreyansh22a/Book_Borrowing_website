using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.models
{
	public class Register
	{
		public Guid ID { get; set; }
		public string email { get; set; }
		public string name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
		public string registrationType { get; set; }
	}
}
