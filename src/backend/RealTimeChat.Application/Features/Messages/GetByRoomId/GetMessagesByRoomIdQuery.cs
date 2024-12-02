using MediatR;
using RealTimeChat.Application.Common.Dtos;

namespace RealTimeChat.Application.Features.Messages.GetByRoomId;

public record GetMessagesByRoomIdQuery(int RoomId) : IRequest<IEnumerable<MessageDto>>;