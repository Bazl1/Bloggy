using MediatR;

namespace Bloggy.Application.Commands.Accounts.Delete;

public record DeleteRequest() : IRequest<DeleteResponse>;