using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PGApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Login with username and password
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required");
            }

            // Dummy authentication logic
            if (request.Username == "admin" && request.Password == "password123")
            {
                return Ok(new { message = "Login successful", token = "dummy_jwt_token_12345" });
            }

            return Unauthorized("Invalid credentials");
        }

        /// <summary>
        /// Logout user
        /// </summary>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logout successful" });
        }

        /// <summary>
        /// Check if user is authenticated
        /// </summary>
        [HttpGet("verify")]
        public IActionResult VerifyToken([FromHeader] string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                return Unauthorized("Token is required");
            }

            // Dummy token verification
            if (authorization.Contains("dummy_jwt_token"))
            {
                return Ok(new { message = "Token is valid" });
            }

            return Unauthorized("Invalid token");
        }
    }

    /// <summary>
    /// Login request model
    /// </summary>
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
