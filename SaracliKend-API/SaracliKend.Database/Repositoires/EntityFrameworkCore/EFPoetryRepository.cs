using SaracliKend.Database.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    internal class EFPoetryRepository : EFRepository<Poetry, SaracliDbContext>, IPoetryRepository
    {
        public EFPoetryRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Poetry> GetAllPoetriesByWriter(int writerId)
        {
            var poetries = GetAll().Where(x => x.PersonId == writerId).Include(x => x.Writer);
            return poetries;
        }
    }
}
