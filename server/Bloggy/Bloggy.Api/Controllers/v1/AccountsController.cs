using Bloggy.Application.Commands.Accounts.ChangePassword;
using Bloggy.Application.Commands.Accounts.Delete;
using Bloggy.Application.Commands.Accounts.GetById;
using Bloggy.Application.Commands.Accounts.My;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[ApiController]
[Route("api/v1/accounts")]
public class AccountsController(
    IMediator _mediator
) : ControllerBase
{
    [HttpGet("{userId:guid}")]
    public IActionResult GetById(Guid userId) => Ok(_mediator.Send(new GetByIdRequest(userId)));

    [Authorize]
    [HttpGet("my")]
    public IActionResult My() => Ok(_mediator.Send(new MyRequest()));

    [Authorize]
    [HttpPut("change-password")]
    public IActionResult ChangePassword(ChangePasswordRequest request) => Ok(_mediator.Send(request));

    [Authorize]
    [HttpDelete("my")]
    public IActionResult Delete() => Ok(_mediator.Send(new DeleteRequest()));
}