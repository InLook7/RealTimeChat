using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.UnitTests.Helpers.Providers;

public static class MessageDataProvider
{
    public static IEnumerable<Message> GetMessages()
    {
        return [
            new Message { Id = 1, Content = "SomeContent" },
            new Message { Id = 2, Content = "SomeText" },
            new Message { Id = 3, Content = "Info" },
            new Message { Id = 4, Content = "Notice" }
        ];
    }

    public static Message GetMessage()
    {
        return new Message { Id = 1, Content = "NewInfo" };
    }
}