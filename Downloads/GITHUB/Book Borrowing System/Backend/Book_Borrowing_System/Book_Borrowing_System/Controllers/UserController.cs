using Microsoft.AspNetCore.Mvc;
using Business_Layer.IServices;
using Shared_Layer.DTOs;
using Data_Access_Layer.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Borrowing_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            // Check if the username already exists
            if (_userService.IsUsernameExists(userDto.Username))
            {
                return Conflict(new { Message = "Username already exists." });
            }

            // Generate a unique identifier and set initial tokens
            string userId = Guid.NewGuid().ToString();
            int initialTokens = 10;

            // Map properties from UserDto to User entity
            var userEntity = new UserDto
            {
                Id = userId,
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password,
                TokensAvailable = initialTokens
            };

            // Save the user to the database
            var createdUser = _userService.CreateUser(userEntity);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var updatedUser = _userService.UpdateUser(id, userDto);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _userService.Authenticate(loginDto.Username, loginDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTcwMTA3MzYyNCwiaWF0IjoxNzAxMDczNjI0fQ.pgu-BQsJ8BjRAAoUdUhfyQHSOrTo71ve5NuauB9DjuY");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            
            
            // Add other user details to the JWT payload as claims
            new Claim("UserId", user.Id),
            new Claim("UserName", user.Name),
            new Claim("TokensAvailabe", user.TokensAvailable.ToString()),
            


             

                    // Add more user details as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var deletedUser = _userService.DeleteUser(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return Ok(deletedUser);
        }

        [HttpPut("update-tokens/{userId}/increment")]
        public IActionResult IncrementUserTokens(string userId)
        {
            var updatedUser = _userService.IncrementUserTokens(userId);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpPut("update-tokens/{userId}/decrement")]
        public IActionResult DecrementUserTokens(string userId)
        {
            var updatedUser = _userService.DecrementUserTokens(userId);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }
    }
}
