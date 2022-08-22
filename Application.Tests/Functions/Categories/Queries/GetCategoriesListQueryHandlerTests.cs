using Application.Contracts.Persistence;
using Application.Functions.Categories.Queries.GetCategoryList;
using Application.Mapper;
using Application.Tests.Mock;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Functions.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

        var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<CategoryView>>();

        result.Count.ShouldBe(5);
    }
}
