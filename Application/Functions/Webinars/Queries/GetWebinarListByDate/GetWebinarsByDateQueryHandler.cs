using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Functions.Webinars.Queries.GetWebinarListByDate;

public class GetWebinarsByDateQueryHandler :
    IRequestHandler<GetWebinarsByDateQuery, PageWebinarByDateViewModel>
{
    private readonly IWebinarRepository webinarRepository;
    private readonly IMapper mapper;

    public GetWebinarsByDateQueryHandler(IWebinarRepository webinarRepository, IMapper mapper)
    {
        this.webinarRepository = webinarRepository;
        this.mapper = mapper;
    }

    public async Task<PageWebinarByDateViewModel> Handle(GetWebinarsByDateQuery request, CancellationToken cancellationToken)
    {
        var list = await this.webinarRepository.GetPagedWebinarsForDate(request.Options, request.Page, request.PageSize, request.Date);
        var webinars = this.mapper.Map<List<WebinarsByDateViewModel>>(list);

        var count = await this.webinarRepository.GetTotalCountOfWebinarsForDate(request.Options, request.Date);
        return new PageWebinarByDateViewModel()
        {
            AllCount = count,
            Webinars = webinars,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
