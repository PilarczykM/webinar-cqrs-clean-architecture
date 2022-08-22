using Application.Functions.Posts.Commands.CreatePost;
using Application.Functions.Posts.Commands.DeletePost;
using Application.Functions.Posts.Commands.UpdatePost;
using Application.Functions.Posts.Queries.GetPostDitail;
using Application.Functions.Posts.Queries.GetPostsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllPosts")]
    public async Task<ActionResult<List<PostViewModel>>> GetAllPosts()
    {
        var list = await _mediator.Send(new GetPostsListQuery());
        return Ok(list);
    }

    [HttpGet("{id}", Name = "GetPostById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PostDetailViewModel>> GetPostById(int id)
    {
        var detailViewModel = await _mediator.Send
            (new GetPostDetailQuery() { Id = id });
        return Ok(detailViewModel);
    }

    [HttpPost(Name = "AddPost")]
    public async Task<ActionResult<int>> Create([FromBody] CreatePostCommand createPostCommand)
    {
        var result = await _mediator.Send(createPostCommand);
        return Ok(result.PostId);
    }

    [HttpPut(Name = "UpdatePost")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
    {
        await _mediator.Send(updatePostCommand);


        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeletePost")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var deletepostCommand = new DeletePostCommand() { PostId = id };
        await _mediator.Send(deletepostCommand);
        return NoContent();
    }
}
