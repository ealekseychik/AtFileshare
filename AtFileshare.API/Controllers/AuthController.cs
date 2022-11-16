namespace AtFileshare.API.Controllers
{
    using AtFileshare.Application.Services.Auth;
    using AtFileshare.Contracts.Auth;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authService.Register(
                request.username,
                request.email,
                request.password,
                request.inviteCode);

            var response = new AuthResult(
                authResult.id,
                authResult.username,
                authResult.email,
                authResult.token);

            return Ok(request);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}
