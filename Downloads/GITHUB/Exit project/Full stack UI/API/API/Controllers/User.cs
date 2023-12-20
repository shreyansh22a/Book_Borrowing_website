using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business_Layer.Interfaces;
using Shared_Layer.DTOs;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> AddUser([FromBody] RegisterDto userDto)
		{
			try
			{
				var addedUser = await _userService.AddUser(userDto);
				return Ok(addedUser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var users = await _userService.GetAllUsers();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("CheckEmailExists")]
		public async Task<IActionResult> CheckEmailExists(string email)
		{
			try
			{
				var emailExists = await _userService.CheckEmailExists(email);
				return Ok(emailExists);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(string email, string password)
		{
			try
			{
				var loginResponse = await _userService.Login(email, password);
				return Ok(loginResponse);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetUserByEmail")]
		public async Task<IActionResult> GetUserByEmail(string email)
		{
			try
			{
				var user = await _userService.GetUserByEmail(email);
				if (user == null)
				{
					return NotFound();
				}

				return Ok(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
