using Minesweeper.DataAccess.Entities;

namespace Minesweeper.DataAccess.Repositories;

public interface IRepository<TEntity, in TKey> where TEntity : IEntity<TKey>
{
    TEntity? Get(TKey id);
    Task<TEntity?> GetAsync(TKey id);

    IEnumerable<TEntity> Get();
    Task<IEnumerable<TEntity>> GetAsync();

    IEnumerable<TEntity> Get(int skip, int take);
    Task<IEnumerable<TEntity>> GetAsync(int skip, int take);

    void Add(TEntity entity);
    Task AddAsync(TEntity entity);

    void Remove(TEntity entity);
    Task RemoveAsync(TEntity entity);

    void Remove(TKey id);
    Task RemoveAsync(TKey id);
}