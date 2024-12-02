using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class SentimentRepository : Repository<Sentiment>, ISentimentRepository
{
    public SentimentRepository(RealTimeChatDbContext dbContext)
        : base(dbContext)
    { }
}