using Application.Contracts.Persistence;
using Application.Functions.Posts.Commands.DeletePost;
using Application.Mapper;
using Application.Tests.Mock;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;

namespace Application.Tests.Functions.Posts.Commands;

public class DeletePostTest
{
    private readonly Mock<IPostRepository> _mockPostRepository;
    private readonly IMapper _mapper;

    public DeletePostTest()
    {
        _mockPostRepository = RepositoryMocks.GetPostRepository();

        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidPost_DeletedFromPostRepo()
    {
        var random = new Random();
        var handler = new DeletePostCommandHandler(this._mockPostRepository.Object);

        var allPostBefore = (await this._mockPostRepository.Object.GetAllAsync()).ToList();

        var postToDeletion = allPostBefore[random.Next(allPostBefore.Count - 1)];

        var command = new DeletePostCommand() { PostId = postToDeletion.PostId };

        await handler.Handle(command, CancellationToken.None);

        var allPostAfter = (await this._mockPostRepository.Object.GetAllAsync()).ToList();

        allPostAfter.Count.ShouldBe(allPostBefore.Count - 1);
        allPostAfter.ShouldNotContain(postToDeletion);
    }

    [Fact]
    public async Task Handle_Not_ValidPost_NotDeletedFromPostRepo()
    {
        var handler = new DeletePostCommandHandler(this._mockPostRepository.Object);

        var allPostBefore = (await this._mockPostRepository.Object.GetAllAsync()).ToList();

        var postToDeletion = new Post
        {
            PostId = 99999
        };

        var command = new DeletePostCommand() { PostId = postToDeletion.PostId };

        await handler.Handle(command, CancellationToken.None);

        var allPostAfter = (await this._mockPostRepository.Object.GetAllAsync()).ToList();

        allPostAfter.Count.ShouldBe(allPostBefore.Count);
        allPostAfter.ShouldNotContain(postToDeletion);
    }
}
