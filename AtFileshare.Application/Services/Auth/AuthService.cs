namespace AtFileshare.Application.Services.Auth
{
    using AtFileshare.Application.Common.Interfaces.Auth;

    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthResult Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public AuthResult Register(string userName, string email, string password, string inviteCode)
        {
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, userName);
            return new AuthResult(userId, userName, email, token);
        }
    }
}
