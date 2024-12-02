using RealTimeChat.Domain.Entities;

namespace RealTimeChat.Domain.Contracts.RepositoryInterfaces;

public interface IMessageRepository : IRepository<Message>
{ 
    Task<IEnumerable<Message>> GetByRoomIdAsync(int roomId);
}