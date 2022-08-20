using MediatR;

namespace Application.Functions.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryView>>
{
}