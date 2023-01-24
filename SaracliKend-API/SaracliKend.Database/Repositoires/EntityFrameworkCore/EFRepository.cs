using Microsoft.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Common.Contracts;
using System.Collections.Immutable;

namespace SaracliKend.Database.Repositories.EntityFrameworkCore;

public abstract class EFRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext
{
    private readonly TContext _context;

    protected TContext Context => _context;

    public EFRepository(TContext context)
    {
        _context = context;
    }

    public virtual IImmutableList<TEntity> GetList()
    {
        return GetAll().ToImmutableList();
    }

    public virtual IQueryable<TEntity> GetAll(string[] includes = null)
    {
        var entities = Context.Set<TEntity>().AsQueryable();
        if (includes != null)
        {
            foreach (string include in includes)
            {
                entities = entities.Include(include);
            }

        }
        return entities.AsNoTracking();
    }

    public virtual async Task<TEntity> GetAsync(int id, params string[] includes)
    {
        var entity = await GetAll(includes).FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
            throw new Exception($"{typeof(TEntity).Name}: Entity was not found by {id} Id.");

        return entity;
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        if (entity is null)
            throw new ArgumentNullException($"{typeof(TEntity).Name}: Entity cannot be null.");

        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        if (entity is null)
            throw new ArgumentNullException($"{typeof(TEntity).Name}: Entity cannot be null.");

        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateRangeAsync(IImmutableList<TEntity> entities)
    {
        if (entities is null)
            throw new ArgumentNullException($"{typeof(TEntity).Name}: Entity cannot be null.");

        Context.Set<TEntity>().UpdateRange(entities);
        await Context.SaveChangesAsync();
    }
}
