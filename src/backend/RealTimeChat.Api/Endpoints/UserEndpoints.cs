using MediatR;
using RealTimeChat.Application.Features.Users.Create;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("users");

        group.MapPost("/", CreateUser)
            .MapToApiVersion(1);
    }

    private static async Task<IResult> CreateUser(ISender sender, UserDto user)
    {
        var command = new CreateUserCommand(
            user.Username
        );

        var result = await sender.Send(command);

        return TypedResults.Created($"api/users/{result.Value.Id}", result.Value);
    }
}