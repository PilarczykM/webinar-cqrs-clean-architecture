using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPostRepository postRepository;

    public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
    {
        this.mapper = mapper;
        this.postRepository = postRepository;
    }

    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {

        var post = this.mapper.Map<Post>(request);

        post = await this.postRepository.AddAsync(post);

        return post.PostId;
    }
}
