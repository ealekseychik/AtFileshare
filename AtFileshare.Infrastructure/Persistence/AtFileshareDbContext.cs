namespace AtFileshare.Infrastructure.Persistence
{
    using AtFileshare.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AtFileshareDbContext : DbContext
    {
        public AtFileshareDbContext(DbContextOptions<AtFileshareDbContext> options)
            : base(options)
        {
            throw new NotImplementedException();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
