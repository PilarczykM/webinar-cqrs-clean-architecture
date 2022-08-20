using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Posts.Queries.GetPostDitail;

public class GetPostDetailQuestyHandler : IRequestHandler<GetPostDetailQuery, PostDetailViewModel>
{
    private readonly IMapper mapper;
    private readonly IPostRepository postRepository;
    private readonly ICategoryRepository categoryRepository;

    public GetPostDetailQuestyHandler(IMapper mapper, IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.postRepository = postRepository;
        this.categoryRepository = categoryRepository;
    }

    public async Task<PostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
    {
        var post = await this.postRepository.GetByIdAsync(request.Id);
        var postDetail = this.mapper.Map<PostDetailViewModel>(post);

        var category = await this.categoryRepository.GetByIdAsync(post.CategoryId);
        postDetail.Category = this.mapper.Map<CategoryDto>(category);

        return postDetail;
    }
}
