using MediatR;

namespace Bloggy.Application.Commands.Accounts.My;

public record MyRequest() : IRequest<MyResponse>;