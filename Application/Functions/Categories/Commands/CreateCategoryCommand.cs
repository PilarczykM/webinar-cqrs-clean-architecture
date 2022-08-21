using MediatR;

namespace Application.Functions.Categories.Commands;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }
}
