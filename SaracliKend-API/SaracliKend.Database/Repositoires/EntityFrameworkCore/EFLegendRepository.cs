using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    internal class EFLegendRepository : EFRepository<Legend, SaracliDbContext>, ILegendRepository
    {
        public EFLegendRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
