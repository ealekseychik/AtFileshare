namespace AtFileshare.Application.Common.Interfaces.Persistence
{
    using AtFileshare.Domain.Entities;

    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
        void AddAsync(User user);
    }
}
