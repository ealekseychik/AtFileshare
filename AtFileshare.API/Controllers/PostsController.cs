namespace AtFileshare.API.Controllers
{
    using AtFileshare.Application.Posts.Commands.CreatePost;
    using AtFileshare.Contracts.Post;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PostsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult CreatePost(CreatePostRequest request)
        {
            var userId = HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == "sub")?
                    .Value ?? string.Empty;

            var command = new CreatePostCommand(
                PostFile: request.Content,
                AuthorId: userId);
            return Ok(request);
        }
    }
}
