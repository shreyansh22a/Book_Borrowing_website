using Business_Layer.Interfaces;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using Microsoft.IdentityModel.Tokens;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<RegisterDto> AddUser(RegisterDto userDTO)
		{
			var user = new Register
			{
				ID = Guid.NewGuid(),
				name = userDTO.Name,
				email = userDTO.Email,
				phone =userDTO.phone,
				password = userDTO.Password,
				registrationType = userDTO.RegistrationType
			};

			var addedUser = await _userRepository.AddUser(user);

			return new RegisterDto
			{
				ID = addedUser.ID,
				Name = addedUser.name,
				Email = addedUser.email,
				RegistrationType = addedUser.registrationType
			};
		}

		public async Task<IEnumerable<RegisterDto>> GetAllUsers()
		{
			var users = await _userRepository.GetAllUsers();

			return users.Select(user => new RegisterDto
			{
				ID = user.ID,
				Name = user.name,
				Email = user.email,
				RegistrationType = user.registrationType
			});
		}

		public async Task<bool> CheckEmailExists(string email)
		{
			return await _userRepository.CheckEmailExists(email);
		}

		public async Task<LoginResponseDTO> Login(string email, string password)
		{
			var user = await _userRepository.GetUserByEmail(email);

			if (user == null)
			{
				return new LoginResponseDTO { Message = "User not found" };
			}

			if (user.password != password)
			{
				return new LoginResponseDTO { Message = "Invalid password" };
			}

			var accessToken = GenerateToken(user.email);

			return new LoginResponseDTO { AccessToken = accessToken, RegistrationType = user.registrationType };
		}

		public async Task<UserDTO> GetUserByEmail(string email)
		{
			var user = await _userRepository.GetUserByEmail(email);

			if (user == null)
			{
				return null;
			}

			return new UserDTO
			{
				Id = user.ID,
				name = user.name
			};
		}

		private string GenerateToken(string email)
		{
			var claims = new List<Claim>
	{
		new Claim(ClaimTypes.Email, email),
        // Add additional claims as needed
    };

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzUxMiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXiLCJVc2Vy"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddMinutes(60);

			var token = new JwtSecurityToken(
				issuer: "JWTAuthenticationService",
				audience: "localhost",
				claims: claims,
				expires: expires,
				signingCredentials: creds
			);

			var tokenHandler = new JwtSecurityTokenHandler();
			return tokenHandler.WriteToken(token);
		}

	}
}
