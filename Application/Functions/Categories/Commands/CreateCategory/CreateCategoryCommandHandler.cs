using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
    }
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryCommandValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid) return new CreateCategoryCommandResponse(validatorResult);

        var category = this.mapper.Map<Category>(request);
        category = await this.categoryRepository.AddAsync(category);

        return new CreateCategoryCommandResponse(category.CategoryId);
    }
}
