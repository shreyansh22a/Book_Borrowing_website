using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interfaces
{
	public interface IUserService
	{
		Task<RegisterDto> AddUser(RegisterDto userDTO);
		Task<IEnumerable<RegisterDto>> GetAllUsers();
		Task<bool> CheckEmailExists(string email);
		Task<LoginResponseDTO> Login(string email, string password);
		Task<UserDTO> GetUserByEmail(string email);
	}
}
