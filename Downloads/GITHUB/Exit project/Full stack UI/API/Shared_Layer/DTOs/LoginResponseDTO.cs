using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Layer.DTOs
{
	public class LoginResponseDTO
	{
		public string AccessToken { get; set; }
		public string RegistrationType { get; set; }
		public string Message { get; set; }
	}
}
