namespace AtFileshare.Application.Auth.Commands.Register
{
    using AtFileshare.Application.Auth.Common;
    using AtFileshare.Application.Common.Interfaces.Auth;
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Domain.Entities;
    using MediatR;

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = command.UserName,
                Email = command.Email,
                Password = command.Password
            };
             _userRepository.AddAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
