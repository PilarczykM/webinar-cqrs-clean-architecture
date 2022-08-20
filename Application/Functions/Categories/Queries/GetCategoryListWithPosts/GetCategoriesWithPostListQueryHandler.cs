using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoryListWithPosts;

public class GetCategoriesWithPostListQueryHandler : IRequestHandler<GetCategoriesWithPostListQuery, List<CategoryPostListViewModel>>
{
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public GetCategoriesWithPostListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
    }
    public async Task<List<CategoryPostListViewModel>> Handle(GetCategoriesWithPostListQuery request, CancellationToken cancellationToken)
    {
        var all = await this.categoryRepository.GetCategoriesWithPost(request.searchCategory);

        return this.mapper.Map<List<CategoryPostListViewModel>>(all);
    }
}
