using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUser(UserDto userDto);
}