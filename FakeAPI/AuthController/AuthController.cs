using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Static list to store users in memory
        private static List<User> Users = new List<User>();

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            // Check if email already exists
            if (Users.Any(u => u.Email == request.Email))
            {
                return BadRequest(new { message = "Email already registered." });
            }

            // Add new user
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Age = request.Age
            };

            Users.Add(user);

            return Ok(new
            {
                message = "User registered successfully!",
                user = user
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = Users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new
            {
                message = "Login successful!",
                token = "fake-jwt-token-1234567890"
            });
        }

        [HttpPost("signout")]
        public IActionResult SignOut()
        {
            return Ok(new { message = "User signed out successfully!" });
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers([FromQuery] int page = 1)
        {
            return Ok(new
            {
                message = "success",
                page = page,
                users = Users
            });
        }
    }

    // DTO classes
    public class SignupRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    // User model to store in memory
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
