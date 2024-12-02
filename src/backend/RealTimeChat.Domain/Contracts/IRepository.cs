using RealTimeChat.Domain.Common;

namespace RealTimeChat.Domain.Contracts;

public interface IRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    Task<bool> DeleteByIdAsync(int id);
}