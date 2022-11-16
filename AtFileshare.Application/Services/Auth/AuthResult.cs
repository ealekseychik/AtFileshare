namespace AtFileshare.Application.Services.Auth
{
    public record AuthResult(
        Guid id,
        string username,
        string email,
        string token);
}
