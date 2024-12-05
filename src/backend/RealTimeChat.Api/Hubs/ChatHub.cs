using MediatR;
using Microsoft.AspNetCore.SignalR;
using RealTimeChat.Application.Features.Messages.Create;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Api.Hubs;

public class ChatHub : Hub<IChatClient>
{
    private readonly ISender _sender;

    public ChatHub(ISender sender)
    {
        _sender = sender;
    }

    public async Task JoinChat(int roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
    }

    public async Task LeaveChat(int roomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
    }

    public async Task SendMessage(MessageDto message)
    {
        var command = new CreateMessageCommand(
            message.Content,
            message.RoomId,
            message.UserId,
            message.CreationDate
        );

        var result = await _sender.Send(command);

        if (result.IsFailed)
        {
            await Clients.Caller
                .ReceiveError(result.Errors.Select(e => e.Message).ToList());
        }
        else
        {
            await Clients.Group(result.Value.RoomId.ToString())
                .ReceiveMessage(result.Value);
        }
    }
}