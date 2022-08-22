using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<CategoryView>>
{
}