using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Interfaces;

public interface IRoomService
{
    Task<List<RoomDto>> GetAllRooms();

    Task<List<MessageDto>> GetMessagesByRoomId(int roomId);
}