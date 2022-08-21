using Application.Common;
using MediatR;

namespace Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class GetWebinarsByDateQuery : IRequest<PageWebinarByDateViewModel>
    {
        public DateTime? Date { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public SearchOptionsWebinars Options { get; set; }
    }
}
