using SaracliKend.Domain.Common.Contracts;
using System.Collections.Immutable;

namespace SaracliKend.Core.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    IImmutableList<T> GetList();
    IQueryable<T> GetAll(string[] includes = null);
    Task<T> GetAsync(int id, params string[] includes);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IImmutableList<T> entities);
    Task DeleteAsync(T entity);
}
