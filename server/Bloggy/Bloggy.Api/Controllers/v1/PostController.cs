using Bloggy.Application.Commands.Posts.Create;
using Bloggy.Application.Commands.Posts.GetAll;
using Bloggy.Application.Commands.Posts.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[Route("api/v1/posts")]
public class PostController(
    IMediator _mediator
) : BloggyControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateRequest request) => Ok(_mediator.Send(request));

    [HttpGet("{postId:guid}")]
    public IActionResult GetById(Guid postId) => Ok(_mediator.Send(new GetByIdRequest(postId)));

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int page,
        [FromQuery] int limit = 3,
        [FromQuery] string category = "",
        [FromQuery] string search = ""
    ) => Ok(_mediator.Send(new GetAllRequest(page, limit, category, search)));
}