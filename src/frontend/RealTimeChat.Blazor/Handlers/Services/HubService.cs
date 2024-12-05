using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChat.Blazor.Handlers.Interfaces;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Services;

public class HubService : IHubService
{
    private readonly HubConnection _hubConnection;

    public HubService(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
    }

    public async Task StartAsync()
    {
        if(_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync();
        }
    }

    public async Task StopAsync()
    {
        if(_hubConnection.State == HubConnectionState.Connected)
        {
            await _hubConnection.StopAsync();
        }
    }

    public void OnReceiveMessage(Action<MessageDto> handler)
    {
        _hubConnection.On("ReceiveMessage", handler);
    }

    public void OnReceiveError(Action<List<string>> handler)
    {
        _hubConnection.On("ReceiveError", handler);
    }

    public async Task JoinChat(int roomId)
    {
        await _hubConnection.SendAsync("JoinChat", roomId);
    }

    public async Task LeaveChat(int roomId)
    {
        await _hubConnection.SendAsync("LeaveChat", roomId);
    }
    
    public async Task SendMessageAsync(MessageDto message)
    {
        if (!string.IsNullOrEmpty(message.Content))
        {
            await _hubConnection.SendAsync("SendMessage", message);
        }
    }
}