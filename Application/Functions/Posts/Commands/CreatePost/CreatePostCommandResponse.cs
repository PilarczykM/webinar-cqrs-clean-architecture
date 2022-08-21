using Application.Common;
using FluentValidation.Results;

namespace Application.Functions.Posts.Commands.CreatePost;

public class CreatePostCommandResponse : BaseResponse
{
    public int? PostId { get; set; }

    public CreatePostCommandResponse() : base() { }

    public CreatePostCommandResponse(int? postId) : base()
    {
        this.PostId = postId;
    }
    public CreatePostCommandResponse(string message) : base(message) { }

    public CreatePostCommandResponse(string message, bool success) : base(message, success) { }

    public CreatePostCommandResponse(ValidationResult validationResult) : base(validationResult) { }
}
