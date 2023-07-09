namespace AtFileshare.Infrastructure.Persistence.Repositories
{
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Domain.Entities;

    public class PostRepository : IPostRepository
    {
        private readonly AtFileshareDbContext _dbContext;

        public PostRepository(AtFileshareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Post post)
        {
            _dbContext.AddAsync(post);
            _dbContext.SaveChangesAsync();
        }
    }
}
