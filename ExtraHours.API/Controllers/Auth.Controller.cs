using ExtraHours.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExtraHours.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);
            if (user == null) return Unauthorized(new { message = "Credenciales incorrectas." });
            return Ok(new { message = "Login exitoso" });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}