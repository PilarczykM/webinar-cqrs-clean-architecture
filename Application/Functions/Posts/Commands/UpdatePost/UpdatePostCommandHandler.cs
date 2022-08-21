using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IMapper mapper;
    private readonly IPostRepository postRepository;

    public UpdatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
    {
        this.mapper = mapper;
        this.postRepository = postRepository;
    }
    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = this.mapper.Map<Post>(request);

        await this.postRepository.UpdateAsync(post);

        return Unit.Value;
    }
}
