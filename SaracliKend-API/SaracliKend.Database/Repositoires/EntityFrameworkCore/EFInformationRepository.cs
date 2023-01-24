using Microsoft.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    public class EFInformationRepository : EFRepository<Information, SaracliDbContext>, IInformationRepository
    {
        public EFInformationRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }

        public async Task RemoveImages(Information entity)
        {
            foreach (var item in await Context.InformationImages.Where(x => x.InformationId == entity.Id).ToListAsync())
            {
                Context.InformationImages.Remove(item);
            }
            await base.UpdateAsync(entity);
        }
    }
}
