using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Interfaces;

public interface IHubService
{
    Task StartAsync();

    Task StopAsync();

    void OnReceiveMessage(Action<MessageDto> handler);

    void OnReceiveError(Action<List<string>> handler);

    Task JoinChat(int roomId);

    Task LeaveChat(int roomId);

    Task SendMessageAsync(MessageDto message);
}