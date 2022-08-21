using Application.Contracts.Persistence;
using MediatR;

namespace Application.Functions.Posts.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IPostRepository postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await this.postRepository.GetByIdAsync(request.PostId);
        await this.postRepository.DeleteAsync(post);

        return Unit.Value;
    }
}
