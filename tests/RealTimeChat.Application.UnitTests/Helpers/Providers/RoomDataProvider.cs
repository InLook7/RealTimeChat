using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Application.UnitTests.Helpers.Providers;

public static class RoomDataProvider
{
    public static IEnumerable<Room> GetRooms()
    {
        return [
            new Room { Id = 1, Name = "Music" },
            new Room { Id = 2, Name = "Reading" },
            new Room { Id = 3, Name = "Science" },
            new Room { Id = 4, Name = "Sport" }
        ];
    }

    public static Room GetRoom()
    {
        return new Room { Id = 1, Name = "Music" };
    }
}