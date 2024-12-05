using RealTimeChat.Domain.Entities;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Application.Common.Mappers;

public static class MessageMapper
{
    public static MessageDto ToMessageDto(this Message message)
    {
        return new MessageDto
        {
            Id = message.Id,
            Content = message.Content,
            RoomId = message.RoomId,
            UserId = message.UserId,
            CreationDate = message.CreationDate,
        };
    }

    public static IEnumerable<MessageDto> ToMessageDto(this IEnumerable<Message> messages)
    {
        return messages.Select(ToMessageDto).ToList();
    }
}