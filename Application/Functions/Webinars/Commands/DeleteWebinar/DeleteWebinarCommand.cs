using MediatR;

namespace Application.Functions.Webinars.Commands.DeleteWebinar;

public class DeleteWebinarCommand : IRequest
{
    public int WebinarId { get; set; }
}
