using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Webinars.Commands.UpdateWebinar;

public class UpdateWebinarCommandHandler : IRequestHandler<UpdateWebinarCommand>
{
    private readonly IMapper mapper;
    private readonly IWebinarRepository webinarRepository;

    public UpdateWebinarCommandHandler(IMapper mapper, IWebinarRepository webinarRepository)
    {
        this.mapper = mapper;
        this.webinarRepository = webinarRepository;
    }
    public async Task<Unit> Handle(UpdateWebinarCommand request, CancellationToken cancellationToken)
    {
        var webinar = this.mapper.Map<Webinar>(request);

        await this.webinarRepository.UpdateAsync(webinar);

        return Unit.Value;
    }
}
