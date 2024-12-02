using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace RealTimeChat.Application.Common.Mappers;

[Mapper]
public static partial class RoomMapper
{
    [MapperIgnoreSource(nameof(Room.Messages))]
    public static partial RoomDto ToRoomDto(this Room room);

    [MapperIgnoreSource(nameof(Room.Messages))]
    public static partial IEnumerable<RoomDto> ToRoomDtos(this IEnumerable<Room> rooms);
}