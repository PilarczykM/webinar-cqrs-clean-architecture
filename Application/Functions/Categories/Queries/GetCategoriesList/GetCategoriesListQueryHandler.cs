using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryView>>
{
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
    }
    public async Task<List<CategoryView>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var categories = await this.categoryRepository.GetAllAsync();
        var ordered = categories.OrderBy(category => category.Name);

        return this.mapper.Map<List<CategoryView>>(ordered);
    }
}
