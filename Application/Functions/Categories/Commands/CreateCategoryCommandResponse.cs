using Application.Common;
using FluentValidation.Results;

namespace Application.Functions.Categories.Commands;

public class CreateCategoryCommandResponse : BaseResponse
{
    public int? CategoryId { get; set; }
    public CreateCategoryCommandResponse() : base() { }
    public CreateCategoryCommandResponse(string message) : base(message) { }
    public CreateCategoryCommandResponse(string message, bool success) : base(message, success) { }
    public CreateCategoryCommandResponse(ValidationResult validationResult) : base(validationResult) { }
    public CreateCategoryCommandResponse(int categoryId)
    {
        CategoryId = categoryId;
    }
}
