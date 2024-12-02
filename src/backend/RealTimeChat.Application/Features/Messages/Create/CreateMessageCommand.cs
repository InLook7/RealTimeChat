using Ardalis.Result;
using MediatR;
using RealTimeChat.Application.Common.Dtos;

namespace RealTimeChat.Application.Features.Messages.Create;

public record CreateMessageCommand(
    string Content,
    int RoomId,
    int UserId,
    DateTime CreationDate) : IRequest<Result<MessageDto>>;