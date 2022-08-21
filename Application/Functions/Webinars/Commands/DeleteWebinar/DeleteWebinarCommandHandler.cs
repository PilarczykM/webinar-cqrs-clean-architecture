using Application.Contracts.Persistence;
using MediatR;

namespace Application.Functions.Webinars.Commands.DeleteWebinar;

public class DeleteWebinarCommandHandler : IRequestHandler<DeleteWebinarCommand>
{
    private readonly IWebinarRepository webinarRepository;

    public DeleteWebinarCommandHandler(IWebinarRepository webinarRepository)
    {
        this.webinarRepository = webinarRepository;
    }

    public async Task<Unit> Handle(DeleteWebinarCommand request, CancellationToken cancellationToken)
    {
        var webinar = await this.webinarRepository.GetByIdAsync(request.WebinarId);

        await this.webinarRepository.DeleteAsync(webinar);

        return Unit.Value;
    }
}
