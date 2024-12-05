using MediatR;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Features.Rooms.GetAll;

public record GetAllRoomsQuery() : IRequest<IEnumerable<RoomDto>>;