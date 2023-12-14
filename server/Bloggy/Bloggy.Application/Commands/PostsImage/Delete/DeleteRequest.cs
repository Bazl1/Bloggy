using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.PostsImage.Delete;

public record DeleteRequest(
    Guid Id,
    IFormFile Image
) : IRequest<DeleteResponse>;