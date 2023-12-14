using Bloggy.Application.Commands.Posts.Create;
using Bloggy.Application.Commands.Posts.GetAll;
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

    [HttpGet]
    public IActionResult GetAll() => Ok(_mediator.Send(new GetAllRequest(0,0)));
}