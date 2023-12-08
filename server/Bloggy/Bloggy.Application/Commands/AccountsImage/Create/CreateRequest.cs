using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bloggy.Application.Commands.AccountsImage.Create;

public record CreateRequest(
    IFormFile Image
) : IRequest<CreateResponse>;