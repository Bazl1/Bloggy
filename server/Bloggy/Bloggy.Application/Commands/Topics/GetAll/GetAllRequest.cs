using MediatR;

namespace Bloggy.Application.Commands.Topics.GetAll;

public record GetAllRequest() : IRequest<GetAllResponse>;