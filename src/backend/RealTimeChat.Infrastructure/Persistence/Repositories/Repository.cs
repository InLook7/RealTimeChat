using Microsoft.EntityFrameworkCore;
using RealTimeChat.Domain.Common;
using RealTimeChat.Domain.Contracts.RepositoryInterfaces;
using RealTimeChat.Infrastructure.Persistence.Data;

namespace RealTimeChat.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(RealTimeChatDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deletedCount = await _dbSet.Where(e => e.Id == id).ExecuteDeleteAsync();

        return deletedCount > 0;
    }
}