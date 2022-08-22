using Application.Common;
using Application.Functions.Categories.Commands;
using Application.Functions.Categories.Queries.GetCategoryList;
using Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryView>>> GetAllCategories()
    {
        var categoryInListViewModel = await _mediator.Send(new GetCategoryListQuery());
        return Ok(categoryInListViewModel);
    }

    [HttpGet("allwithposts", Name = "GetCategoriesWithPosts")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryPostListViewModel>>> GetCategoriesWithPosts
        (SearchCategoryOptions searchOptions)
    {
        GetCategoriesWithPostListQuery getCategoriesListWithPostsQuery =
            new GetCategoriesWithPostListQuery() { searchCategory = searchOptions };

        var dtos = await _mediator.Send(getCategoriesListWithPostsQuery);
        return Ok(dtos);
    }

    [HttpPost(Name = "addCategory")]
    public async Task<ActionResult<CreateCategoryCommandResponse>> Create
        ([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var response = await _mediator.Send(createCategoryCommand);
        return Ok(response);
    }
}
