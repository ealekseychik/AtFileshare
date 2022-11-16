namespace AtFileshare.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Login(string username, string password);
        AuthResult Register(string username, string email, string password, string inviteCode);
    }
}
