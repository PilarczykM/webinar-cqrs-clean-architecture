using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Webinars.Queries.GetWebinar;

public class GetWebinarQueryHandler :
            IRequestHandler<GetWebinarQuery, WebinarViewModel>
{
    private readonly IAsyncRepository<Webinar> _webinarRepository;
    private readonly IMapper _mapper;

    public GetWebinarQueryHandler(
        IAsyncRepository<Webinar> webinarRepository,
        IMapper mapper)
    {
        _webinarRepository = webinarRepository;
        _mapper = mapper;
    }

    public async Task<WebinarViewModel> Handle
        (GetWebinarQuery request,
        CancellationToken cancellationToken)
    {
        var webinar = await _webinarRepository.GetByIdAsync(request.Id);
        var webinarMaped = _mapper.Map<WebinarViewModel>(webinar);

        return webinarMaped;
    }
}
