using Bloggy.Application.Commands.Authorization.Login;
using Bloggy.Application.Commands.Authorization.Logout;
using Bloggy.Application.Commands.Authorization.Refresh;
using Bloggy.Application.Commands.Authorization.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[ApiController]
[Route("api/v1/oauth")]
public class OAuthController(
    IMediator _mediator
) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request) => Ok(_mediator.Send(request));
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request) => Ok(_mediator.Send(request));

    [Authorize]
    [HttpPost("logout")]
    public IActionResult Logout() => Ok(_mediator.Send(new LogoutRequest()));
    
    [HttpPost("refresh")]
    public IActionResult Refresh() => Ok(_mediator.Send(new RefreshRequest()));
}