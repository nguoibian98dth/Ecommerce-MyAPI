using Domain.Entities.Repository;
using Insfrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Insfrastructure.Repository;

internal class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _transaction;


    public BaseRepository(ApplicationDbContext context)//, IDbContextTransaction transaction)
    {
        _context = context;
        //_transaction = transaction;
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    { 
        var entity = await _context.Set<TEntity>().FindAsync(id);

        if (entity is null)
        {
            throw new Exception($"{typeof(TEntity).Name} with id {id} not found.");
        }

        return entity!;
    }

    public IQueryable<TEntity> AsQuery(bool asNoTracking = false)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    public async Task AddAsync(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        if (!entities.Any())
            return;

        _context.Set<TEntity>().UpdateRange(entities);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        if (!entities.Any())
            return;

        _context.Set<TEntity>().RemoveRange(entities);
    }
}
