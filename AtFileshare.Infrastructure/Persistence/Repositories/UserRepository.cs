namespace AtFileshare.Infrastructure.Persistence.Repositories
{
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Domain.Entities;

    public class UserRepository : IUserRepository
    {
        private readonly AtFileshareDbContext _dbContext;

        public UserRepository(AtFileshareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public async void AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            _dbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.SingleOrDefault(u => u.Email == email);
        }
    }
}
