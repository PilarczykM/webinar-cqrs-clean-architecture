using Application.Contracts.Persistence;
using Application.Functions.Categories.Commands;
using Application.Mapper;
using Application.Tests.Mock;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Functions.Categories.Commands;

public class CreateCategoryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;

    public CreateCategoryTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

        var allCategoriesBeforeCount = (await _mockCategoryRepository.Object.GetAllAsync()).Count;

        var response = await handler.Handle(new CreateCategoryCommand()
        { Name = "Test", DisplayName = "Test" }
        , CancellationToken.None);

        var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

        response.Success.ShouldBe(true);
        response.ValidationErrors.Count.ShouldBe(0);
        allCategories.Count.ShouldBe(allCategoriesBeforeCount + 1);
        response.CategoryId.ShouldNotBeNull();

    }
}
