using MediatR;

namespace Application.Functions.Posts.Commands.DeletePost;

public class DeletePostCommand : IRequest
{
    public int PostId { get; set; }
}
