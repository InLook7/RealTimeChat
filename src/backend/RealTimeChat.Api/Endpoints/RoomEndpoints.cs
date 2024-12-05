using MediatR;
using RealTimeChat.Application.Features.Messages.GetByRoomId;
using RealTimeChat.Application.Features.Rooms.GetAll;

namespace RealTimeChat.Api.Endpoints;

public static class RoomEndpoints
{
    public static void MapRoomEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/rooms");

        group.MapGet("/", GetAllRooms);
        group.MapGet("/{roomId}/messages", GetMessagesByRoomId);
    }

    private static async Task<IResult> GetAllRooms(ISender sender)
    {
        var rooms = await sender.Send(new GetAllRoomsQuery());

        return TypedResults.Ok(rooms);
    }

    private static async Task<IResult> GetMessagesByRoomId(ISender sender, int roomId)
    {
        var result = await sender.Send(new GetMessagesByRoomIdQuery(roomId));

        if (result.IsFailed)
        {
            return TypedResults.BadRequest(result.Errors.Select(e => e.Message));
        }

        return TypedResults.Ok(result.Value);
    }
}