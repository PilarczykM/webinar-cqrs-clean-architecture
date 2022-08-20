using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IPostRepository : IAsyncRepository<Post>
{
}
