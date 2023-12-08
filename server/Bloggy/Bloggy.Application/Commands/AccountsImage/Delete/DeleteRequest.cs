using MediatR;

namespace Bloggy.Application.Commands.AccountsImage.Delete;

public record DeleteRequest() : IRequest<DeleteResponse>;