using Application.Contracts.Persistence;
using Domain.Entities;

namespace InfrastructureWithEFRegistration.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(EFContext dbContext) : base(dbContext)
    { }

    public Task<bool> IsNameAndAuthorAlreadyExist(string title, string author)
    {
        var matches = _dbContext.Posts.
            Any(a => a.Title.Equals(title) && a.Author.Equals(author));

        return Task.FromResult(matches);
    }
}
