using Bloggy.Application.Commands.PostsImage.Delete;
using Bloggy.Application.Commands.PostsImage.Upload;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Api.Controllers.v1;

[Authorize]
[Route("api/v1/posts/{postId:guid}/image")]
public class PostImageController(
    IMediator _mediator
) : BloggyControllerBase
{
    [HttpPost]
    public IActionResult Upload([FromRoute] Guid postId, IFormFile image)
        => Ok(_mediator.Send(new UploadRequest(postId, image)));

    [HttpPost]
    public IActionResult Delete([FromRoute] Guid postId)
        => Ok(_mediator.Send(new DeleteRequest(postId)));
}