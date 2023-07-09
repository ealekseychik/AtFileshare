namespace AtFileshare.Application.Posts.Commands.CreatePost
{
    using AtFileshare.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public record CreatePostCommand(
        IFormFile PostFile,
        string AuthorId) : IRequest<Post>;
}
