namespace AtFileshare.Contracts.Auth
{
    public record AuthResponse(
        Guid Id,
        string UserName,
        string Email,
        string Token);
}
