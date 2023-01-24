using SaracliKend.Domain.Entities;

namespace SaracliKend.Core.Repositories;

public interface IPoetryRepository : IRepository<Poetry>
{
    IQueryable<Poetry> GetAllPoetriesByWriter(int writerId);
}
