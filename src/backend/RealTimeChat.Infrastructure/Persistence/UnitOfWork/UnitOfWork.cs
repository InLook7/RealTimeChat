using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Contracts.UnitOfWork;
using RealTimeChat.Infrastructure.Persistence.Data;
using RealTimeChat.Infrastructure.Persistence.Repositories;

namespace RealTimeChat.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly RealTimeChatDbContext _dbContext;

    public UnitOfWork(RealTimeChatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IMessageRepository MessageRepository => new MessageRepository(_dbContext);
    public IRoomRepository RoomRepository => new RoomRepository(_dbContext);
    public IUserRepository UserRepository => new UserRepository(_dbContext);
    public ISentimentRepository SentimentRepository => new SentimentRepository(_dbContext);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
        
        GC.SuppressFinalize(this);
    }
}