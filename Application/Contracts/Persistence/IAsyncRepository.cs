namespace Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync();
    Task DeleteAsync();
    Task<T> UpdateAsync();
}
