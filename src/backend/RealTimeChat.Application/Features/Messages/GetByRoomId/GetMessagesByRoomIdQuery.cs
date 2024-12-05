using FluentResults;
using MediatR;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Features.Messages.GetByRoomId;

public record GetMessagesByRoomIdQuery(int RoomId) : IRequest<Result<IEnumerable<MessageDto>>>;