using FluentResults;
using MediatR;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Features.Users.Create;

public record CreateUserCommand(string UserName) : IRequest<Result<UserDto>>;