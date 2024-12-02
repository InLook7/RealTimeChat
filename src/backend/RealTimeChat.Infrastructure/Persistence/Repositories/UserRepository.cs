using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Domain.Entities;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(RealTimeChatDbContext dbContext)
        : base(dbContext)
    { }
}