using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    public class EFNewsRepository : EFRepository<News, SaracliDbContext>, INewsRepository
    {
        public EFNewsRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
