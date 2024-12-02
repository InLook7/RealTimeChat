using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(RealTimeChatDbContext dbContext)
        : base(dbContext)
    { }
}