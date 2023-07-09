namespace AtFileshare.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string FileLocation { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.MinValue;

        public Guid AuthorId { get; set; } = Guid.Empty;
    }
}
