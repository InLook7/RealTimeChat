using Microsoft.EntityFrameworkCore;
using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(RealTimeChatDbContext dbContext)
        : base(dbContext)
    { }

    public async Task<IEnumerable<Message>> GetByRoomIdAsync(int roomId)
    {
        return await _dbSet
            .Include(m => m.User)
            .Include(m => m.Sentiment)
            .Where(m => m.RoomId == roomId)
            .ToListAsync();
    }
}