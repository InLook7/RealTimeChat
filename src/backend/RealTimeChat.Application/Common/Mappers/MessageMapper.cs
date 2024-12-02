using Riok.Mapperly.Abstractions;
using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.Common.Mappers;

[Mapper]
public static partial class MessageMapper
{
    [MapProperty(nameof(Message.User.Username), nameof(MessageDto.UserName))]
    [MapProperty(nameof(Message.Sentiment.SentimentResult), nameof(MessageDto.Sentiment))]
    [MapperIgnoreSource(nameof(Message.Room))]
    public static partial MessageDto ToMessageDto(this Message message);

    [MapProperty(nameof(Message.User.Username), nameof(MessageDto.UserName))]
    [MapProperty(nameof(Message.Sentiment.SentimentResult), nameof(MessageDto.Sentiment))]
    [MapperIgnoreSource(nameof(Message.Room))]
    public static partial IEnumerable<MessageDto> ToMessageDtos(this IEnumerable<Message> message);
}