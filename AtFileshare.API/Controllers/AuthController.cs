namespace AtFileshare.API.Controllers
{
    using AtFileshare.Application.Auth.Commands.Register;
    using AtFileshare.Application.Auth.Queries.Login;
    using AtFileshare.Contracts.Auth;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var authResult = await _sender.Send(command);

            return Ok(_mapper.Map<AuthResponse>(authResult));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _sender.Send(query);

            return Ok(_mapper.Map<AuthResponse>(authResult));
        }
    }
}
