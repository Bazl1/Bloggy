using Bloggy.Application.Commands.Topics.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[ApiController]
[Route("api/v1/topics")]
public class TopicsController(
    IMediator _mediator
) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(_mediator.Send(new GetAllRequest()));
}