using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.PostsImage.Upload;

public record UploadRequest(
    Guid Id,
    IFormFile Image
) : IRequest<UploadResponse>;