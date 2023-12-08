using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet("error")]
    public IActionResult Errors()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(
            statusCode: StatusCodes.Status400BadRequest,
            title: exception?.Message
        );
    }
}