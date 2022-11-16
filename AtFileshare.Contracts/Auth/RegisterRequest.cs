namespace AtFileshare.Contracts.Auth
{
    public record RegisterRequest(
        string username,
        string email,
        string password,
        string inviteCode);
}
