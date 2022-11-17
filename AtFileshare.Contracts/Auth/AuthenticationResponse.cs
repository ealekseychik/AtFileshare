namespace AtFileshare.Contracts.Auth
{
    public record AuthenticationResponse(
        Guid id,
        string userName,
        string email,
        string token);
}
