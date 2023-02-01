using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    public class EFFooterRepository : EFRepository<Footer, SaracliDbContext>, IFooterRepository
    {
        public EFFooterRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
