using AtFileshare.Domain.Entities;

namespace AtFileshare.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
