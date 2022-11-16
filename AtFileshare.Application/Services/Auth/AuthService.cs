namespace AtFileshare.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public AuthResult Register(string username, string email, string password, string inviteCode)
        {
            return new AuthResult(Guid.NewGuid(), username, email, password);
        }
    }
}
