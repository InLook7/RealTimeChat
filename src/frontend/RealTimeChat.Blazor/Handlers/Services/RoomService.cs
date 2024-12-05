using System.Net.Http.Json;
using RealTimeChat.Blazor.Handlers.Interfaces;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Services;

public class RoomService : IRoomService
{
    private readonly HttpClient _httpClient;

    public RoomService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RoomDto>> GetAllRooms()
    {
        var rooms = await _httpClient.GetFromJsonAsync<List<RoomDto>>("api/rooms");

        return rooms;
    }

    public async Task<List<MessageDto>> GetMessagesByRoomId(int roomId)
    {
        var messages = await _httpClient.GetFromJsonAsync<List<MessageDto>>($"api/rooms/{roomId}/messages");

        return messages;
    }
}