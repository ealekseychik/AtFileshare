namespace AtFileshare.Contracts.Post
{
    public record PostResponse(
        Guid Id,
        string Name,
        string FileUrl,
        DateTime Created,
        Guid AuthorId);
}
