namespace Domain.Entities.Repository;

public interface IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    Task<TEntity> GetByIdAsync(TKey id);

    IQueryable<TEntity> AsQuery(bool asNoTracking = false);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void UpdateRange(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteRange(IEnumerable<TEntity> entities);

}
