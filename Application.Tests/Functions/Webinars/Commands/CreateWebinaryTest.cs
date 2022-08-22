using Application.Contracts.Persistence;
using Application.Functions.Webinars.Commands.CreateWebinar;
using Application.Mapper;
using Application.Tests.Mock;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Functions.Webinars.Commands;

public class CreateWebinaryTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IWebinarRepository> _mockWebinarRepository;

    public CreateWebinaryTest()
    {
        _mockWebinarRepository = RepositoryMocks.GetWebinarRepository();

        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
        }
        );

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidWebinar_AddedToWebinarRepo()
    {
        var handler = new CreateWebinarCommandHandler
            (_mapper, _mockWebinarRepository.Object);

        var allWebinarsBeforeCount = (await _mockWebinarRepository.Object.GetAllAsync()).Count;

        var command = new CreateWebinarCommand()
        {
            ImageUrl = "TestTest",
            Title = new string('*', 80),
            FacebookEventUrl = "TestTest",
            Date = DateTime.Now.AddDays(-14),
        };

        var response = await handler.Handle(command, CancellationToken.None);

        var allWebinars = await _mockWebinarRepository.Object.GetAllAsync();

        response.Success.ShouldBe(true);
        response.ValidationErrors.Count.ShouldBe(0);
        allWebinars.Count.ShouldBe(allWebinarsBeforeCount + 1);
        response.Id.ShouldNotBeNull();
    }
}
