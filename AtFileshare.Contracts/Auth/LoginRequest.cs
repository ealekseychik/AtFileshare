namespace AtFileshare.Contracts.Auth
{
    public record LoginRequest(
        string username,
        string password);
}
