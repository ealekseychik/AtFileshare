namespace AtFileshare.Contracts.Auth
{
    public record AuthResponse(
        Guid Id = default!,
        string UserName = default!,
        string Email = default!,
        string Token = default!);
}
