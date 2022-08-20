using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoryList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoyListQuery, List<CategoryView>>
{
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public GetCategoryListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
    }
    public async Task<List<CategoryView>> Handle(GetCategoyListQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync();
        var ordered = categories.OrderBy(category => category.Name);

        return mapper.Map<List<CategoryView>>(ordered);
    }
}