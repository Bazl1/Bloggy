using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.AccountsImage.Update;

public record UpdateRequest(
    IFormFile Image
) : IRequest<UpdateResponse>;