using Application.Common;
using Application.Contracts.Persistence;
using Application.Functions.Posts.Commands.CreatePost;
using Application.Mapper;
using Application.Tests.Mock;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Functions.Posts.Commands;

public class CreatePostTest
{
	private readonly Mock<IPostRepository> _mockPostRepository;
	private readonly IMapper _mapper;

	public CreatePostTest()
	{
		_mockPostRepository = RepositoryMocks.GetPostRepository();

		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfiles>();
		});

		_mapper = configurationProvider.CreateMapper();
	}

	[Fact]
	public async Task Handle_ValidPost_AddedToPostRepo()
	{
		var handler = new CreatePostCommandHandler(this._mapper, this._mockPostRepository.Object);

		var allPostBeforeCount = (await this._mockPostRepository.Object.GetAllAsync()).Count;

		var command = new CreatePostCommand()
		{
			Title = "TestTest",
			Date = DateTime.Now.AddDays(-14),
			Rate = 9,
			Author = "AAAA"
		};

		var response = await handler.Handle(command, CancellationToken.None);

		var allPosts = await this._mockPostRepository.Object.GetAllAsync();

		response.Success.ShouldBe(true);
		response.Status.ShouldBe(ResponseStatus.Success);
		response.PostId.ShouldNotBeNull();
		response.ValidationErrors.Count.ShouldBe(0);
		allPosts.Count.ShouldBe(allPostBeforeCount + 1);
	}

	[Fact]
	public async Task Handle_Not_ValidPost_TooLongTitle_81Characters_NotAddedToPostRepo()
	{
		var handler = new CreatePostCommandHandler(this._mapper, this._mockPostRepository.Object);

		var allPostBeforeCount = (await this._mockPostRepository.Object.GetAllAsync()).Count;

		var command = new CreatePostCommand()
		{
			Title = new string('*', 81),
			Date = DateTime.Now.AddDays(-14),
			Rate = 9,
			Author = "AAAA"
		};

		var response = await handler.Handle(command, CancellationToken.None);

		var allPosts = await this._mockPostRepository.Object.GetAllAsync();

		response.Success.ShouldBe(false);
		response.Status.ShouldBe(ResponseStatus.ValidationError);
		response.PostId.ShouldBeNull();
		response.ValidationErrors.Count.ShouldBe(1);
		allPosts.Count.ShouldBe(allPostBeforeCount);
	}

	[Fact]
	public async Task Handle_Not_ValidPost_FutureDate_2DayIntoTheFuture_NotAddedToPostRepo()
	{
		var handler = new CreatePostCommandHandler
			(this._mapper, this._mockPostRepository.Object);

		var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

		var command = new CreatePostCommand()
		{
			Title = new string('*', 80),
			Date = DateTime.Now.AddDays(2),
			Rate = 9,
			Author = "AAAA"
		};

		var response = await handler.Handle(command, CancellationToken.None);

		var allPosts = await _mockPostRepository.Object.GetAllAsync();

		response.Success.ShouldBe(false);
		response.Status.ShouldBe(ResponseStatus.ValidationError);
		response.ValidationErrors.Count.ShouldBe(1);
		allPosts.Count.ShouldBe(allPostsBeforeCount);
		response.PostId.ShouldBeNull();
	}

	[Fact]
	public async Task Handle_Not_ValidPost_RateToBig_NotAddedToPostRepo()
	{
		var handler = new CreatePostCommandHandler
			(this._mapper, this._mockPostRepository.Object);

		var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

		var command = new CreatePostCommand()
		{
			Title = new string('*', 80),
			Date = DateTime.Now.AddDays(2),
			Rate = 9,
			Author = "AAAA"
		};

		var response = await handler.Handle(command, CancellationToken.None);

		var allPosts = await _mockPostRepository.Object.GetAllAsync();

		response.Success.ShouldBe(false);
		response.Status.ShouldBe(ResponseStatus.ValidationError);
		response.ValidationErrors.Count.ShouldBe(1);
		allPosts.Count.ShouldBe(allPostsBeforeCount);
		response.PostId.ShouldBeNull();
	}
}
