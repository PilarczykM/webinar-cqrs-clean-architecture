using Application.Common;
using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoryListWithPosts;

public class GetCategoriesWithPostListQuery : IRequest<List<CategoryPostListViewModel>>
{
    public SearchCategoryOptions searchCategory { get; set; }
}
