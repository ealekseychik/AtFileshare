namespace AtFileshare.Contracts.Auth
{
    public record LoginRequest(
        string userName,
        string password);
}
