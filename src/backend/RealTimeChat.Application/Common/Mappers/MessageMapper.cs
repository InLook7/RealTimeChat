using Riok.Mapperly.Abstractions;
using RealTimeChat.Application.Common.Dtos;
using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.Common.Mappers;

[Mapper]
public static partial class MessageMapper
{
    [MapperIgnoreSource(nameof(Message.Room))]
    [MapperIgnoreSource(nameof(Message.User))]
    [MapperIgnoreSource(nameof(Message.Sentiment))]
    public static partial MessageDto ToMessageDto(this Message message);
}