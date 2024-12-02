using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(RealTimeChatDbContext dbContext)
        : base(dbContext)
    { }
}