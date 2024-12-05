using RealTimeChat.Domain.Entities;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Common.Mappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username
        };
    }

    public static IEnumerable<UserDto> ToUserDtos(this IEnumerable<User> users)
    {
        return users.Select(ToUserDto).ToList();
    }
}