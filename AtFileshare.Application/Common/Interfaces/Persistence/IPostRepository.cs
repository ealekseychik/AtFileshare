namespace AtFileshare.Application.Common.Interfaces.Persistence
{
    using AtFileshare.Domain.Entities;

    public interface IPostRepository
    {
        void Add(Post post);
    }
}
