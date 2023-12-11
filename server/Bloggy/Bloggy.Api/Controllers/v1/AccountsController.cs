using Bloggy.Application.Commands.Accounts.ChangePassword;
using Bloggy.Application.Commands.Accounts.Delete;
using Bloggy.Application.Commands.Accounts.GetById;
using Bloggy.Application.Commands.Accounts.My;
using Bloggy.Application.Commands.Accounts.Update;
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
    [HttpPut("change-password")]
    public IActionResult ChangePassword(ChangePasswordRequest request) => Ok(_mediator.Send(request));

    [Authorize]
    [HttpGet("my")]
    public IActionResult GetMy() => Ok(_mediator.Send(new MyRequest()));

    [Authorize]
    [HttpPut("my")]
    public IActionResult UpdateMy(UpdateRequest request) => Ok(_mediator.Send(request));

    [Authorize]
    [HttpDelete("my")]
    public IActionResult DeleteMy() => Ok(_mediator.Send(new DeleteRequest()));
}