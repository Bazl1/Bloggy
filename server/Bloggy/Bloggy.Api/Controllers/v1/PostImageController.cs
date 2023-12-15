using Bloggy.Application.Commands.PostsImage.Upload;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[ApiController]
[Route("api/v1/posts/{postId:guid}/image")]
public class PostImageController(
    IMediator _mediator
) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public IActionResult Upload([FromRoute] Guid postId, [FromBody] IFormFile image)
        => Ok(_mediator.Send(new UploadRequest(postId, image)));

    [Authorize]
    [HttpPost]
    public IActionResult Delete([FromRoute] Guid postId, [FromBody] IFormFile image)
        => Ok(_mediator.Send(new UploadRequest(postId, image)));
}