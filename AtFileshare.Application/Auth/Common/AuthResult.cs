namespace AtFileshare.Application.Auth.Common
{
    using AtFileshare.Domain.Entities;

    public record AuthResult(
        User User,
        string Token);
}
