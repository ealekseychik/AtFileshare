namespace AtFileshare.Application.Posts.Commands.CreatePost
{
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Application.Common.Interfaces.Services;
    using AtFileshare.Domain.Entities;
    using MediatR;
    using System;

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IPostRepository _postRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IFileSystemProvider _fileSystemProvider;

        public CreatePostCommandHandler(IPostRepository postRepository, IDateTimeProvider dateTimeProvider, IFileSystemProvider fileSystemProvider)
        {
            _postRepository = postRepository;
            _dateTimeProvider = dateTimeProvider;
            _fileSystemProvider = fileSystemProvider;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Name = request.PostFile.Name,
                FileLocation = _fileSystemProvider.SaveToFileSystem(request.PostFile),
                Created = _dateTimeProvider.UtcNow,
                AuthorId = Guid.Parse(request.AuthorId)
            };
            _postRepository.Add(post);

            return post;
        }
    }
}
