using MediatR;
using RealTimeChat.Application.Common.Dtos;

namespace RealTimeChat.Application.Features.Rooms.GetAll;

public record GetAllRoomsQuery() : IRequest<IEnumerable<RoomDto>>;