using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
{
    private readonly IMapper mapper;
    private readonly IPostRepository postRepository;

    public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
    {
        this.mapper = mapper;
        this.postRepository = postRepository;
    }

    public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostCommandValidator(this.postRepository);
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid) return new CreatePostCommandResponse(validatorResult);

        var post = this.mapper.Map<Post>(request);

        post = await this.postRepository.AddAsync(post);

        return new CreatePostCommandResponse(post.PostId);
    }
}
