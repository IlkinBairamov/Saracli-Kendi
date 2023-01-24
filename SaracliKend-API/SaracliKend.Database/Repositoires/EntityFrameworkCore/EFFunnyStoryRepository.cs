using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    internal class EFFunnyStoryRepository : EFRepository<FunnyStory, SaracliDbContext>, IFunnyStoryRepository
    {
        public EFFunnyStoryRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
