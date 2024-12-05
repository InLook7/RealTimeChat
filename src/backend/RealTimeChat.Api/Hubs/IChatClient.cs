using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Api.Hubs;

public interface IChatClient
{
    Task ReceiveMessage(MessageDto message);
    Task ReceiveError(List<string> errors);
}