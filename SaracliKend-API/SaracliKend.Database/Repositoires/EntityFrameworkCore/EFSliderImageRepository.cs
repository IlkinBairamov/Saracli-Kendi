using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    public class EFSliderImageRepository : EFRepository<SliderImage, SaracliDbContext>, ISliderImageRepository
    {
        public EFSliderImageRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
