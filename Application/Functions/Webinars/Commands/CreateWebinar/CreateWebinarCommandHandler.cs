using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Functions.Webinars.Commands.CreateWebinar;

public class CreateWebinarCommandHandler : IRequestHandler<CreateWebinarCommand, CreateWebinarCommandResponse>
{
    private readonly IMapper mapper;
    private readonly IWebinarRepository webinarRepository;

    public CreateWebinarCommandHandler(IMapper mapper, IWebinarRepository webinarRepository)
    {
        this.mapper = mapper;
        this.webinarRepository = webinarRepository;
    }
    public async Task<CreateWebinarCommandResponse> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateWebinarCommandValidator();
        var validatorResulr = await validator.ValidateAsync(request);

        if (!validatorResulr.IsValid) return new CreateWebinarCommandResponse(validatorResulr);

        var webinar = this.mapper.Map<Webinar>(request);

        webinar = await this.webinarRepository.AddAsync(webinar);

        return new CreateWebinarCommandResponse(webinar.Id);
    }
}
