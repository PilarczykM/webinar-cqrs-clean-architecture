using MediatR;

namespace Application.Functions.Webinars.Queries.GetWebinar;

public class GetWebinarQuery : IRequest<WebinarViewModel>
{
    public int Id { get; set; }
}
