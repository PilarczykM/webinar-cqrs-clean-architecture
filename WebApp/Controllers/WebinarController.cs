using Application.Common;
using Application.Functions.Webinars.Commands.CreateWebinar;
using Application.Functions.Webinars.Commands.DeleteWebinar;
using Application.Functions.Webinars.Commands.UpdateWebinar;
using Application.Functions.Webinars.Queries.GetWebinar;
using Application.Functions.Webinars.Queries.GetWebinarListByDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebinarController : Controller
{
    private readonly IMediator _mediator;

    public WebinarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/getwebinarfordate", Name = "GetPagedWebinarsForDate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PageWebinarByDateViewModel>> GetPagedOrdersForMonth(SearchOptionsWebinars searchOptionsWebinars, int page, int pagesize, DateTime? date)
    {
        var getWebinarForMonthQuery = new GetWebinarsByDateQuery()
        { Date = date, Page = page, PageSize = pagesize, Options = searchOptionsWebinars };
        var pageWebinarsByDateViewModel = await _mediator.Send(getWebinarForMonthQuery);

        return Ok(pageWebinarsByDateViewModel);
    }


    [HttpPost(Name = "AddWebinar")]
    public async Task<ActionResult<int>> Create([FromBody] CreateWebinarCommand createWebinarCommand)
    {
        var result = await _mediator.Send(createWebinarCommand);
        return Ok(result.Id);
    }

    [HttpGet("{id}", Name = "GetWebinar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<WebinarViewModel>> GetWebinarById(int id)
    {
        var result = await _mediator.Send(new GetWebinarQuery() { Id = id });
        return Ok(result);
    }

    [HttpPut(Name = "UpdateWebinar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateWebinarCommand updatePostCommand)
    {
        await _mediator.Send(updatePostCommand);


        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteWebinar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var deletepostCommand = new DeleteWebinarCommand() { WebinarId = id };
        await _mediator.Send(deletepostCommand);
        return NoContent();
    }
}
