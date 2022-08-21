using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPostRepository : IAsyncRepository<Post>
{
    Task<bool> IsNameAndAuthorAlreadyExist(string? title, string? author);
}
