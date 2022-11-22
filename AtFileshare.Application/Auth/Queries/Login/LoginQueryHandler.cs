namespace AtFileshare.Application.Auth.Queries.Login
{
    using AtFileshare.Application.Auth.Common;
    using AtFileshare.Application.Common.Interfaces.Auth;
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new Exception("Could not find user specified!");
            }

            if (user.Password != query.Password)
            {
                throw new Exception("Could not find user specified!");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
