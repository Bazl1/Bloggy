using Bloggy.Application.Commands.AccountsImage.Create;
using Bloggy.Application.Commands.AccountsImage.Delete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[Authorize]
[ApiController]
[Route("api/v1/accounts/my/image")]
public class AccountsImageController(
    IMediator _mediator
) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(IFormFile image) => Ok(_mediator.Send(new CreateRequest(image)));

    [HttpDelete]
    public IActionResult Delete() => Ok(_mediator.Send(new DeleteRequest()));
}