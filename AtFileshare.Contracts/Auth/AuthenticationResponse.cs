namespace AtFileshare.Contracts.Auth
{
    public record AuthenticationResponse(
        Guid id,
        string username,
        string email,
        string token);
}
