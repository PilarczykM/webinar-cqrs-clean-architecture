using Application.Common;
using FluentValidation.Results;

namespace Application.Functions.Webinars.Commands.CreateWebinar;

public class CreateWebinarCommandResponse : BaseResponse
{
    public int? Id { get; set; }

    public CreateWebinarCommandResponse() : base()
    { }

    public CreateWebinarCommandResponse(ValidationResult validationResult)
        : base(validationResult)
    { }

    public CreateWebinarCommandResponse(string message)
    : base(message)
    { }

    public CreateWebinarCommandResponse(string message, bool success)
        : base(message, success)
    { }

    public CreateWebinarCommandResponse(int webinarId)
    {
        Id = webinarId;
    }
}