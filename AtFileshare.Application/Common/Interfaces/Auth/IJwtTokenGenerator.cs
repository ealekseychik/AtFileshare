namespace AtFileshare.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName);
    }
}
