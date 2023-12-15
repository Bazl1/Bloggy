using Bloggy.Application.Commands.Topics.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[Route("api/v1/topics")]
public class TopicsController(
    IMediator _mediator
) : BloggyControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(_mediator.Send(new GetAllRequest()));
}