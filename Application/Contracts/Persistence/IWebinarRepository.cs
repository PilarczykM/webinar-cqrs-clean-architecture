using Application.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IWebinarRepository : IAsyncRepository<Webinar>
{
    Task<int> GetTotalCountOfWebinarsForDate(SearchOptionsWebinars options, DateTime? date);
    Task<List<Webinar>> GetPagedWebinarsForDate(SearchOptionsWebinars options, int page, int pageSize, DateTime? date);
}
