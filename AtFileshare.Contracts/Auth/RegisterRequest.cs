namespace AtFileshare.Contracts.Auth
{
    public record RegisterRequest(
        string userName,
        string email,
        string password,
        string inviteCode);
}
