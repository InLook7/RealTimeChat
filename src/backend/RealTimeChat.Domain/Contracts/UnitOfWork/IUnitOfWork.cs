using RealTimeChat.Domain.Contracts.RepositoryInterfaces;

namespace RealTimeChat.Domain.Contracts.UnitOfWork;

public interface IUnitOfWork
{
    IMessageRepository MessageRepository { get; }
    IRoomRepository RoomRepository { get; }
    IUserRepository UserRepository { get; }
    ISentimentRepository SentimentRepository { get; }

    Task SaveAsync();
}