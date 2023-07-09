namespace AtFileshare.Contracts.Post
{
    using Microsoft.AspNetCore.Http;

    public record CreatePostRequest(
        IFormFile Content);
}
