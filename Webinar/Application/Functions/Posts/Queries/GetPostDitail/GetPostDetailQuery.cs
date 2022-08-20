using MediatR;

namespace Application.Functions.Posts.Queries.GetPostDitail;

public class GetPostDetailQuery : IRequest<PostDetailViewModel>
{
    public int Id { get; set; }
}
