namespace AtFileshare.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Login(string userName, string password);
        AuthResult Register(string userName, string email, string password, string inviteCode);
    }
}
