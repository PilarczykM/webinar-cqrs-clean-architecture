using MediatR;

namespace Application.Functions.Posts.Queries.GetPostsList;

public class GetPostsListQuery : IRequest<List<PostViewModel>>
{
}
