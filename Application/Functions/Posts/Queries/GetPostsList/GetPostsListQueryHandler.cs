using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Posts.Queries.GetPostsList;

public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostViewModel>>
{
    private readonly IMapper mapper;
    private readonly IPostRepository postRepository;

    public GetPostsListQueryHandler(IMapper mapper, IPostRepository postRepository)
    {
        this.mapper = mapper;
        this.postRepository = postRepository;
    }
    public async Task<List<PostViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
    {
        var all = await postRepository.GetAllAsync();
        var orderedPosts = all.OrderBy(post => post.Date);

        return mapper.Map<List<PostViewModel>>(orderedPosts);
    }
}
