using MediatR;

namespace Application.Functions.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<CreatePostCommandResponse>
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public int Rate { get; set; }
}
