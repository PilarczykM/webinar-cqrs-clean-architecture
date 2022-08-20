using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoryList;

public class GetCategoyListQuery : IRequest<List<CategoryView>>
{
}