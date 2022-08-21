using FluentValidation;

namespace Application.Functions.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .MinimumLength(2).MaximumLength(15)
            .WithMessage("{PropertName} Length is beewten 2 and 15");
        RuleFor(c => c.DisplayName)
            .MinimumLength(2).MaximumLength(15)
            .WithMessage("{PropertName} Length is beewten 2 and 15");
    }
}
