namespace AtFileshare.Application.Services.Auth
{
    public record AuthResult(
        Guid id,
        string userName,
        string email,
        string token);
}
